using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


namespace PostgresConnectAxum
{
    public partial class Form3 : Form
    {
        bool connected = false;
        //string folderPath;
        string creationTime;

        public static Form3 instance;

        public Button but1;
        public Button but2;
        public Button but3;

        public Form3()
        {
            InitializeComponent();

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            Assembly execAssembly = Assembly.GetExecutingAssembly();
            //creationTime = new FileInfo(execAssembly.Location).CreationTime.ToString("ddMMyyyy");
            //creationTime = new FileInfo(execAssembly.Location).LastAccessTime.ToString("ddMMyyyy");

            instance = this;
            but1 = button1;
            but2 = button2;
            but3 = button3;
        }

        private void Form3_Activated(object sender, EventArgs e)
        {
            string command = $"mkdir C:\\TempAxum\\";
            string output = "";
            if (command != null)
            {
                output = GlobalFunctions.cmdCommandOutput(command);
            }

            //Form3.ActiveForm.Text = "Remove log files and more v" + creationTime;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox1.Font = new Font("courier", 11);
            textBox1.ForeColor = System.Drawing.Color.DarkRed;
            textBox1.AppendText("");
            textBox1.AppendText("With this utility, you can delete the log files in the /var/log directory on the server\r\n");
            textBox1.AppendText("\r\n");
            textBox1.AppendText("If you are NOT sure what to do, stop now.\r\n");
            textBox1.AppendText("\r\n");
            textBox1.AppendText("If you are very sure what you are doing, you can choose the options left.\r\n");
            textBox1.AppendText("\r\n");
            textBox1.AppendText("We are not responsible. Be sure you already downloaded an image backup, from the Axum \r\n");
            textBox1.AppendText("system configuration webpage \r\n");
        }

        // Connect button
        private void button1_Click(object sender, EventArgs e)
        {
            
            GlobalVariables.ipAddressStr = comboBox1.Text;

            string ipAdress = GlobalVariables.ipAddressStr;

            if (ipAdress == "")
            {
                textBox1.Clear();
                MessageBox.Show("Enter IP address ");
                return;
            }


            if (connected == false)
            {
                connected = true;
                //textBox1.Clear();
                //textBox1.Font = new Font("courier", 11);
                //textBox1.ForeColor = System.Drawing.Color.DarkRed;
                //textBox1.AppendText("");
                //textBox1.AppendText("With this utility, you can delete the log files in the /var/log directory on the server\r\n");
                //textBox1.AppendText("\r\n");
                //textBox1.AppendText("If you are NOT sure what to do, stop now.\r\n");
                //textBox1.AppendText("\r\n");
                //textBox1.AppendText("If you are very sure what you are doing, you can choose the options left.\r\n");
                //textBox1.AppendText("\r\n");
                //textBox1.AppendText("We are not responsible. Be sure you already downloaded an image backup, from the Axum \r\n");
                //textBox1.AppendText("system configuration webpage \r\n");
            }
            else
            {
                MessageBox.Show("For a new or different connection, close this application and start this application again.");
            }

            string pingCmd = $"ping -n 2 {ipAdress}";
            string pingOutput = GlobalFunctions.cmdCommandOutput(pingCmd);

            // Check if the pinging is valid
            bool isValidPing = pingOutput.Contains("unreachable");

            if (isValidPing)
            {
                MessageBox.Show("Wrong ip or unreachable connection");
                this.Dispose();
                return;
            }
            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            string command = $"echo y | pscp -pw {password} {username}@{ipAdress}:{"/root/ test"}";
            //string command = $"pscp -pw axm root@192.168.1.76:/root/ test";

            string output = "";
            if (command != null)
                output = GlobalFunctions.cmdCommandOutput(command);

            // Check if the password is valid
            bool isValidPassword = !output.Contains("password");

            if (isValidPassword == false)
            {
                var Form3UserPass = new Form3UserPass();
                Form3UserPass.Show();
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;

                infoAxum(GlobalVariables.ipAddressStr);

            }
        }


        // remove log files from  /var/log button
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.Color.Black;
            button2.Enabled = false;
            deleteLogs(GlobalVariables.ipAddressStr);
            button2.Enabled = true;
        }

        private void Form3_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.isValid == true)
            {
                button2.Enabled = true;
            }
        }



        // Reboot de axum
        private void button3_Click(object sender, EventArgs e)
        {
            //textBox1.ForeColor = System.Drawing.Color.Black;
            button2.Enabled = false;
            rebootAxum(GlobalVariables.ipAddressStr);
            button2.Enabled = true;
        }

        // Verander de UIids van de axum processen
        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Form3ChangeUIidsAxum inputForm = new Form3ChangeUIidsAxum();
            inputForm.ChangeUIidsAxum(GlobalVariables.ipAddressStr);
            inputForm.Show();
            button2.Enabled = true;
        }

        // Display global information
        private void button5_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            infoAxum(GlobalVariables.ipAddressStr);
            button2.Enabled = true;
        }

        // Verander het IP adres
        private void button6_Click(object sender, EventArgs e)
        {
            //Form3ChangeIPAxum
            button2.Enabled = false;
            Form3ChangeIPAxum changeIPForm = new Form3ChangeIPAxum();
            changeIPForm.ChangeIPAxum(GlobalVariables.ipAddressStr);
            changeIPForm.Show();
            button2.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Font = new Font("courier", 11);
            textBox1.ForeColor = System.Drawing.Color.DarkRed;
            textBox1.AppendText("");
            textBox1.AppendText("Remove Log files\r\n");
            textBox1.AppendText("\r\n");
            textBox1.AppendText("Dante 16 to 32 issue run perl.\r\n");
            textBox1.AppendText("\r\n");
            textBox1.AppendText("Bitrate clock.\r\n");
            textBox1.AppendText("\r\n");
            textBox1.AppendText(" \r\n");
            //textBox1.AppendText("system configuration webpage \r\n");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            searchAxumAxite ch = new searchAxumAxite();
            ch.searchAxumAxit(GlobalVariables.ipAddressStr);
            ch.Show();
            button2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //textBox1.Text = DateTime.Now.ToString();
            //textBox1.AppendText("#");
            //textBox1.AppendText("#");



        }
    }
}
