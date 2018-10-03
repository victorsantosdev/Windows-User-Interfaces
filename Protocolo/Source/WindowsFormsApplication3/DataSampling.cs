using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace LMPT_Protocolo
{
    public partial class DataSampling : Form
    {


        public DataSampling()
        {
            InitializeComponent();

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

            Application.Exit();
        }
    }
}
