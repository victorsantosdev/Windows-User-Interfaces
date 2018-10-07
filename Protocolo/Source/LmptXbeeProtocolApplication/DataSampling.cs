using System;
using System.Windows.Forms;


namespace LmptProtocol
{
    public partial class DataSampling : Form
    {
        ComPort samplingPort;
        XbeeNetwork samplingNetwork;

        public DataSampling(ComPort port, XbeeNetwork xbeeNetwork)
        {
            samplingNetwork = xbeeNetwork;
            samplingPort = port;
            InitializeComponent();
            UpdateAddressFields(xbeeNetwork);

        }

        void UpdateAddressFields(XbeeNetwork xbeeNetwork) {
            foreach (string s in xbeeNetwork.GetFoundNodes())
            {
                for (int i = 0; i < xbeeNetwork.NumberOfNodes(); i++)
                {
                    if (s == xbeeNetwork.GetNode(i))
                    {
                        switch (i)
                        {
                            case 0:

                                TextBoxSlaveAddr1Sampling.Text = xbeeNetwork.GetNode(i);
                                break;
                            case 1:

                                TextBoxSlaveAddr2Sampling.Text = xbeeNetwork.GetNode(i);
                                break;

                            default: break;
                        }
                    }
                }
            }
        }


        private void BTN_Quit_Sampling_Click(object sender, EventArgs e)
        {
            samplingPort.Close();
            samplingPort.Dispose();
            Application.Exit();
        }
    }
}
