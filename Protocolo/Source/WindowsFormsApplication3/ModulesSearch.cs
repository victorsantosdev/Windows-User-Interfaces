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
using LMPT_Protocolo;

namespace LMPT_Protocolo
{
    public partial class ModulesSearch : Form
    {
        private const int timeToSearch = 30000; //30s
        public int g_delay_next_btn = 3; //3k ms = 3s
        public bool g_toogle_search = false;

        SerialPort pc_com_port = new SerialPort();
       
        System.Windows.Forms.Timer timer_blink_searching;
        System.Windows.Forms.Timer timer_to_enable_next;


        public bool g_blink_search_flag = false;
        LMPT_SerialProtocol lpmt_sp = new LMPT_SerialProtocol();
        XbeeNetwork xbee_network;

        public ModulesSearch()
        {
            xbee_network = new XbeeNetwork(new string[] { "0x02", "0x03" });

            InitializeComponent();
            this.FormClosing += ModulesSearch_Close;

            //default COM port Arduino configuration
            pc_com_port.BaudRate = 115200;
            pc_com_port.Parity = Parity.None;
            pc_com_port.DataBits = 8;
            pc_com_port.StopBits = StopBits.One;

            //if needed to keep a fixed window size
            //this.MinimumSize = new Size(800, 800);
            //this.MaximumSize = new Size(800, 800);

            TB_SA1_Search.Text = xbee_network.getNode(0);
            TB_SA2_Search.Text = xbee_network.getNode(1);
            LBL_Searching.Visible = false;
            LBL_Header.Visible = false;
            LBL_SA1_Search.Visible = false;
            LBL_SA2_Search.Visible = false;
            TB_SA1_Search.Visible = false;
            TB_SA2_Search.Visible = false;

            timer_blink_searching = new System.Windows.Forms.Timer();
            timer_blink_searching.Interval = 250; //250ms
            timer_blink_searching.Tick += new EventHandler(timer_blink_searching_label_Tick);

            timer_to_enable_next = new System.Windows.Forms.Timer();
            timer_to_enable_next.Interval = 1000; //1s
            timer_to_enable_next.Tick += new EventHandler(timer_to_enable_next_Tick);

            BTN_COM_Close.Enabled = false;
            BTN_Search2Sampling.Enabled = false;
            timer_blink_searching.Enabled = false;
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



        private void timer_blink_searching_label_Tick(Object myObject, EventArgs myEventArgs)
        {
            g_blink_search_flag = !g_blink_search_flag;

            this.Invoke((MethodInvoker)delegate
            {
                LBL_Searching.Visible = g_blink_search_flag;
            });

        }

        private void ModulesSearch_Close(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (xbee_network.searching() == true)
            {
                try { xbee_network.stopSearch(); } finally { pc_com_port.Close(); }

            }

            Application.Exit();
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

        private void BTN_Search2Sampling_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataSampling dataSamping_form = new DataSampling();
            dataSamping_form.Show();

            if (pc_com_port.IsOpen == true)
            {
                pc_com_port.Close();
            }

            try
            {
                xbee_network.stopSearch();
            } //mata a tread de busca quando inicia a thread de aquisicao
            finally
            {

                BTN_Search2Sampling.Enabled = false;
                BTN_Search2Sampling.Visible = false;

            }
        }

        private void BTN_Quit_Search_Click(object sender, EventArgs e)
        {
            if (xbee_network.searching() == true)
            {
                try { xbee_network.stopSearch(); } finally { pc_com_port.Close(); }

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
                    //pc_com_port.Write(lpmt_sp.knock_cmd(), 0, lpmt_sp.maxLenght());
                    pc_com_port.Close();
                    BTN_COM_Close.Enabled = true;
                    LBL_Searching.Visible = true;
                    LBL_Header.Visible = true;
                    LBL_SA1_Search.Visible = true;
                    LBL_SA2_Search.Visible = true;
                    TB_SA1_Search.Visible = true;
                    TB_SA2_Search.Visible = true;
                    timer_blink_searching.Start();
                    xbee_network.startSearch(pc_com_port, xbee_network, timeToSearch);
                    //xbee_network.foundNodes
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

