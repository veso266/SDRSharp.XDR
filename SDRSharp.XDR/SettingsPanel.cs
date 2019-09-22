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
        // Comport
        public int comIndex;
        public int BaudIndex;
        public string[] myPort;
        public string[] myBaud;
        public ComboBox comPortsBox;
        public ComboBox BaudrateBox;

        // Plugin stuff
        private XDRPlugin _plugin;

        // Main Checkbox
        public CheckBox enableXdrCheckBox;
        public bool XdrEnabled;

        // Main Panel
        private TableLayoutPanel mainTableLayoutPanel;

        // Comport
        private Label label1;
        private Button AdvancedRDS;

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
        //We will open another windows when we click
        private void AdvancedRDS_Click(object sender, EventArgs e)
        {
            AdvancedRDSWindow.Instance.Show(); 
        }
    }
}
