using SDRSharp.Radio;
using System;
using System.Diagnostics;

namespace SDRSharp.XDR
{
    public partial class SerialCommands
    {
        static int PI_NONE        = -1;
        static int PI_UNLIKELY    =  0;
        static int PI_LIKELY      =  1;
        static int PI_VERY_LIKELY =  2;
        static int PI_CORRECT     =  3;

        static int RDS_SYNC_WAIT = 10;
        /* PI_BUFFER_SIZE must be a multiple of 8. */
        static int PI_BUFFER_SIZE = 64;
        static byte pi_buffer_fill = 0;
        static byte pi_pos = 0;
        static short pi_state = -1;
        static uint last_rds_reset = 0;

        static void serial_pi(ushort pi, int err)
        {
            SP.Write("P");
            serial_hex((byte)(pi >> 8));
            serial_hex((byte)(pi & 0xFF));
            err = PI_CORRECT - err;
            while (err-- != 0)
                SP.Write("?");
            SP.Write("\n");
        }
        public static void sdr_read_rds(ref RdsFrame _rdsFrame)
        {

            ushort[] pi_buffer = new ushort[PI_BUFFER_SIZE];
            byte[] pi_buffer_errorfree = new byte[PI_BUFFER_SIZE / 8];
            ushort pi_val;
            uint rds_timer = 0;
            byte[] rds_buffer = new byte[4];
            byte rds_status_buffer;
            //byte status = dsp_read_16(DSP_RDS_STATUS);
            //ushort buffer = dsp_read_16(DSP_RDS_DATA);
            byte current_pi_count = 0;
            byte current_pi_errorfree = 0;
            byte current_pi_state;
            Debug.WriteLine(_rdsFrame.Filter);

            //SP.Write("R");
            //serial_hex((byte)_rdsFrame.GroupA);
            //serial_hex((byte)_rdsFrame.GroupB);
            //serial_hex((byte)_rdsFrame.GroupC);
            //serial_hex((byte)_rdsFrame.GroupD);
            //SP.Write("\n");

            //Debug.WriteLine(_rdsFrame.GroupA.ToString("X4"));
        }
    }
}
