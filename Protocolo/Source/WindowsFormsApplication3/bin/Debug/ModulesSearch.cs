using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Drawing;
using System.Timers;

namespace LMPT_Protocolo
{


    public partial class Searching_Step : Form
    {
        byte[] KNOCK = { 0xAF, 0xB2, 0x01, 0x01, 0x0C, 0x01, 0x00, 0x0A, 0x0B, 0x0C, 0x0D, 0x10 };
        string[] registered_slave_modules = new string[] { "0x02", "0x03"}; //Endereços dos Arduinos registrados na rede
        public int connected_slave_modules = 0; //numero de radios CONECTADOS, posso ter varios radios REGISTRADOS mas só alguns conectados
        const int MAX_PROTOCOL_LENGTH = 12;

        public int g_delay_next_btn = 3; //3k ms = 3s

        public bool g_toogle_search = false;
        Thread thr_searching;

        SerialPort pc_com_port = new SerialPort();
        System.Windows.Forms.Timer timer_blink_searching_label;
        System.Windows.Forms.Timer timer_stop_searching;
        System.Windows.Forms.Timer timer_to_enable_next;

        int g_searching_flag = 0;
        public bool g_stop_discovery_flag = false;
        Int32 g_searching_time = 30000; //30s
        public bool searching_modules_flag = false;

        public Searching_Step()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;//register event - usado para o thread

            //this.MinimumSize = new Size(800, 800);
            //this.MaximumSize = new Size(800, 800);

            TB_SA1_Search.Text = registered_slave_modules[0];
            TB_SA2_Search.Text = registered_slave_modules[1];
            LBL_Searching.Visible = false;
            LBL_Header.Visible = false;
            LBL_SA1_Search.Visible = false;
            LBL_SA2_Search.Visible = false;
            TB_SA1_Search.Visible = false;
            TB_SA2_Search.Visible = false;
            // 
            // timer_blink_searching_label
            // 
            timer_blink_searching_label = new System.Windows.Forms.Timer();
            timer_blink_searching_label.Interval = 250; //250ms
            timer_blink_searching_label.Tick += new EventHandler(timer_blink_searching_label_Tick);

            // 
            // timer_stop_searching
            // 
            timer_stop_searching = new System.Windows.Forms.Timer();
            timer_stop_searching.Interval = g_searching_time;
            timer_stop_searching.Tick += new EventHandler(timer_stop_searching_Tick);

            // timer_to_enable_next
            // 
            timer_to_enable_next = new System.Windows.Forms.Timer();
            timer_to_enable_next.Interval = 1000; //1s
            timer_to_enable_next.Tick += new EventHandler(timer_to_enable_next_Tick);

            BTN_COM_Close.Enabled = false;
            BTN_Search2Sampling.Enabled = false;
            timer_blink_searching_label.Enabled = false;
            update_com_ports();
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }


