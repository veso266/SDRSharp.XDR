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
            byte status = AnalyseRDS(_rdsFrame.GroupB);
            //ushort buffer = dsp_read_16(DSP_RDS_DATA);
            byte current_pi_count = 0;
            byte current_pi_errorfree = 0;
            byte current_pi_state;

            //SP.Write((status & 0xF800).ToString("X4"));
            //SP.Write("\r\n");

        }

        public static byte AnalyseRDS(ushort groupB)
        {
            //SP.Write((groupB & 0xf800).ToString("X4"));
            //SP.Write(((groupType)(groupB >> 11)).ToString()); //Group B contains Group Type info
            //SP.Write(((byte)(groupB >> 11)).ToString("X4")); //Group B contains Group Type info
            SP.Write((groupB & 0xF800).ToString("X4"));
            SP.Write("\r\n");
            return (byte)(groupB >> 11);
        }
        private enum groupType : byte
        {
            RDS_TYPE_0A = 0x0000,
            RDS_TYPE_0B = 0x0001,
            RDS_TYPE_1A = 0x0002,
            RDS_TYPE_1B = 0x0003,
            RDS_TYPE_2A = 0x0004,
            RDS_TYPE_2B = 0x0005,
            RDS_TYPE_3A = 0x0006,
            RDS_TYPE_3B = 0x0007,
            RDS_TYPE_4A = 0x0008,
            RDS_TYPE_4B = 0x0009,
            RDS_TYPE_5A = 0x000A,
            RDS_TYPE_5B = 0x000B,
            RDS_TYPE_6A = 0x000C,
            RDS_TYPE_6B = 0x000D,
            RDS_TYPE_7A = 0x000E,
            RDS_TYPE_7B = 0x000F,
            RDS_TYPE_8A = 0x0010,
            RDS_TYPE_8B = 0x0011,
            RDS_TYPE_9A = 0x0012,
            RDS_TYPE_9B = 0x0013,
            RDS_TYPE_10A = 0x0014,
            RDS_TYPE_10B = 0x0015,
            RDS_TYPE_11A = 0x0016,
            RDS_TYPE_11B = 0x0017,
            RDS_TYPE_12A = 0x0018,
            RDS_TYPE_12B = 0x0019,
            RDS_TYPE_13A = 0x001A,
            RDS_TYPE_13B = 0x001B,
            RDS_TYPE_14A = 0x001C,
            RDS_TYPE_14B = 0x001D,
            RDS_TYPE_15A = 0x001E,
            RDS_TYPE_15B = 0x001F
        }
    }
}
