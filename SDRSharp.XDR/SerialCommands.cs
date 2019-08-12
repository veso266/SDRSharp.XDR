using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SDRSharp.Radio;
using SDRSharp.PanView;

namespace SDRSharp.XDR
{
    public partial class SerialCommands
    {
        private static System.IO.Ports.SerialPort SP; //For Serial Communication
        private static byte filter; //Filter BW
        public static void ComThreadEngine()
        {
            while (XDRPlugin._continue && !XDRPlugin._waiting)
            {
                SP = XDRPlugin._serialPort;
                try
                {
                    string Tuner = SP.ReadLine();
                    char TunerCMD = Tuner[0];
                    string TunerData = Tuner.Substring(1);
                    switch (TunerCMD)
                    {
                        case 'x': //Start the tuner
                            Debug.WriteLine("Tuner Connected");
                            XDRPlugin._sdr.StartRadio();
                            SP.Write("OK \n");
                            break;
                        case 'Y': //Volume (meh, don't need that)
                            Console.WriteLine("Volume is: {0}", TunerData);
                            SP.Write(TunerCMD.ToString());
                            SP.Write(TunerData.ToString());
                            SP.Write("\n");
                            break;
                        case 'Q': //Squelch
                            int value = (int)(Convert.ToInt32(TunerData) * 100 * 2.56 / byte.MaxValue);
                            XDRPlugin._sdr.SquelchEnabled = (Convert.ToInt32(TunerData) > 0);
                            if (value > 0) { XDRPlugin._sdr.SquelchThreshold = value; }
                            SP.Write(TunerCMD.ToString());
                            SP.Write(TunerData.ToString());
                            SP.Write("\n");
                            break;
                        case 'M': //Modulation (AM,FM)
                            switch (TunerData)
                                {
                                case "0":
                                    XDRPlugin._sdr.DetectorType = DetectorType.WFM;
                                    break;
                                case "1":
                                    XDRPlugin._sdr.DetectorType = DetectorType.AM;
                                    break;
                            }
                            

                            SP.Write(TunerCMD.ToString());
                            SP.Write(TunerData.ToString()); //It should print actual volume not the one that controller requested :)
                            SP.Write("\n");
                            break;
                        case 'T': //Tunning
                            XDRPlugin._sdr.SetFrequency((long)Convert.ToInt64(TunerData + "000"), true); //Frequency gets like 87500 from Controller which is NotFiniteNumberException right format, right format should be 87500000
                            SP.Write(TunerCMD.ToString());
                            SP.Write(TunerData.ToString()); //It should print actual frequency not the one that controller requested :)
                            SP.Write("\n");
                            break;
                        case 'A':
                            //NOT IMPLEMENTED
                            SP.Write(TunerCMD.ToString());
                            SP.Write(TunerData.ToString()); //It should print actual volume not the one that controller requested :)
                            SP.Write("\n");
                            break;
                        case 'F': //digital filter bandwidth
                            switch(TunerData)
                            {
                                case "-1": //It should be Adaptive BW but no algo for that so 120khz it is
                                    Debug.WriteLine("Adaptive BW");
                                    filter = 120;
                                    break;
                                case "31": //9KHz
                                    filter = 9;
                                    break;
                                case "16": //15khz
                                    filter = 15;
                                    break;
                                case "17": //17kHz
                                    filter = 17;
                                    break;
                                case "18": //20kHz
                                    filter = 20;
                                    break;
                                case "19": //24kHz
                                    filter = 24;
                                    break;
                                case "20": //27kHz
                                    filter = 27;
                                    break;
                                case "21": //32kHz
                                    filter = 32;
                                    break;
                                case "22": //36kHz
                                    filter = 36;
                                    break;
                                case "23": //42kHz
                                    filter = 42;
                                    break;
                                case "24": //48kHz
                                    filter = 48;
                                    break;
                                case "0": //55kHz
                                    filter = 55;
                                    break;
                                case "26": //63kHz
                                    filter = 63;
                                    break;
                                case "1": //73kHz
                                    filter = 73;
                                    break;
                                case "28": //83kHz
                                    filter = 83;
                                    break;
                                case "2": //90kHz
                                    filter = 90;
                                    break;
                                case "29": //95kHz
                                    filter = 95;
                                    break;
                                case "3": //108kHz
                                    filter = 108;
                                    break;
                                case "4": //125kHz
                                    filter = 125;
                                    break;
                                case "5": //142kHz
                                    filter = 142;
                                    break;
                                case "6": //159kHz
                                    filter = 159;
                                    break;
                                case "7": //177kHz
                                    filter = 177;
                                    break;
                                case "8": //194kHz
                                    filter = 194;
                                    break;
                                case "9": //211kHz
                                    filter = 211;
                                    break;
                                case "10": //229kHz
                                    filter = 229;
                                    break;
                                case "11": //246kHz
                                    filter = 246;
                                    break;
                                case "12": //263kHz (250Khz)
                                    filter = 250;
                                    break;
                                case "13": //281kHz
                                case "14": //298kHz
                                case "15": //309kHz
                                    break;

                            }
                            XDRPlugin._sdr.FilterBandwidth = (int)filter * 1000;
                            SP.Write(TunerCMD.ToString());
                            SP.Write(TunerData.ToString()); //It should print actual volume not the one that controller requested :)
                            SP.Write("\n");
                            break;
                        case 'N': //Stereo/Mono switch (injection pilot???)
                            XDRPlugin._sdr.FmStereo = !XDRPlugin._sdr.FmStereo;
                            break;
                        case 'D':
                            //NOT IMPLEMENTED
                            SP.Write(TunerCMD.ToString());
                            SP.Write(TunerData.ToString()); //It should print actual volume not the one that controller requested :)
                            SP.Write("\n");
                            break;
                        case 'G':
                            SP.Write(TunerCMD.ToString());
                            SP.Write("1"); //It should print actual volume not the one that controller requested :)
                            SP.Write("\n");
                            break;
                        case 'Z':
                            //NOT IMPLEMENTED
                            break;
                        case 'X': //Stop Tuner
                            Debug.WriteLine("Tuner Disconnected");
                            XDRPlugin._sdr.StopRadio();
                            SP.Write("OK \n");
                            break;
                        default:
                            //Debug.WriteLine(Tuner);
                            break;
                    }
                    Debug.WriteLine(Tuner);
                }
                catch (TimeoutException) //It updates to slowly so why not sent it when nothing is happening :) 
                {

                    //Signal, stereo and RDS :)
                    SP.Write("S"); //Signal
                    
                    //Sterep/MONO
                    if (XDRPlugin._sdr.FmStereo) //If stereo checkbox is checked
                    {
                        SP.Write((XDRPlugin._sdr.FmPilotIsDetected) ? "s" : "m");
                    }
                    else
                    {
                        SP.Write((XDRPlugin._sdr.FmPilotIsDetected) ? "S" : "m");
                    }
                    serial_signal(XDRPlugin._sdr.VisualSNR, 2); //Signal 
                    SP.Write("\n");


                    //RDS
                    serial_pi(XDRPlugin.PI_Code, PI_CORRECT);
                    SP.Write("R");
                    SP.Write(XDRPlugin.RDS_Group + "00"); //00 at the end are error correction: 0 - no errors 1 - max 2-bit correction 2 - max 5-bit correction
                    SP.Write("\n");
                    XDRPlugin.RDS_Group = null;
                }
            }
            XDRPlugin._waiting = false;
            XDRPlugin._continue = false;
        }
        static void serial_signal(float level, byte precision)
        {
            byte n = (byte)((level - (int)level) * Math.Pow(10, precision));

            SP.Write(((int)level).ToString());
            SP.Write(".");
            if (precision == 2 && n < 10)
                SP.Write("0");
            SP.Write(n.ToString());
        }
        public static void serial_hex(byte val)
        {
            try
            {
                SP.Write(((val >> 4) & 0xF).ToString("X"));
                SP.Write((val & 0xF).ToString("X"));
            }
            catch{}
        }
    }
}
