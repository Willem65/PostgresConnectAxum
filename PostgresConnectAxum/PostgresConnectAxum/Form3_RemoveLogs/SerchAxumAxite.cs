
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Renci.SshNet;
using ThreadState = System.Threading.ThreadState;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form3 : Form
    {
        //bool procend = false;

        public  void run()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = @"C:\LogfilesRemoveETCsmallVersion\advanced_ip_scanner_console.exe",
                Verb = "runas", // Run as administrator
                Arguments = "/r:192.168.1.1-192.168.1.255 /f:c:\\TempAxum\\results.txt",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            process.StartInfo = startInfo;
            //process.StartInfo.Arguments(folderPath);
            process.Start();
            process.WaitForExit();
            //if (process.ExitCode == 0)
            //    procend = true;
        }

        public void searchAxumAxite(string ipAdress)
        {


            string host = ipAdress;
            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            textBox1.Clear();


            timer1.Enabled = true;
            Thread tr = new Thread(run);
            tr.Start();

            //tr.ThreadState= 


            if (tr.ThreadState == ThreadState.Background)
            {
                timer1.Enabled = false;
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
                        }
                    }
                }
            }
        }
    }
}
