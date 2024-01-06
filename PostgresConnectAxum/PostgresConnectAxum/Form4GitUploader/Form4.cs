using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgresConnectAxum
{
    public partial class Form4 : Form
    {
        string creationTime;
        string folderPath;

        //string output;
        static string programFilePat = Directory.GetCurrentDirectory();
        static string programFilePath = programFilePat + "\\";

        public Form4()
        {
            InitializeComponent();
            Assembly execAssembly = Assembly.GetExecutingAssembly();
            creationTime = new FileInfo(execAssembly.Location).LastAccessTime.ToString("ddMMyyyy");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            initGit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            downloadGit();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uploadGit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addIgnore();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            readmefile();
        }

        // Use cmd
        private void button10_Click(object sender, EventArgs e)
        {
            string strCmdText;
            //For Testing
            strCmdText = "/K cd " + folderPath;

            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GitPublic();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Font = new Font("new courier", 11);
            textBox1.ForeColor = System.Drawing.Color.DarkRed;
            textBox1.AppendText("\r\n");
            textBox1.AppendText("\r\nWith this utility, you can download and upload to GIT.\r\n\r\n");
            textBox1.AppendText("\r\n");
            textBox1.AppendText("You have to install GitHub CLI tool  https://www.techielass.com/create-a-new-github-repository-from-the-command-line/\r\n");
            textBox1.AppendText("\r\n");
            textBox1.AppendText("You have to add the gh.exe location and git.exe location into your path environment.\r\n");
            textBox1.AppendText("");
            textBox1.AppendText("");
            textBox1.AppendText("");
            textBox1.AppendText("");
            textBox1.AppendText("");
            textBox1.AppendText("");
            textBox1.AppendText("");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result;

            button7.BackColor = Color.Red;
            result = MessageBox.Show("Are you sure to delete repository", "Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                button7.BackColor = default(Color);
                deleteRepo();
            }
            else if (result == DialogResult.No)
            {
                button7.BackColor = default(Color);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            authoriZe();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            privateGit();
        }



        private void Form4_Activated(object sender, EventArgs e)
        {
            Form4.ActiveForm.Text = "Backup and restore v" + creationTime;
        }


    }
}
