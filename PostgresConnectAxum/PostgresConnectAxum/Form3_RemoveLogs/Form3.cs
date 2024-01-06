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

            Assembly execAssembly = Assembly.GetExecutingAssembly();
            //creationTime = new FileInfo(execAssembly.Location).CreationTime.ToString("ddMMyyyy");
            creationTime = new FileInfo(execAssembly.Location).LastAccessTime.ToString("ddMMyyyy");

            instance = this;
            but1 = button1;
            but2 = button2;
            but3 = button3;
        }

        private void Form3_Activated(object sender, EventArgs e)
        {
            Form3.ActiveForm.Text = "Remove log files v" + creationTime;
        }

        // Connect button
        private void button1_Click(object sender, EventArgs e)
        {
            
            GlobalVariables.ipAddressStr = comboBox1.Text;

            string ipAdress = GlobalVariables.ipAddressStr;

            if (ipAdress == "")
            {
                listBox1.Items.Clear();
                MessageBox.Show("Enter IP address ");
                return;
            }

            if (connected == false)
            {
                connected = true;
                listBox1.Items.Clear();
                listBox1.Font = new Font("courier", 11);
                listBox1.ForeColor = System.Drawing.Color.DarkRed;
                listBox1.Items.Add("");
                listBox1.Items.Add("With this utility, you can delete the log files in the /var/log directory on the server");
                listBox1.Items.Add("");
                listBox1.Items.Add("If you are NOT sure what to do, stop now.");
                listBox1.Items.Add("");
                listBox1.Items.Add("If you are very sure what you are doing, you can choose the options left.");
                listBox1.Items.Add("");
                listBox1.Items.Add("We are not responsible. Be sure you already downloaded an image backup, from the Axum ");
                listBox1.Items.Add("system configuration webpage");
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

            string command = $"pscp -pw {password} {username}@{ipAdress}:{"/root/ test"}";
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
            }
        }


        // remove log files /var/log button
        private void button2_Click(object sender, EventArgs e)
        {      
            listBox1.ForeColor = System.Drawing.Color.Black;
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

        private void Form3_Load(object sender, EventArgs e)
        {
            //listBox1.Font = new Font("Tahoma", 11);
            //listBox1.ForeColor = System.Drawing.Color.DarkRed;
            //listBox1.Items.Add("");
            //listBox1.Items.Add("With this utility, you can delete the log files in the /var/log directory on the server");
            //listBox1.Items.Add("");
            //listBox1.Items.Add("If you are NOT sure what to do, stop now.");
            //listBox1.Items.Add("");
            //listBox1.Items.Add("If you are very sure what you are doing, you can choose the options left.");
            //listBox1.Items.Add("");
            //listBox1.Items.Add("We are not responsible. Be sure you already downloaded an image backup, from the Axum ");
            //listBox1.Items.Add("system configuration webpage");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.ForeColor = System.Drawing.Color.Black;
            button2.Enabled = false;
            rebootAxum(GlobalVariables.ipAddressStr);
            button2.Enabled = true;
        }
    }
}
