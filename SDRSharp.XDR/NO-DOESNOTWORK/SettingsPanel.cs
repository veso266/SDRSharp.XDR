using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

using SDRSharp.Radio;
using SDRSharp.Common;

namespace SDRSharp.XDR
{
	public partial class SettingsPanel : UserControl
	{
        //When SettingsPanel starts it will call this
        public void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.enableXdrCheckBox = new System.Windows.Forms.CheckBox();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.comPortsBox = new System.Windows.Forms.ComboBox();
            this.BaudrateBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.acquireButton = new System.Windows.Forms.Button();
            this.rebuildButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.averageTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.enableCheckBox = new System.Windows.Forms.CheckBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.mainTableLayoutPanel.SuspendLayout();

            //integrationNumericUpDown
            this.integrationNumericUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.integrationNumericUpDown)).BeginInit();
            // 
            // enableXdrCheckBox
            // 
            this.enableXdrCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableXdrCheckBox.AutoSize = true;
            this.enableXdrCheckBox.Location = new System.Drawing.Point(3, 6);
            this.enableXdrCheckBox.Name = "enableXdrCheckBox";
            this.enableXdrCheckBox.Size = new System.Drawing.Size(85, 17);
            this.enableXdrCheckBox.TabIndex = 0;
            this.enableXdrCheckBox.Text = "Enable XDR";
            this.enableXdrCheckBox.UseVisualStyleBackColor = true;
            this.enableXdrCheckBox.CheckedChanged += new System.EventHandler(this.enableXdrCheckBox_CheckedChanged);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 3;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.90196F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.09804F));
            this.mainTableLayoutPanel.Controls.Add(this.enableXdrCheckBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.comPortsBox, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.BaudrateBox, 1, 2);
            this.mainTableLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.label2, 1, 1);
            this.mainTableLayoutPanel.Controls.Add(this.sourceComboBox, 1, 3);
            this.mainTableLayoutPanel.Controls.Add(this.label3, 0, 3);
            this.mainTableLayoutPanel.Controls.Add(this.label5, 0, 5);
            this.mainTableLayoutPanel.Controls.Add(this.referenceTextBox, 1, 4);
            this.mainTableLayoutPanel.Controls.Add(this.acquireButton, 2, 4);
            this.mainTableLayoutPanel.Controls.Add(this.integrationNumericUpDown, 1, 5);
            this.mainTableLayoutPanel.Controls.Add(this.rebuildButton, 2, 5);
            this.mainTableLayoutPanel.Controls.Add(this.resetButton, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.averageTextBox, 1, 6);
            this.mainTableLayoutPanel.Controls.Add(this.label4, 0, 4);
            this.mainTableLayoutPanel.Controls.Add(this.label6, 0, 6);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 4;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(206, 217);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // comPortsBox
            // 
            this.comPortsBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comPortsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortsBox.FormattingEnabled = true;
            this.comPortsBox.Location = new System.Drawing.Point(3, 50);
            this.comPortsBox.Name = "comPortsBox";
            this.comPortsBox.Size = new System.Drawing.Size(96, 21);
            this.comPortsBox.TabIndex = 2;
            this.comPortsBox.SelectedIndexChanged += new System.EventHandler(this.XdrComPortChanged_CheckedChanged);
            // 
            // BaudrateBox
            // 
            this.BaudrateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTableLayoutPanel.SetColumnSpan(this.BaudrateBox, 2);
            this.BaudrateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudrateBox.FormattingEnabled = true;
            this.BaudrateBox.Location = new System.Drawing.Point(105, 50);
            this.BaudrateBox.Name = "BaudrateBox";
            this.BaudrateBox.Size = new System.Drawing.Size(98, 21);
            this.BaudrateBox.TabIndex = 3;
            this.BaudrateBox.SelectedIndexChanged += new System.EventHandler(this.BaudrateBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
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
            this.label2.Location = new System.Drawing.Point(105, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baudrate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sourceComboBox
            // 
            this.sourceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTableLayoutPanel.SetColumnSpan(this.sourceComboBox, 2);
            this.sourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceComboBox.FormattingEnabled = true;
            this.sourceComboBox.Items.AddRange(new object[] {
            "Filtered IF",
            "Full IQ",
            "Demodulator"});
            this.sourceComboBox.Location = new System.Drawing.Point(105, 77);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(98, 21);
            this.sourceComboBox.TabIndex = 7;
            this.sourceComboBox.SelectedIndexChanged += this.sourceComboBox_SelectedIndexChanged;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Source";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Integration (sec)";
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.referenceTextBox.Location = new System.Drawing.Point(105, 107);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.ReadOnly = true;
            this.referenceTextBox.Size = new System.Drawing.Size(51, 20);
            this.referenceTextBox.TabIndex = 11;
            this.referenceTextBox.Text = "0.00 dB";
            this.referenceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // acquireButton
            // 
            this.acquireButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.acquireButton.Location = new System.Drawing.Point(162, 106);
            this.acquireButton.Name = "acquireButton";
            this.acquireButton.Size = new System.Drawing.Size(41, 22);
            this.acquireButton.TabIndex = 10;
            this.acquireButton.Text = "Acquire";
            this.acquireButton.UseVisualStyleBackColor = true;
            this.acquireButton.Click += this.acquireButton_Click;
            // 
            // integrationNumericUpDown
            // 
            this.integrationNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.integrationNumericUpDown.Location = new System.Drawing.Point(105, 138);
            NumericUpDown numericUpDown = this.integrationNumericUpDown;
            //numericUpDown.Maximum = 300;

            this.integrationNumericUpDown.Name = "integrationNumericUpDown";
            this.integrationNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.integrationNumericUpDown.TabIndex = 13;
            this.integrationNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //NumericUpDown numericUpDown = this.integrationNumericUpDown;
            //int[] array = new int[4];
            //array[0] = 300;
            //numericUpDown.Maximum = new decimal(array);
            

            //NumericUpDown numericUpDown2 = this.integrationNumericUpDown;
            //int[] array2 = new int[4];
            //array2[0] = 1;
            //numericUpDown2.Minimum = new decimal(array2);
            //NumericUpDown numericUpDown3 = this.integrationNumericUpDown;
            //int[] array3 = new int[4];
            //array3[0] = 30;
            //numericUpDown3.Value = new decimal(array3);
            //this.integrationNumericUpDown.ValueChanged += this.integrationNumericUpDown_ValueChanged;

            ((ISupportInitialize)this.integrationNumericUpDown).EndInit();

            // rebuildButton
            // 
            this.rebuildButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rebuildButton.Location = new System.Drawing.Point(162, 138);
            this.rebuildButton.Name = "rebuildButton";
            this.rebuildButton.Size = new System.Drawing.Size(41, 20);
            this.rebuildButton.TabIndex = 17;
            this.rebuildButton.Text = "Rebuild";
            this.rebuildButton.UseVisualStyleBackColor = true;
            this.rebuildButton.Click += this.rebuildButton_Click;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTableLayoutPanel.SetColumnSpan(this.resetButton, 2);
            this.resetButton.Location = new System.Drawing.Point(105, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(98, 22);
            this.resetButton.TabIndex = 16;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += this.resetButton_Click;
            // 
            // averageTextBox
            // 
            this.averageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.averageTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.averageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainTableLayoutPanel.SetColumnSpan(this.averageTextBox, 2);
            this.averageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.averageTextBox.Location = new System.Drawing.Point(105, 177);
            this.averageTextBox.Name = "averageTextBox";
            this.averageTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.averageTextBox.Size = new System.Drawing.Size(98, 25);
            this.averageTextBox.TabIndex = 14;
            this.averageTextBox.Text = "0.00 dB";
            this.averageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Reference";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Power:";
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableCheckBox.AutoSize = true;
            this.enableCheckBox.Location = new System.Drawing.Point(3, 5);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(65, 17);
            this.enableCheckBox.TabIndex = 0;
            this.enableCheckBox.Text = "Enabled";
            this.enableCheckBox.UseVisualStyleBackColor = true;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 500;
            this.refreshTimer.Tick += this.refreshTimer_Tick;
            // 
            // SettingsPanel
            // 
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(206, 217);
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

        // Plugin stuff
        private XDRPlugin _plugin;

        // SD# Exposes that interface
        private IContainer components;

        // Main Checkbox
        public CheckBox enableXdrCheckBox;
        public bool XdrEnabled;

        // Main Panel
        private TableLayoutPanel mainTableLayoutPanel;



        //Another UserControl squshed inhere
        private ISharpControl _control;
        private AmplitudeProcessor _processor;
        private float _reference;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox sourceComboBox;
        private Label label3;
        private Button acquireButton;
        private TextBox referenceTextBox;
        private Label label5;
        private Label label6;
        public NumericUpDown integrationNumericUpDown;
        private Timer refreshTimer;
        private Button resetButton;


        private Button rebuildButton;
        private Label label1;
        private Label label2;
        public ComboBox BaudrateBox;
        private TextBox averageTextBox;
        private Label label4;
        private CheckBox enableCheckBox;

        public SettingsPanel(XDRPlugin plugin, AmplitudeProcessor processor, ISharpControl control)
        {
            this._plugin = plugin;
            this._processor = processor;
            this._control = control;
            //this.sourceComboBox.SelectedIndex = 0;
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
            this.integrationNumericUpDown_ValueChanged(null, null);
        }

        // XDREnabled Button
        private void enableXdrCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.comPortsBox.Enabled = (this.XdrEnabled = this.enableXdrCheckBox.Checked);
            this.BaudrateBox.Enabled = (this.XdrEnabled = this.enableXdrCheckBox.Checked);
            this._plugin.PopulateComPort();

            this._processor.Enabled = this.enableCheckBox.Checked;
            this.refreshTimer.Enabled = this.enableCheckBox.Checked;
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

        //for custom Signal Meter

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            //TODO
            if (this._processor.Enabled && !this.averageTextBox.Focused)
            {
                if (this._processor.Average < -500f)
                {
                    this.averageTextBox.Text = "-";
                    return;
                }
                this.averageTextBox.Text = (this._processor.Average - this._reference).ToString("#0.00") + " dB";
            }
        }

        private void acquireButton_Click(object sender, EventArgs e)
        {
            this._reference = this._processor.Average;
            this.referenceTextBox.Text = this._processor.Average.ToString("#0.00") + " dB";
        }

        private void sourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._control.UnregisterStreamHook(this._processor);
            switch (this.sourceComboBox.SelectedIndex)
            {
                case 0:
                    this._control.RegisterStreamHook(this._processor, ProcessorType.DecimatedAndFilteredIQ);
                    break;
                case 1:
                    this._control.RegisterStreamHook(this._processor, ProcessorType.RawIQ);
                    break;
                case 2:
                    this._control.RegisterStreamHook(this._processor, ProcessorType.DemodulatorOutput);
                    break;
            }
            this.resetButton_Click(null, null);
        }

        private void integrationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this._processor.Integration = (double)this.integrationNumericUpDown.Value;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this._reference = 0f;
            this.referenceTextBox.Text = "0.00 dB";
            this._processor.Rebuild();
        }

        private void rebuildButton_Click(object sender, EventArgs e)
        {
            this._processor.Rebuild();
        }
    }
}
