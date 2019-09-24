using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SDRSharp.XDR.Tools;
using SDRSharp.Radio;

namespace SDRSharp.XDR
{
    public partial class AdvancedRDSWindow : Form
    {
        private static AdvancedRDSWindow form2;
        ToolTip toolTip1 = new CustomToolTip();
        private AdvancedRDSWindow()
        {
            InitializeComponent();
        }

        public static AdvancedRDSWindow Instance
        {
            //singleton design pattern to return always the same instance of a form
            get
            {
                if (form2 == null || form2.IsDisposed)
                {
                    form2 = new AdvancedRDSWindow();
                    form2.Text = "Advanced RDS Settings";
                    XDRPlugin.EsterEgg = Utils.GetBooleanSetting("EsterEgg", true);
                    if (XDRPlugin.EsterEgg)
                        form2.NonClientMouseHover += form2.TitleHoveredEvent; //Hook into TitleHover event
                    if (!XDRPlugin.ExternalRDS)
                        form2.internalrds.Checked = true;
                    else
                    {
                        form2.rdsspy.Checked = true;
                    }
                }
                return form2;

            }
        }
        private void TitleHoveredEvent(object sender, EventArgs e)
        {
            toolTip1.Show("You found the easter egg", this, 0, -100, 10000); //I have to write something as text otherwise tooltip won't appear
        }
        private void rdsspy_CheckedChanged(object sender, EventArgs e)
        {
            //Enable adress,port control if we are using External RDS Source
            UDPListen.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            XDRPlugin.ExternalRDS = true;
        }
        private void internalrds_CheckedChanged(object sender, EventArgs e)
        {
            //Disable adress,port control if we are using Internal RDS Source
            UDPListen.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            XDRPlugin.ExternalRDS = false;
        }


        private void UDPListen_Click(object sender, EventArgs e)
        {
            StartServer();
            UDPListen.Text = "Connected, don't click me again!!";
            UDPListen.Enabled = false;
        }
        public static void StartServer(int listenPort)
        {
            UDPServer.listenPort = listenPort;
            Thread RecieveUDP = new Thread(UDPServer.Serve);
            RecieveUDP.Start();
            RecieveUDP.IsBackground = true; //if this is not true we won't be able to close the SDR# because this will keep running and we don't want that
        }
        private void StartServer()
        {
            UDPServer.listenPort = Convert.ToInt32(textBox2.Text);
            Thread RecieveUDP = new Thread(UDPServer.Serve);
            RecieveUDP.Start();
            RecieveUDP.IsBackground = true; //if this is not true we won't be able to close the SDR# because this will keep running and we don't want that
        }
    }
}
