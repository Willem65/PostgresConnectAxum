using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Renci.SshNet;


namespace PostgresConnectAxum
{
    public partial class Form3ChangeIPAxum : Form 
    {

        string host;
        string username = GlobalVariables.uStr;
        string password = GlobalVariables.pStr;
        string searchText;
        int timercnt = 1;
        static bool timerAlarm=false;

        public Form3ChangeIPAxum()
        {
            InitializeComponent();

        }
        
        public void ChangeIPAxum(string ipAdress)
        {

            host = ipAdress;


            textBox5.AppendText("Please wait\n\r\n\r");

            // Construct the PSCP command, haal de file op via pscp uitgevoerd op de cmd command prompt
            // download
            string command = $"echo y | pscp -pw {password} {username}@{host}:{"/etc/conf.d/ip"} {"C:\\TempAxum"}";
            string output = "";
            if (command != null)
            {
                output = GlobalFunctions.cmdCommandOutput(command);
            }


            //Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {

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

                    var commnd = client.RunCommand(@"cat /etc/conf.d/ip");
                    string message = commnd.Result.Replace("\n", "\r\n");
                    int pos1 = message.IndexOf("# create");
                    textBox5.Text = message.Substring(0, pos1);

                    pos1 = message.IndexOf("net_ip=") + 8;
                    string data = message.Substring(pos1, 16).Trim();
                    int pos2 = data.IndexOf("\"");
                    data = message.Substring(pos1, pos2).Trim();
                    textBox1.Text = data;


                    pos1 = message.IndexOf("net_mask=") + 10;
                    data = message.Substring(pos1, 16).Trim();
                    pos2 = data.IndexOf("\"");
                    data = message.Substring(pos1, pos2).Trim();
                    textBox2.Text = data;

                    pos1 = message.IndexOf("net_gw=") + 8;
                    data = message.Substring(pos1, 16).Trim();
                    pos2 = data.IndexOf("\"");
                    data = message.Substring(pos1, pos2).Trim();
                    textBox3.Text = data;

                    pos1 = message.IndexOf("net_dns=") + 9;
                    data = message.Substring(pos1, 16).Trim();
                    pos2 = data.IndexOf("\"");
                    data = message.Substring(pos1, pos2).Trim();
                    textBox4.Text = data;

                    client.Disconnect();
                }
            }
        }




        public void button1_Click_1(object sender, EventArgs e)
        {

            string readFile = File.ReadAllText("C:\\TempAxum\\ip");
            int pos1 = readFile.IndexOf("net_ip=") + 8;
            searchText = readFile.Substring(pos1, 16).Trim();
            int pos2 = searchText.IndexOf("\"");
            File.WriteAllText("C:\\TempAxum\\ip", File.ReadAllText("C:\\TempAxum\\ip").Remove(pos1, pos2));
            File.WriteAllText("C:\\TempAxum\\ip", File.ReadAllText("C:\\TempAxum\\ip").Insert(pos1, textBox1.Text.Trim()));



            readFile = File.ReadAllText("C:\\TempAxum\\ip");
            pos1 = readFile.IndexOf("net_mask=") + 10;
            searchText = readFile.Substring(pos1, 16).Trim();
            pos2 = searchText.IndexOf("\"");
            File.WriteAllText("C:\\TempAxum\\ip", File.ReadAllText("C:\\TempAxum\\ip").Remove(pos1, pos2));
            File.WriteAllText("C:\\TempAxum\\ip", File.ReadAllText("C:\\TempAxum\\ip").Insert(pos1, textBox2.Text.Trim()));


            readFile = File.ReadAllText("C:\\TempAxum\\ip");
            pos1 = readFile.IndexOf("net_gw=") + 8;
            searchText = readFile.Substring(pos1, 16).Trim();
            pos2 = searchText.IndexOf("\"");
            File.WriteAllText("C:\\TempAxum\\ip", File.ReadAllText("C:\\TempAxum\\ip").Remove(pos1, pos2));
            File.WriteAllText("C:\\TempAxum\\ip", File.ReadAllText("C:\\TempAxum\\ip").Insert(pos1, textBox3.Text.Trim()));


            readFile = File.ReadAllText("C:\\TempAxum\\ip");
            pos1 = readFile.IndexOf("net_dns=") + 9;
            searchText = readFile.Substring(pos1, 16).Trim();
            pos2 = searchText.IndexOf("\"");
            File.WriteAllText("C:\\TempAxum\\ip", File.ReadAllText("C:\\TempAxum\\ip").Remove(pos1, pos2));
            File.WriteAllText("C:\\TempAxum\\ip", File.ReadAllText("C:\\TempAxum\\ip").Insert(pos1, textBox4.Text.Trim()));





            // upload
            string pscpCommand = $"echo y | pscp -pw {password} {"C:\\TempAxum\\ip"} {username}@{host}:{"/etc/conf.d/ip"}";
            string respons = GlobalFunctions.cmdCommandErr(pscpCommand);
            if (respons != "")
            {
                textBox5.AppendText(respons + "Please select the right folder where the file is located.\r\n\r\n");
            }
            Thread.Sleep(1);



            // Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {
                textBox5.AppendText("Please wait\n\r\n\r");
                
                // Connect to the SSH server
                try
                {
                    client.Connect();
                    Thread.Sleep(1);
                }
                catch (Exception)
                {
                    MessageBox.Show("Not connected");
                    return;
                }

                if (client.IsConnected)
                {

                    var commad = client.RunCommand(@"cat /etc/conf.d/ip");
                    string message = commad.Result.Replace("\n", "\r\n");
                    pos1 = message.IndexOf("# create");
                    textBox5.Text = message.Substring(0, pos1);
                    commad = client.RunCommand("sleep 1");
                    client.Disconnect();

                    //Thread.Sleep(15);
                    //for( int t=0; t<5; t++)
                    //{
                    //timer1.Enabled = true;
                    //while (timerAlarm == false)
                    //{
                    //    ;
                    //}
                    //timer1.Enabled = false;
                    //    string cnt = (5 - t).ToString();
                        textBox5.AppendText("\r\n" + " After you have schanged the IP address, \r\n you have now to reboot the Axum \r\n and close this program ");
                    //}
                    //commad = client.RunCommand(@"reboot");
                    //Thread.Sleep(3);
                    //this.Dispose();
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

        public void timer1_Tick(object sender, EventArgs e)
        {
            timercnt++;
            textBox5.AppendText(timercnt.ToString());
            if (timercnt > 5)
            {
                timerAlarm = true;
                timer1.Enabled = false;
            }

        }
    }
}
