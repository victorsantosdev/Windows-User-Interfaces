using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace LmptProtocol
{
    public class XbeeNetwork
    {
        private string[] networkNodes; //network structure, passed at the class instantiation
        private List<string> foundNodes; //list filled during the Searching process

        /* Hint: System Form Timers will not works inside classes and threads */
        private System.Timers.Timer timerSendKnock = new System.Timers.Timer();
        private System.Timers.Timer timerStopSearching = new System.Timers.Timer();
        private Thread thrSearchNodes;
        private LmptSerialProtocol lmptSerialProtocol = new LmptSerialProtocol();
        private bool isSearching = false;
  
        public XbeeNetwork(){}

        public XbeeNetwork(string[] radiosAddress)
        {
            this.networkNodes = radiosAddress;
            foundNodes = new List<string>(networkNodes.Length);
        }

        public List<string> GetFoundNodes() {
            return foundNodes;
        }

        public bool Searching()
        {
            return isSearching;
        }

        public string GetNode(int node_index)
        {
            return networkNodes[node_index];
        }

        public int NumberOfNodes()
        {
            return networkNodes.Length;
        }

        public int NumberOfFound()
        {
            return foundNodes.Count();
        }

        public void StopSearch()
        {
            if (thrSearchNodes.IsAlive) { this.thrSearchNodes.Abort();  }
            this.isSearching = false;
            this.timerSendKnock.Enabled = false;
        }

        public void StartSearch(ComPort arduinoMasterComPort, XbeeNetwork xbeeNetwork, int searchingTime)
        { //searchingTime in milliseconds

            this.timerStopSearching.Elapsed += new ElapsedEventHandler(StopSearchingEvent);
            this.timerStopSearching.Interval = searchingTime;

            this.timerSendKnock.Interval = 1000; //1s
            this.thrSearchNodes = new Thread(() => SearchNodes(arduinoMasterComPort, xbeeNetwork));
            this.thrSearchNodes.Name = "nodeSearch_thread";
            this.thrSearchNodes.Start();
        }


        private void KnockEvent(object sender, ElapsedEventArgs e, SerialPort arduinoMasterComPort)
        {
            arduinoMasterComPort.Write(lmptSerialProtocol.Knock(), 0, lmptSerialProtocol.Knock().Length);
        }

        private void StopSearchingEvent(object source, ElapsedEventArgs e)
        {
            this.isSearching = false;
            this.timerSendKnock.Enabled = false;
            this.timerSendKnock.Dispose();
            if (thrSearchNodes.IsAlive == true) thrSearchNodes.Abort();
        }

        private static byte[] StringToByteArray(String hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private void SearchNodes(ComPort arduinoMasterComPort, XbeeNetwork xbeeNetwork)
        {
            this.isSearching = true;

            StringBuilder protocolRxBuffer = new StringBuilder();
            List<string> discoveredNodes = new List<string>();
            int protocolRxCount = 0;
            byte[] rxSamples;
            int checksum = 0;
            int numModules = xbeeNetwork.NumberOfNodes();
            List<string> nodes_to_find = new List<string>(xbeeNetwork.networkNodes);

            if (arduinoMasterComPort.IsOpen) arduinoMasterComPort.Close();
            arduinoMasterComPort.Open();

            this.timerStopSearching.Enabled = true;
            this.timerSendKnock.Elapsed += (sender, e) => KnockEvent(sender, e, arduinoMasterComPort);
            this.timerSendKnock.Enabled = true;


            while (numModules > 0 && isSearching == true) //tratar as condições para g_stop_discovery_flag = true
            {
                if (arduinoMasterComPort.IsOpen == true)
                {

                    if (arduinoMasterComPort.BytesToRead > 0)
                    {
                        String arduino_uart_tx = arduinoMasterComPort.ReadByte().ToString("X2"); //mostra a string em hexadecimal

                        if (protocolRxCount > 0)
                        {
                            protocolRxBuffer.Append(arduino_uart_tx);
                            protocolRxCount = protocolRxCount + 1;

                            if (protocolRxCount == lmptSerialProtocol.MaxLenght()) //tamanho do pacote do protocolo
                            {
                                //debug em console
                                Console.WriteLine("Protocolo: HEX STRING: ");
                                Console.Write(protocolRxBuffer);
                                protocolRxCount = 0;
                                rxSamples = StringToByteArray(protocolRxBuffer.ToString());
                                Console.WriteLine("");
                                Console.WriteLine("Protocolo: HEX BYTE ARRAY: ");
                                string hex = BitConverter.ToString(rxSamples);
                                Console.Write(hex);

                                //faz o calculo do checksum: CheckSum8 Xor 
                                checksum = 0; //zera a soma usada para calcular o checksum, o cálculo é feito até o penúltimo byte
                                for (int i = 0; i < (rxSamples.Length) - 1; i = i + 1)
                                {
                                    checksum = checksum ^ rxSamples[i];
                                }

                                Console.WriteLine("");
                                Console.WriteLine("Protocolo: Tamanho Byte array: {0}", rxSamples.Length);

                                //valida o checksum
                                if (checksum == rxSamples[rxSamples.Length - 1])
                                {
                                    Console.WriteLine("Protocolo: Pacote Integro");
                                    discoveredNodes.Add("0x" + protocolRxBuffer.ToString().Substring(20, 2)); //oitavo byte eh o ID do modulo detectado
                                    Console.WriteLine("" + protocolRxBuffer.ToString().Substring(20, 2));
                                    Console.WriteLine("IO Data: Modulo Arduino Adicionado:");
                                    Console.WriteLine(discoveredNodes[discoveredNodes.Count - 1]);
                                }

                                checksum = 0;

                                //limpa a string de dados recebidos
                                protocolRxBuffer.Clear();

                                for (int i = 0; i < (nodes_to_find.Count); i++)
                                {
                                    for (int j = 0; j < (discoveredNodes.Count); j++)
                                    {
                                        if (discoveredNodes[j] == nodes_to_find[i])
                                        {
                                            //debug console
                                            Console.WriteLine("IO Data: Node found: ");
                                            Console.WriteLine(nodes_to_find[i]);
                                            //var indice = Array.FindIndex(registered_slave_modules, row => row.Contains(nodes_to_find[i]));
                                            //Console.WriteLine("IO Data: Achou: ");
                                            //Console.WriteLine(registered_slave_modules[indice]);
                                            xbeeNetwork.foundNodes.Add(nodes_to_find[i]);
                                            nodes_to_find.RemoveAt(i);
                                            numModules = numModules - 1;
                                            //connected_slave_modules = connected_slave_modules + 1;
                                            if (numModules == 0) {
                                                isSearching = false;
                                                break;
                                            } 
                                        }
                                    }
                                }

                                discoveredNodes.Clear(); //limpa em caso de adicionar o mesmo endereço duas vezes
                            }
                        }
                        //AF byte de inicio do frame API do radio
                        if (String.Equals(arduino_uart_tx, "AF"))
                        {
                            protocolRxCount = 1;
                            protocolRxBuffer.Clear();
                            protocolRxBuffer.Append(arduino_uart_tx);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("COM port error: COM closed.");
                }

            }
            if (numModules == 0 || isSearching == false)
            {
                this.timerSendKnock.Enabled = false;
                this.timerSendKnock.Dispose();
                while (true) ; //wait for abort

            }
        }
    }
}
