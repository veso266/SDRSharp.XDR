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
            bool done = false;
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            byte[] receive_byte_array;
            try

            {
                while (!done)
                {
                    Debug.WriteLine("Waiting for broadcast");

                    receive_byte_array = listener.Receive(ref groupEP);
                    if (groupEP != null) //If we have any data on UDP we have RDS
                    {
                        XDRPlugin.RDSDetected = true;
                        SerialCommands.ParseData(Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length));
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
    class UDPClient
    {
        class Program

        {
            static void test(string[] args)
            {
                Boolean done = false;
                Boolean exception_thrown = false;

                Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
                ProtocolType.Udp);

                IPAddress send_to_address = IPAddress.Parse("192.168.2.255");

                IPEndPoint sending_end_point = new IPEndPoint(send_to_address, 11000);

                #region comments
                // The below three lines of code will not work. They appear to load

                // the variable broadcast_string witha broadcast address. But that

                // address causes an exception when performing the send.

                //

                //string broadcast_string = IPAddress.Broadcast.ToString();

                //Console.WriteLine("broadcast_string contains {0}", broadcast_string);

                //send_to_address = IPAddress.Parse(broadcast_string);

                #endregion

                Console.WriteLine("Enter text to broadcast via UDP.");
                Console.WriteLine("Enter a blank line to exit the program.");
                while (!done)
                {
                    Console.WriteLine("Enter text to send, blank line to quit");
                    string text_to_send = Console.ReadLine();
                    if (text_to_send.Length == 0)
                    {
                        done = true;
                    }
                    else

                    {
                        // the socket object must have an array of bytes to send.

                        // this loads the string entered by the user into an array of bytes.

                        byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);

                        // Remind the user of where this is going.

                        Console.WriteLine("sending to address: {0} port: {1}",
                        sending_end_point.Address,
                        sending_end_point.Port);
                        try

                        {
                            sending_socket.SendTo(send_buffer, sending_end_point);
                        }
                        catch (Exception send_exception)
                        {
                            exception_thrown = true;
                            Console.WriteLine(" Exception {0}", send_exception.Message);
                        }
                        if (exception_thrown == false)
                        {
                            Console.WriteLine("Message has been sent to the broadcast address");
                        }
                        else

                        {
                            exception_thrown = false;
                            Console.WriteLine("The exception indicates the message was not sent.");
                        }
                    }
                } // end of while (!done)

            } // end of main()

        } // end of class Program
    }
}
