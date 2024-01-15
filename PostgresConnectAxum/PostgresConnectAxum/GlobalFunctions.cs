
using System.Diagnostics;


namespace PostgresConnectAxum
{
    class GlobalFunctions 
    {
        // voor een opdracht uit op de cmd command prompt van windows.
        public static string cmdCommandOutput(string command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;

            p.Start();

            // Pass the command to the command prompt and execute it
            p.StandardInput.WriteLine(command);
            p.StandardInput.Flush();
            p.StandardInput.Close();

            // Read the output content
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            return output;
        }

        public static string commandGitOutput(string command)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files\Git\git-cmd.exe";
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;

            p.Start();

            // Pass the command to the command prompt and execute it
            p.StandardInput.WriteLine(command);
            p.StandardInput.Flush();
            p.StandardInput.Close();

            // Read the output content
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            return output;
        }

        public static string cmdCommandErr(string command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;

            p.Start();

            // Pass the command to the command prompt and execute it
            p.StandardInput.WriteLine(command);
            p.StandardInput.Flush();
            p.StandardInput.Close();

            // Read the output content
            string output = p.StandardError.ReadToEnd();
            p.WaitForExit();

            return output;
        }

        //public static string cmdCommandInput(string command)
        //{
        //    Process p = new Process();
        //    p.StartInfo.FileName = "cmd.exe";
        //    p.StartInfo.RedirectStandardInput = true;
        //    p.StartInfo.RedirectStandardOutput = true;
        //    p.StartInfo.CreateNoWindow = true;
        //    p.StartInfo.UseShellExecute = false;
        //    p.StartInfo.RedirectStandardInput = true;

        //    p.Start();

        //    // Pass the command to the command prompt and execute it
        //    p.StandardInput.WriteLine(command);
        //    p.StandardInput.Flush();
        //    p.StandardInput.Close();

        //    // Read the output content
        //    string output = p.StandardInput.();
        //    p.WaitForExit();

        //    return output;
        //}


    }
}
