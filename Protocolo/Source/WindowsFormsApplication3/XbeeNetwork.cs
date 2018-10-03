using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace LMPT_Protocolo
{
    public class XbeeNetwork
    {
        private string[] networkNodes;
        private List<string> foundNodes;
        /* Hint: System Form Timers will not works inside classes and threads */
        private System.Timers.Timer timer_send_knock = new System.Timers.Timer();
        private System.Timers.Timer timer_stop_searching = new System.Timers.Timer();
        private Thread thr_searching;
        private bool is_searching = false;
        private LMPT_SerialProtocol lmpt_serProt = new LMPT_SerialProtocol();
  
        public XbeeNetwork()
        {
        }

        public XbeeNetwork(string[] radios_address)
        {
            this.networkNodes = radios_address;
        }

        public bool searching()
        {
            return is_searching;
        }

        public string getNode(int node_index)
        {
            return networkNodes[node_index];
        }

        public int numberOfNodes()
        {
            return networkNodes.Length;
        }

        public int numberOfFound()
        {
            return foundNodes.Count();
        }

        public void stopSearch()
        {
            this.thr_searching.Abort();
        }

        public void startSearch(SerialPort arduino_master_com, XbeeNetwork xbeeNetwork, int searching_time)
        { //arg in milliseconds
           
            this.timer_stop_searching.Elapsed += new ElapsedEventHandler(stop_searching_event);
            this.timer_stop_searching.Interval = searching_time;

            this.timer_send_knock.Interval = 1000; //1s

            this.thr_searching = new Thread(() => nodes_search(arduino_master_com, xbeeNetwork.numberOfNodes()));
            this.thr_searching.Start();
        }


        private void knock_event(object sender, ElapsedEventArgs e, SerialPort arduino_master_serial)
        {

            arduino_master_serial.Write(lmpt_serProt.knock_cmd(), 0, lmpt_serProt.maxLenght());
        }

        private void stop_searching_event(object source, ElapsedEventArgs e)
        {
            this.is_searching = false;
            this.timer_send_knock.Enabled = false;

        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private void nodes_search(SerialPort arduino_master_serial, int n_nodes)
        {
            this.is_searching = true;

            StringBuilder protocol_rx_buffer = new StringBuilder();
            List<string> found_module_addr = new List<string>();
            List<string> valid_packages = new List<string>();
            int protocol_rx_count = 0;
            byte[] rx_samples;
            int checksum = 0;
            int num_modules = n_nodes;
            List<string> temp_registered_modules = new List<string>(n_nodes);

            if (arduino_master_serial.IsOpen) arduino_master_serial.Close();
            arduino_master_serial.Open();


            this.timer_stop_searching.Enabled = true;
            this.timer_send_knock.Elapsed += (sender, e) => knock_event(sender, e, arduino_master_serial);
            this.timer_send_knock.Enabled = true;


            while (num_modules > 0 && is_searching == true) //tratar as condições para g_stop_discovery_flag = true
            {
                if (arduino_master_serial.IsOpen == true)
                {

                    if (arduino_master_serial.BytesToRead > 0)
                    {
                        String arduino_uart_tx = arduino_master_serial.ReadByte().ToString("X2"); //mostra a string em hexadecimal


                        if (protocol_rx_count > 0)
                        {
                            protocol_rx_buffer.Append(arduino_uart_tx);
                            protocol_rx_count = protocol_rx_count + 1;

                            if (protocol_rx_count == lmpt_serProt.maxLenght()) //tamanho do pacote do protocolo
                            {
                                //debug em console
                                Console.WriteLine("Protocolo: HEX STRING: ");
                                Console.Write(protocol_rx_buffer);
                                protocol_rx_count = 0;
                                rx_samples = StringToByteArray(protocol_rx_buffer.ToString());
                                Console.WriteLine("");
                                Console.WriteLine("Protocolo: HEX BYTE ARRAY: ");
                                string hex = BitConverter.ToString(rx_samples);
                                Console.Write(hex);

                                //faz o calculo do checksum: CheckSum8 Xor 
                                checksum = 0; //zera a soma usada para calcular o checksum, o cálculo é feito até o penúltimo byte
                                for (int i = 0; i < (rx_samples.Length) - 1; i = i + 1)
                                {
                                    checksum = checksum ^ rx_samples[i];
                                }

                                Console.WriteLine("");
                                Console.WriteLine("Protocolo: Tamanho Byte array: {0}", rx_samples.Length);

                                //valida o checksum
                                if (checksum == rx_samples[rx_samples.Length - 1])
                                {

                                    Console.WriteLine("Protocolo: Pacote Integro");
                                    valid_packages.Add(protocol_rx_buffer.ToString());
                                    found_module_addr.Add("0x" + protocol_rx_buffer.ToString().Substring(20, 2)); //oitavo byte eh o ID do modulo detectado
                                    Console.WriteLine("" + protocol_rx_buffer.ToString().Substring(20, 2));
                                    Console.WriteLine("IO Data: Modulo Arduino Adicionado:");
                                    Console.WriteLine(found_module_addr[found_module_addr.Count - 1]);

                                }

                                checksum = 0;

                                //limpa a string de dados recebidos
                                protocol_rx_buffer.Clear();

                                //itera o vetor de radios registrados para ver se o SL atual encontra-se neste vetor
                                //melhorar esse algoritmo, ver uma associação melhor entre as labels e os vetores
                                for (int i = 0; i < (temp_registered_modules.Count); i++)
                                {
                                    for (int j = 0; j < (found_module_addr.Count); j++)
                                    {
                                        if (temp_registered_modules[i] == found_module_addr[j])
                                        {
                                            //debug console
                                            Console.WriteLine("IO Data: Detectou um modulo registrado: ");
                                            Console.WriteLine(temp_registered_modules[i]);
                                            //var indice = Array.FindIndex(registered_slave_modules, row => row.Contains(temp_registered_modules[i]));
                                            Console.WriteLine("IO Data: Achou: ");
                                            //Console.WriteLine(registered_slave_modules[indice]);
                                            switch (i)
                                            {
                                                case 0:
                                                    //this.Invoke((MethodInvoker)delegate
                                                    //{
                                                    //    TB_SA1_Search.BackColor = Color.Green;
                                                    //});
                                                    break;
                                                case 1:
                                                    //this.Invoke((MethodInvoker)delegate
                                                    //{
                                                    //    TB_SA2_Search.BackColor = Color.Green;
                                                    //});
                                                    break;

                                                default: break;
                                            }

                                            found_module_addr.RemoveAt(j);
                                            temp_registered_modules.RemoveAt(i);
                                            num_modules = num_modules - 1;
                                            //connected_slave_modules = connected_slave_modules + 1;
                                            if (num_modules == 0) break;
                                        }
                                    }
                                }

                                found_module_addr.Clear(); //limpa em caso de adicionar o mesmo endereço duas vezes

                            }
                        }
                        //AF byte de inicio do frame API do radio
                        if (String.Equals(arduino_uart_tx, "AF"))
                        {
                            protocol_rx_count = 1;
                            protocol_rx_buffer.Clear();
                            protocol_rx_buffer.Append(arduino_uart_tx);
                        }

                    }

                }
                else
                {
                    //problema_porta = true;
                }

            }
            if (num_modules == 0 || is_searching == false)
            {

                //this.Invoke((MethodInvoker)delegate
                //{
                //    timer_blink_searching.Stop();
                //    timer_stop_searching.Stop();
                //    LBL_Searching.Visible = true;
                //    LBL_Searching.Text = "Modules Found";
                //    timer_to_enable_next.Start(); // runs on UI thread              
                //});

            }
        }
    }
}