        void update_com_ports()
        {
            String[] portas = SerialPort.GetPortNames();
            CB_COM_List.Items.AddRange(portas);

        }

     

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

      
        public void search_for_modules(SerialPort arduino_master_serial, int n_modules)
        {
            g_searching_flag = 1;

            StringBuilder protocol_rx_buffer = new StringBuilder();
            List<string> found_module_addr = new List<string>();
            List<string> valid_packages = new List<string>();
            int protocol_rx_token = 0;
            byte[] rx_samples;
            int checksum = 0;
            int num_modules = n_modules;
            List<string> temp_registered_modules = new List<string>(registered_slave_modules);

            string open_port = arduino_master_serial.PortName; // pega o nome da porta já aberta, recebido como parametro de função 

            this.Invoke((MethodInvoker)delegate
            {
                timer_blink_searching_label.Start();
                timer_stop_searching.Start();
            });

            pc_com_port = new SerialPort(open_port, 115200, Parity.None, 8, StopBits.One); //padrão da serial 9600-8-N-1
            if (pc_com_port.IsOpen) pc_com_port.Close();
            pc_com_port.Open();

            while (num_modules > 0 && g_stop_discovery_flag == false) //tratar as condições para g_stop_discovery_flag = true
            {
                if (pc_com_port.IsOpen == true)
                {
                    pc_com_port.Write(KNOCK, 0, KNOCK.Length);

                    if (pc_com_port.BytesToRead > 0)
                    {
                        String arduino_uart_tx = pc_com_port.ReadByte().ToString("X2"); //mostra a string em hexadecimal


                        if (protocol_rx_token > 0)
                        {
                            protocol_rx_buffer.Append(arduino_uart_tx);
                            protocol_rx_token = protocol_rx_token + 1;

                            if (protocol_rx_token == MAX_PROTOCOL_LENGTH) //tamanho do pacote do protocolo
                            {
                                //debug em console
                                Console.WriteLine("Protocolo: HEX STRING: ");
                                Console.Write(protocol_rx_buffer);
                                protocol_rx_token = 0;
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
                                    found_module_addr.Add("0x"+protocol_rx_buffer.ToString().Substring(20, 2)); //oitavo byte eh o ID do modulo detectado
                                    Console.WriteLine(""+ protocol_rx_buffer.ToString().Substring(20, 2));
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
                                            var indice = Array.FindIndex(registered_slave_modules, row => row.Contains(temp_registered_modules[i]));
                                            Console.WriteLine("IO Data: Achou: ");
                                            Console.WriteLine(registered_slave_modules[indice]);
                                            switch (i)
                                            {
                                                case 0:
                                                    this.Invoke((MethodInvoker)delegate
                                                    {
                                                        TB_SA1_Search.BackColor = Color.Green;
                                                    });
                                                    break;
                                                case 1:
                                                    this.Invoke((MethodInvoker)delegate
                                                    {
                                                        TB_SA2_Search.BackColor = Color.Green;
                                                    });
                                                    break;

                                                default: break;
                                            }

                                            found_module_addr.RemoveAt(j);
                                            temp_registered_modules.RemoveAt(i);
                                            num_modules = num_modules - 1;
                                            connected_slave_modules = connected_slave_modules + 1;
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
                            protocol_rx_token = 1;
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
            if (num_modules == 0 || g_stop_discovery_flag == true)
            {

                this.Invoke((MethodInvoker)delegate
                {
                    timer_blink_searching_label.Stop();
                    timer_stop_searching.Stop();
                    LBL_Searching.Visible = true;
                    LBL_Searching.Text = "Modules Found";
                    timer_to_enable_next.Start(); // runs on UI thread              
                });

            }
        }

    

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (g_searching_flag == 1)
            {
                if (thr_searching.ThreadState.Equals(ThreadState.Running))
                {
                    try { thr_searching.Abort(); } finally { pc_com_port.Close(); }
                }
            }

            Application.Exit();
        }

        private void timer_stop_searching_Tick(Object myObject, EventArgs myEventArgs)
        {
            g_stop_discovery_flag = true;
        }

        private void timer_to_enable_next_Tick(Object myObject, EventArgs myEventArgs)
        {
            if (g_delay_next_btn > 0)
            {
                g_delay_next_btn = g_delay_next_btn - 1;
            }
            this.Invoke((MethodInvoker)delegate
            {
                BTN_Search2Sampling.Text = "Next [" + g_delay_next_btn.ToString() + "]";
            });

            if (g_delay_next_btn == 0)
            {
                BTN_Search2Sampling.Text = "Next";
                this.Invoke((MethodInvoker)delegate
                {
                    timer_to_enable_next.Stop(); // runs on UI thread
                    BTN_Search2Sampling.Enabled = true;
                });
            }
        }

        private void timer_blink_searching_label_Tick(Object myObject, EventArgs myEventArgs)
        {
            searching_modules_flag = !searching_modules_flag;

            this.Invoke((MethodInvoker)delegate
            {
                LBL_Searching.Visible = searching_modules_flag;
            });

        }

        private void BTN_Search2Sampling_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataSampling form2 = new DataSampling();
            form2.Show();
            //Form FORM_Aquis = new Form();
            //FORM_Aquis.Show();

            if (pc_com_port.IsOpen == true)
            {
                pc_com_port.Close();
            }

            try
            {
                thr_searching.Abort();
                g_searching_flag = 0;
            } //mata a tread de busca quando inicia a thread de aquisicao
            finally
            {

                BTN_Search2Sampling.Enabled = false;
                BTN_Search2Sampling.Visible = false;

            }
        }

        private void BTN_Quit_Search_Click(object sender, EventArgs e)
        {
            if (g_searching_flag == 1)
            {
                if (thr_searching.ThreadState.Equals(ThreadState.Running))
                {
                    try { thr_searching.Abort(); } finally { pc_com_port.Close(); }
                }
            }

            Application.Exit();
        }

        private void BTN_COM_Open_Click(object sender, EventArgs e)
        {
            if (CB_COM_List.SelectedIndex != -1)
            {
                pc_com_port.PortName = CB_COM_List.Text;
                try
                {
                    pc_com_port.Open();
                }
                catch
                {
                    //problema_porta = true;
                    //sinalizar erro de porta
                }

                if (pc_com_port.IsOpen == true)
                {
                    BTN_COM_Open.Enabled = false;

                    pc_com_port.Close();
                    BTN_COM_Close.Enabled = true;
                    LBL_Searching.Visible = true;
                    LBL_Header.Visible = true;
                    LBL_SA1_Search.Visible = true;
                    LBL_SA2_Search.Visible = true;
                    TB_SA1_Search.Visible = true;
                    TB_SA2_Search.Visible = true;
                    thr_searching = new Thread(() => search_for_modules(pc_com_port, registered_slave_modules.Length));
                    thr_searching.Start();

                }
                else
                {
                    serError_lbl.Visible = true;
                }
            }
            else
            {
                CB_COM_List.Items.Clear();
                update_com_ports();
            }
        }


    }
}

