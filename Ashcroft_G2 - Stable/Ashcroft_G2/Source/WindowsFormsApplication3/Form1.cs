using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports; // adicionado na mão
using System.IO;
using System.Threading; // adicionado


namespace WindowsFormsApplication3
{
  public partial class Form1 : Form
  {
    // variaveis globais aqui
    public string cabecalho = " Day_Hour, Time(s), T_Out, T_HFM, Delta_T, T_h_meter, PWM, V_Flux_1, V_Flux_2, V_Rad_Out, V_Rad_In, Flux_1, Flux_2, Flux_avg, Rad_out, Rad_In, h_out, T_Sol, Heading, Incoming Angle, SHGC_Ang, SHGC_Norm ";
    public double SHGC_Ang, SHGC_Norm, tempo_grav, tempo_grav_zero;
    public string[] pal; // vetor armazena  cada palavra da linha lida na serial
    public int cont;
    //public string local_arquivo = "d:/lixo";
    public string caminho_e_nome, aa, bb;

    StreamWriter Escrevedor; // cria uma classe com esse nome
    Thread t;  //run a separate thread for reading the usb port
     private volatile bool _shouldStop = false;     //a volatile flag to signal to the other thread to stop
     private volatile bool problema_porta = false;    

    //-------------------------------------------------------------------------------------

    public Form1() // constructor
    {
            InitializeComponent();

            this.FormClosing += Form1_FormClosing;//register event - usado para o thread

            Verifica_Ports_Availables(); // sub  rotina abaixo
            serialPort1.BaudRate = 9600;
            cont = 0;
            timer1.Enabled = false;
         //   aa = "1,2,3,4,5,6,7,8,9,10,1,2,3,4,5,6,7,8,9,10, 21,22"; // se nao dá erro na primeira varrida
            aa = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,"; // se nao dá erro na primeira varrida
  
    }
    //-------------------------------------------------------------------------------------


    void Verifica_Ports_Availables()
    {
         String[] portas = SerialPort.GetPortNames(); // carrega nome das portas
         comboBox1_Lista_Portas.Items.AddRange(portas);// lista as portas no combox

    }

        //------------------------------------------------------------------
        

    private void button3_Open_Port_Click(object sender, EventArgs e)
    {

          serialPort1.PortName = comboBox1_Lista_Portas.Text; // pega a clicada
          try
          {    serialPort1.Open();  // nao mudou nada com esse catch
          }
          catch
          {    problema_porta = true;
          }
         


          if (serialPort1.IsOpen == true) // só faz se porta está aberta
          {
            button3_Open_Port.Enabled = false; // não deixa abrir de novo (daria erro)
            progressBar1.Value = 100; // p/  mostrar que a porta abriu
            label1.Visible = false;
            serialPort1.Close(); // pois quem vai abrir cada vez é o Thread

            t = new Thread(new ThreadStart(SerialReadLoop)); // esse SerialReadLoop é uma rotina abaixo (tipo loop)     //create and start the serial thread 
            t.Start();   // Run Go() on the new thread.

            Grava_Cabecalho();
            timer1.Enabled = true; // começa a ler e mostrar na tela
          }
          else
          {
            label1.Visible = true;
          }
      
    }

    //-------------------------------------------------------------------
    //---------------------------------------------------------------------

    private void Grava_Cabecalho()
    {
    
      DateTime tt = DateTime.Now; // pega tudo e poe no tt
      int dia = tt.Day;
      int mes = tt.Month;
      int ano = tt.Year;
      int hora = tt.Hour;
      int min = tt.Minute;

      bb = mes.ToString() + "-" + dia.ToString() + "-" + ano.ToString() + "  " + hora.ToString() + "_" + min.ToString();
      //caminho_e_nome = caminho + bb + ".txt"; // var escrever no local especificado CAMINHO
      caminho_e_nome = bb + ".txt"; // vai escrever onde está o executavel (debug,bin)

      Escrevedor = File.CreateText(caminho_e_nome); // se quer escrever por cima de arq existente
      //Escrevedor = File.AppendText(caminho_e_nome); // se quer adicionar texto sobre arq existente

      Escrevedor.WriteLine(cabecalho); // escreve uma linha e pula
      Escrevedor.Close(); // tem que fechar senão dá erro qdo tentar escrever de novo

      timer2.Enabled = true; // p/ piscar o label "saving..."

    }



    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {

    }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_Lista_Portas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //-------------------------------------------------------------------
        //---------------------------------------------------------------------


