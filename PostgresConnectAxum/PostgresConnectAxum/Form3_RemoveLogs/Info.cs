
using System;
using System.Windows.Forms;
using Renci.SshNet;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form3 : Form
    {
        
        public void infoAxum(string ipAdress)
        { 
            //disableButtons();
            // Connection info
            string host = ipAdress;
            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            textBox1.Clear();

            // Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {
                textBox1.AppendText("Connecting\r\n");
                textBox1.AppendText("Please wait\r\n");
                // Connect to the SSH server
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
                textBox1.Clear();

                textBox1.AppendText("The Axum is online. For IP changes are made, you have to reboot de axum\r\n");

                var command = client.RunCommand("ifconfig");
                textBox1.AppendText("\r\n");

                string message = command.Result + "  ";
                int pos1 = message.IndexOf("addr:") + 5;
                //Get the string position of the next word, starting index being after the first position
                int pos2 = message.IndexOf(" ", pos1);
                string data = "Ip        " + message.Substring(pos1, pos2 - pos1);
                textBox1.AppendText(data);
                textBox1.AppendText("\r\n");

                message = command.Result + "  ";
                pos1 = message.IndexOf("HWaddr") + 7;
                //Get the string position of the next word, starting index being after the first position
                pos2 = message.IndexOf(" ", pos1);
                data = "MAC   " + message.Substring(pos1, pos2 - pos1).Trim();
                textBox1.AppendText(data);
                textBox1.AppendText("\r\n\r\n");


                command = client.RunCommand(@"cat /var/lib/axum/uniqueids-rack");
                textBox1.AppendText(command.Result.Replace("\n", "\r\n") );

                textBox1.AppendText("");
                command = client.RunCommand("sleep 1");


                client.Disconnect();


            }
        }
    }
}
