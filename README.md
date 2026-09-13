 Gemini
Nieuw gesprek
Zoeken in gesprekken
Afbeeldingen
Video's
Bibliotheek
Nieuwe notebook
Arduino Code Refactoring and Consolidation
ESP32 Project README en Pinout
Testbeeld Genereren: Beschrijving of Afbeelding
GitHub README generator voor C# toepassing
README.md generatie voor C++ Ember+ client
README.md genereren voor EmberPlusWinForms
NICAM 728 Project GitHub READMEs
Windows 10 in VirtualBox op Ubuntu
SVG-editors voor Ubuntu Linux
Maatwerk Bril Met Dubbele Leessterkte
Mappen zippen in Linux
Xmega Flash Uitlezen Oplossen
Succesvolle AVRdude PDI-verbinding met Xmega
Snellere Ubuntu Bestandsbeheerders Alternatieven
Pico ATxmega Programmer Storing Oplossen
Clarifying the Meaning of RaceCon
TeamViewer op Ubuntu Linux
Waarschuwing voor phishing bij creditcardverificatie
Volkswagen Polo Alarm door Interieurbewaking
Eenvoudig ATxmega128A4U Programmeren Alternatief
Beste dunne Samsung Flip 7 hoesjes
Alternatieve route overwegen
Android SDR Streams Beluisteren
EchoLink Alternatieven voor Zendamateurs
RT-950 Morse Code Call Sign Uitzenden
Trillend Oor: Oorzaken en Oplossingen
Foto's lokaal opslaan, niet Google Drive
Zoeken Naar Specifiek Testbeeld
Radtel RT-950 Nederlandse Repeaters
Nederlandse Radio Zendamateur Repeaters 2026
RT950: Piep en Spraak Uitzetten
Samsung Meldingen: Kort of Now Brief
Wat is een software wrapper?
Portofoon: Bajeton BJ-9000 vs RT-950 Pro
CMake en SDK: Bouwproces Uitleg
Frequentie Instellen Per Digit GRC
Wat impliciet betekent: een uitleg
Hulp Vragen Na Begrip
Hulp Gevraagd Na Akkoord
Vertaling van SDR-document naar Nederlands
GMSK Modulator: Praktische Implementaties
PCM over UDP Sample Rate Fix
Activiteit
Landsmeer, Nederland Op basis van jouw plaatsen (Thuis) Locatie updaten
Gesprek met Gemini

genereer een readme.md inhoud voor dit voor op github : ﻿using System;

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

Het README.md bestand voor GitHub is gegenereerd.
MD-icoon
README
 MD 
Inhoud van README.md
Markdown

# PostgresConnectAxum

**PostgresConnectAxum** is een C# Windows Forms-toepassing (.NET) ontworpen voor het beheren, maken van back-ups, herstellen en uitlezen van configuratie- en databasedata van een **Axum** digitaal audiomengpaneel / netwerksysteem (Linux-gebaseerde controller node).

De applicatie maakt gebruik van **SSH** en **PostgreSQL (Npgsql)** om op afstand beheer- en onderhoudstaken uit te voeren op het Axum-systeem.

---

## 📸 Functionaliteiten

- **Remote SSH Beheer (`Renci.SshNet`)**:
  - **Automated Service Management**: Het gecontroleerd stoppen en starten van Axum-systeemdiensten (`axum-engine`, `axum-gateway`, `axum-address`, `axum-learner`, `axum-cleandb`, `lighttpd`, `xinetd`).
  - **Back-up genereren**: Het aanmaken van database dumps (`pg_dumpall`) en het opslaan van systeembestanden (`/var/lib/axum/.backup`).
  - **Systeemherstel & Reboot**: Automatisch herstellen van de SQL-database en configuratiebestanden met een aansluitende systeem-reboot.
  - **Logbestand Onderhoud**: Het opschonen van oude logbestanden (`/var/log/*.log*`).

- **Bestandsoverdracht (Upload / Download via PSCP)**:
  - Downloaden van `.backup` en `dbaxumall.sql` naar een lokale map op de PC.
  - Uploaden van lokale back-upbestanden rechtstreeks naar het Axum-systeem.

- **Directe PostgreSQL Database Inzage (`Npgsql`)**:
  - Rechtstreekse SQL-verbinding met de PostgreSQL database op poort 5432.
  - Direct uitlezen en weergave van tabellen in een `DataGridView`, waaronder:
    - `addresses` (IP-/netwerkadressen)
    - `predefined_node_config` (Vooraf ingestelde node-configuraties)

---

## 🛠️ Vereisten & Afhankelijkheden

### Ontwikkelomgeving
- **Framework**: .NET Framework 4.7.2+ of .NET 6.0/8.0 Windows Desktop Runtime
- **IDE**: Visual Studio 2019 / 2022

