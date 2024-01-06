using System.Windows.Forms;
using Npgsql;
using Renci.SshNet;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form1 : Form
    {
        
        public void backUp(string ipAdress)
        { 
            //disableButtons();
            // Connection info
            string host = ipAdress;
            string username = "root";
            string password = "axum";

            listBox1.Items.Clear();

            // Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {
                listBox1.Items.Add("Connecting").ToString();
                listBox1.Items.Add("Please wait").ToString();
                // Connect to the SSH server
                client.Connect();


                //var command = client.RunCommand(@"/etc/rc.d/axum-cleandb stop");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand(@"/etc/rc.d/axum-gateway stop");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand(@"/etc/rc.d/axum-address stop");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand("//etc//rc.d//axum-learner stop");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand("//etc//rc.d//axum-engine stop");
                //listBox1.Items.Add(command.Result.ToString());
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand("//etc//rc.d//lighttpd stop");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand("//etc//rc.d//xinetd stop");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");



                var command = client.RunCommand("cp -f /root/.backup /root/.backup.old");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                //command = client.RunCommand("rm /root/.backup");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                command = client.RunCommand("cp -f /var/lib/axum/.backup /root");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("cp -f /root/dbaxumall.sql /root/dbaxumall.old");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("rm /root/dbaxumall.sql");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("echo \"making /root/dbaxumall.sql\"");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("echo \"making /root/.backup\"");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("pg_dumpall -U postgres -f /root/dbaxumall.sql > /dev/null");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                //command = client.RunCommand(@"/etc/rc.d/axum-cleandb start");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand(@"/etc/rc.d/axum-gateway start");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand(@"/etc/rc.d/axum-address start");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand("//etc//rc.d//axum-learner start");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand("//etc//rc.d//axum-engine start");
                //listBox1.Items.Add(command.Result.ToString());
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand("//etc//rc.d//lighttpd start");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");

                //command = client.RunCommand("//etc//rc.d//xinetd start");
                //listBox1.Items.Add(command.Result).ToString();
                //command = client.RunCommand("sleep 1");


                // Disconnect from the SSH server
                listBox1.Items.Add("Disconnect").ToString();
                client.Disconnect();
                listBox1.Items.Add("done").ToString();
                //enableButtons();

            }

        }

    }
}
