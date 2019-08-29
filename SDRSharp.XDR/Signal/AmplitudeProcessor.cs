using System;
using SDRSharp.Radio;

namespace SDRSharp.XDR
{
    public class AmplitudeProcessor : IIQProcessor, IStreamProcessor, IBaseProcessor, IRealProcessor
    {
        public double SampleRate
        {
            get
            {
                return this._sampleRate;
            }
            set
            {
                this._sampleRate = value;
                this._rebuildNeeded = true;
            }
        }
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
        public double Integration
        {
            get
            {
                return this._integration;
            }
            set
            {
                this._integration = value;
            }
        }
        public float Average
        {
            get
            {
                return (float)(10.0 * Math.Log10(1E-60 + (double)this._avg));
            }
        }
        public void Rebuild()
        {
            this._rebuildNeeded = true;
        }
        public unsafe void Process(float* buffer, int length)
        {
            if (this._rebuildNeeded)
            {
                this._avg = 0f;
                this._buildSamples = (int)(this._sampleRate * 10.0);
                this._rebuildNeeded = false;
            }
            double num;
            if (this._buildSamples > 0)
            {
                num = 2.0;
                this._buildSamples -= length;
            }
            else
            {
                num = this._integration;
            }
            float num2 = (float)(1.0 - Math.Exp(-1.0 / (this._sampleRate * num)));
            for (int i = 0; i < length; i++)
            {
                float num3 = buffer[i] * buffer[i];
                this._avg += num2 * (num3 - this._avg);
            }
        }
        public unsafe void Process(Complex* buffer, int length)
        {
            if (this._rebuildNeeded)
            {
                this._avg = 0f;
                this._buildSamples = (int)(this._sampleRate * 10.0);
                this._rebuildNeeded = false;
            }
            double num;
            if (this._buildSamples > 0)
            {
                num = 2.0;
                this._buildSamples -= length;
            }
            else
            {
                num = this._integration;
            }
            float num2 = (float)(1.0 - Math.Exp(-1.0 / (this._sampleRate * num)));
            for (int i = 0; i < length; i++)
            {
                float num3 = buffer[i].ModulusSquared();
                this._avg += num2 * (num3 - this._avg);
            }
        }

        private const float BuildIntegration = 2f;
        private const float BuildDuration = 10f;
        private double _sampleRate;
        private double _integration;
        private bool _enabled;
        private bool _rebuildNeeded;
        private float _avg;
        private int _buildSamples;
    }
}
