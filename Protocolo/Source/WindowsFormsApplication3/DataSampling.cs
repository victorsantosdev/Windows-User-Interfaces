using System;
using System.Windows.Forms;


namespace LMPT_Protocolo
{
    public partial class DataSampling : Form
    {
        ComPort samplingPort;
        XbeeNetwork samplingNetwork;

        public DataSampling(ComPort port, XbeeNetwork xbee_network)
        {
            samplingNetwork = xbee_network;
            samplingPort = port;
            InitializeComponent();
            refresNodesAddress(xbee_network);



        }

        void refresNodesAddress(XbeeNetwork xbee_network) {
            foreach (string s in xbee_network.getFoundNodes())
            {
                for (int i = 0; i < xbee_network.numberOfNodes(); i++)
                {
                    if (s == xbee_network.getNode(i))
                    {
                        switch (i)
                        {
                            case 0:

                                TB_SA1_Sampling.Text = xbee_network.getNode(i);

                                break;
                            case 1:

                                TB_SA2_Sampling.Text = xbee_network.getNode(i);

                                break;

                            default: break;
                        }
                    }
                }
            }
        }


        private void BTN_Quit_Sampling_Click(object sender, EventArgs e)
        {
            //if (g_searching_flag == 1)
            //{
            //    if (thr_searching.ThreadState.Equals(ThreadState.Running))
            //    {
            //        try { thr_searching.Abort(); } finally { pc_com_port.Close(); }
            //    }
            //}

            samplingPort.Close();
            samplingPort.Dispose();
            Application.Exit();
        }
    }
}
