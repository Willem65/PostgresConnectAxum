
using Renci.SshNet;
using System;

namespace PostgresConnectAxum
{
    
    public partial class Form2
    {
        //Restore settings
        public void restoreSettings(string ipAdress)
        {
            string host = ipAdress;
            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            textBox1.Clear();

            // Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {
                textBox1.AppendText("Please wait");
                textBox1.AppendText(Environment.NewLine);

                // Connect to the SSH server
                client.Connect();

                var command = client.RunCommand(@"/etc/rc.d/axum-cleandb stop");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand(@"/etc/rc.d/axum-gateway stop");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand(@"/etc/rc.d/axum-address stop");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand("//etc//rc.d//axum-learner stop");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand("//etc//rc.d//axum-engine stop");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand("//etc//rc.d//lighttpd stop");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand("//etc//rc.d//xinetd stop");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);
                //All processes stopped


                //Now making the backup file's
                command = client.RunCommand("cp -f /root/.backup /var/lib/axum/");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand("/usr/bin/dropdb -U postgres axum");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand("/usr/bin/psql -U postgres -h 127.0.0.1 -p 5432 < /root/dbaxumall.sql");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);




                command = client.RunCommand(@"/etc/rc.d/axum-cleandb start");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand(@"/etc/rc.d/axum-gateway start");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand(@"/etc/rc.d/axum-address start");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand("//etc//rc.d//axum-learner start");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand("//etc//rc.d//axum-engine start");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand("//etc//rc.d//lighttpd start");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);

                command = client.RunCommand("//etc//rc.d//xinetd start");
                textBox1.AppendText(command.Result);
                command = client.RunCommand("sleep 1");
                textBox1.AppendText(Environment.NewLine);




                command = client.RunCommand("reboot");
                textBox1.AppendText(command.Result);
                textBox1.AppendText(Environment.NewLine);
                command = client.RunCommand("sleep 1");


                // Disconnect from the SSH server
                textBox1.AppendText("reboot");
                textBox1.AppendText(Environment.NewLine);
                client.Disconnect();
                textBox1.AppendText("wait till the Axum is started");
                textBox1.AppendText(Environment.NewLine);

            }

        }

    }
}
