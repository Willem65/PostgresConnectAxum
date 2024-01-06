using System;
using System.Windows.Forms;
using Renci.SshNet;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form2 : Form
    {
        public void backUp(string ipAdress)
        { 
            string host = ipAdress;
            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            textBox1.Clear();

            // Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {               
                textBox1.AppendText("Connecting");
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("Please wait");
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText(Environment.NewLine);
                // Connect to the SSH server
                client.Connect();


                var command = client.RunCommand("cp -f /root/.backup /root/.backup.old");
                command = client.RunCommand("sleep 1");
                command = client.RunCommand("cp -f /var/lib/axum/.backup /root");
                command = client.RunCommand("sleep 1");
                command = client.RunCommand("cp -f /root/dbaxumall.sql /root/dbaxumall.old");
                command = client.RunCommand("sleep 1");
                command = client.RunCommand("rm /root/dbaxumall.sql");
                command = client.RunCommand("sleep 1");
                command = client.RunCommand("echo \"making /root/dbaxumall.sql\"");
                textBox1.AppendText(command.Result + "\n\r");
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);
                command = client.RunCommand("echo \"making /root/.backup\"");
                textBox1.AppendText(command.Result + "\n");
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);
                command = client.RunCommand("pg_dumpall -U postgres -f /root/dbaxumall.sql > /dev/null");
                textBox1.AppendText(command.Result + "\n");
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);


                // Disconnect from the SSH server
                textBox1.AppendText("Disconnect\n");
                textBox1.AppendText(Environment.NewLine);
                client.Disconnect();
                textBox1.AppendText("done\n");
                textBox1.AppendText(Environment.NewLine);
            }
        }
    }
}
