
using System.Windows.Forms;
using Renci.SshNet;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form3 : Form
    {
        
        public void deleteLogs(string ipAdress)
        { 
            //disableButtons();
            // Connection info
            string host = ipAdress;
            string username = "root";
            string password = "axum";

            textBox1.Clear();

            // Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {
                textBox1.AppendText("Connecting");
                textBox1.AppendText("Please wait");
                // Connect to the SSH server
                client.Connect();

                var command = client.RunCommand("rm /var/log/*.log*");
                textBox1.AppendText("");
                textBox1.AppendText(command.CommandText);
                textBox1.AppendText("");
                command = client.RunCommand("sleep 1");

                // Disconnect from the SSH server
                textBox1.AppendText("Disconnect");
                client.Disconnect();
                textBox1.AppendText("done");
                //enableButtons();

            }
        }
    }
}