### NuGet Packages
- **[Npgsql](https://www.nuget.org/packages/Npgsql/)**: Voor de PostgreSQL databaseverbinding.
- **[SSH.NET](https://www.nuget.org/packages/SSH.NET/) (`Renci.SshNet`)**: Voor het uitvoeren van SSH-commando's op het Linux-systeem.

### Externe Tools
- **`pscp.exe`** (PuTTY Secure Copy Client): Zorg ervoor dat `pscp` aanwezig is in het Windows PATH of de uitvoeringsmap van de applicatie voor de bestandsoverdracht via SCP/SFTP.

---

## 📋 Standaard Inlog- & Netwerkgegevens

De applicatie maakt standaard gebruik van de volgende systeeminstellingen (aanpasbaar in de broncode):

| Parameter | Standaardwaarde |
| :--- | :--- |
| **SSH Gebruiker** | `root` |
| **SSH Wachtwoord** | `axum` |
| **PostgreSQL Database** | `axum` |
| **PostgreSQL Gebruiker** | `axum` / `postgres` |
| **PostgreSQL Wachtwoord**| `axum` |
| **PostgreSQL Poort** | `5432` |

---

## 🚀 Gebruiksaanwijzing

1. **Verbinden**:
   - Vul het IP-adres van het Axum-systeem in (of kies uit de ComboBox) en klik op **Connect**.
2. **Back-up Maken**:
   - Klik op de back-upknop om de actieve services stop te zetten, een database-dump te maken en de configuratie op te slaan.
3. **Instellingen Downloaden / Uploaden**:
   - Selecteer een lokale doelmap om de bestanden `.backup` en `dbaxumall.sql` op te halen of te uploaden via PSCP.
4. **Data Inzien**:
   - Klik op de gewenste knop (bijv. *View Addresses* of *Node Config*) om de live gegevens in de DataGridView te laden.
5. **Herstellen**:
   - Voer een restore uit om de `dbaxumall.sql` terug te zetten in PostgreSQL waarna het Axum-systeem herstart.

---

## 📄 Licentie

Dit project is gelicenseerd onder de MIT-licentie. Zie het `LICENSE` bestand voor meer informatie.


Gemini is AI en kan fouten maken, ook over mensen. Jouw privacy en GeminiOpent in een nieuw venster
Analyseren

# PostgresConnectAxum

**PostgresConnectAxum** is een C# Windows Forms-toepassing (.NET) ontworpen voor het beheren, maken van back-ups, herstellen en uitlezen van configuratie- en databasedata van een **Axum** digitaal audiomengpaneel / netwerksysteem (Linux-gebaseerde controller node).

De applicatie maakt gebruik van **SSH** en **PostgreSQL (Npgsql)** om op afstand beheer- en onderhoudstaken uit te voeren op het Axum-systeem.

---

## 📸 Functionaliteiten

- **Remote SSH Beheer (`Renci.SshNet`)**:
  - **Automated Service Management**: Het gecontroleerd stoppen en starten van Axum-systeemdiensten (`axum-engine`, `axum-gateway`, `axum-address`, `axum-learner`, `axum-cleandb`, `lighttpd`, `xinetd`).
  - **Back-up genereren**: Het aanmaken van database dumps (`pg_dumpall`) en het opslaan van systeembestanden (`/var/lib/axum/.backup`).
  - **Systeemherstel & Reboot**: Automatisch herstellen van de SQL-database en configuratiebestanden met een aansluitende systeem-reboot.
  - **Logbestand Onderhoud**: Het opschonen van oude logbestanden (`/var/log/*.log*`).

- **Bestandsoverdracht (Upload / Download via PSCP)**:
  - Downloaden van `.backup` en `dbaxumall.sql` naar een lokale map op de PC.
  - Uploaden van lokale back-upbestanden rechtstreeks naar het Axum-systeem.

- **Directe PostgreSQL Database Inzage (`Npgsql`)**:
  - Rechtstreekse SQL-verbinding met de PostgreSQL database op poort 5432.
  - Direct uitlezen en weergave van tabellen in een `DataGridView`, waaronder:
    - `addresses` (IP-/netwerkadressen)
    - `predefined_node_config` (Vooraf ingestelde node-configuraties)

---

## 🛠️ Vereisten & Afhankelijkheden

### Ontwikkelomgeving
- **Framework**: .NET Framework 4.7.2+ of .NET 6.0/8.0 Windows Desktop Runtime
- **IDE**: Visual Studio 2019 / 2022

### NuGet Packages
- **[Npgsql](https://www.nuget.org/packages/Npgsql/)**: Voor de PostgreSQL databaseverbinding.
- **[SSH.NET](https://www.nuget.org/packages/SSH.NET/) (`Renci.SshNet`)**: Voor het uitvoeren van SSH-commando's op het Linux-systeem.

### Externe Tools
- **`pscp.exe`** (PuTTY Secure Copy Client): Zorg ervoor dat `pscp` aanwezig is in het Windows PATH of de uitvoeringsmap van de applicatie voor de bestandsoverdracht via SCP/SFTP.

---

## 📋 Standaard Inlog- & Netwerkgegevens

De applicatie maakt standaard gebruik van de volgende systeeminstellingen (aanpasbaar in de broncode):

| Parameter | Standaardwaarde |
| :--- | :--- |
| **SSH Gebruiker** | `root` |
| **SSH Wachtwoord** | `axum` |
| **PostgreSQL Database** | `axum` |
| **PostgreSQL Gebruiker** | `axum` / `postgres` |
| **PostgreSQL Wachtwoord**| `axum` |
| **PostgreSQL Poort** | `5432` |

---

## 🚀 Gebruiksaanwijzing

1. **Verbinden**:
   - Vul het IP-adres van het Axum-systeem in (of kies uit de ComboBox) en klik op **Connect**.
2. **Back-up Maken**:
   - Klik op de back-upknop om de actieve services stop te zetten, een database-dump te maken en de configuratie op te slaan.
3. **Instellingen Downloaden / Uploaden**:
   - Selecteer een lokale doelmap om de bestanden `.backup` en `dbaxumall.sql` op te halen of te uploaden via PSCP.
4. **Data Inzien**:
   - Klik op de gewenste knop (bijv. *View Addresses* of *Node Config*) om de live gegevens in de DataGridView te laden.
5. **Herstellen**:
   - Voer een restore uit om de `dbaxumall.sql` terug te zetten in PostgreSQL waarna het Axum-systeem herstart.

---

## 📄 Licentie

Dit project is gelicenseerd onder de MIT-licentie. Zie het `LICENSE` bestand voor meer informatie.

README.md
README.md weergeven.
