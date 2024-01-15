
using System;
using System.Windows.Forms;
using Renci.SshNet;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form3 : Form
    {
        
        public void rebootAxum(string ipAdress)
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
                textBox1.AppendText("Connecting");
                textBox1.AppendText("Please wait");
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

                var command = client.RunCommand("reboot");
                textBox1.AppendText("");
                textBox1.AppendText(command.CommandText);
                textBox1.AppendText("");
                command = client.RunCommand("sleep 1");

                // Disconnect from the SSH server
                textBox1.AppendText("Rebooting");
                client.Disconnect();
                textBox1.AppendText("Pleas wait ( ~ 30 seconds )");
                textBox1.AppendText("done");
                //enableButtons();
                client.Disconnect();

            }
        }
    }
}
