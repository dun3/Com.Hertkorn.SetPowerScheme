namespace Com.Hertkorn.SetPowerScheme
{
    partial class ShowAvailableSchemes
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.TextBox textBox2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowAvailableSchemes));
            System.Windows.Forms.PictureBox pictureBox1;
            System.Windows.Forms.Label label2;
            this.txtAvailablePowerSchemes = new System.Windows.Forms.TextBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showKnownPowerSchemesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCurrentlySetsTo = new System.Windows.Forms.TextBox();
            this.setPowerSchemeTimer = new System.Windows.Forms.Timer(this.components);
            label1 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.trayContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(12, 106);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(386, 24);
            label1.TabIndex = 1;
            label1.Text = "Known Power Schemes and their Guids:";
            // 
            // textBox2
            // 
            textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox2.Location = new System.Drawing.Point(70, 13);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(893, 80);
            textBox2.TabIndex = 2;
            textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // pictureBox1
            // 
            pictureBox1.Image = global::Com.Hertkorn.SetPowerScheme.Properties.Resources.power;
            pictureBox1.ImageLocation = "";
            pictureBox1.Location = new System.Drawing.Point(0, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(64, 64);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // txtAvailablePowerSchemes
            // 
            this.txtAvailablePowerSchemes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAvailablePowerSchemes.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvailablePowerSchemes.Location = new System.Drawing.Point(12, 134);
            this.txtAvailablePowerSchemes.Multiline = true;
            this.txtAvailablePowerSchemes.Name = "txtAvailablePowerSchemes";
            this.txtAvailablePowerSchemes.Size = new System.Drawing.Size(951, 355);
            this.txtAvailablePowerSchemes.TabIndex = 0;
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayContextMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Set Power Scheme";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // trayContextMenuStrip
            // 
            this.trayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showKnownPowerSchemesMenuItem,
            this.exitMenuItem});
            this.trayContextMenuStrip.Name = "trayContextMenuStrip";
            this.trayContextMenuStrip.Size = new System.Drawing.Size(189, 48);
            // 
            // showKnownPowerSchemesMenuItem
            // 
            this.showKnownPowerSchemesMenuItem.Name = "showKnownPowerSchemesMenuItem";
            this.showKnownPowerSchemesMenuItem.Size = new System.Drawing.Size(188, 22);
            this.showKnownPowerSchemesMenuItem.Text = "&Show power schemes";
            this.showKnownPowerSchemesMenuItem.Click += new System.EventHandler(this.showKnownPowerSchemesMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exitMenuItem.Text = "&Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 506);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(85, 13);
            label2.TabIndex = 4;
            label2.Text = "Currently sets to:";
            // 
            // txtCurrentlySetsTo
            // 
            this.txtCurrentlySetsTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentlySetsTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentlySetsTo.Location = new System.Drawing.Point(103, 506);
            this.txtCurrentlySetsTo.Name = "txtCurrentlySetsTo";
            this.txtCurrentlySetsTo.ReadOnly = true;
            this.txtCurrentlySetsTo.Size = new System.Drawing.Size(860, 13);
            this.txtCurrentlySetsTo.TabIndex = 5;
            this.txtCurrentlySetsTo.Text = "None set";
            // 
            // setPowerSchemeTimer
            // 
            this.setPowerSchemeTimer.Interval = 300000;
            // 
            // ShowAvailableSchemes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 531);
            this.Controls.Add(this.txtCurrentlySetsTo);
            this.Controls.Add(label2);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtAvailablePowerSchemes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(639, 307);
            this.Name = "ShowAvailableSchemes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Known Power Schemes";
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.trayContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAvailablePowerSchemes;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showKnownPowerSchemesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.TextBox txtCurrentlySetsTo;
        private System.Windows.Forms.Timer setPowerSchemeTimer;

    }
}

