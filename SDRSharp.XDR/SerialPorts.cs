using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.IO.Ports;
using System.Windows.Forms;
using SDRSharp.Common;

namespace SDRSharp.XDR
{
    public partial class XDRPlugin
    {
        public void PopulateComPort()
        {
            if (XDRPlugin._continue)
            {
                XDRPlugin._waiting = true;
                while (XDRPlugin._waiting)
                {
                    Thread.Sleep(10);
                }
                _serialPort.Close();
                _serialPort = null;
                this._comThread.Join();
                this._comThread = new Thread(new ThreadStart(SerialCommands.ComThreadEngine));
            }
            if (!this._controlPanel.XdrEnabled || this._controlPanel.comIndex == 0 || this._controlPanel.BaudIndex == 0)
            {
                return;
            }
            _serialPort = new SerialPort();
            if (!_serialPort.IsOpen)
            {
                _serialPort.PortName = this._controlPanel.myPort[this._controlPanel.comIndex - 1];
                _serialPort.BaudRate = Int32.Parse(this._controlPanel.myBaud[this._controlPanel.BaudIndex - 1]);
                _serialPort.DataBits = 8;
                _serialPort.StopBits = StopBits.One;
                _serialPort.Parity = Parity.None;
                _serialPort.Handshake = Handshake.None;
                _serialPort.ReadTimeout = 25;
                //_serialPort.WriteTimeout = 25;
                
                try
                {
                    _serialPort.Open();
                    if (_serialPort.IsOpen)
                    {
                        XDRPlugin._continue = true;
                        this._comThread.Start();
                    }
                }
                catch (Exception ex)
                {
                    Exception e2 = ex;
                    Exception e = e2;
                    new Thread(delegate ()
                    {
                        MessageBox.Show(e.Message);
                    }).Start();
                    this._controlPanel.comIndex = (this._controlPanel.comPortsBox.SelectedIndex = 0);
                }
            }
        }
    }
}
