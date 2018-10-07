using System;
using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace LmptProtocol
{
    public partial class ModulesSearch : Form
    {
        private const int timeToSearch = 30000; //30s
        private int delayNextButton = 3; //3k ms = 3s
        private System.Windows.Forms.Timer timerBlinkSearching;
        private System.Windows.Forms.Timer timerEnableNextButton;
        private System.Windows.Forms.Timer timerUpdateComPorts;
        private bool blinkSearchFlag = false;
        private Thread thrWaitSearchDone;

        ComPort pcComPort = new ComPort(); //parameter is refresh rate for update com ports in milliseconds
        LmptSerialProtocol lmptSerialProtocol = new LmptSerialProtocol();
        XbeeNetwork xbeeNetwork;

        public ModulesSearch()
        {
            xbeeNetwork = new XbeeNetwork(new string[] { "0x02", "0x03" });

            InitializeComponent();
            this.FormClosing += ModulesSearchFormClose;

            //if needed to keep a fixed window size
            //this.MinimumSize = new Size(800, 800);
            //this.MaximumSize = new Size(800, 800);

            TextBoxSlaveAddr1Search.Text = xbeeNetwork.GetNode(0);
            TextBoxSlaveAddr2Search.Text = xbeeNetwork.GetNode(1);
            LabelSearching.Visible = false;
            LabelHeader.Visible = false;
            LabelSlaveAddr1Search.Visible = false;
            LabelSlaveAddr2Search.Visible = false;
            TextBoxSlaveAddr1Search.Visible = false;
            TextBoxSlaveAddr2Search.Visible = false;

            timerBlinkSearching = new System.Windows.Forms.Timer();
            timerBlinkSearching.Interval = 250; //250ms
            timerBlinkSearching.Tick += new EventHandler(BlinkSearchingLabel);

            timerEnableNextButton = new System.Windows.Forms.Timer();
            timerEnableNextButton.Interval = 1000; //1s
            timerEnableNextButton.Tick += new EventHandler(EnableNextButton);

            timerUpdateComPorts = new System.Windows.Forms.Timer();
            timerUpdateComPorts.Interval = 5000; //1s
            timerUpdateComPorts.Tick += new EventHandler(UpdateAvailablePorts);
            timerUpdateComPorts.Start();

            ButtonComPortClose.Enabled = false;
            ButtonNextSampling.Enabled = false;
            timerBlinkSearching.Enabled = false;
            ComboBoxComList.DataSource = pcComPort.UpdateComPorts();

            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        private void UpdateAvailablePorts(Object myObject, EventArgs myEventArgs)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ComboBoxComList.DataSource = pcComPort.UpdateComPorts();
            });
        }

        private void BlinkSearchingLabel(Object myObject, EventArgs myEventArgs)
        {
            if (xbeeNetwork.Searching() == true)
            {
                blinkSearchFlag = !blinkSearchFlag;

                this.Invoke((MethodInvoker)delegate
                {
                    LabelSearching.Visible = blinkSearchFlag;
                });
            }
            else timerBlinkSearching.Enabled = false;
        }

        private void ModulesSearchFormClose(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (xbeeNetwork.Searching() == true)
            {
                try { xbeeNetwork.StopSearch(); } finally { pcComPort.Close(); pcComPort.Dispose(); }
                this.Invoke((MethodInvoker)delegate
                {
                    timerBlinkSearching.Enabled = false;
                });

            }

            Application.Exit();
        }

        private void EnableNextButton(Object myObject, EventArgs myEventArgs)
        {
            if (delayNextButton > 0)
            {
                delayNextButton = delayNextButton - 1;
            }
            this.Invoke((MethodInvoker)delegate
            {
                ButtonNextSampling.Text = "Next [" + delayNextButton.ToString() + "]";
            });

            if (delayNextButton == 0)
            {
                if (thrWaitSearchDone.IsAlive) thrWaitSearchDone.Abort();

                ButtonNextSampling.Text = "Next";
                this.Invoke((MethodInvoker)delegate
                {

                    timerEnableNextButton.Stop(); // runs on UI thread
                    ButtonNextSampling.Enabled = true;
                });
            }
        }


        private void ButtonNextSamplingClick(object sender, EventArgs e)
        {
            this.Hide();
            DataSampling dataSamping_form = new DataSampling(pcComPort, xbeeNetwork);
            dataSamping_form.Show();

            if (pcComPort.IsOpen == true)
            {
                pcComPort.Close();
            }

            ButtonNextSampling.Enabled = false;
            ButtonNextSampling.Visible = false;
        }

        private void ButtonQuitSearchClick(object sender, EventArgs e)
        {
            if (xbeeNetwork.Searching() == true)
            {
                thrWaitSearchDone.Abort();
                try { xbeeNetwork.StopSearch(); } finally { pcComPort.Close();
                    pcComPort.Dispose();
                }

            }
            Application.Exit();
        }

        private void ButtonComPortCloseClick(object sender, EventArgs e)
        {
            if (xbeeNetwork.Searching() == true)
            {
                try { xbeeNetwork.StopSearch(); }
                finally
                {
                    pcComPort.Close();
                    pcComPort.Dispose();
                }
                ButtonComPortOpen.Enabled = true;
                ComboBoxComList.DataSource = pcComPort.UpdateComPorts();
            }
        }

        private void ButtonComPortOpenClick(object sender, EventArgs e)
        {
            if (ComboBoxComList.SelectedIndex != -1)
            {
                pcComPort.PortName = ComboBoxComList.Text;
                try
                {
                    pcComPort.Open();
                }
                catch
                {
                    //problema_porta = true;
                    //sinalizar erro de porta
                }

                if (pcComPort.IsOpen == true)
                {
                    timerUpdateComPorts.Stop();
                    ButtonComPortOpen.Enabled = false;
                    //pcComPort.Write(lmptSerialProtocol.Knock(), 0, lmptSerialProtocol.maxLenght());
                    pcComPort.Close();
                    ButtonComPortClose.Enabled = true;
                    LabelSearching.Visible = true;
                    LabelHeader.Visible = true;
                    LabelSlaveAddr1Search.Visible = true;
                    LabelSlaveAddr2Search.Visible = true;
                    TextBoxSlaveAddr1Search.Visible = true;
                    TextBoxSlaveAddr2Search.Visible = true;
                    timerBlinkSearching.Start();
                    xbeeNetwork.StartSearch(pcComPort, xbeeNetwork, timeToSearch);
                    thrWaitSearchDone = new Thread(() => WaitSearchDone(xbeeNetwork));
                    thrWaitSearchDone.Name = "WaitSearchDone_thread";
                    thrWaitSearchDone.Start();
                }
                else
                {
                    //  serError_lbl.Visible = true;
                }
            }
        }

        private void WaitSearchDone(XbeeNetwork xbeeNetwork) {
            Thread.Sleep(5000);
            while (xbeeNetwork.Searching()) { Thread.Sleep(1000); }
            this.Invoke((MethodInvoker)delegate
            {
                //elements of UI thread
                LabelSearching.Visible = true;
                LabelSearching.Text = "          Modules Found"; //TODO: fix this!
            });


            this.Invoke((MethodInvoker)delegate
            {
                foreach (string s in xbeeNetwork.GetFoundNodes())
                {
                    for (int i = 0; i < xbeeNetwork.NumberOfNodes(); i++)
                    {
                        if (s == xbeeNetwork.GetNode(i))
                        {
                            switch (i)
                            {
                                case 0:
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        TextBoxSlaveAddr1Search.BackColor = System.Drawing.Color.Green;
                                    });
                                    break;
                                case 1:
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        TextBoxSlaveAddr2Search.BackColor = System.Drawing.Color.Green;
                                    });
                                    break;

                                default: break;
                            }
                        }
                    }
                }
                timerEnableNextButton.Start();
            });
        }


    }
}

