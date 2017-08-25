using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Globalization;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public string delimitador = ";"; // delimitador entre parametros para ser usado no arquivo salvo
        public string cabecalho = "Time;Pressure";
        public string pressao;
        public string[] pal; // vetor armazena  cada palavra da linha lida na serial
        public int cont = 0;
        public List<string> aa = new List<string>();
        public List<string> a = new List<string>();
        public string caminho_e_nome, bb, indata;
        public int periodo = 1; //periodo em segundos de amostra.
        StreamWriter Escrevedor; // cria uma classe com esse nome
        Thread t;  //run a separate thread for reading the usb port
        private volatile bool _shouldStop = false;     //a volatile flag to signal to the other thread to stop
        private volatile bool problema_porta = false;

        public Form1() // constructor
        {
            InitializeComponent();
            this.Text = "Ashcroft G2 Pressure Transducer Software";
            this.FormClosing += Form1_FormClosing;//register event - usado para o thread

            Verifica_Ports_Availables(); // sub  rotina abaixo
            timer1.Enabled = false;
            button4.Enabled = false;
            aa.Add("0,0,0");
            this.SetStyle(ControlStyles.StandardDoubleClick, true);
            this.chart1.DoubleClick += new System.EventHandler(chart1_DoubleClick);
            chart1.Series.Add("Pressure (psi)").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[0].Color = System.Drawing.Color.Red;
            foreach (var series in chart1.Series)
            {
                series.Enabled = false;
                series.BorderWidth = 3;
            }
            // Inicialização da lista na página 2
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.AllowColumnReorder = true;
            listView1.Columns.Add("Time (s)", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Pressure (psi)", -2, HorizontalAlignment.Left);
            /// manter todas as colunas com mesmo tamanho
            int x = listView1.Width / 2 == 0 ? 1 : listView1.Width / 2;
            foreach (ColumnHeader coluna in listView1.Columns)
            {
                coluna.Width = Convert.ToInt32(Math.Floor(x * 0.98));
            }
            /// Definição de cultura do programa
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            /// Inicialização checkbox e textbox
            textBox17.Visible = false;
            ///


        }

        //verifica e atualiza as portas seriais disponiveis
        void Verifica_Ports_Availables()
        {
            String[] portas = SerialPort.GetPortNames(); // carrega nome das portas
            comboBox1_Lista_Portas.Items.AddRange(portas);// lista as portas no combox

        }

        //abre a porta serial
        private void button3_Open_Port_Click(object sender, EventArgs e)
        {
            if (comboBox1_Lista_Portas.SelectedIndex != -1)
            {
                serialPort1.PortName = comboBox1_Lista_Portas.Text; // pega a clicada
                try
                {
                    serialPort1.Open();
                }
                catch
                {
                    problema_porta = true;
                }



                if (serialPort1.IsOpen == true) // só faz se porta está aberta
                {
                    button3_Open_Port.Enabled = false; // não deixa abrir de novo (daria erro)
                    for (int counter = 0; counter <= 100; counter++)
                    {
                        progressBar1.Value = counter; // p/  mostrar que a porta abriu
                    }

                    label1.Visible = false;
                    serialPort1.Close(); // pois quem vai abrir cada vez é o Thread
                    button1.Visible = true;
                    button3.Visible = true;
                    button4.Enabled = true;
                    textBox17.Visible = false;
                    t = new Thread(new ThreadStart(SerialReadLoop)); // esse SerialReadLoop é uma rotina abaixo (tipo loop)     //create and start the serial thread
                    t.Start();   // Run Go() on the new thread.
                    timer1.Enabled = true; // começa a ler e mostrar na tela
                    timer1.Interval = 1000 * periodo;
                    button3.Enabled = false;
                    button1.Enabled = true;
                    chart1.Series["Pressure (psi)"].Enabled = true;
                    chart1.ChartAreas[0].AxisX.Title = "T [s]";
                    chart1.ChartAreas[0].AxisY.Title = "P [psi]";
                    chart1.ChartAreas[0].AxisY.Maximum = double.NaN;
                    chart1.ChartAreas[0].AxisY.Minimum = double.NaN;
                    // Clear graphic
                    cont = 0;
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }

                    // Clear List - pagina 2
                    listView1.Items.Clear();


                }
                else
                {
                    label1.Visible = true;
                }
            }
            else
            {
                comboBox1_Lista_Portas.Items.Clear();
                Verifica_Ports_Availables();
            }
        }

        //grava a estrutura inicial do arquivo de log
        private void Grava_Cabecalho(string path)
        {

            DateTime tt = DateTime.Now; // pega tudo e poe no tt
            int dia = tt.Day;
            int mes = tt.Month;
            int ano = tt.Year;
            int hora = tt.Hour;
            int min = tt.Minute;
            bb = "Ashcroft_G2_Readings-" + dia.ToString() + "-" + mes.ToString() + "-" + ano.ToString() + "  " + hora.ToString() + "_" + min.ToString();
            caminho_e_nome = Path.Combine(path, bb + ".txt"); // vai escrever no diretório escolhido pelo usuário
            Escrevedor = File.CreateText(caminho_e_nome); // se quer escrever por cima de arq existente
            Escrevedor.WriteLine(cabecalho); // escreve uma linha e pula
            Escrevedor.Close(); // tem que fechar senão dá erro qdo tentar escrever de novo


        }


        //start da gravacao em arquivo
        private void button1_Click(object sender, EventArgs e)
        {

            string sSelectedPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Lo‌​cation);
            listView1.Items.Clear();
            cont = 0;
            button1.Enabled = false;
            button3.Enabled = true;
            timer2.Enabled = true;
            textBox17.Visible = false;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            if ((t.IsAlive.Equals(true) == false))
            {
                cont = 0;
                t = new Thread(new ThreadStart(SerialReadLoop));
                t.Start();
            }
            Grava_Cabecalho(sSelectedPath);

        }

        //Stop da gravacao em arquivo
        private void button3_Click(object sender, EventArgs e)
        {

            timer2.Enabled = false;
            button1.Enabled = true;
            button3.Enabled = false;
            label20.Visible = false;
        }

        private void chart1_DoubleClick(object sender, EventArgs e)
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

        //a cada 1s esse timer atualiza o chart com os dados lidos na serial
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                pressao = Convert.ToString(Math.Round(Convert.ToDouble(aa[0]), 1));
                aa.Clear();
                a.Add(pressao);
                
                var lista = new ListViewItem(new[] { Convert.ToString(cont * periodo), pressao });
                listView1.Items.Add(lista);
            }
            catch
            {
                problema_porta = true;
            }
            textBox17.Visible = true;
            chart1.Series["Pressure (psi)"].Points.AddXY(cont * periodo, pressao);
            textBox17.Text = pressao;
            if (timer2.Enabled == true)
            //if (button1.Enabled.Equals(false) == true)
            {
                Escrevedor = File.AppendText(caminho_e_nome); // se quer adicionar texto sobre arq existente
                Escrevedor.WriteLine(cont * periodo + delimitador + pressao); // escreve uma linha e pula
                Escrevedor.Close(); // tem que fechar senão dá erro qdo tentar escrever de novo
            }
            //if (timer2.Enabled != true) { timer2.Enabled = true; } // começa a ler e mostrar na tela
            if (problema_porta == true)
            {
            }

            cont = cont + 1;
        }

        //open da serial port
        private void button4_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
            try { t.Abort(); }
            finally
            {
                progressBar1.Value = 0;
                comboBox1_Lista_Portas.Items.Clear();
                Verifica_Ports_Availables();
                button4.Enabled = false;
                button3_Open_Port.Enabled = true;
                if ((t != null) && (t.IsAlive == true)) { t.Abort(); }
                timer1.Enabled = false;
                timer2.Enabled = false;
                button1.Enabled = true;
                button1.Visible = false;
                button3.Enabled = false;
                button3.Visible = false;
                label20.Visible = false;
                comboBox1_Lista_Portas.SelectedIndex = -1;
                comboBox1_Lista_Portas.Text = "";
                label1.Visible = false;
                serialPort1.Close();
                //limpa os dados
                listView1.Items.Clear();
                cont = 0;
                textBox17.Visible = false;
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
            }
        }

        //thread iniciada ao abrir a porta serial
        private void SerialReadLoop()      //loop untill told to stop
        {
            //create and open a port
            //SerialPort port;
            string nome_porta = serialPort1.PortName; // pega o nome da porta já aberta
            serialPort1 = new SerialPort(nome_porta, 9600, Parity.None, 8, StopBits.One); //padrão da serial: igual arduino

            serialPort1.Open();

            //loop forever
            while (!_shouldStop)
            {
                if (serialPort1.IsOpen == true)
                {
                    if (serialPort1.BytesToRead > 0) //  when there is data, read a line / numero de bytes aleatorio, o número de bytes por linha que será lido é 49 (de acordo com versao atual do sistema de aquisição)
                    {
                        string indata = serialPort1.ReadLine();
                        //MessageBox.Show(string.Format("Indata: {0}\n", indata), "Results", MessageBoxButtons.OK);
                        pressao = indata;
                        aa.Add(pressao);
                        //MessageBox.Show(string.Format("aa: {0}\n", aa[0]), "pressao", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    problema_porta = true;
                }// end if else

            }// end while

            serialPort1.Close();


        } // fim void

        //timer só para piscar o aviso de saving..
        private void timer2_Tick(object sender, EventArgs e)
        {  // para piscar o "saving..."

            if (label20.Visible == true)
            {
                label20.Visible = false;
            }
            else if (button3.Enabled == true)
            {
                label20.Visible = true;
            }
        }

        // Botao QUIT
        private void button2_Click(object sender, EventArgs e)
        { 
            serialPort1.Close();
            Application.Exit();
        }

        //-----------------------------------------------------------------------
        // -------- interrompe o Thread quando sai - precisa isso senao porta fica aberta e dá erro

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Request that the worker thread stop itself:
            _shouldStop = true;

            // Use the Join method to block the current thread until the object's thread terminates.
            try
            {
                if ((t.IsAlive.Equals(true) == true))
                {
                    t.Join();
                }
            }
            catch (NullReferenceException)
            {
                serialPort1.Close();
                Application.Exit();
            }
        }

    }
}
