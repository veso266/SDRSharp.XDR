using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

using SDRSharp.Radio;

namespace SDRSharp.XDR
{
	public partial class SettingsPanel : UserControl
	{
        //When SettingsPanel starts it will call this
        public void InitializeComponent()
		{
            this.enableXdrCheckBox = new System.Windows.Forms.CheckBox();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.comPortsBox = new System.Windows.Forms.ComboBox();
            this.BaudrateBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // enableXdrCheckBox
            // 
            this.enableXdrCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableXdrCheckBox.AutoSize = true;
            this.enableXdrCheckBox.Location = new System.Drawing.Point(3, 3);
            this.enableXdrCheckBox.Name = "enableXdrCheckBox";
            this.enableXdrCheckBox.Size = new System.Drawing.Size(85, 17);
            this.enableXdrCheckBox.TabIndex = 0;
            this.enableXdrCheckBox.Text = "Enable XDR";
            this.enableXdrCheckBox.UseVisualStyleBackColor = true;
            this.enableXdrCheckBox.CheckedChanged += new System.EventHandler(this.enableXdrCheckBox_CheckedChanged);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainTableLayoutPanel.Controls.Add(this.enableXdrCheckBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.comPortsBox, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.BaudrateBox, 1, 2);
            this.mainTableLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.label2, 1, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(204, 153);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // comPortsBox
            // 
            this.comPortsBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comPortsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortsBox.FormattingEnabled = true;
            this.comPortsBox.Location = new System.Drawing.Point(3, 39);
            this.comPortsBox.Name = "comPortsBox";
            this.comPortsBox.Size = new System.Drawing.Size(96, 21);
            this.comPortsBox.TabIndex = 2;
            this.comPortsBox.SelectedIndexChanged += new System.EventHandler(this.XdrComPortChanged_CheckedChanged);
            // 
            // BaudrateBox
            // 
            this.BaudrateBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BaudrateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudrateBox.FormattingEnabled = true;
            this.BaudrateBox.Location = new System.Drawing.Point(105, 39);
            this.BaudrateBox.Name = "BaudrateBox";
            this.BaudrateBox.Size = new System.Drawing.Size(96, 21);
            this.BaudrateBox.TabIndex = 3;
            this.BaudrateBox.SelectedIndexChanged += new System.EventHandler(this.BaudrateBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "COM Port";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baudrate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingsPanel
            // 
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(204, 153);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}
        // Comport
        public int comIndex;
        public int BaudIndex;
        public string[] myPort;
        public string[] myBaud;
        public ComboBox comPortsBox;
        public ComboBox BaudrateBox;

        // Plugin stuff
        private XDRPlugin _plugin;

        // SD# Exposes that interface
        private IContainer components;

        // Main Checkbox
        public CheckBox enableXdrCheckBox;
        public bool XdrEnabled;

        // Main Panel
        private TableLayoutPanel mainTableLayoutPanel;

        // Comport
        private Label label1;

        // Baudrate
        private Label label2;

        public SettingsPanel(XDRPlugin plugin)
        {
            this._plugin = plugin;
            this.comIndex = 0;
            this.BaudIndex = 0;
            this.XdrEnabled = false;
            this.InitializeComponent();
            this.XdrEnabled = Utils.GetBooleanSetting("enableXdr", false);
            this.enableXdrCheckBox.Enabled = true;
            this.comPortsBox.Enabled = this.XdrEnabled;
            this.BaudrateBox.Enabled = this.XdrEnabled;
            this.comPortsBox.Items.Add("None");
            this.BaudrateBox.Items.Add("None");
            this.myPort = SerialPort.GetPortNames();
            this.myBaud = new string[] { "300", "600", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600" }; //Baudrate is here
            ComboBox.ObjectCollection items = this.comPortsBox.Items;
            ComboBox.ObjectCollection Bitems = this.BaudrateBox.Items;
            object[] items2 = this.myPort;
            object[] Bitems2 = this.myBaud;
            items.AddRange(items2);
            Bitems.AddRange(Bitems2);
            this.comIndex = Utils.GetIntSetting("comIndex", 0);
            this.BaudIndex = Utils.GetIntSetting("BaudIndex", 6);
            if (this.comIndex > this.myPort.Length)
            {
                this.comIndex = 0;
            }
            if (this.BaudIndex > this.myBaud.Length)
            {
                this.BaudIndex = 6;
            }
        }

        // XDREnabled Button
        private void enableXdrCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.comPortsBox.Enabled = (this.XdrEnabled = this.enableXdrCheckBox.Checked);
            this.BaudrateBox.Enabled = (this.XdrEnabled = this.enableXdrCheckBox.Checked);
            this._plugin.PopulateComPort();
        }

        // Comport dropdown
        private void XdrComPortChanged_CheckedChanged(object sender, EventArgs e)
        {
            Utils.SaveSetting("comIndex", this.comPortsBox.SelectedIndex);
            this.comIndex = this.comPortsBox.SelectedIndex;
            this._plugin.PopulateComPort();
        }
        // Baudrate dropdown
        private void BaudrateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.SaveSetting("BaudIndex", this.BaudrateBox.SelectedIndex);
            this.BaudIndex = this.BaudrateBox.SelectedIndex;
            this._plugin.PopulateComPort();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
