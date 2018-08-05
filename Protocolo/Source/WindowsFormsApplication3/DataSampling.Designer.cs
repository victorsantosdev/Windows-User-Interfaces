namespace LMPT_Protocolo
{
    partial class DataSampling
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LBL_Title = new System.Windows.Forms.Label();
            this.PB_UFSC_Icon = new System.Windows.Forms.PictureBox();
            this.PB_LMPT_Icon = new System.Windows.Forms.PictureBox();
            this.LBL_SLA1_Sampling = new System.Windows.Forms.Label();
            this.LBL_SLA2_Sampling = new System.Windows.Forms.Label();
            this.LBL_FormDescription_Sampling = new System.Windows.Forms.Label();
            this.TB_SA1_Sampling = new System.Windows.Forms.TextBox();
            this.TB_SLA2_Sampling = new System.Windows.Forms.TextBox();
            this.TB_SLA1_Sensor1 = new System.Windows.Forms.TextBox();
            this.TB_SLA1_Sensor2 = new System.Windows.Forms.TextBox();
            this.TB_SLA1_Sensor3 = new System.Windows.Forms.TextBox();
            this.TB_SLA1_Sensor4 = new System.Windows.Forms.TextBox();
            this.TB_SLA2_Sensor4 = new System.Windows.Forms.TextBox();
            this.TB_SLA3_Sensor3 = new System.Windows.Forms.TextBox();
            this.TB_SLA2_Sensor2 = new System.Windows.Forms.TextBox();
            this.TB_SLA2_Sensor1 = new System.Windows.Forms.TextBox();
            this.LBL_SLA1_Sensor1 = new System.Windows.Forms.Label();
            this.LBL_SLA1_Sensor2 = new System.Windows.Forms.Label();
            this.LBL_SLA1_Sensor3 = new System.Windows.Forms.Label();
            this.LBL_SLA1_Sensor4 = new System.Windows.Forms.Label();
            this.LBL_SLA2_Sensor1 = new System.Windows.Forms.Label();
            this.LBL_SLA2_Sensor2 = new System.Windows.Forms.Label();
            this.LBL_SLA2_Sensor3 = new System.Windows.Forms.Label();
            this.LBL_SLA2_Sensor4 = new System.Windows.Forms.Label();
            this.BTN_Quit_Sampling = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_UFSC_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LMPT_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Title.Location = new System.Drawing.Point(218, 139);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(364, 24);
            this.LBL_Title.TabIndex = 12;
            this.LBL_Title.Text = "LMPT Radio Protocol Communication ";
            // 
            // PB_UFSC_Icon
            // 
            this.PB_UFSC_Icon.Image = global::Protocolo.Properties.Resources.ufsc_brasao;
            this.PB_UFSC_Icon.Location = new System.Drawing.Point(389, 12);
            this.PB_UFSC_Icon.Name = "PB_UFSC_Icon";
            this.PB_UFSC_Icon.Size = new System.Drawing.Size(180, 124);
            this.PB_UFSC_Icon.TabIndex = 14;
            this.PB_UFSC_Icon.TabStop = false;
            // 
            // PB_LMPT_Icon
            // 
            this.PB_LMPT_Icon.Image = global::Protocolo.Properties.Resources.lpmt_resized;
            this.PB_LMPT_Icon.Location = new System.Drawing.Point(237, 12);
            this.PB_LMPT_Icon.Name = "PB_LMPT_Icon";
            this.PB_LMPT_Icon.Size = new System.Drawing.Size(146, 124);
            this.PB_LMPT_Icon.TabIndex = 13;
            this.PB_LMPT_Icon.TabStop = false;
            // 
            // LBL_SLA1_Sampling
            // 
            this.LBL_SLA1_Sampling.AutoSize = true;
            this.LBL_SLA1_Sampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_SLA1_Sampling.Location = new System.Drawing.Point(53, 249);
            this.LBL_SLA1_Sampling.Name = "LBL_SLA1_Sampling";
            this.LBL_SLA1_Sampling.Size = new System.Drawing.Size(115, 17);
            this.LBL_SLA1_Sampling.TabIndex = 15;
            this.LBL_SLA1_Sampling.Text = "Slave Address 1:";
            // 
            // LBL_SLA2_Sampling
            // 
            this.LBL_SLA2_Sampling.AutoSize = true;
            this.LBL_SLA2_Sampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_SLA2_Sampling.Location = new System.Drawing.Point(397, 255);
            this.LBL_SLA2_Sampling.Name = "LBL_SLA2_Sampling";
            this.LBL_SLA2_Sampling.Size = new System.Drawing.Size(115, 17);
            this.LBL_SLA2_Sampling.TabIndex = 16;
            this.LBL_SLA2_Sampling.Text = "Slave Address 2:";
            // 
            // LBL_FormDescription_Sampling
            // 
            this.LBL_FormDescription_Sampling.AutoSize = true;
            this.LBL_FormDescription_Sampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_FormDescription_Sampling.Location = new System.Drawing.Point(339, 163);
            this.LBL_FormDescription_Sampling.Name = "LBL_FormDescription_Sampling";
            this.LBL_FormDescription_Sampling.Size = new System.Drawing.Size(131, 24);
            this.LBL_FormDescription_Sampling.TabIndex = 17;
            this.LBL_FormDescription_Sampling.Text = "Data Sampling";
            // 
            // TB_SA1_Sampling
            // 
            this.TB_SA1_Sampling.Location = new System.Drawing.Point(176, 249);
            this.TB_SA1_Sampling.Name = "TB_SA1_Sampling";
            this.TB_SA1_Sampling.ReadOnly = true;
            this.TB_SA1_Sampling.Size = new System.Drawing.Size(145, 20);
            this.TB_SA1_Sampling.TabIndex = 18;
            this.TB_SA1_Sampling.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_SLA2_Sampling
            // 
            this.TB_SLA2_Sampling.Location = new System.Drawing.Point(520, 252);
            this.TB_SLA2_Sampling.Name = "TB_SLA2_Sampling";
            this.TB_SLA2_Sampling.ReadOnly = true;
            this.TB_SLA2_Sampling.Size = new System.Drawing.Size(145, 20);
            this.TB_SLA2_Sampling.TabIndex = 19;
            this.TB_SLA2_Sampling.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TB_SLA1_Sensor1
            // 
            this.TB_SLA1_Sensor1.Location = new System.Drawing.Point(176, 297);
            this.TB_SLA1_Sensor1.Name = "TB_SLA1_Sensor1";
            this.TB_SLA1_Sensor1.Size = new System.Drawing.Size(143, 20);
            this.TB_SLA1_Sensor1.TabIndex = 20;
            // 
            // TB_SLA1_Sensor2
            // 
            this.TB_SLA1_Sensor2.Location = new System.Drawing.Point(176, 337);
            this.TB_SLA1_Sensor2.Name = "TB_SLA1_Sensor2";
            this.TB_SLA1_Sensor2.Size = new System.Drawing.Size(143, 20);
            this.TB_SLA1_Sensor2.TabIndex = 21;
            // 
            // TB_SLA1_Sensor3
            // 
            this.TB_SLA1_Sensor3.Location = new System.Drawing.Point(176, 374);
            this.TB_SLA1_Sensor3.Name = "TB_SLA1_Sensor3";
            this.TB_SLA1_Sensor3.Size = new System.Drawing.Size(143, 20);
            this.TB_SLA1_Sensor3.TabIndex = 22;
            // 
            // TB_SLA1_Sensor4
            // 
            this.TB_SLA1_Sensor4.Location = new System.Drawing.Point(176, 409);
            this.TB_SLA1_Sensor4.Name = "TB_SLA1_Sensor4";
            this.TB_SLA1_Sensor4.Size = new System.Drawing.Size(143, 20);
            this.TB_SLA1_Sensor4.TabIndex = 23;
            // 
            // TB_SLA2_Sensor4
            // 
            this.TB_SLA2_Sensor4.Location = new System.Drawing.Point(520, 409);
            this.TB_SLA2_Sensor4.Name = "TB_SLA2_Sensor4";
            this.TB_SLA2_Sensor4.Size = new System.Drawing.Size(143, 20);
            this.TB_SLA2_Sensor4.TabIndex = 27;
            // 
            // TB_SLA3_Sensor3
            // 
            this.TB_SLA3_Sensor3.Location = new System.Drawing.Point(520, 374);
            this.TB_SLA3_Sensor3.Name = "TB_SLA3_Sensor3";
            this.TB_SLA3_Sensor3.Size = new System.Drawing.Size(143, 20);
            this.TB_SLA3_Sensor3.TabIndex = 26;
            // 
            // TB_SLA2_Sensor2
            // 
            this.TB_SLA2_Sensor2.Location = new System.Drawing.Point(520, 337);
            this.TB_SLA2_Sensor2.Name = "TB_SLA2_Sensor2";
            this.TB_SLA2_Sensor2.Size = new System.Drawing.Size(143, 20);
            this.TB_SLA2_Sensor2.TabIndex = 25;
            // 
            // TB_SLA2_Sensor1
            // 
            this.TB_SLA2_Sensor1.Location = new System.Drawing.Point(520, 297);
            this.TB_SLA2_Sensor1.Name = "TB_SLA2_Sensor1";
            this.TB_SLA2_Sensor1.Size = new System.Drawing.Size(143, 20);
            this.TB_SLA2_Sensor1.TabIndex = 24;
            // 
            // LBL_SLA1_Sensor1
            // 
            this.LBL_SLA1_Sensor1.AutoSize = true;
            this.LBL_SLA1_Sensor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_SLA1_Sensor1.Location = new System.Drawing.Point(53, 297);
            this.LBL_SLA1_Sensor1.Name = "LBL_SLA1_Sensor1";
            this.LBL_SLA1_Sensor1.Size = new System.Drawing.Size(113, 17);
            this.LBL_SLA1_Sensor1.TabIndex = 28;
            this.LBL_SLA1_Sensor1.Text = "Analog Reading:";
            // 
            // LBL_SLA1_Sensor2
            // 
            this.LBL_SLA1_Sensor2.AutoSize = true;
            this.LBL_SLA1_Sensor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_SLA1_Sensor2.Location = new System.Drawing.Point(55, 337);
            this.LBL_SLA1_Sensor2.Name = "LBL_SLA1_Sensor2";
            this.LBL_SLA1_Sensor2.Size = new System.Drawing.Size(104, 17);
            this.LBL_SLA1_Sensor2.TabIndex = 29;
            this.LBL_SLA1_Sensor2.Text = "Analog Writing:";
            // 
            // LBL_SLA1_Sensor3
            // 
            this.LBL_SLA1_Sensor3.AutoSize = true;
            this.LBL_SLA1_Sensor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_SLA1_Sensor3.Location = new System.Drawing.Point(53, 371);
            this.LBL_SLA1_Sensor3.Name = "LBL_SLA1_Sensor3";
            this.LBL_SLA1_Sensor3.Size = new System.Drawing.Size(108, 17);
            this.LBL_SLA1_Sensor3.TabIndex = 30;
            this.LBL_SLA1_Sensor3.Text = "Digital Reading:";
            // 
            // LBL_SLA1_Sensor4
            // 
            this.LBL_SLA1_Sensor4.AutoSize = true;
            this.LBL_SLA1_Sensor4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_SLA1_Sensor4.Location = new System.Drawing.Point(55, 409);
            this.LBL_SLA1_Sensor4.Name = "LBL_SLA1_Sensor4";
            this.LBL_SLA1_Sensor4.Size = new System.Drawing.Size(99, 17);
            this.LBL_SLA1_Sensor4.TabIndex = 31;
            this.LBL_SLA1_Sensor4.Text = "Digital Writing:";
            // 
            // LBL_SLA2_Sensor1
            // 
            this.LBL_SLA2_Sensor1.AutoSize = true;
            this.LBL_SLA2_Sensor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_SLA2_Sensor1.Location = new System.Drawing.Point(397, 297);
            this.LBL_SLA2_Sensor1.Name = "LBL_SLA2_Sensor1";
            this.LBL_SLA2_Sensor1.Size = new System.Drawing.Size(108, 17);
            this.LBL_SLA2_Sensor1.TabIndex = 32;
            this.LBL_SLA2_Sensor1.Text = "ADS Channel 1:";
            // 
            // LBL_SLA2_Sensor2
            // 
            this.LBL_SLA2_Sensor2.AutoSize = true;
            this.LBL_SLA2_Sensor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_SLA2_Sensor2.Location = new System.Drawing.Point(397, 337);
            this.LBL_SLA2_Sensor2.Name = "LBL_SLA2_Sensor2";
            this.LBL_SLA2_Sensor2.Size = new System.Drawing.Size(108, 17);
            this.LBL_SLA2_Sensor2.TabIndex = 33;
            this.LBL_SLA2_Sensor2.Text = "ADS Channel 2:";
            // 
            // LBL_SLA2_Sensor3
            // 
            this.LBL_SLA2_Sensor3.AutoSize = true;
            this.LBL_SLA2_Sensor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_SLA2_Sensor3.Location = new System.Drawing.Point(399, 377);
            this.LBL_SLA2_Sensor3.Name = "LBL_SLA2_Sensor3";
            this.LBL_SLA2_Sensor3.Size = new System.Drawing.Size(108, 17);
            this.LBL_SLA2_Sensor3.TabIndex = 34;
            this.LBL_SLA2_Sensor3.Text = "ADS Channel 3:";
            // 
            // LBL_SLA2_Sensor4
            // 
            this.LBL_SLA2_Sensor4.AutoSize = true;
            this.LBL_SLA2_Sensor4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_SLA2_Sensor4.Location = new System.Drawing.Point(399, 412);
            this.LBL_SLA2_Sensor4.Name = "LBL_SLA2_Sensor4";
            this.LBL_SLA2_Sensor4.Size = new System.Drawing.Size(108, 17);
            this.LBL_SLA2_Sensor4.TabIndex = 35;
            this.LBL_SLA2_Sensor4.Text = "ADS Channel 4:";
            // 
            // BTN_Quit_Sampling
            // 
            this.BTN_Quit_Sampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.BTN_Quit_Sampling.Location = new System.Drawing.Point(627, 539);
            this.BTN_Quit_Sampling.Name = "BTN_Quit_Sampling";
            this.BTN_Quit_Sampling.Size = new System.Drawing.Size(82, 39);
            this.BTN_Quit_Sampling.TabIndex = 36;
            this.BTN_Quit_Sampling.Text = "Quit";
            this.BTN_Quit_Sampling.UseVisualStyleBackColor = true;
            this.BTN_Quit_Sampling.Click += new System.EventHandler(this.BTN_Quit_Sampling_Click);
            // 
            // DataSampling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 590);
            this.Controls.Add(this.BTN_Quit_Sampling);
            this.Controls.Add(this.LBL_SLA2_Sensor4);
            this.Controls.Add(this.LBL_SLA2_Sensor3);
            this.Controls.Add(this.LBL_SLA2_Sensor2);
            this.Controls.Add(this.LBL_SLA2_Sensor1);
            this.Controls.Add(this.LBL_SLA1_Sensor4);
            this.Controls.Add(this.LBL_SLA1_Sensor3);
            this.Controls.Add(this.LBL_SLA1_Sensor2);
            this.Controls.Add(this.LBL_SLA1_Sensor1);
            this.Controls.Add(this.TB_SLA2_Sensor4);
            this.Controls.Add(this.TB_SLA3_Sensor3);
            this.Controls.Add(this.TB_SLA2_Sensor2);
            this.Controls.Add(this.TB_SLA2_Sensor1);
            this.Controls.Add(this.TB_SLA1_Sensor4);
            this.Controls.Add(this.TB_SLA1_Sensor3);
            this.Controls.Add(this.TB_SLA1_Sensor2);
            this.Controls.Add(this.TB_SLA1_Sensor1);
            this.Controls.Add(this.TB_SLA2_Sampling);
            this.Controls.Add(this.TB_SA1_Sampling);
            this.Controls.Add(this.LBL_FormDescription_Sampling);
            this.Controls.Add(this.LBL_SLA2_Sampling);
            this.Controls.Add(this.LBL_SLA1_Sampling);
            this.Controls.Add(this.PB_UFSC_Icon);
            this.Controls.Add(this.PB_LMPT_Icon);
            this.Controls.Add(this.LBL_Title);
            this.Name = "DataSampling";
            this.Text = "DataSampling";
            ((System.ComponentModel.ISupportInitialize)(this.PB_UFSC_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LMPT_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_UFSC_Icon;
        private System.Windows.Forms.PictureBox PB_LMPT_Icon;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Label LBL_SLA1_Sampling;
        private System.Windows.Forms.Label LBL_SLA2_Sampling;
        private System.Windows.Forms.Label LBL_FormDescription_Sampling;
        private System.Windows.Forms.TextBox TB_SA1_Sampling;
        private System.Windows.Forms.TextBox TB_SLA2_Sampling;
        private System.Windows.Forms.TextBox TB_SLA1_Sensor1;
        private System.Windows.Forms.TextBox TB_SLA1_Sensor2;
        private System.Windows.Forms.TextBox TB_SLA1_Sensor3;
        private System.Windows.Forms.TextBox TB_SLA1_Sensor4;
        private System.Windows.Forms.TextBox TB_SLA2_Sensor4;
        private System.Windows.Forms.TextBox TB_SLA3_Sensor3;
        private System.Windows.Forms.TextBox TB_SLA2_Sensor2;
        private System.Windows.Forms.TextBox TB_SLA2_Sensor1;
        private System.Windows.Forms.Label LBL_SLA1_Sensor1;
        private System.Windows.Forms.Label LBL_SLA1_Sensor2;
        private System.Windows.Forms.Label LBL_SLA1_Sensor3;
        private System.Windows.Forms.Label LBL_SLA1_Sensor4;
        private System.Windows.Forms.Label LBL_SLA2_Sensor1;
        private System.Windows.Forms.Label LBL_SLA2_Sensor2;
        private System.Windows.Forms.Label LBL_SLA2_Sensor3;
        private System.Windows.Forms.Label LBL_SLA2_Sensor4;
        private System.Windows.Forms.Button BTN_Quit_Sampling;
    }
}