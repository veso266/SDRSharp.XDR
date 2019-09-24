using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SDRSharp.XDR
{
    class UDPServer
    {
        public static int listenPort = 8888;
        public static void Serve()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            byte[] receive_byte_array;
            try

            {
                while (true)
                {
                    receive_byte_array = listener.Receive(ref groupEP);
                    string data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                    if (!data.Contains("NO-RDS")) //If we have any data on UDP we have RDS if only it would be null if there is no data but once it is filled with data it stays filled with data
                    {
                        XDRPlugin.RDSDetected = true;
                        SerialCommands.ParseData(data);
                    }
                    else
                    {
                        XDRPlugin.RDSDetected = false;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            listener.Close();
        }
    }
}
