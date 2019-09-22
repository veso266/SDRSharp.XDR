namespace SDRSharp.XDR
{
    partial class AdvancedRDSWindow
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
                toolTip1.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedRDSWindow));
            this.ipLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rdsspy = new System.Windows.Forms.RadioButton();
            this.internalrds = new System.Windows.Forms.RadioButton();
            this.UDPListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(12, 43);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(23, 13);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "IP: ";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(147, 43);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(32, 13);
            this.PortLabel.TabIndex = 1;
            this.PortLabel.Text = "Port: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(41, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "localhost";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(180, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "8888";
            // 
            // rdsspy
            // 
            this.rdsspy.AutoSize = true;
            this.rdsspy.Location = new System.Drawing.Point(12, 12);
            this.rdsspy.Name = "rdsspy";
            this.rdsspy.Size = new System.Drawing.Size(133, 17);
            this.rdsspy.TabIndex = 3;
            this.rdsspy.TabStop = true;
            this.rdsspy.Text = "External RDS Decoder";
            this.rdsspy.UseVisualStyleBackColor = true;
            this.rdsspy.CheckedChanged += new System.EventHandler(this.rdsspy_CheckedChanged);
            // 
            // internalrds
            // 
            this.internalrds.AutoSize = true;
            this.internalrds.Location = new System.Drawing.Point(150, 12);
            this.internalrds.Name = "internalrds";
            this.internalrds.Size = new System.Drawing.Size(130, 17);
            this.internalrds.TabIndex = 4;
            this.internalrds.TabStop = true;
            this.internalrds.Text = "Internal RDS Decoder";
            this.internalrds.UseVisualStyleBackColor = true;
            this.internalrds.CheckedChanged += new System.EventHandler(this.internalrds_CheckedChanged);
            // 
            // UDPListen
            // 
            this.UDPListen.Location = new System.Drawing.Point(12, 66);
            this.UDPListen.Name = "UDPListen";
            this.UDPListen.Size = new System.Drawing.Size(268, 23);
            this.UDPListen.TabIndex = 5;
            this.UDPListen.Text = "Listen für RDS ";
            this.UDPListen.UseVisualStyleBackColor = true;
            this.UDPListen.Click += new System.EventHandler(this.UDPListen_Click);
            // 
            // AdvancedRDSWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 200);
            this.Controls.Add(this.UDPListen);
            this.Controls.Add(this.internalrds);
            this.Controls.Add(this.rdsspy);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.ipLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdvancedRDSWindow";
            this.Text = "AdvancedRDSWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton rdsspy;
        private System.Windows.Forms.RadioButton internalrds;
        private System.Windows.Forms.Button UDPListen;
    }
}