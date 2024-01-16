
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Renci.SshNet;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form3 : Form
    {
        
        public void searchAxumAxite(string ipAdress)
        { 
            //disableButtons();
            // Connection info
            string host = ipAdress;
            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            textBox1.Clear();


            ////// string batchFile = @"advanced_ip_scanner_console.exe /r:192.168.1.1-192.168.1.255 /f:c:\TempAxum\results.txt";
            //////string pingOutput = GlobalFunctions.cmdCommandErr(pingCmd);

            //////string batchFile = ((char)34) + programFilePath + "git-private.bat " + ((char)34);
            //////Process process = new Process();
            //////ProcessStartInfo startInfo = new ProcessStartInfo()
            //////{
            //////    FileName = batchFile,
            //////    Verb = "runas", // Run as administrator
            //////    Arguments = ((char)34) + folderPath + ((char)34),
            //////    RedirectStandardInput = true,
            //////    RedirectStandardOutput = true,
            //////    UseShellExecute = false,
            //////    RedirectStandardError = true,

            //////    CreateNoWindow = true
            //////};

            //////Process process = new Process();
            //////ProcessStartInfo startInfo = new ProcessStartInfo()
            //////{
            //////    FileName = batchFile,
            //////    Verb = "runas", // Run as administrator
            //////    Arguments = folderPath,
            //////    RedirectStandardInput = true,
            //////    RedirectStandardOutput = true,
            //////    UseShellExecute = false,
            //////    CreateNoWindow = true
            //////};

            ////Process process = new Process();
            ////ProcessStartInfo startInfo = new ProcessStartInfo()
            ////{
            ////    FileName = @"C:\LogfilesRemoveETCsmallVersion\advanced_ip_scanner_console.exe",
            ////    Verb = "runas", // Run as administrator
            ////    Arguments = "/r:192.168.1.1-192.168.1.255 /f:c:\\TempAxum\\results.txt",
            ////    RedirectStandardInput = true,
            ////    RedirectStandardOutput = true,
            ////    UseShellExecute = false,
            ////    RedirectStandardError = true,
            ////    CreateNoWindow = true
            ////};

            ////process.StartInfo = startInfo;
            //////process.StartInfo.Arguments(folderPath);
            ////process.Start();

            //////Thread.Sleep(5000);
            //////foreach (var node in Process.GetProcessesByName("cmd"))
            //////{
            //////    node.Kill();
            //////}

            ////process.WaitForExit();

            ////string str = process.StandardOutput.ReadToEnd();
            ////Thread.Sleep(1);
            ////string output = process.StandardError.ReadToEnd();
            ////Thread.Sleep(1);
            ////textBox1.Clear();
            ////textBox1.Text = (str + "\r\n" + output + "\r\n");
            ///

            string readFile = File.ReadAllText("C:\\TempAxum\\results.txt");
            int pos1 = readFile.IndexOf("PCS") - 50;
            //string searchText = readFile.Substring(pos1, 16).Trim();
            //int pos2 = searchText.IndexOf("\"");
            //File.WriteAllText("C:\\TempAxum\\results.txt", File.ReadAllText("C:\\TempAxum\\results.txt").Remove(pos1, pos2));
            //File.WriteAllText("C:\\TempAxum\\results.txt", File.ReadAllText("C:\\TempAxum\\results.txt").Insert(pos1, textBox1.Text.Trim()));

            //string readFile = File.ReadAllText("C:\\TempAxum\\results.txt");

            if (readFile.Contains("PCS"))
                textBox1.AppendText(readFile.Substring(pos1, 150));



            //textBox1.AppendText(result.ToString());


        }
    }
}
