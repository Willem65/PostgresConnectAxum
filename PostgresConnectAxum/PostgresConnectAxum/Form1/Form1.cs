using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Renci.SshNet;

namespace PostgresConnectAxum
{


    public partial class Form1 : Form
    {
        bool connected = false;
        string ipAdress;
        int teller = 0;
        string folderPath;
        //private Rectangle datagridOriginalRectangle;
        private Rectangle originalFormSize;

        public Form1()
        {
            
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Visible = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        public void enableButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
        }

        public void disableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        //Backup settings
        private void button1_Click(object sender, EventArgs e)
        {

            backUp(ipAdress);
            ////disableButtons();
            ////// Connection info
            ////string host = ipAdress;
            ////string username = "root";
            ////string password = "axum";

            ////listBox1.Items.Clear();

            ////// Create a new SSH client
            ////using (var client = new SshClient(host, username, password))
            ////{
            ////    listBox1.Items.Add("Connecting").ToString();
            ////    listBox1.Items.Add("Please wait").ToString();
            ////    // Connect to the SSH server
            ////    client.Connect();





            ////    //var command = client.RunCommand(@"/etc/rc.d/axum-cleandb stop");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand(@"/etc/rc.d/axum-gateway stop");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand(@"/etc/rc.d/axum-address stop");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand("//etc//rc.d//axum-learner stop");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand("//etc//rc.d//axum-engine stop");
            ////    //listBox1.Items.Add(command.Result.ToString());
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand("//etc//rc.d//lighttpd stop");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand("//etc//rc.d//xinetd stop");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");











            ////    var command = client.RunCommand("cp -f /root/.backup /root/.backup.old");
            ////    listBox1.Items.Add(command.Result).ToString();
            ////    command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand("rm /root/.backup");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    command = client.RunCommand("cp -f /var/lib/axum/.backup /root");
            ////    listBox1.Items.Add(command.Result).ToString();
            ////    command = client.RunCommand("sleep 1");

            ////    command = client.RunCommand("cp -f /root/dbaxumall.sql /root/dbaxumall.old");
            ////    listBox1.Items.Add(command.Result).ToString();
            ////    command = client.RunCommand("sleep 1");

            ////    command = client.RunCommand("rm /root/dbaxumall.sql");
            ////    listBox1.Items.Add(command.Result).ToString();
            ////    command = client.RunCommand("sleep 1");

            ////    command = client.RunCommand("echo \"making /root/dbaxumall.sql\"");
            ////    listBox1.Items.Add(command.Result).ToString();
            ////    command = client.RunCommand("sleep 1");

            ////    command = client.RunCommand("echo \"making /root/.backup\"");
            ////    listBox1.Items.Add(command.Result).ToString();
            ////    command = client.RunCommand("sleep 1");

            ////    command = client.RunCommand("pg_dumpall -U postgres -f /root/dbaxumall.sql > /dev/null");
            ////    listBox1.Items.Add(command.Result).ToString();
            ////    command = client.RunCommand("sleep 1");








            ////    //command = client.RunCommand(@"/etc/rc.d/axum-cleandb start");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand(@"/etc/rc.d/axum-gateway start");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand(@"/etc/rc.d/axum-address start");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand("//etc//rc.d//axum-learner start");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand("//etc//rc.d//axum-engine start");
            ////    //listBox1.Items.Add(command.Result.ToString());
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand("//etc//rc.d//lighttpd start");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");

            ////    //command = client.RunCommand("//etc//rc.d//xinetd start");
            ////    //listBox1.Items.Add(command.Result).ToString();
            ////    //command = client.RunCommand("sleep 1");






            ////    // Disconnect from the SSH server
            ////    listBox1.Items.Add("Disconnect").ToString();
            ////    client.Disconnect();
            ////    listBox1.Items.Add("done").ToString();
            ////    enableButtons();

            ////}
        }

        //Restore settings
        private void button2_Click(object sender, EventArgs e)
        {
            disableButtons();
            // Connection info
            string host = ipAdress;
            string username = "root";
            string password = "axum";

            listBox1.Items.Clear();

            // Create a new SSH client
            using (var client = new SshClient(host, username, password))
            {
                listBox1.Items.Add("Please wait").ToString();

                // Connect to the SSH server
                client.Connect();

                var command = client.RunCommand(@"/etc/rc.d/axum-cleandb stop");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand(@"/etc/rc.d/axum-gateway stop");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand(@"/etc/rc.d/axum-address stop");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("//etc//rc.d//axum-learner stop");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("//etc//rc.d//axum-engine stop");
                listBox1.Items.Add(command.Result.ToString());
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("//etc//rc.d//lighttpd stop");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("//etc//rc.d//xinetd stop");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");
                //All processes stopped


                //Now making the backup file's
                command = client.RunCommand("cp -f /root/.backup /var/lib/axum/");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("/usr/bin/dropdb -U postgres axum");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("/usr/bin/psql -U postgres -h 127.0.0.1 -p 5432 < /root/dbaxumall.sql");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");




                command = client.RunCommand(@"/etc/rc.d/axum-cleandb start");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand(@"/etc/rc.d/axum-gateway start");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand(@"/etc/rc.d/axum-address start");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("//etc//rc.d//axum-learner start");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("//etc//rc.d//axum-engine start");
                listBox1.Items.Add(command.Result.ToString());
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("//etc//rc.d//lighttpd start");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");

                command = client.RunCommand("//etc//rc.d//xinetd start");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");




                command = client.RunCommand("reboot");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");


                // Disconnect from the SSH server
                listBox1.Items.Add("reboot").ToString();
                client.Disconnect();
                listBox1.Items.Add("wait till the Axum is started").ToString();
                enableButtons();

            }
        }


