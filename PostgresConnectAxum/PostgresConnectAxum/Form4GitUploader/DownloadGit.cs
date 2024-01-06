
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form4
    {

        public void downloadGit()
        {
            textBox1.Clear();
            OpenFileDialog folderBrowser = new OpenFileDialog();
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

            

            string batchFile = ((char)34) + programFilePath + "git-pull.bat " + ((char)34);


            //Process process = new Process();
            //ProcessStartInfo startInfo = new ProcessStartInfo()
            //{
            //    FileName = batchFile,
            //    Verb = "runas", // Run as administrator
            //    Arguments = folderPath,
            //    RedirectStandardInput = true,
            //    RedirectStandardOutput = true,
            //    UseShellExecute = false,
            //    RedirectStandardError = true,
            //    CreateNoWindow = true
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
            //process.StartInfo.Arguments(folderPath);
            process.Start();
            Thread.Sleep(5000);

            foreach (var node in Process.GetProcessesByName("cmd"))
            {
                node.Kill();
            }

            process.WaitForExit();

            string str = process.StandardOutput.ReadToEnd();
            string output = process.StandardError.ReadToEnd();
            textBox1.Clear();
            textBox1.Text = (str + "\r\n" + output + "\r\n");
        }
    }
}
