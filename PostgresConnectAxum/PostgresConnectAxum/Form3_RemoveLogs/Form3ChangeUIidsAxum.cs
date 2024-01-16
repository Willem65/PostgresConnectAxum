using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Renci.SshNet;


namespace PostgresConnectAxum
{
    public partial class Form3ChangeUIidsAxum : Form 
    {
        string rackOrUi;
        string host;
        string username = GlobalVariables.uStr;
        string password = GlobalVariables.pStr;

        public Form3ChangeUIidsAxum()
        {
            InitializeComponent();

        }
        
        public void ChangeUIidsAxum(string ipAdress)
        {

            host = ipAdress;

            // Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {
                textBox5.AppendText("Please wait\n\r\n\r");

                // Connect to the SSH server
                try
                {
                    client.Connect();
                }
                catch (Exception)
                {
                    MessageBox.Show("Not connected");
                    return;
                }

                
                if (client.IsConnected)
                {
                    var command = client.RunCommand(@"cat /var/lib/axum/uniqueids-rack");
                    if (command.Result == "")
                    {
                        command = client.RunCommand(@"cat /var/lib/axum/uniqueids-ui");
                        rackOrUi = "ui";
                    }
                    else
                    {
                        rackOrUi = "rack";
                    }

                    textBox5.Text = command.Result.Replace("\n", "\r\n");
                    string message = textBox5.Text + "                                         ";

                    if (message.Contains("axum-address"))
                    {
                        int pos1 = message.IndexOf("axum-address") + 13;
                        string data = message.Substring(pos1, 4).Trim();
                        textBox1.Text = data;
                    }

                    if (message.Contains("axum-engine"))
                    {
                        int pos1 = message.IndexOf("axum-engine") + 12;
                        string data = message.Substring(pos1, 4).Trim();
                        textBox2.Text = data;
                    }

                    if (message.Contains("axum-gateway"))
                    {
                        int pos1 = message.IndexOf("axum-gateway") + 13;
                        string data = message.Substring(pos1, 4).Trim();
                        textBox3.Text = data;
                    }

                    if (message.Contains("axum-learner"))
                    {
                        int pos1 = message.IndexOf("axum-learner") + 13;
                        string data = message.Substring(pos1, 4).Trim();
                        textBox4.Text = data;
                        textBox5.AppendText("\r\nRack-Engine");
                    }

                    if (message.Contains("axum-meters"))
                    {
                        int pos1 = message.IndexOf("axum-meters") + 12;
                        string data = message.Substring(pos1, 4).Trim();
                        textBox6.Text = data;
                        textBox5.AppendText("\r\nUI-Surface");
                    }

                    client.Disconnect();
                }
            }
        }



        public void button1_Click_1(object sender, EventArgs e)
        {

            //// Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {
                textBox5.AppendText("Please wait\n\r\n\r");

                // Connect to the SSH server
                try
                {
                    client.Connect();
                }
                catch (Exception)
                {
                    MessageBox.Show("Not connected");
                    return;
                }


                if (client.IsConnected)
                {
                    //string uiids = "axum-address 121 axum-engine 121 axum-gateway 121 axum-learner 121 ";

                    if (rackOrUi == "rack")
                    {
                        string uiids = "axum-address " + textBox1.Text.Trim();
                        client.RunCommand(@"echo " + uiids + " > /var/lib/axum/uniqueids-" + rackOrUi);
                        uiids = "\n";
                        client.RunCommand(@"echo " + uiids + " >> /var/lib/axum/uniqueids-" + rackOrUi);

                        uiids = "axum-engine " + textBox2.Text.Trim();
                        client.RunCommand(@"echo " + uiids + " >> /var/lib/axum/uniqueids-" + rackOrUi);
                        uiids = "\n";
                        client.RunCommand(@"echo " + uiids + " >> /var/lib/axum/uniqueids-" + rackOrUi);

                        uiids = "axum-gateway " + textBox3.Text.Trim();
                        client.RunCommand(@"echo " + uiids + " >> /var/lib/axum/uniqueids-" + rackOrUi);
                        uiids = "\n";
                        client.RunCommand(@"echo " + uiids + " >> /var/lib/axum/uniqueids-" + rackOrUi);

                        uiids = "axum-learner " + textBox4.Text.Trim();
                        client.RunCommand(@"echo " + uiids + " >> /var/lib/axum/uniqueids-" + rackOrUi);
                        uiids = "\n";
                        client.RunCommand(@"echo " + uiids + " >> /var/lib/axum/uniqueids-" + rackOrUi);
                    }
                    else if (rackOrUi == "ui")
                    {
                        string uiids = "axum-gateway " + textBox3.Text.Trim();
                        client.RunCommand(@"echo " + uiids + " > /var/lib/axum/uniqueids-" + rackOrUi);
                        uiids = "\n";
                        client.RunCommand(@"echo " + uiids + " >> /var/lib/axum/uniqueids-" + rackOrUi);

                        uiids = "axum-meters " + textBox6.Text.Trim();
                        client.RunCommand(@"echo " + uiids + " >> /var/lib/axum/uniqueids-" + rackOrUi);
                        uiids = "\n";
                        client.RunCommand(@"echo " + uiids + " >> /var/lib/axum/uniqueids-" + rackOrUi);
                    }



                    var command = client.RunCommand(@"cat /var/lib/axum/uniqueids-" + rackOrUi);
                    textBox5.Text = command.Result.Replace("\n", "\r\n");
                    //command = client.RunCommand("sleep 1");
                    string message = textBox5.Text + "                                         ";

                    if (message.Contains("axum-address"))
                    {
                        int pos1 = message.IndexOf("axum-address") + 13;
                        string data = message.Substring(pos1, 4).Trim();
                        textBox1.Text = data;
                    }

                    if (message.Contains("axum-engine"))
                    {
                        int pos1 = message.IndexOf("axum-engine") + 12;
                        string data = message.Substring(pos1, 4).Trim();
                        textBox2.Text = data;
                    }

                    if (message.Contains("axum-gateway"))
                    {
                        int pos1 = message.IndexOf("axum-gateway") + 13;
                        string data = message.Substring(pos1, 4).Trim();
                        textBox3.Text = data;
                    }

                    if (message.Contains("axum-learner"))
                    {
                        int pos1 = message.IndexOf("axum-learner") + 13;
                        string data = message.Substring(pos1, 4).Trim();
                        textBox4.Text = data;
                    }

                    if (message.Contains("axum-meters"))
                    {
                        int pos1 = message.IndexOf("axum-meters") + 12;
                        string data = message.Substring(pos1, 4).Trim();
                        textBox6.Text = data;
                    }
                    client.Disconnect();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3ChangeUIidsAxum.ActiveForm.Hide();
        }

        private void Form3ChangeUIidsAxum_Load(object sender, EventArgs e)
        {

        }
    }
}
