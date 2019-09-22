using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

using SDRSharp.Common;
using SDRSharp.Radio;
using SDRSharp.PanView; //For Signal Meter, Spectrum, etc

namespace SDRSharp.XDR
{
	public partial class XDRPlugin : ISharpPlugin
	{
        //Plugin Display Name
        public string DisplayName
		{
			get
			{
				return "XDR-GTK Server";
			}
		}

		//Which class should it load for GUI
		public UserControl Gui
		{
			get
			{
				return this._controlPanel;
			}
		}

		// When the plugin starts it will call this
		public void Initialize(ISharpControl control)
		{
			XDRPlugin._sdr = control;
			XDRPlugin._continue = false;
			XDRPlugin._waiting = false;

			this._comThread = new Thread(new ThreadStart(SerialCommands.ComThreadEngine));
			this._controlPanel = new SettingsPanel(this);
			this._controlPanel.enableXdrCheckBox.Checked = this._controlPanel.XdrEnabled;
			this._controlPanel.comPortsBox.SelectedIndex = this._controlPanel.comIndex;
			this._controlPanel.BaudrateBox.SelectedIndex = this._controlPanel.BaudIndex;

            //For Signal meter
            this.spectrumAnalyzer = new SpectrumAnalyzer();
            this.spectrumAnalyzer.EnableSNR = true;

            //Hook into RDS stream
            XDRPlugin._sdr.RegisterStreamHook(new RDSHandle(), ProcessorType.RDSBitStream);
        }

		// When you close SDR# it calls this
		public void Close()
		{
			Utils.SaveSetting("enableXdr", this._controlPanel.XdrEnabled);
			Utils.SaveSetting("XdrComIndex", this._controlPanel.comIndex);
			Utils.SaveSetting("BaudIndex", this._controlPanel.BaudIndex);
			if (XDRPlugin._continue)
			{
				XDRPlugin._waiting = true;
				while (XDRPlugin._waiting)
				{
					Thread.Sleep(10);
				}
				XDRPlugin._serialPort.Close();
				XDRPlugin._serialPort = null;
				this._comThread.Join();
			}
		}

        //For signal meter
        private SpectrumAnalyzer spectrumAnalyzer;

        //For GUI
        private SettingsPanel _controlPanel;

        //For Communication
        private Thread _comThread;
        public static SerialPort _serialPort;
        public static bool _continue;
        public static bool _waiting;


        //Main controls are here (set frequency, start radio, stop radio, etx)
        public static ISharpControl _sdr;

        //for RDS
        public static ushort RDS_PI;
        public static string RDS_Group = null;
        public static bool RDSDetected = false;

        //For AdvancedRDSWindow
        public static bool ExternalRDS = false;
    }
}
