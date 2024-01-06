using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Renci.SshNet;

namespace PostgresConnectAxum
{
    public partial class Form2 : Form
    {
        
        bool connected = false;
        string folderPath;
        string creationTime;

        public static Form2 instance;

        public Button but1;
        public Button but2;
        public Button but3;
        public Button but8;

        string ipAdress = GlobalVariables.ipAddressStr;
        string username = GlobalVariables.uStr;
        string password = GlobalVariables.pStr;

        public Form2()
        {
            InitializeComponent();
            disableButtons();
            button4.Enabled = true;
            Assembly execAssembly = Assembly.GetExecutingAssembly();
            creationTime = new FileInfo(execAssembly.Location).LastAccessTime.ToString("ddMMyyyy");

            instance = this;
            but1 = button1;
            but2 = button2;
            but3 = button3;
            but8 = button8;
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            Form2.ActiveForm.Text = "Backup and restore v" + creationTime;
        }

        public void enableButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button8.Enabled = true;
        }

        public void disableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button8.Enabled = false;
        }



        // Connect button
        private void button4_Click(object sender, EventArgs e)
        {


            textBox1.Clear();
            GlobalVariables.ipAddressStr = comboBox1.Text;

            ipAdress = GlobalVariables.ipAddressStr;

            if (ipAdress == "")
            {
                MessageBox.Show("Enter IP address ");
                return;
            }

            if (connected == false)
            {
                connected = true;
                //connected = true;
                textBox1.Font = new Font("new courier", 11);
                textBox1.ForeColor = System.Drawing.Color.DarkRed;
                textBox1.AppendText("");
                textBox1.AppendText("\r\nWith this utility, you can backup, restore, download and upload the settings.\r\n\r\n");
                textBox1.AppendText("");
                textBox1.AppendText("If you are NOT sure what to do, stop now.\r\n");
                textBox1.AppendText("");
                textBox1.AppendText("If you are very sure what you are doing, you can choose one of the options left.\r\n");
                textBox1.AppendText("");
                textBox1.AppendText("We are not responsible. Be sure you already downloaded an image backup, from the Axum ");
                textBox1.AppendText("system configuration webpage.\r\n");
                textBox1.AppendText("");
                textBox1.AppendText("\r\n");
                textBox1.AppendText("");
                textBox1.AppendText("For a clean overview, Use an empty folder for downloading the files.\r\n");
            }
            else
            {
                MessageBox.Show("For a new or different connection, close this application and start this application again.");
            }

            string pingCmd = $"ping -n 1 {ipAdress}";
            Thread.Sleep(200);
            string pingOutput = GlobalFunctions.cmdCommandOutput(pingCmd);

            // Check if the pinging is valid
            bool isValidPing = pingOutput.Contains("Reply from");

            if (isValidPing == false)
            {
                MessageBox.Show("No Reply from " + ipAdress);
                this.Dispose();
                return;
            }

            //string username = GlobalVariables.uStr;
            //string password = GlobalVariables.pStr;

            string command = $"echo y | pscp -pw {password} {username}@{ipAdress}:{"/root/ test"}";
            //string command = $"pscp -pw axum root@192.168.1.76:/root/ test";


            //bool slash = command.Contains("\"");

            //if (slash == true)
            //{
            //    MessageBox.Show("Wrong ip");
            //    this.Dispose();
            //    return;
            //}

            string output = "";
            if (command != null)
            {
                output = GlobalFunctions.cmdCommandOutput(command);
            }

            // Check if the password is valid
            bool isValidPassword = !output.Contains("password");

            if (isValidPassword == false)
            {
                var Form2UserPass = new Form2UserPass();
                Form2UserPass.Show();
            }
            else
            {
                if (checkIfAxum() == true)
                {
                    enableButtons();
                }
                else
                {
                    MessageBox.Show("This is not the Axum IP address");
                }
            }

        }


        // Create a new SSH client
        public bool checkIfAxum()
        {
            bool axumroot=false;

            using (var client = new SshClient(ipAdress, username, password))
            {
                // Connect to the SSH server
                try
                {
                    client.Connect();
                }
                catch (Exception)
                {
                    MessageBox.Show("Can not connect");
                }

                if (client.IsConnected == true)
                {
                    var command = client.RunCommand("pwd");

                    if (command.Result.Contains("/root") == true)
                    {
                        axumroot = true;
                    }
                    client.Disconnect();
                }
            }
            return axumroot;
        }

        // backup settings button
        public void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = System.Drawing.Color.Black;
            disableButtons();
            backUp(GlobalVariables.ipAddressStr);
            enableButtons();
        }

        // restore settings button
        public void button2_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.Black;
            disableButtons();
            restoreSettings(GlobalVariables.ipAddressStr);
            enableButtons();
        }

        // download settings button
        public void button3_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.Black;
            disableButtons();
            DownloadSettings(GlobalVariables.ipAddressStr);
            enableButtons();
        }

        // upload settings button
        public void button8_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.Black;
            disableButtons();
            upLoadSettings(GlobalVariables.ipAddressStr);
            enableButtons();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ////connected = true;
            //textBox1.Font = new Font("new courier", 11);
            //textBox1.ForeColor = System.Drawing.Color.DarkRed;
            //textBox1.AppendText("");
            //textBox1.AppendText("\r\nWith this utility, you can backup, restore, download and upload the settings.\r\n\r\n");
            //textBox1.AppendText("");
            //textBox1.AppendText("If you are NOT sure what to do, stop now.\r\n");
            //textBox1.AppendText("");
            //textBox1.AppendText("If you are very sure what you are doing, you can choose one of the options left.\r\n");
            //textBox1.AppendText("");
            //textBox1.AppendText("We are not responsible. Be sure you already downloaded an image backup, from the Axum ");
            //textBox1.AppendText("system configuration webpage.\r\n");
            //textBox1.AppendText("");
            //textBox1.AppendText("\r\n");
            //textBox1.AppendText("");
            //textBox1.AppendText("For a clean overview, Use an empty folder for downloading the files.\r\n");
        }
    }
}
