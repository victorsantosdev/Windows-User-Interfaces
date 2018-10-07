namespace LmptProtocol
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
            this.LabelTitle = new System.Windows.Forms.Label();
            this.TextBoxSlaveAddr1Search = new System.Windows.Forms.TextBox();
            this.LabelComPort = new System.Windows.Forms.Label();
            this.ComboBoxComList = new System.Windows.Forms.ComboBox();
            this.ButtonComPortOpen = new System.Windows.Forms.Button();
            this.ButtonNextSampling = new System.Windows.Forms.Button();
            this.LabelSlaveAddr1Search = new System.Windows.Forms.Label();
            this.LabelSlaveAddr2Search = new System.Windows.Forms.Label();
            this.TextBoxSlaveAddr2Search = new System.Windows.Forms.TextBox();
            this.LabelHeader = new System.Windows.Forms.Label();
            this.UfscIcon = new System.Windows.Forms.PictureBox();
            this.LmptIcon = new System.Windows.Forms.PictureBox();
            this.ButtonComPortClose = new System.Windows.Forms.Button();
            this.ButtonQuitSearch = new System.Windows.Forms.Button();
            this.LabelSearching = new System.Windows.Forms.Label();
            this.LabelFormDescriptionSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UfscIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LmptIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTitle.Location = new System.Drawing.Point(196, 139);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(364, 24);
            this.LabelTitle.TabIndex = 0;
            this.LabelTitle.Text = "LMPT Radio Protocol Communication ";
            // 
            // TextBoxSlaveAddr1Search
            // 
            this.TextBoxSlaveAddr1Search.Location = new System.Drawing.Point(148, 434);
            this.TextBoxSlaveAddr1Search.Name = "TextBoxSlaveAddr1Search";
            this.TextBoxSlaveAddr1Search.ReadOnly = true;
            this.TextBoxSlaveAddr1Search.Size = new System.Drawing.Size(145, 20);
            this.TextBoxSlaveAddr1Search.TabIndex = 1;
            this.TextBoxSlaveAddr1Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LabelComPort
            // 
            this.LabelComPort.AutoSize = true;
            this.LabelComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LabelComPort.Location = new System.Drawing.Point(28, 217);
            this.LabelComPort.Name = "LabelComPort";
            this.LabelComPort.Size = new System.Drawing.Size(116, 17);
            this.LabelComPort.TabIndex = 2;
            this.LabelComPort.Text = "Select COM Port:";
            // 
            // ComboBoxComList
            // 
            this.ComboBoxComList.FormattingEnabled = true;
            this.ComboBoxComList.Location = new System.Drawing.Point(31, 237);
            this.ComboBoxComList.Name = "ComboBoxComList";
            this.ComboBoxComList.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxComList.TabIndex = 3;
            // 
            // ButtonComPortOpen
            // 
            this.ButtonComPortOpen.Location = new System.Drawing.Point(31, 264);
            this.ButtonComPortOpen.Name = "ButtonComPortOpen";
            this.ButtonComPortOpen.Size = new System.Drawing.Size(75, 23);
            this.ButtonComPortOpen.TabIndex = 4;
            this.ButtonComPortOpen.Text = "Open";
            this.ButtonComPortOpen.UseVisualStyleBackColor = true;
            this.ButtonComPortOpen.Click += new System.EventHandler(this.ButtonComPortOpenClick);
            // 
            // ButtonNextSampling
            // 
            this.ButtonNextSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNextSampling.Location = new System.Drawing.Point(241, 592);
            this.ButtonNextSampling.Name = "ButtonNextSampling";
            this.ButtonNextSampling.Size = new System.Drawing.Size(91, 40);
            this.ButtonNextSampling.TabIndex = 5;
            this.ButtonNextSampling.Text = "Next";
            this.ButtonNextSampling.UseVisualStyleBackColor = true;
            this.ButtonNextSampling.Click += new System.EventHandler(this.ButtonNextSamplingClick);
            // 
            // LabelSlaveAddr1Search
            // 
            this.LabelSlaveAddr1Search.AutoSize = true;
            this.LabelSlaveAddr1Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSlaveAddr1Search.Location = new System.Drawing.Point(28, 437);
            this.LabelSlaveAddr1Search.Name = "LabelSlaveAddr1Search";
            this.LabelSlaveAddr1Search.Size = new System.Drawing.Size(119, 17);
            this.LabelSlaveAddr1Search.TabIndex = 6;
            this.LabelSlaveAddr1Search.Text = "Slave_1 Address:";
            // 
            // LabelSlaveAddr2Search
            // 
            this.LabelSlaveAddr2Search.AutoSize = true;
            this.LabelSlaveAddr2Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSlaveAddr2Search.Location = new System.Drawing.Point(28, 471);
            this.LabelSlaveAddr2Search.Name = "LabelSlaveAddr2Search";
            this.LabelSlaveAddr2Search.Size = new System.Drawing.Size(119, 17);
            this.LabelSlaveAddr2Search.TabIndex = 7;
            this.LabelSlaveAddr2Search.Text = "Slave_2 Address:";
            // 
            // TextBoxSlaveAddr2Search
            // 
            this.TextBoxSlaveAddr2Search.Location = new System.Drawing.Point(148, 468);
            this.TextBoxSlaveAddr2Search.Name = "TextBoxSlaveAddr2Search";
            this.TextBoxSlaveAddr2Search.ReadOnly = true;
            this.TextBoxSlaveAddr2Search.Size = new System.Drawing.Size(145, 20);
            this.TextBoxSlaveAddr2Search.TabIndex = 8;
            this.TextBoxSlaveAddr2Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LabelHeader
            // 
            this.LabelHeader.AutoSize = true;
            this.LabelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelHeader.Location = new System.Drawing.Point(288, 329);
            this.LabelHeader.Name = "LabelHeader";
            this.LabelHeader.Size = new System.Drawing.Size(179, 24);
            this.LabelHeader.TabIndex = 9;
            this.LabelHeader.Text = "Registered Modules";
            // 
            // UfscIcon
            // 
            this.UfscIcon.Image = global::LmptProtocol.Properties.Resources.ufsc_brasao;
            this.UfscIcon.Location = new System.Drawing.Point(367, 12);
            this.UfscIcon.Name = "UfscIcon";
            this.UfscIcon.Size = new System.Drawing.Size(180, 124);
            this.UfscIcon.TabIndex = 11;
            this.UfscIcon.TabStop = false;
            // 
            // LmptIcon
            // 
            this.LmptIcon.Image = global::LmptProtocol.Properties.Resources.lpmt_resized;
            this.LmptIcon.Location = new System.Drawing.Point(215, 12);
            this.LmptIcon.Name = "LmptIcon";
            this.LmptIcon.Size = new System.Drawing.Size(146, 124);
            this.LmptIcon.TabIndex = 10;
            this.LmptIcon.TabStop = false;
            // 
            // ButtonComPortClose
            // 
            this.ButtonComPortClose.Location = new System.Drawing.Point(31, 293);
            this.ButtonComPortClose.Name = "ButtonComPortClose";
            this.ButtonComPortClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonComPortClose.TabIndex = 12;
            this.ButtonComPortClose.Text = "Close";
            this.ButtonComPortClose.UseVisualStyleBackColor = true;
            this.ButtonComPortClose.Click += new System.EventHandler(this.ButtonComPortCloseClick);
            // 
            // ButtonQuitSearch
            // 
            this.ButtonQuitSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.ButtonQuitSearch.Location = new System.Drawing.Point(594, 593);
            this.ButtonQuitSearch.Name = "ButtonQuitSearch";
            this.ButtonQuitSearch.Size = new System.Drawing.Size(82, 39);
            this.ButtonQuitSearch.TabIndex = 13;
            this.ButtonQuitSearch.Text = "Quit";
            this.ButtonQuitSearch.UseVisualStyleBackColor = true;
            this.ButtonQuitSearch.Click += new System.EventHandler(this.ButtonQuitSearchClick);
            // 
            // LabelSearching
            // 
            this.LabelSearching.AutoSize = true;
            this.LabelSearching.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.LabelSearching.Location = new System.Drawing.Point(257, 365);
            this.LabelSearching.Name = "LabelSearching";
            this.LabelSearching.Size = new System.Drawing.Size(238, 20);
            this.LabelSearching.TabIndex = 14;
            this.LabelSearching.Text = "Searching for online modules...";
            // 
            // LabelFormDescriptionSearch
            // 
            this.LabelFormDescriptionSearch.AutoSize = true;
            this.LabelFormDescriptionSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFormDescriptionSearch.Location = new System.Drawing.Point(288, 163);
            this.LabelFormDescriptionSearch.Name = "LabelFormDescriptionSearch";
            this.LabelFormDescriptionSearch.Size = new System.Drawing.Size(178, 24);
            this.LabelFormDescriptionSearch.TabIndex = 15;
            this.LabelFormDescriptionSearch.Text = "RF Modules Search";
            // 
            // ModulesSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(688, 644);
            this.Controls.Add(this.LabelFormDescriptionSearch);
            this.Controls.Add(this.LabelSearching);
            this.Controls.Add(this.ButtonQuitSearch);
            this.Controls.Add(this.ButtonComPortClose);
            this.Controls.Add(this.UfscIcon);
            this.Controls.Add(this.LmptIcon);
            this.Controls.Add(this.LabelHeader);
            this.Controls.Add(this.TextBoxSlaveAddr2Search);
            this.Controls.Add(this.LabelSlaveAddr2Search);
            this.Controls.Add(this.LabelSlaveAddr1Search);
            this.Controls.Add(this.ButtonNextSampling);
            this.Controls.Add(this.ButtonComPortOpen);
            this.Controls.Add(this.ComboBoxComList);
            this.Controls.Add(this.LabelComPort);
            this.Controls.Add(this.TextBoxSlaveAddr1Search);
            this.Controls.Add(this.LabelTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModulesSearch";
            this.Text = "LmptXbeeProtocol";
            ((System.ComponentModel.ISupportInitialize)(this.UfscIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LmptIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.TextBox TextBoxSlaveAddr1Search;
        private System.Windows.Forms.Label LabelComPort;
        private System.Windows.Forms.ComboBox ComboBoxComList;
        private System.Windows.Forms.Button ButtonComPortOpen;
        private System.Windows.Forms.Button ButtonNextSampling;
        private System.Windows.Forms.Label LabelSlaveAddr1Search;
        private System.Windows.Forms.Label LabelSlaveAddr2Search;
        private System.Windows.Forms.TextBox TextBoxSlaveAddr2Search;
        private System.Windows.Forms.Label LabelHeader;
        private System.Windows.Forms.PictureBox LmptIcon;
        private System.Windows.Forms.PictureBox UfscIcon;
        private System.Windows.Forms.Button ButtonComPortClose;
        private System.Windows.Forms.Button ButtonQuitSearch;
        private System.Windows.Forms.Label LabelSearching;
        private System.Windows.Forms.Label LabelFormDescriptionSearch;
    }
}

