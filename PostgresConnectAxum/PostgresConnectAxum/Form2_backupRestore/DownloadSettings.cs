
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form2
    {
        string output;
        

        public void DownloadSettings(string ipAdress)
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
                folderPath = folderPath + "\\";
            }

            textBox1.Clear();
            string remoteFilePath = ".backup";
            downloadSsh(remoteFilePath, ipAdress);
            remoteFilePath = "dbaxumall.sql";
            downloadSsh(remoteFilePath, ipAdress);

            folderPath = ((char)34) + folderPath + ((char)34);

            output = GlobalFunctions.cmdCommandOutput("dir " + folderPath + "*\r\n");

            if (output.Contains(".backup") && output.Contains("dbaxumall.sql"))
            {
                textBox1.AppendText("files ( .backup and dbaxumall.sql ) are located in " + folderPath + "\r\n\r\n");
                int end = 0;
                int start = output.IndexOf("Directory ", end) + 20;
                end = output.IndexOf("free", start);
                string otherPart = output.Substring(start + 4, end - start);
                textBox1.AppendText(otherPart);
                textBox1.AppendText("\n\r\n\r\n\rDownloading done");
            }
        }

        public void downloadSsh(string remoteStr, string ipAdress)
        {
            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            const string quote = "\"";
            string localFilePath = quote + folderPath + remoteStr + quote;
            string serverAddress = ipAdress;

            // Construct the PSCP command
            string pscpCommand = $"pscp -pw {password} {username}@{serverAddress}:{"/root/" + remoteStr} {localFilePath}";

            GlobalFunctions.cmdCommandOutput(pscpCommand);
        }       
    }
}
