namespace LmptProtocol
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
            this.LabelTitle = new System.Windows.Forms.Label();
            this.UfscIcon = new System.Windows.Forms.PictureBox();
            this.LmptIcon = new System.Windows.Forms.PictureBox();
            this.LabelSlaveAddr1Sampling = new System.Windows.Forms.Label();
            this.LabelSlaveAddr2Sampling = new System.Windows.Forms.Label();
            this.LabelFormDescriptionSampling = new System.Windows.Forms.Label();
            this.TextBoxSlaveAddr1Sampling = new System.Windows.Forms.TextBox();
            this.TextBoxSlaveAddr2Sampling = new System.Windows.Forms.TextBox();
            this.TextBoxSlaveAddr1Sensor1 = new System.Windows.Forms.TextBox();
            this.TextBoxSlaveAddr1Sensor2 = new System.Windows.Forms.TextBox();
            this.TextBoxSlaveAddr1Sensor3 = new System.Windows.Forms.TextBox();
            this.TextBoxSlaveAddr1Sensor4 = new System.Windows.Forms.TextBox();
            this.LabelSlaveAddr2Sensor4 = new System.Windows.Forms.TextBox();
            this.LabelSlaveAddr2Sensor3 = new System.Windows.Forms.TextBox();
            this.LabelSlaveAddr2Sensor2 = new System.Windows.Forms.TextBox();
            this.LabelSlaveAddr2Sensor1 = new System.Windows.Forms.TextBox();
            this.LabelSlaveAddr1Sensor1 = new System.Windows.Forms.Label();
            this.LabelSlaveAddr1Sensor2 = new System.Windows.Forms.Label();
            this.LabelSlaveAddr1Sensor3 = new System.Windows.Forms.Label();
            this.LabelSlaveAddr1Sensor4 = new System.Windows.Forms.Label();
            this.TextBoxSlaveAddr2Sensor1 = new System.Windows.Forms.Label();
            this.TextBoxSlaveAddr2Sensor2 = new System.Windows.Forms.Label();
            this.TextBoxSlaveAddr2Sensor3 = new System.Windows.Forms.Label();
            this.TextBoxSlaveAddr2Sensor4 = new System.Windows.Forms.Label();
            this.BTN_Quit_Sampling = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UfscIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LmptIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTitle.Location = new System.Drawing.Point(218, 139);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(364, 24);
            this.LabelTitle.TabIndex = 12;
            this.LabelTitle.Text = "LMPT Radio Protocol Communication ";
            // 
            // UfscIcon
            // 
            this.UfscIcon.Image = global::LmptProtocol.Properties.Resources.ufsc_brasao;
            this.UfscIcon.Location = new System.Drawing.Point(389, 12);
            this.UfscIcon.Name = "UfscIcon";
            this.UfscIcon.Size = new System.Drawing.Size(180, 124);
            this.UfscIcon.TabIndex = 14;
            this.UfscIcon.TabStop = false;
            // 
            // LmptIcon
            // 
            this.LmptIcon.Image = global::LmptProtocol.Properties.Resources.lpmt_resized;
            this.LmptIcon.Location = new System.Drawing.Point(237, 12);
            this.LmptIcon.Name = "LmptIcon";
            this.LmptIcon.Size = new System.Drawing.Size(146, 124);
            this.LmptIcon.TabIndex = 13;
            this.LmptIcon.TabStop = false;
            // 
            // LabelSlaveAddr1Sampling
            // 
            this.LabelSlaveAddr1Sampling.AutoSize = true;
            this.LabelSlaveAddr1Sampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LabelSlaveAddr1Sampling.Location = new System.Drawing.Point(53, 249);
            this.LabelSlaveAddr1Sampling.Name = "LabelSlaveAddr1Sampling";
            this.LabelSlaveAddr1Sampling.Size = new System.Drawing.Size(115, 17);
            this.LabelSlaveAddr1Sampling.TabIndex = 15;
            this.LabelSlaveAddr1Sampling.Text = "Slave Address 1:";
            // 
            // LabelSlaveAddr2Sampling
            // 
            this.LabelSlaveAddr2Sampling.AutoSize = true;
            this.LabelSlaveAddr2Sampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LabelSlaveAddr2Sampling.Location = new System.Drawing.Point(397, 255);
            this.LabelSlaveAddr2Sampling.Name = "LabelSlaveAddr2Sampling";
            this.LabelSlaveAddr2Sampling.Size = new System.Drawing.Size(115, 17);
            this.LabelSlaveAddr2Sampling.TabIndex = 16;
            this.LabelSlaveAddr2Sampling.Text = "Slave Address 2:";
            // 
            // LabelFormDescriptionSampling
            // 
            this.LabelFormDescriptionSampling.AutoSize = true;
            this.LabelFormDescriptionSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFormDescriptionSampling.Location = new System.Drawing.Point(339, 163);
            this.LabelFormDescriptionSampling.Name = "LabelFormDescriptionSampling";
            this.LabelFormDescriptionSampling.Size = new System.Drawing.Size(131, 24);
            this.LabelFormDescriptionSampling.TabIndex = 17;
            this.LabelFormDescriptionSampling.Text = "Data Sampling";
            // 
            // TextBoxSlaveAddr1Sampling
            // 
            this.TextBoxSlaveAddr1Sampling.Location = new System.Drawing.Point(176, 249);
            this.TextBoxSlaveAddr1Sampling.Name = "TextBoxSlaveAddr1Sampling";
            this.TextBoxSlaveAddr1Sampling.ReadOnly = true;
            this.TextBoxSlaveAddr1Sampling.Size = new System.Drawing.Size(145, 20);
            this.TextBoxSlaveAddr1Sampling.TabIndex = 18;
            this.TextBoxSlaveAddr1Sampling.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxSlaveAddr2Sampling
            // 
            this.TextBoxSlaveAddr2Sampling.Location = new System.Drawing.Point(520, 252);
            this.TextBoxSlaveAddr2Sampling.Name = "TextBoxSlaveAddr2Sampling";
            this.TextBoxSlaveAddr2Sampling.ReadOnly = true;
            this.TextBoxSlaveAddr2Sampling.Size = new System.Drawing.Size(145, 20);
            this.TextBoxSlaveAddr2Sampling.TabIndex = 19;
            this.TextBoxSlaveAddr2Sampling.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxSlaveAddr1Sensor1
            // 
            this.TextBoxSlaveAddr1Sensor1.Location = new System.Drawing.Point(176, 297);
            this.TextBoxSlaveAddr1Sensor1.Name = "TextBoxSlaveAddr1Sensor1";
            this.TextBoxSlaveAddr1Sensor1.Size = new System.Drawing.Size(143, 20);
            this.TextBoxSlaveAddr1Sensor1.TabIndex = 20;
            // 
            // TextBoxSlaveAddr1Sensor2
            // 
            this.TextBoxSlaveAddr1Sensor2.Location = new System.Drawing.Point(176, 337);
            this.TextBoxSlaveAddr1Sensor2.Name = "TextBoxSlaveAddr1Sensor2";
            this.TextBoxSlaveAddr1Sensor2.Size = new System.Drawing.Size(143, 20);
            this.TextBoxSlaveAddr1Sensor2.TabIndex = 21;
            // 
            // TextBoxSlaveAddr1Sensor3
            // 
            this.TextBoxSlaveAddr1Sensor3.Location = new System.Drawing.Point(176, 374);
            this.TextBoxSlaveAddr1Sensor3.Name = "TextBoxSlaveAddr1Sensor3";
            this.TextBoxSlaveAddr1Sensor3.Size = new System.Drawing.Size(143, 20);
            this.TextBoxSlaveAddr1Sensor3.TabIndex = 22;
            // 
            // TextBoxSlaveAddr1Sensor4
            // 
            this.TextBoxSlaveAddr1Sensor4.Location = new System.Drawing.Point(176, 409);
            this.TextBoxSlaveAddr1Sensor4.Name = "TextBoxSlaveAddr1Sensor4";
            this.TextBoxSlaveAddr1Sensor4.Size = new System.Drawing.Size(143, 20);
            this.TextBoxSlaveAddr1Sensor4.TabIndex = 23;
            // 
            // LabelSlaveAddr2Sensor4
            // 
            this.LabelSlaveAddr2Sensor4.Location = new System.Drawing.Point(520, 409);
            this.LabelSlaveAddr2Sensor4.Name = "LabelSlaveAddr2Sensor4";
            this.LabelSlaveAddr2Sensor4.Size = new System.Drawing.Size(143, 20);
            this.LabelSlaveAddr2Sensor4.TabIndex = 27;
            // 
            // LabelSlaveAddr2Sensor3
            // 
            this.LabelSlaveAddr2Sensor3.Location = new System.Drawing.Point(520, 374);
            this.LabelSlaveAddr2Sensor3.Name = "LabelSlaveAddr2Sensor3";
            this.LabelSlaveAddr2Sensor3.Size = new System.Drawing.Size(143, 20);
            this.LabelSlaveAddr2Sensor3.TabIndex = 26;
            // 
            // LabelSlaveAddr2Sensor2
            // 
            this.LabelSlaveAddr2Sensor2.Location = new System.Drawing.Point(520, 337);
            this.LabelSlaveAddr2Sensor2.Name = "LabelSlaveAddr2Sensor2";
            this.LabelSlaveAddr2Sensor2.Size = new System.Drawing.Size(143, 20);
            this.LabelSlaveAddr2Sensor2.TabIndex = 25;
            // 
            // LabelSlaveAddr2Sensor1
            // 
            this.LabelSlaveAddr2Sensor1.Location = new System.Drawing.Point(520, 297);
            this.LabelSlaveAddr2Sensor1.Name = "LabelSlaveAddr2Sensor1";
            this.LabelSlaveAddr2Sensor1.Size = new System.Drawing.Size(143, 20);
            this.LabelSlaveAddr2Sensor1.TabIndex = 24;
            // 
            // LabelSlaveAddr1Sensor1
            // 
            this.LabelSlaveAddr1Sensor1.AutoSize = true;
            this.LabelSlaveAddr1Sensor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LabelSlaveAddr1Sensor1.Location = new System.Drawing.Point(53, 297);
            this.LabelSlaveAddr1Sensor1.Name = "LabelSlaveAddr1Sensor1";
            this.LabelSlaveAddr1Sensor1.Size = new System.Drawing.Size(113, 17);
            this.LabelSlaveAddr1Sensor1.TabIndex = 28;
            this.LabelSlaveAddr1Sensor1.Text = "Analog Reading:";
            // 
            // LabelSlaveAddr1Sensor2
            // 
            this.LabelSlaveAddr1Sensor2.AutoSize = true;
            this.LabelSlaveAddr1Sensor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LabelSlaveAddr1Sensor2.Location = new System.Drawing.Point(55, 337);
            this.LabelSlaveAddr1Sensor2.Name = "LabelSlaveAddr1Sensor2";
            this.LabelSlaveAddr1Sensor2.Size = new System.Drawing.Size(104, 17);
            this.LabelSlaveAddr1Sensor2.TabIndex = 29;
            this.LabelSlaveAddr1Sensor2.Text = "Analog Writing:";
            // 
            // LabelSlaveAddr1Sensor3
            // 
            this.LabelSlaveAddr1Sensor3.AutoSize = true;
            this.LabelSlaveAddr1Sensor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LabelSlaveAddr1Sensor3.Location = new System.Drawing.Point(53, 371);
            this.LabelSlaveAddr1Sensor3.Name = "LabelSlaveAddr1Sensor3";
            this.LabelSlaveAddr1Sensor3.Size = new System.Drawing.Size(108, 17);
            this.LabelSlaveAddr1Sensor3.TabIndex = 30;
            this.LabelSlaveAddr1Sensor3.Text = "Digital Reading:";
            // 
            // LabelSlaveAddr1Sensor4
            // 
            this.LabelSlaveAddr1Sensor4.AutoSize = true;
            this.LabelSlaveAddr1Sensor4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LabelSlaveAddr1Sensor4.Location = new System.Drawing.Point(55, 409);
            this.LabelSlaveAddr1Sensor4.Name = "LabelSlaveAddr1Sensor4";
            this.LabelSlaveAddr1Sensor4.Size = new System.Drawing.Size(99, 17);
            this.LabelSlaveAddr1Sensor4.TabIndex = 31;
            this.LabelSlaveAddr1Sensor4.Text = "Digital Writing:";
            // 
            // TextBoxSlaveAddr2Sensor1
            // 
            this.TextBoxSlaveAddr2Sensor1.AutoSize = true;
            this.TextBoxSlaveAddr2Sensor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.TextBoxSlaveAddr2Sensor1.Location = new System.Drawing.Point(397, 297);
            this.TextBoxSlaveAddr2Sensor1.Name = "TextBoxSlaveAddr2Sensor1";
            this.TextBoxSlaveAddr2Sensor1.Size = new System.Drawing.Size(108, 17);
            this.TextBoxSlaveAddr2Sensor1.TabIndex = 32;
            this.TextBoxSlaveAddr2Sensor1.Text = "ADS Channel 1:";
            // 
            // TextBoxSlaveAddr2Sensor2
            // 
            this.TextBoxSlaveAddr2Sensor2.AutoSize = true;
            this.TextBoxSlaveAddr2Sensor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.TextBoxSlaveAddr2Sensor2.Location = new System.Drawing.Point(397, 337);
            this.TextBoxSlaveAddr2Sensor2.Name = "TextBoxSlaveAddr2Sensor2";
            this.TextBoxSlaveAddr2Sensor2.Size = new System.Drawing.Size(108, 17);
            this.TextBoxSlaveAddr2Sensor2.TabIndex = 33;
            this.TextBoxSlaveAddr2Sensor2.Text = "ADS Channel 2:";
            // 
            // TextBoxSlaveAddr2Sensor3
            // 
            this.TextBoxSlaveAddr2Sensor3.AutoSize = true;
            this.TextBoxSlaveAddr2Sensor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.TextBoxSlaveAddr2Sensor3.Location = new System.Drawing.Point(399, 377);
            this.TextBoxSlaveAddr2Sensor3.Name = "TextBoxSlaveAddr2Sensor3";
            this.TextBoxSlaveAddr2Sensor3.Size = new System.Drawing.Size(108, 17);
            this.TextBoxSlaveAddr2Sensor3.TabIndex = 34;
            this.TextBoxSlaveAddr2Sensor3.Text = "ADS Channel 3:";
            // 
            // TextBoxSlaveAddr2Sensor4
            // 
            this.TextBoxSlaveAddr2Sensor4.AutoSize = true;
            this.TextBoxSlaveAddr2Sensor4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.TextBoxSlaveAddr2Sensor4.Location = new System.Drawing.Point(399, 412);
            this.TextBoxSlaveAddr2Sensor4.Name = "TextBoxSlaveAddr2Sensor4";
            this.TextBoxSlaveAddr2Sensor4.Size = new System.Drawing.Size(108, 17);
            this.TextBoxSlaveAddr2Sensor4.TabIndex = 35;
            this.TextBoxSlaveAddr2Sensor4.Text = "ADS Channel 4:";
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
            this.Controls.Add(this.TextBoxSlaveAddr2Sensor4);
            this.Controls.Add(this.TextBoxSlaveAddr2Sensor3);
            this.Controls.Add(this.TextBoxSlaveAddr2Sensor2);
            this.Controls.Add(this.TextBoxSlaveAddr2Sensor1);
            this.Controls.Add(this.LabelSlaveAddr1Sensor4);
            this.Controls.Add(this.LabelSlaveAddr1Sensor3);
            this.Controls.Add(this.LabelSlaveAddr1Sensor2);
            this.Controls.Add(this.LabelSlaveAddr1Sensor1);
            this.Controls.Add(this.LabelSlaveAddr2Sensor4);
            this.Controls.Add(this.LabelSlaveAddr2Sensor3);
            this.Controls.Add(this.LabelSlaveAddr2Sensor2);
            this.Controls.Add(this.LabelSlaveAddr2Sensor1);
            this.Controls.Add(this.TextBoxSlaveAddr1Sensor4);
            this.Controls.Add(this.TextBoxSlaveAddr1Sensor3);
            this.Controls.Add(this.TextBoxSlaveAddr1Sensor2);
            this.Controls.Add(this.TextBoxSlaveAddr1Sensor1);
            this.Controls.Add(this.TextBoxSlaveAddr2Sampling);
            this.Controls.Add(this.TextBoxSlaveAddr1Sampling);
            this.Controls.Add(this.LabelFormDescriptionSampling);
            this.Controls.Add(this.LabelSlaveAddr2Sampling);
            this.Controls.Add(this.LabelSlaveAddr1Sampling);
            this.Controls.Add(this.UfscIcon);
            this.Controls.Add(this.LmptIcon);
            this.Controls.Add(this.LabelTitle);
            this.Name = "DataSampling";
            this.Text = "DataSampling";
            ((System.ComponentModel.ISupportInitialize)(this.UfscIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LmptIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UfscIcon;
        private System.Windows.Forms.PictureBox LmptIcon;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelSlaveAddr1Sampling;
        private System.Windows.Forms.Label LabelSlaveAddr2Sampling;
        private System.Windows.Forms.Label LabelFormDescriptionSampling;
        private System.Windows.Forms.TextBox TextBoxSlaveAddr1Sampling;
        private System.Windows.Forms.TextBox TextBoxSlaveAddr2Sampling;
        private System.Windows.Forms.TextBox TextBoxSlaveAddr1Sensor1;
        private System.Windows.Forms.TextBox TextBoxSlaveAddr1Sensor2;
        private System.Windows.Forms.TextBox TextBoxSlaveAddr1Sensor3;
        private System.Windows.Forms.TextBox TextBoxSlaveAddr1Sensor4;
        private System.Windows.Forms.TextBox LabelSlaveAddr2Sensor4;
        private System.Windows.Forms.TextBox LabelSlaveAddr2Sensor3;
        private System.Windows.Forms.TextBox LabelSlaveAddr2Sensor2;
        private System.Windows.Forms.TextBox LabelSlaveAddr2Sensor1;
        private System.Windows.Forms.Label LabelSlaveAddr1Sensor1;
        private System.Windows.Forms.Label LabelSlaveAddr1Sensor2;
        private System.Windows.Forms.Label LabelSlaveAddr1Sensor3;
        private System.Windows.Forms.Label LabelSlaveAddr1Sensor4;
        private System.Windows.Forms.Label TextBoxSlaveAddr2Sensor1;
        private System.Windows.Forms.Label TextBoxSlaveAddr2Sensor2;
        private System.Windows.Forms.Label TextBoxSlaveAddr2Sensor3;
        private System.Windows.Forms.Label TextBoxSlaveAddr2Sensor4;
        private System.Windows.Forms.Button BTN_Quit_Sampling;
    }
}