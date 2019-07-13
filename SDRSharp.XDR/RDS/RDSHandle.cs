using System.Threading;
using SDRSharp.Radio;

namespace SDRSharp.XDR
{
    public class RDSHandle : IRdsBitStreamProcessor, IBaseProcessor
    {
        private bool _enabled = true;

        public bool Enabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                this._enabled = value;
            }
        }

        public void Process(ref RdsFrame _rdsFrame)
        {
            string text = string.Format("{0:X}", _rdsFrame.GroupA);
            if (text.Length == 4)
            {
                //SerialCommands.sdr_read_rds(ref _rdsFrame);
                //Debug.WriteLine(_rdsFrame.GroupA.ToString("X4"));
                //this._rdsDDekoder.printData(ref _rdsFrame);
            }

        }
    }
}