        private void timer1_Tick(object sender, EventArgs e)
    {
      try
      {
        richTextBox1.AppendText(aa); // escreve tudo no TexBox
        pal = aa.Split(','); // separa nas virgulas p/ vetor pal[] - starts on 0 (zero)
      }
      catch
      {
        problema_porta = true;

      }

         //double tempo = double.Parse(pal[1]);
      SHGC_Ang = double.Parse(pal[20]);  // transforma string em double
      SHGC_Norm = double.Parse(pal[21]);  // transforma string em double

      if (SHGC_Ang > 1) SHGC_Ang = 0.999;
      if (SHGC_Norm > 1) SHGC_Norm = 0.999;

      /* if (cont == 0)
       { tempo_grav_zero = tempo; }

        tempo_grav = tempo - tempo_grav_zero;
      */

      textBox1.Text = pal[0]; //data
          // textBox2.Text = tempo_grav.ToString(); // tempo a partir gravacao
          textBox2.Text = pal[1]; // tempo
          textBox3.Text = pal[2]; // Tout
          textBox4.Text = pal[3]; // T plate
          textBox5.Text = pal[4]; // Delta T
          textBox6.Text = pal[5]; // T h meter
          textBox7.Text = pal[6]; // PWM
          textBox8.Text = pal[11]; // Flux 1
          textBox9.Text = pal[12]; // Flux 2
          textBox10.Text = pal[13]; // flux med
          textBox11.Text = pal[14]; // Rad out
          textBox12.Text = pal[15]; // Rad int
          textBox13.Text = pal[16]; // h out
          textBox14.Text = pal[17]; // T sol
          textBox15.Text = pal[18]; // Heading
          textBox16.Text = pal[19]; // Incoming angle
          textBox17.Text = pal[19]; // Incoming angl
          textBox18.Text = pal[20]; // SHGC ang
          textBox19.Text = pal[21];// SHGC Norm

      

          chart1.Series["SHGC_Ang"].Points.AddXY(cont, SHGC_Ang);
          chart1.Series["SHGC_Norm"].Points.AddXY(cont, SHGC_Norm);


          Escrevedor = File.AppendText(caminho_e_nome); // se quer adicionar texto sobre arq existente
          Escrevedor.WriteLine(aa); // escreve uma linha e pula
          Escrevedor.Close(); // tem que fechar senão dá erro qdo tentar escrever de novo

          if (problema_porta == true)
          { label1.Visible = true;
          }

          cont = cont + 1;

    }

    //-------------------------------------------------------------------------
    //-------------------------------------------------------------------------

    private void SerialReadLoop()      //loop untill told to stop 
    {
      //create and open a port
      //SerialPort port;
      string nome_porta = serialPort1.PortName; // pega o nome da porta já aberta
      serialPort1 = new SerialPort(nome_porta, 9600, Parity.None, 8, StopBits.One);

      serialPort1.Open();

      //loop forever
      while (!_shouldStop)
      {
          if (serialPort1.IsOpen == true)
          { 
            if (serialPort1.BytesToRead > 0) //  when there is data, read a line
            {
                  aa = serialPort1.ReadLine();
            }

          }
         else
          {
              problema_porta = true;
          }// end if else

      }// end while

      serialPort1.Close();   

    } // fim void


    /*-----------------------------------------------------------------------------------------*/
    /*-----------------------------------------------------------------------------------------*/

    private void timer2_Tick(object sender, EventArgs e)
    {  // para piscar o "saving..."

      if (label20.Visible == true)
      {
        label20.Visible = false;
      } else
      {
        label20.Visible = true;
      }
    }

    //--------------------------------------------------------------------- 
    //--------------------------------------------------------------------- 

    private void button2_Click(object sender, EventArgs e)
    { // Botao QUIT
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
      t.Join();

    }

  }
}
