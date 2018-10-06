using System;
using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace LMPT_Protocolo
{
    public partial class ModulesSearch : Form
    {
        private const int timeToSearch = 30000; //30s
        public int g_delay_next_btn = 3; //3k ms = 3s
        public bool g_toogle_search = false;

        ComPort pc_com_port = new ComPort(); //parameter is refresh rate for update com ports in milliseconds

        System.Windows.Forms.Timer timer_blink_searching;
        System.Windows.Forms.Timer timer_to_enable_next;
        System.Windows.Forms.Timer timer_refreshComPorts;


        public bool g_blink_search_flag = false;
        LMPT_SerialProtocol lpmt_sp = new LMPT_SerialProtocol();
        XbeeNetwork xbee_network;
        private Thread thr_waitSearchDone;

        public ModulesSearch()
        {
            xbee_network = new XbeeNetwork(new string[] { "0x02", "0x03" });

            InitializeComponent();
            this.FormClosing += ModulesSearch_Close;

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

            timer_refreshComPorts = new System.Windows.Forms.Timer();
            timer_refreshComPorts.Interval = 5000; //1s
            timer_refreshComPorts.Tick += new EventHandler(refresh_com_event);
            timer_refreshComPorts.Start();

            BTN_COM_Close.Enabled = false;
            BTN_Search2Sampling.Enabled = false;
            timer_blink_searching.Enabled = false;
            CB_COM_List.DataSource = pc_com_port.update_comPorts();

            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        private void refresh_com_event(Object myObject, EventArgs myEventArgs)
        {
            this.Invoke((MethodInvoker)delegate
            {
                CB_COM_List.DataSource = pc_com_port.update_comPorts();
            });
        }

        private void timer_blink_searching_label_Tick(Object myObject, EventArgs myEventArgs)
        {
            if (xbee_network.searching() == true)
            {
                g_blink_search_flag = !g_blink_search_flag;

                this.Invoke((MethodInvoker)delegate
                {
                    LBL_Searching.Visible = g_blink_search_flag;
                });
            }
            else timer_blink_searching.Enabled = false;
        }

        private void ModulesSearch_Close(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (xbee_network.searching() == true)
            {
                try { xbee_network.stopSearch(); } finally { pc_com_port.Close(); }
                this.Invoke((MethodInvoker)delegate
                {
                    timer_blink_searching.Enabled = false;
                });

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
                if (thr_waitSearchDone.IsAlive) thr_waitSearchDone.Abort();

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
            DataSampling dataSamping_form = new DataSampling(pc_com_port, xbee_network);
            dataSamping_form.Show();

            if (pc_com_port.IsOpen == true)
            {
                pc_com_port.Close();
            }

            BTN_Search2Sampling.Enabled = false;
            BTN_Search2Sampling.Visible = false;
        }

        private void BTN_Quit_Search_Click(object sender, EventArgs e)
        {
            if (xbee_network.searching() == true)
            {
                try { xbee_network.stopSearch(); } finally { pc_com_port.Close();
                    pc_com_port.Dispose();
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
                    timer_refreshComPorts.Stop();
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
                    thr_waitSearchDone = new Thread(() => waitSearchDone(xbee_network));
                    thr_waitSearchDone.Name = "waitSearchDone_thread";
                    thr_waitSearchDone.Start();
                }
                else
                {
                    //  serError_lbl.Visible = true;
                }
            }
        }

        private void waitSearchDone(XbeeNetwork xbee_network) {
            int index = 0;
            Thread.Sleep(5000);
            while (xbee_network.searching()) { Thread.Sleep(1000); }
            this.Invoke((MethodInvoker)delegate
            {
                //elements of UI thread
                LBL_Searching.Visible = true;
                LBL_Searching.Text = "          Modules Found"; //TODO: fix this!
            });


            this.Invoke((MethodInvoker)delegate
            {
                foreach (string s in xbee_network.getFoundNodes())
                {
                    for (int i = 0; i < xbee_network.numberOfNodes(); i++)
                    {
                        if (s == xbee_network.getNode(i)) {
                            switch (i) {
                                case 0:
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        TB_SA1_Search.BackColor = System.Drawing.Color.Green;
                                    });
                                    break;
                                case 1:
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        TB_SA2_Search.BackColor = System.Drawing.Color.Green;
                                    });
                                    break;

                                default: break;
                            }
                        }
                    }
                }
                timer_to_enable_next.Start();
            });


        }

        private void BTN_COM_Close_Click(object sender, EventArgs e)
        {
            if (xbee_network.searching() == true)
            {
                try { xbee_network.stopSearch(); } finally { pc_com_port.Close();
                    pc_com_port.Dispose();
                }
                BTN_COM_Open.Enabled = true;
                CB_COM_List.DataSource = pc_com_port.update_comPorts();
            }
        }
    }
}

