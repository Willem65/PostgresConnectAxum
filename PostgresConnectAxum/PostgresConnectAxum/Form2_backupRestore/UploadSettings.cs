
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PostgresConnectAxum
{
    //class Backup
    public partial class Form2
    {
        // Upload settings
        public void upLoadSettings(string ipAdress)
        {
            textBox1.Clear();
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.Title = "Please select now only the folder where the upload files (.backup  and  dbaxumall.sql) are located";
            // Always default to Folder Selection.
            folderBrowser.FileName = " Select Folder";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                folderPath = folderPath + "\\";
            }
            textBox1.Clear();
            textBox1.AppendText("Please wait, uploading the files \r\n");
            textBox1.AppendText("\r\n");
            string remoteFilePath = ".backup";
            uploadSsh(remoteFilePath, ipAdress);
            remoteFilePath = "dbaxumall.sql";
            uploadSsh(remoteFilePath, ipAdress);
            textBox1.AppendText("done \r\n\r\n");
            textBox1.AppendText("To make the axum run on this uploaded files, you have to click on Restore Settings \r\n\r\n");
        }

        // Upload Files
        private void uploadSsh(string remoteStr, string ipAdress)
        {
            string localFilePath = folderPath + remoteStr;
            string serverAddress = ipAdress;

            localFilePath = ((char)34) + localFilePath + ((char)34);

            string username = GlobalVariables.uStr;
            string password = GlobalVariables.pStr;

            string pscpCommand = $"pscp -pw {password} {localFilePath} {username}@{serverAddress}:{"/root"}";

            string respons = GlobalFunctions.cmdCommandErr(pscpCommand);

            if (respons != "")
                textBox1.AppendText(respons + "Please select the right folder where the file is located.\r\n\r\n");
        }
    }
}
