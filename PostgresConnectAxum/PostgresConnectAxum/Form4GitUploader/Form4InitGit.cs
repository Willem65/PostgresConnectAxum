
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form4
    {

        public void initGit()
        {
            //folderPath = "";
            textBox1.Clear();
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.InitialDirectory = "c:";
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.Title = "Please select now only the folder where you will download the files in it";
            // Always default to Folder Selection.
            folderBrowser.FileName = " Select Folder";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                textBox1.Text = "Please wait";
            }
            else
                return;

            if (folderPath == null)
                return;

            

            string batchFile = ((char)34) + programFilePath + "git-init.bat " + ((char)34);

            //string folderPathM = ((char)34) + folderPath + ((char)34);

            //Process process = new Process();
            //ProcessStartInfo startInfo = new ProcessStartInfo()
            //{
            //    FileName = batchFile,
            //    //FileName = "\"C:\\Program Files\\Git\\git-bash.exe \"" + batchFile,
            //    Verb = "runas", // Run as administrator
            //    Arguments = folderPathM,
            //    //Arguments = "Nieuwe map",
            //    RedirectStandardInput = true,
            //    RedirectStandardOutput = true,
            //    UseShellExecute = false,
            //    RedirectStandardError = true,
            //    CreateNoWindow = false
            //};

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = batchFile,
                Verb = "runas", // Run as administrator
                Arguments = ((char)34) + folderPath + ((char)34),
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                CreateNoWindow = false
            };

            process.StartInfo = startInfo;
            process.Start();


            Thread.Sleep(5000);
            foreach (var node in Process.GetProcessesByName("cmd"))
            {
                node.Kill();
            }

            process.WaitForExit();
            //process.CloseMainWindow();





            string str = process.StandardOutput.ReadToEnd();
            Thread.Sleep(1);
            string output = process.StandardError.ReadToEnd();
            Thread.Sleep(1);
            textBox1.Clear();
            textBox1.Text = (str + "\r\n\r\n" + output + "\r\n\r\n");


        }
    }
}
