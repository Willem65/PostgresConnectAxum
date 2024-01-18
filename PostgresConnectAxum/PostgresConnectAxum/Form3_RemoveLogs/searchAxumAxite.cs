using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Renci.SshNet;
using ThreadState = System.Threading.ThreadState;


namespace PostgresConnectAxum
{
    public partial class searchAxumAxite : Form 
    {
        BackgroundWorker bgWorker = new BackgroundWorker();
        string comb1;
        string comb2;

        public searchAxumAxite()
        {
            InitializeComponent();
            comb1 = comboBox1.Text = "192.168.0.1";
            comb2 = comboBox2.Text = "192.168.0.1";
        }


        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            //Perform the background work here
            //This code will run on a separate background thread
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = @"C:\LogfilesRemoveETCsmallVersion\advanced_ip_scanner_console.exe",
                Verb = "runas", // Run as administrator                
                Arguments = "/r:" + comb1 + "-" + comb2 + " /f:c:\\TempAxum\\results.txt",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox1.AppendText("\r\n\r\n");
            bool flag = false;

            // The background work is finished, handle any necessary tasks here
            foreach (var line in System.IO.File.ReadAllLines("C:\\TempAxum\\results.txt"))
            {
                if (line.Contains("PCS"))
                {
                    if (line.Contains("alive"))
                    {
                        string[] parts = line.Split(new[] { '|' });
                        textBox1.AppendText(parts[4].Trim() + " <----------- Axum Rack Engine\r\n");
                        textBox1.AppendText(parts[7].Trim() + " \r\n");
                        textBox1.AppendText(parts[8].Trim() + "\r\n\r\n");
                        flag = true;
                    }
                }
                if (line.Contains("ICP"))
                {
                    if (line.Contains("alive"))
                    {
                        string[] parts = line.Split(new[] { '|' });
                        textBox1.AppendText(parts[4].Trim() + " <----------- Axum Surface \r\n");
                        textBox1.AppendText(parts[7].Trim() + " \r\n");
                        textBox1.AppendText(parts[8].Trim() + "\r\n\r\n");
                        flag = true;
                    }
                }
            }
            if (flag == false)
            {
                textBox1.Text = "No engine found \r\n";
            }
            //MessageBox.Show("Background thread finished");
            
            timer1.Enabled = false;
        }

        public void searchAxumAxit(string ipAdress)
        {
            string host = ipAdress;
            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            // Event handler for the background work
            bgWorker.DoWork += BgWorker_DoWork;

            // Event handler for work completion
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            textBox1.Clear();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.AppendText("#");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comb1 = comboBox1.Text;
            comb2 = comboBox2.Text;
            bgWorker.RunWorkerAsync();
            textBox1.Clear();
            textBox1.Font = new Font("courier", 11);
            textBox1.ForeColor = System.Drawing.Color.DarkRed;
            textBox1.AppendText("");
            textBox1.AppendText(" \r\n");
            textBox1.AppendText("Please wait it is now searching for Axum / Axite rack and UI surfaceses, between IP range " + comb1 + " and " + comb2 + " --->> ");
            timer1.Enabled = true;
        }
    }
}
