using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using Button = DiscordRPC.Button;

namespace Easy_RPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                system_tray.Visible = true;
            }
        }

        private void system_tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            system_tray.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (app_ID.Text != String.Empty)
            {
                if (details.Text != String.Empty || state.Text != String.Empty || img_1.Text != String.Empty)
                {
                    DiscordRpcClient client = new DiscordRpcClient(app_ID.Text);
                    client.Initialize();

                    RichPresence presence = new RichPresence();
                    presence.Details = details.Text;
                    presence.State = state.Text;
                    presence.Assets = new Assets()
                    {
                        LargeImageKey = img_1.Text,
                        LargeImageText = img_1_txt.Text,
                        SmallImageKey = img_2.Text,
                        SmallImageText = img_2_txt.Text
                    };
                    presence.Buttons = new Button[]
                            {
                                new Button() { Label = btn1.Text, Url = btn1_url.Text }
                            };
                    client.SetPresence(presence);
                }


            }
            else
            {
                MessageBox.Show("DONT YOU HAVE AN ID??");
            }
        }
    }
}