        // Download settings
        private void button3_Click(object sender, EventArgs e)
        {
            disableButtons();


            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = " Select Folder";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                folderPath = folderPath + "\\";
                // ...
            }


            listBox1.Items.Clear();
            string remoteFilePath = ".backup";
            downloadSsh(remoteFilePath);
            remoteFilePath = "dbaxumall.sql";
            downloadSsh(remoteFilePath);
            enableButtons();
        }

        private void downloadSsh(string remoteStr)
        {
            const string quote = "\"";
            //const string backSlash = "\\";
            string localFilePath = quote + folderPath + remoteStr + quote;
            string serverAddress = ipAdress;
            string username = "root";
            string password = "axum";

            // Construct the PSCP command
            string pscpCommand = $"pscp -pw {password} {username}@{serverAddress}:{"/root/" + remoteStr} {localFilePath}";

            // Create a new process to run the command
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;

            process.Start();

            // Execute the PSCP command
            process.StandardInput.WriteLine(pscpCommand);
            process.StandardInput.Flush();
            process.StandardInput.Close();

            // Wait for the process to finish
            process.WaitForExit();

            // Check if the file was downloaded successfully
            if (process.ExitCode == 0)
            {
                teller++;
                if (teller < 2)
                    listBox1.Items.Add(teller + " File downloaded successfully.").ToString();
                else
                    listBox1.Items.Add(teller + " File's downloaded successfully.").ToString();
            }
            else
            {
                listBox1.Items.Add("Failed to download the file.").ToString();
            }
        }


        // Connect button
        private void button4_Click(object sender, EventArgs e)
        {
            ipAdress = comboBox1.Text;

            if (ipAdress == "")
            {
                MessageBox.Show("Wrong or missing IP address ");
                return;
            }

            if (connected == false)
            {
                connected = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                listBox1.Items.Add("Connect").ToString();
            }
            else
            {
                MessageBox.Show("for an new or different connection, close it and start the application again ");
            }
        }

        // View SQL datagrid
        private void button5_Click(object sender, EventArgs e)
        {
            disableButtons();
            listBox1.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection("Server=" + ipAdress + "; Port=5432; User Id=axum; Password=axum; Database=axum");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from addresses";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns();
            }
            comm.Dispose();
            conn.Close();
            enableButtons();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            disableButtons();
            listBox1.Items.Clear();
            NpgsqlConnection conn = new NpgsqlConnection("Server=" + ipAdress + "; Port=5432; User Id=axum; Password=axum; Database=axum");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from predefined_node_config";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns();
            }
            comm.Dispose();
            conn.Close();
            enableButtons();
        }

        //-------------------------------------------------------------------------------------------------------------------------
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Title = "Browse File";
            //fileDialog.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            //fileDialog.FilterIndex = 2;
            //fileDialog.InitialDirectory = "c:\\";
            //fileDialog.RestoreDirectory = true;

            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //   //txtFileName.Text = fileDialog.FileName;
            //}

            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                // ...
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
            // datagridOriginalRectangle = new Rectangle(dataGridView1.Location.X, dataGridView1.Location.Y, dataGridView1.Width, dataGridView1.Height);
            //Form f1 = new Form1();
            //f1.Visible = false;
        }




        private void Form1_Resize(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
            dataGridView1.Size = new Size((int)originalFormSize.Width - 450, (int)originalFormSize.Height - 100);
            dataGridView1.AutoResizeColumns();
            //dataGridView1.Size = new Size(300, 500);
        }
        // Upload settings
        private void button8_Click(object sender, EventArgs e)
        {

            disableButtons();
            teller = 0;

            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = " Select Folder";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                folderPath = folderPath + "\\";
                // ...
            }


            listBox1.Items.Clear();
            string remoteFilePath = ".backup";
            uploadSsh(remoteFilePath);
            remoteFilePath = "dbaxumall.sql";
            uploadSsh(remoteFilePath);
            enableButtons();

        }

        //willem tel was here

        // Upload Files
        private void uploadSsh(string remoteStr)
        {
            //const string quote = "\"";
            //const string backSlash = "\\";
            string localFilePath = remoteStr;
            string serverAddress = ipAdress;
            string username = "root";
            string password = "axum";

            // Construct the PSCP command
            //string pscpCommand = $"pscp -pw {password} {username}@{serverAddress}:{"/root/" + remoteStr} {localFilePath}";
            string pscpCommand = $"pscp -pw {password} {username}@{serverAddress}:{localFilePath} {"/root/" + remoteStr}";

            // Create a new process to run the command
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;

            process.Start();

            // Execute the PSCP command
            process.StandardInput.WriteLine(pscpCommand);
            process.StandardInput.Flush();
            process.StandardInput.Close();

            // Wait for the process to finish
            process.WaitForExit();

            // Check if the file was downloaded successfully
            if (process.ExitCode == 0)
            {
                teller++;
                if (teller < 2)
                    listBox1.Items.Add(teller + " File uploaded successfully.").ToString();
                else
                    listBox1.Items.Add(teller + " File's uploaded successfully.").ToString();
            }
            else
            {
                listBox1.Items.Add("Failed to upload the file.").ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            disableButtons();
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

                var command = client.RunCommand("rm /var/log/*.log*");
                listBox1.Items.Add(command.Result).ToString();
                command = client.RunCommand("sleep 1");
                listBox1.Items.Add("/var/log Log files deleted").ToString();

                // Disconnect from the SSH server
                listBox1.Items.Add("Disconnect").ToString();
                client.Disconnect();
                listBox1.Items.Add("done").ToString();
                enableButtons();

            }
        }

        // Screen timeout
        private void button10_Click(object sender, EventArgs e)
        {
            // Screen timeout
        }
    }
}
