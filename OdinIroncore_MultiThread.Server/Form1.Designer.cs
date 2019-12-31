namespace YazLabP2_Server
{
    partial class MainForm
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
            this.pBMainServer = new System.Windows.Forms.ProgressBar();
            this.lblMainserverPrc = new System.Windows.Forms.Label();
            this.lblMainThread = new System.Windows.Forms.Label();
            this.lblMTAlinanIstekSayisi = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanelSubServers = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBMainServer
            // 
            this.pBMainServer.Location = new System.Drawing.Point(78, 7);
            this.pBMainServer.Maximum = 10050;
            this.pBMainServer.Name = "pBMainServer";
            this.pBMainServer.Size = new System.Drawing.Size(170, 23);
            this.pBMainServer.TabIndex = 2;
            // 
            // lblMainserverPrc
            // 
            this.lblMainserverPrc.AutoSize = true;
            this.lblMainserverPrc.Location = new System.Drawing.Point(254, 11);
            this.lblMainserverPrc.Name = "lblMainserverPrc";
            this.lblMainserverPrc.Size = new System.Drawing.Size(13, 13);
            this.lblMainserverPrc.TabIndex = 3;
            this.lblMainserverPrc.Text = "0";
            // 
            // lblMainThread
            // 
            this.lblMainThread.AutoSize = true;
            this.lblMainThread.Location = new System.Drawing.Point(5, 12);
            this.lblMainThread.Name = "lblMainThread";
            this.lblMainThread.Size = new System.Drawing.Size(64, 13);
            this.lblMainThread.TabIndex = 5;
            this.lblMainThread.Text = "Main Server";
            // 
            // lblMTAlinanIstekSayisi
            // 
            this.lblMTAlinanIstekSayisi.AutoSize = true;
            this.lblMTAlinanIstekSayisi.Location = new System.Drawing.Point(384, 26);
            this.lblMTAlinanIstekSayisi.Name = "lblMTAlinanIstekSayisi";
            this.lblMTAlinanIstekSayisi.Size = new System.Drawing.Size(35, 13);
            this.lblMTAlinanIstekSayisi.TabIndex = 6;
            this.lblMTAlinanIstekSayisi.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pBMainServer);
            this.panel2.Controls.Add(this.lblMainserverPrc);
            this.panel2.Controls.Add(this.lblMainThread);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 40);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(349, 40);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.progressBar1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(78, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(266, 31);
            this.panel4.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 3);
            this.progressBar1.Maximum = 10050;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(170, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sub Server";
            // 
            // flowLayoutPanelSubServers
            // 
            this.flowLayoutPanelSubServers.AutoScroll = true;
            this.flowLayoutPanelSubServers.Location = new System.Drawing.Point(12, 80);
            this.flowLayoutPanelSubServers.Name = "flowLayoutPanelSubServers";
            this.flowLayoutPanelSubServers.Size = new System.Drawing.Size(420, 335);
            this.flowLayoutPanelSubServers.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanelSubServers);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblMTAlinanIstekSayisi);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pBMainServer;
        private System.Windows.Forms.Label lblMainserverPrc;
        private System.Windows.Forms.Label lblMainThread;
        private System.Windows.Forms.Label lblMTAlinanIstekSayisi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSubServers;
    }
}

