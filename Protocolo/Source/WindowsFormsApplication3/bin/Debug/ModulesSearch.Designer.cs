namespace LMPT_Protocolo
{
    partial class ModulesSearch
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
            this.TB_SA1_Search = new System.Windows.Forms.TextBox();
            this.LBL_COM = new System.Windows.Forms.Label();
            this.CB_COM_List = new System.Windows.Forms.ComboBox();
            this.BTN_COM_Open = new System.Windows.Forms.Button();
            this.BTN_Search2Sampling = new System.Windows.Forms.Button();
            this.LBL_SA1_Search = new System.Windows.Forms.Label();
            this.LBL_SA2_Search = new System.Windows.Forms.Label();
            this.TB_SA2_Search = new System.Windows.Forms.TextBox();
            this.LBL_Header = new System.Windows.Forms.Label();
            this.PB_UFSC_Icon = new System.Windows.Forms.PictureBox();
            this.PB_LMPT_Icon = new System.Windows.Forms.PictureBox();
            this.BTN_COM_Close = new System.Windows.Forms.Button();
            this.BTN_Quit_Search = new System.Windows.Forms.Button();
            this.LBL_Searching = new System.Windows.Forms.Label();
            this.LBL_FormDescription_Search = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_UFSC_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LMPT_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Title.Location = new System.Drawing.Point(196, 139);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(364, 24);
            this.LBL_Title.TabIndex = 0;
            this.LBL_Title.Text = "LMPT Radio Protocol Communication ";
            // 
            // TB_SA1_Search
            // 
            this.TB_SA1_Search.Location = new System.Drawing.Point(148, 434);
            this.TB_SA1_Search.Name = "TB_SA1_Search";
            this.TB_SA1_Search.ReadOnly = true;
            this.TB_SA1_Search.Size = new System.Drawing.Size(145, 20);
            this.TB_SA1_Search.TabIndex = 1;
            this.TB_SA1_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LBL_COM
            // 
            this.LBL_COM.AutoSize = true;
            this.LBL_COM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LBL_COM.Location = new System.Drawing.Point(28, 217);
            this.LBL_COM.Name = "LBL_COM";
            this.LBL_COM.Size = new System.Drawing.Size(116, 17);
            this.LBL_COM.TabIndex = 2;
            this.LBL_COM.Text = "Select COM Port:";
            // 
            // CB_COM_List
            // 
            this.CB_COM_List.FormattingEnabled = true;
            this.CB_COM_List.Location = new System.Drawing.Point(31, 237);
            this.CB_COM_List.Name = "CB_COM_List";
            this.CB_COM_List.Size = new System.Drawing.Size(121, 21);
            this.CB_COM_List.TabIndex = 3;
            // 
            // BTN_COM_Open
            // 
            this.BTN_COM_Open.Location = new System.Drawing.Point(31, 264);
            this.BTN_COM_Open.Name = "BTN_COM_Open";
            this.BTN_COM_Open.Size = new System.Drawing.Size(75, 23);
            this.BTN_COM_Open.TabIndex = 4;
            this.BTN_COM_Open.Text = "Open";
            this.BTN_COM_Open.UseVisualStyleBackColor = true;
            this.BTN_COM_Open.Click += new System.EventHandler(this.BTN_COM_Open_Click);
            // 
            // BTN_Search2Sampling
            // 
            this.BTN_Search2Sampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Search2Sampling.Location = new System.Drawing.Point(241, 592);
            this.BTN_Search2Sampling.Name = "BTN_Search2Sampling";
            this.BTN_Search2Sampling.Size = new System.Drawing.Size(91, 40);
            this.BTN_Search2Sampling.TabIndex = 5;
            this.BTN_Search2Sampling.Text = "Next";
            this.BTN_Search2Sampling.UseVisualStyleBackColor = true;
            this.BTN_Search2Sampling.Click += new System.EventHandler(this.BTN_Search2Sampling_Click);
            // 
            // LBL_SA1_Search
            // 
            this.LBL_SA1_Search.AutoSize = true;
            this.LBL_SA1_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_SA1_Search.Location = new System.Drawing.Point(28, 437);
            this.LBL_SA1_Search.Name = "LBL_SA1_Search";
            this.LBL_SA1_Search.Size = new System.Drawing.Size(119, 17);
            this.LBL_SA1_Search.TabIndex = 6;
            this.LBL_SA1_Search.Text = "Slave_1 Address:";
            // 
            // LBL_SA2_Search
            // 
            this.LBL_SA2_Search.AutoSize = true;
            this.LBL_SA2_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_SA2_Search.Location = new System.Drawing.Point(28, 471);
            this.LBL_SA2_Search.Name = "LBL_SA2_Search";
            this.LBL_SA2_Search.Size = new System.Drawing.Size(119, 17);
            this.LBL_SA2_Search.TabIndex = 7;
            this.LBL_SA2_Search.Text = "Slave_2 Address:";
            // 
            // TB_SA2_Search
            // 
            this.TB_SA2_Search.Location = new System.Drawing.Point(148, 468);
            this.TB_SA2_Search.Name = "TB_SA2_Search";
            this.TB_SA2_Search.ReadOnly = true;
            this.TB_SA2_Search.Size = new System.Drawing.Size(145, 20);
            this.TB_SA2_Search.TabIndex = 8;
            this.TB_SA2_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LBL_Header
            // 
            this.LBL_Header.AutoSize = true;
            this.LBL_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Header.Location = new System.Drawing.Point(288, 329);
            this.LBL_Header.Name = "LBL_Header";
            this.LBL_Header.Size = new System.Drawing.Size(179, 24);
            this.LBL_Header.TabIndex = 9;
            this.LBL_Header.Text = "Registered Modules";
            // 
            // PB_UFSC_Icon
            // 
            this.PB_UFSC_Icon.Image = global::LMPT_Protocolo.Properties.Resources.ufsc_brasao;
            this.PB_UFSC_Icon.Location = new System.Drawing.Point(367, 12);
            this.PB_UFSC_Icon.Name = "PB_UFSC_Icon";
            this.PB_UFSC_Icon.Size = new System.Drawing.Size(180, 124);
            this.PB_UFSC_Icon.TabIndex = 11;
            this.PB_UFSC_Icon.TabStop = false;
            // 
            // PB_LMPT_Icon
            // 
            this.PB_LMPT_Icon.Image = global::LMPT_Protocolo.Properties.Resources.lpmt_resized;
            this.PB_LMPT_Icon.Location = new System.Drawing.Point(215, 12);
            this.PB_LMPT_Icon.Name = "PB_LMPT_Icon";
            this.PB_LMPT_Icon.Size = new System.Drawing.Size(146, 124);
            this.PB_LMPT_Icon.TabIndex = 10;
            this.PB_LMPT_Icon.TabStop = false;
            // 
            // BTN_COM_Close
            // 
            this.BTN_COM_Close.Location = new System.Drawing.Point(31, 293);
            this.BTN_COM_Close.Name = "BTN_COM_Close";
            this.BTN_COM_Close.Size = new System.Drawing.Size(75, 23);
            this.BTN_COM_Close.TabIndex = 12;
            this.BTN_COM_Close.Text = "Close";
            this.BTN_COM_Close.UseVisualStyleBackColor = true;
            this.BTN_COM_Close.Click += new System.EventHandler(this.BTN_COM_Close_Click);
            // 
            // BTN_Quit_Search
            // 
            this.BTN_Quit_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.BTN_Quit_Search.Location = new System.Drawing.Point(594, 593);
            this.BTN_Quit_Search.Name = "BTN_Quit_Search";
            this.BTN_Quit_Search.Size = new System.Drawing.Size(82, 39);
            this.BTN_Quit_Search.TabIndex = 13;
            this.BTN_Quit_Search.Text = "Quit";
            this.BTN_Quit_Search.UseVisualStyleBackColor = true;
            this.BTN_Quit_Search.Click += new System.EventHandler(this.BTN_Quit_Search_Click);
            // 
            // LBL_Searching
            // 
            this.LBL_Searching.AutoSize = true;
            this.LBL_Searching.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.LBL_Searching.Location = new System.Drawing.Point(257, 365);
            this.LBL_Searching.Name = "LBL_Searching";
            this.LBL_Searching.Size = new System.Drawing.Size(238, 20);
            this.LBL_Searching.TabIndex = 14;
            this.LBL_Searching.Text = "Searching for online modules...";
            // 
            // LBL_FormDescription_Search
            // 
            this.LBL_FormDescription_Search.AutoSize = true;
            this.LBL_FormDescription_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_FormDescription_Search.Location = new System.Drawing.Point(288, 163);
            this.LBL_FormDescription_Search.Name = "LBL_FormDescription_Search";
            this.LBL_FormDescription_Search.Size = new System.Drawing.Size(178, 24);
            this.LBL_FormDescription_Search.TabIndex = 15;
            this.LBL_FormDescription_Search.Text = "RF Modules Search";
            // 
            // ModulesSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(688, 644);
            this.Controls.Add(this.LBL_FormDescription_Search);
            this.Controls.Add(this.LBL_Searching);
            this.Controls.Add(this.BTN_Quit_Search);
            this.Controls.Add(this.BTN_COM_Close);
            this.Controls.Add(this.PB_UFSC_Icon);
            this.Controls.Add(this.PB_LMPT_Icon);
            this.Controls.Add(this.LBL_Header);
            this.Controls.Add(this.TB_SA2_Search);
            this.Controls.Add(this.LBL_SA2_Search);
            this.Controls.Add(this.LBL_SA1_Search);
            this.Controls.Add(this.BTN_Search2Sampling);
            this.Controls.Add(this.BTN_COM_Open);
            this.Controls.Add(this.CB_COM_List);
            this.Controls.Add(this.LBL_COM);
            this.Controls.Add(this.TB_SA1_Search);
            this.Controls.Add(this.LBL_Title);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModulesSearch";
            this.Text = "LMPT LMPT_Protocolo";
            ((System.ComponentModel.ISupportInitialize)(this.PB_UFSC_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LMPT_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ser_lbl;
        private System.Windows.Forms.Label serError_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.TextBox TB_SA1_Search;
        private System.Windows.Forms.Label LBL_COM;
        private System.Windows.Forms.ComboBox CB_COM_List;
        private System.Windows.Forms.Button BTN_COM_Open;
        private System.Windows.Forms.Button BTN_Search2Sampling;
        private System.Windows.Forms.Label LBL_SA1_Search;
        private System.Windows.Forms.Label LBL_SA2_Search;
        private System.Windows.Forms.TextBox TB_SA2_Search;
        private System.Windows.Forms.Label LBL_Header;
        private System.Windows.Forms.PictureBox PB_LMPT_Icon;
        private System.Windows.Forms.PictureBox PB_UFSC_Icon;
        private System.Windows.Forms.Button BTN_COM_Close;
        private System.Windows.Forms.Button BTN_Quit_Search;
        private System.Windows.Forms.Label LBL_Searching;
        private System.Windows.Forms.Label LBL_FormDescription_Search;
    }
}

