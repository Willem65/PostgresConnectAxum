using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;



namespace PostgresConnectAxum
{
    public partial class Form3UserPass : Form 
    {
        public Form3UserPass()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            GlobalVariables.uStr = textBox1.Text;
            GlobalVariables.pStr = textBox2.Text;

            if (passOke())
            {
                GlobalVariables.isValid = true;
                this.Dispose();               
            }
            else
            {
                //MessageBox.Show("Wrong username or password");
                Application.Exit();
                Thread.Sleep(200);
                Process.GetCurrentProcess().Kill();
            }
        }

        private bool passOke()
        {
            string ipAdress = GlobalVariables.ipAddressStr;
            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            string command = $"echo y | pscp -pw {password} {username}@{ipAdress}:{"/root/ test"}";

            string output = "";
            if (command != null)
                output = GlobalFunctions.cmdCommandOutput(command);

            // Check if the password is valid
            bool isValidPassword = !output.Contains("password");

            if (isValidPassword == false)
            {
                //MessageBox.Show("Invalid Password");
                var Form3UserPass = new Form3UserPass();
                Form3UserPass.Show();
            }
            return isValidPassword;
        }
       
        public void Form3UserPass_Deactivate(object sender, EventArgs e)
        {
            Form3.instance.but1.Enabled = true;
            Form3.instance.but2.Enabled = true;
            Form3.instance.but3.Enabled = true;
        }
    }
}
