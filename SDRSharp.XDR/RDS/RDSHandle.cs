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
            if (text.Length == 4 && (!XDRPlugin.ExternalRDS))
            {
                XDRPlugin.RDS_Group = _rdsFrame.GroupB.ToString("X4") + _rdsFrame.GroupC.ToString("X4") + _rdsFrame.GroupD.ToString("X4");
            }
        }
    }
}
