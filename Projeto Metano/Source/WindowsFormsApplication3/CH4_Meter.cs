using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Timers;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public string delimitador = ";"; // delimitador entre parametros para ser usado no arquivo salvo
        public string cabecalho = "Time (s);Methane (ppm);Pressure (psi);Tanks";
        public string metano, pressao, n_tanques;
        public int cont = 0;
        //public List<string> udp_data = new List<string>();
        public string udp_data;
        public string caminho_e_nome, header_arquivo, indata;
        public int periodo = 5; //periodo em segundos de amostra.
        StreamWriter log_arquivo; // cria uma classe com esse nome
        Thread t_udp;  //run a separate thread for reading the usb port
        private volatile bool _shouldStop = false;     //a volatile flag to signal to the other thread to stop
        public string conn_error;

        public Form1() // constructor
        {
            InitializeComponent();
            this.Text = "CH4 Flow Meter Software";
            this.FormClosing += Form1_FormClosing;//register event - usado para o thread

            this.SetStyle(ControlStyles.StandardDoubleClick, true);
            this.chart1.DoubleClick += new System.EventHandler(grafico_DoubleClick);
            chart1.Series.Add("Methane").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[0].Color = System.Drawing.Color.Red;
            foreach (var series in chart1.Series)
            {
                series.Enabled = false;
                series.BorderWidth = 3;
            }
            // Inicialização da lista na página 2
            lista_dados.View = View.Details;
            lista_dados.GridLines = true;
            lista_dados.FullRowSelect = true;
            lista_dados.AllowColumnReorder = true;
            lista_dados.Columns.Add("Time (s)", -2, HorizontalAlignment.Left);
            lista_dados.Columns.Add("Methane (ppm)", -2, HorizontalAlignment.Left);
            lista_dados.Columns.Add("Pressure (psi)", -2, HorizontalAlignment.Left);
            lista_dados.Columns.Add("Filled Tanks", -2, HorizontalAlignment.Left);
            /// manter todas as colunas com mesmo tamanho
            int x = lista_dados.Width / 4 == 0 ? 1 : lista_dados.Width / 4;
            foreach (ColumnHeader coluna in lista_dados.Columns)
            {
                coluna.Width = Convert.ToInt32(Math.Floor(x * 0.98));
            }
            /// Definição de cultura do programa
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            /// Inicialização checkbox e textbox
            metano_atual_texto.Visible = false;
            ///
            conn_error = "";

            label_error.Text = conn_error;
            t_udp = new Thread(new ThreadStart(Request_UDP_Data)); // esse SerialReadLoop é uma rotina abaixo (tipo loop)     //create and start the serial thread
            t_udp.Start();   // Run Go() on the new thread.

            chart1.Series["Methane"].Enabled = true;
            chart1.ChartAreas[0].AxisX.Title = "T [s]";
            chart1.ChartAreas[0].AxisY.Title = "Methane [ppm]";
            chart1.ChartAreas[0].AxisY.Maximum = double.NaN;
            chart1.ChartAreas[0].AxisY.Minimum = double.NaN;
            // Clear graphic
            cont = 0;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            // Clear List - pagina 2
            lista_dados.Items.Clear();

            timer1.Enabled = true; // começa a ler e mostrar na tela
            timer1.Interval = 1000 * periodo;

            timer_blink.Interval = 250;
            timer_blink.Enabled = false;

            watchdog_timer.Interval = 250;
            watchdog_timer.Enabled = true;

            btn_start_log.Visible = true;
            btn_stop_log.Visible = true;
            btn_start_log.Enabled = true;
            btn_stop_log.Enabled = false;
        }

        private void Inicializa_Log(string path)
        {

            DateTime time_struct = DateTime.Now; 
            int dia = time_struct.Day;
            int mes = time_struct.Month;
            int ano = time_struct.Year;
            int hora = time_struct.Hour;
            int min = time_struct.Minute;
            header_arquivo = "CH4_Flow_Meter_Readings-" + dia.ToString() + "-" + mes.ToString() + "-" + ano.ToString() + "  " + hora.ToString() + "_" + min.ToString();
            caminho_e_nome = Path.Combine(path, header_arquivo + ".txt"); // vai escrever no diretório escolhido pelo usuário
            log_arquivo = File.CreateText(caminho_e_nome); // se quer escrever por cima de arq existente
            log_arquivo.WriteLine(cabecalho); // escreve uma linha e pula
            log_arquivo.Close(); // tem que fechar senão dá erro qdo tentar escrever de novo


        }

        private void btn_start_log_Click(object sender, EventArgs e)
        {

            string sSelectedPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Lo‌​cation);
            lista_dados.Items.Clear();
            cont = 0;
            btn_start_log.Enabled = false;
            btn_stop_log.Enabled = true;
            timer_blink.Enabled = true;

            metano_atual_texto.Visible = false;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            if ((t_udp.IsAlive.Equals(true) == false))
            {
                cont = 0;
                t_udp = new Thread(new ThreadStart(Request_UDP_Data));
                t_udp.Start();
            }
            Inicializa_Log(sSelectedPath);

        }

        //Stop da gravacao em arquivo
        private void btn_stop_log_Click(object sender, EventArgs e)
        {
            timer_blink.Enabled = false;
            btn_start_log.Enabled = true;
            btn_stop_log.Enabled = false;
            log_flag.Visible = false;
        }

        private void grafico_DoubleClick(object sender, EventArgs e)
        {
            //~Habilita edição da janela de configuração do gráfico
            AxisConfig SecondaryForm = new AxisConfig();
            SecondaryForm.ShowDialog();
            string[] parametros = SecondaryForm.Parametros;
            if ((IsNumeric(parametros[0]) == true) && (parametros[0].Equals("auto") == false) && (parametros[1].Equals("") == false) && (parametros[0].Equals("") == false) && (parametros[0].Equals("null") == false) && (Convert.ToDouble(parametros[0]) > Convert.ToDouble(parametros[1]))) { chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(parametros[0]); }
            if ((IsNumeric(parametros[1]) == true) && (parametros[0].Equals("auto") == false) && (parametros[1].Equals("") == false) && (parametros[0].Equals("") == false) && (parametros[1].Equals("null") == false) && (Convert.ToDouble(parametros[0]) > Convert.ToDouble(parametros[1]))) { chart1.ChartAreas[0].AxisX.Minimum = Convert.ToDouble(parametros[1]); }
            if ((IsNumeric(parametros[2]) == true) && (parametros[0].Equals("auto") == false) && (parametros[3].Equals("") == false) && (parametros[2].Equals("") == false) && (parametros[2].Equals("null") == false) && (Convert.ToDouble(parametros[2]) > Convert.ToDouble(parametros[3]))) { chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(parametros[2]); }
            if ((IsNumeric(parametros[3]) == true) && (parametros[0].Equals("auto") == false) && (parametros[3].Equals("") == false) && (parametros[2].Equals("") == false) && (parametros[3].Equals("null") == false) && (Convert.ToDouble(parametros[2]) > Convert.ToDouble(parametros[3]))) { chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(parametros[3]); }
            if ((parametros[0] == "auto" & parametros[1] == "auto" & parametros[2] == "auto" & parametros[3] == "auto") == true)
            {
                chart1.ChartAreas[0].AxisX.Maximum = double.NaN;
                chart1.ChartAreas[0].AxisY.Maximum = double.NaN;
                chart1.ChartAreas[0].AxisX.Minimum = double.NaN;
                chart1.ChartAreas[0].AxisY.Minimum = double.NaN;
            }

        }

        public static bool IsNumeric(object value)
        {
            if (value == null || value is DateTime)
            {
                return false;
            }

            if (value is Int16 || value is Int32 || value is Int64 || value is Decimal || value is Single || value is Double || value is Boolean)
            {
                return true;
            }

            try
            {
                if (value is string)
                    Double.Parse(value as string);
                else
                    Double.Parse(value.ToString());
                return true;
            }
            catch { }
            return false;
        }

        //Timer1 atualiza os dados do grafico
        private void timer1_Tick_1(object sender, EventArgs e)
        {
           // Console.WriteLine("teste");

            string[] vars = udp_data.Split(';');

            metano = vars[0];
            //Console.WriteLine(metano);
            pressao = vars[1];
            //Console.WriteLine(pressao);
            n_tanques = vars[2];
            //Console.WriteLine(n_tanques);

            var lista = new ListViewItem(new[] { Convert.ToString(cont * periodo), metano, pressao, n_tanques });
            lista_dados.Items.Add(lista);
            metano_atual_texto.Visible = true;

            chart1.Series["Methane"].Points.AddXY(cont * periodo, metano);
            metano_atual_texto.Text = metano;

            if (timer_blink.Enabled == true)
            {
                log_arquivo = File.AppendText(caminho_e_nome); // se quer adicionar texto sobre arq existente
                log_arquivo.WriteLine(cont * periodo + delimitador + metano + delimitador + pressao + delimitador + n_tanques); // escreve uma linha e pula
                log_arquivo.Close(); // tem que fechar senão dá erro qdo tentar escrever de novo
            }
            cont = cont + 1;
        }

        private void watchdog_Tick(object sender, EventArgs e)
        {
            if (conn_error != "") {
                label_error.Text = conn_error;
            }
        }

        private void timer_blink_Tick_1(object sender, EventArgs e)
        {  // para piscar o "saving..."

            if (log_flag.Visible == true)
            {
                log_flag.Visible = false;
            }
            else if (btn_stop_log.Enabled == true)
            {
                log_flag.Visible = true;
            }
        }

        //Recebe os dados do socket UDP
        private void Request_UDP_Data()
        {
            while (!_shouldStop)
            {
                try
                {
                    var client = new UdpClient();
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse("10.1.1.5"), 8888); // endpoint where server is listening (testing localy)
                    client.Connect(ep);
                    string udp_msg = "$GET_DATA";
                    byte[] send_buffer = Encoding.ASCII.GetBytes(udp_msg);
                    // send data
                    client.Send(send_buffer, send_buffer.Length);

                    // then receive data
                    var receivedData = client.Receive(ref ep);


                    string result = System.Text.Encoding.UTF8.GetString(receivedData);
                    udp_data = result;
                    string[] debug = result.Split(';');

                    Console.WriteLine("receive data from " + ep.ToString());
                    for (int i = 0; i < debug.Length; i++)
                    {
                        Console.WriteLine(debug[i]);
                    }

                    client.Close();
                    Thread.Sleep(1000); //sleep de 5s
                }
                catch (SocketException ex)
                {
                    conn_error = "Socket Error";
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
                {
                    conn_error = "Server Error";
                    Console.WriteLine(ex);
                }
               
        }
        }

        private void btn_quit_Click(object sender, EventArgs e)
        { 
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Request that the worker thread stop itself:
            _shouldStop = true;

            // Use the Join method to block the current thread until the object's thread terminates.
            try
            {
                if ((t_udp.IsAlive.Equals(true) == true))
                {
                    t_udp.Join();
                }
            }
            catch (NullReferenceException)
            {
                Application.Exit();
            }
        }

    }
}
