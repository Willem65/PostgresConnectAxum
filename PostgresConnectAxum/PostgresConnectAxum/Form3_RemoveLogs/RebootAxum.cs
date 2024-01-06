
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
            //string username = "root";
            //string password = "axum";
            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            listBox1.Items.Clear();

            // Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {
                listBox1.Items.Add("Connecting").ToString();
                listBox1.Items.Add("Please wait").ToString();
                // Connect to the SSH server
                client.Connect();

                var command = client.RunCommand("reboot");
                listBox1.Items.Add("").ToString();
                listBox1.Items.Add(command.CommandText).ToString();
                listBox1.Items.Add("").ToString();
                command = client.RunCommand("sleep 1");

                // Disconnect from the SSH server
                listBox1.Items.Add("Rebooting").ToString();
                client.Disconnect();
                listBox1.Items.Add("Pleas wait ( ~ 30 seconds )");
                listBox1.Items.Add("done").ToString();
                //enableButtons();

            }
        }
    }
}
