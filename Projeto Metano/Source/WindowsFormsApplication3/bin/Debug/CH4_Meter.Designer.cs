namespace WindowsFormsApplication3
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lista_dados = new System.Windows.Forms.ListView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.metano_atual_texto = new System.Windows.Forms.TextBox();
            this.btn_stop_log = new System.Windows.Forms.Button();
            this.log_flag = new System.Windows.Forms.Label();
            this.btn_start_log = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_quit = new System.Windows.Forms.Button();
            this.label_error = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_blink = new System.Windows.Forms.Timer(this.components);
            this.watchdog_timer = new System.Windows.Forms.Timer(this.components);
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lista_dados);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(687, 434);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Data Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lista_dados
            // 
            this.lista_dados.Location = new System.Drawing.Point(6, 6);
            this.lista_dados.Name = "lista_dados";
            this.lista_dados.Size = new System.Drawing.Size(649, 369);
            this.lista_dados.TabIndex = 0;
            this.lista_dados.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.metano_atual_texto);
            this.tabPage1.Controls.Add(this.btn_stop_log);
            this.tabPage1.Controls.Add(this.log_flag);
            this.tabPage1.Controls.Add(this.btn_start_log);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Controls.Add(this.btn_quit);
            this.tabPage1.Controls.Add(this.label_error);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(687, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Methane (ppm) X Time Chart";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // metano_atual_texto
            // 
            this.metano_atual_texto.Location = new System.Drawing.Point(191, 87);
            this.metano_atual_texto.Margin = new System.Windows.Forms.Padding(2);
            this.metano_atual_texto.Name = "metano_atual_texto";
            this.metano_atual_texto.Size = new System.Drawing.Size(52, 20);
            this.metano_atual_texto.TabIndex = 39;
            // 
            // btn_stop_log
            // 
            this.btn_stop_log.Enabled = false;
            this.btn_stop_log.Location = new System.Drawing.Point(549, 83);
            this.btn_stop_log.Margin = new System.Windows.Forms.Padding(2);
            this.btn_stop_log.Name = "btn_stop_log";
            this.btn_stop_log.Size = new System.Drawing.Size(84, 24);
            this.btn_stop_log.TabIndex = 54;
            this.btn_stop_log.Text = "Stop Data Log";
            this.btn_stop_log.UseVisualStyleBackColor = true;
            this.btn_stop_log.Visible = false;
            this.btn_stop_log.Click += new System.EventHandler(this.btn_stop_log_Click);
            // 
            // log_flag
            // 
            this.log_flag.AutoSize = true;
            this.log_flag.ForeColor = System.Drawing.Color.Red;
            this.log_flag.Location = new System.Drawing.Point(573, 44);
            this.log_flag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.log_flag.Name = "log_flag";
            this.log_flag.Size = new System.Drawing.Size(49, 13);
            this.log_flag.TabIndex = 53;
            this.log_flag.Text = "Saving...";
            this.log_flag.Visible = false;
            // 
            // btn_start_log
            // 
            this.btn_start_log.Location = new System.Drawing.Point(549, 59);
            this.btn_start_log.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start_log.Name = "btn_start_log";
            this.btn_start_log.Size = new System.Drawing.Size(84, 24);
            this.btn_start_log.TabIndex = 49;
            this.btn_start_log.Text = "Start Data Log";
            this.btn_start_log.UseVisualStyleBackColor = true;
            this.btn_start_log.Visible = false;
            this.btn_start_log.Click += new System.EventHandler(this.btn_start_log_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(23, 111);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(568, 305);
            this.chart1.TabIndex = 47;
            this.chart1.Text = "chart1";
            // 
            // btn_quit
            // 
            this.btn_quit.Location = new System.Drawing.Point(549, 14);
            this.btn_quit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(84, 23);
            this.btn_quit.TabIndex = 8;
            this.btn_quit.Text = "Quit";
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.ForeColor = System.Drawing.Color.Red;
            this.label_error.Location = new System.Drawing.Point(20, 14);
            this.label_error.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(96, 13);
            this.label_error.TabIndex = 7;
            this.label_error.Text = "Server not working";
            this.label_error.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(695, 460);
            this.tabControl1.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timer_blink
            // 
            this.timer_blink.Interval = 250;
            this.timer_blink.Tick += new System.EventHandler(this.timer_blink_Tick_1);
            // 
            // watchdog_timer
            // 
            this.watchdog_timer.Interval = 250;
            this.watchdog_timer.Tick += new System.EventHandler(this.watchdog_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(695, 460);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lista_dados;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_stop_log;
        private System.Windows.Forms.Label log_flag;
        private System.Windows.Forms.Button btn_start_log;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TextBox metano_atual_texto;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer_blink;
        private System.Windows.Forms.Timer watchdog_timer;
    }
}

