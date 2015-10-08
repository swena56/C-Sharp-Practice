using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//powershell

using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace C_Sharp_Practice
{
    public class FileOperations
    {
        public FileOperations()
        {
            Console.WriteLine("FileOperations constructor");
           // runPowerShellCommand();
            //getShellWithPowerShell();
        }

        private void runPowerShellCommand()
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = runspace;
                ps.AddScript("Get-Process");
                var results = ps.Invoke();
                // Do something with result ... 
                
                foreach (var result in results)
                {
                    var process = (System.Diagnostics.Process)result.BaseObject;
                    Console.WriteLine(process.Id);
                    Console.WriteLine(process.ProcessName);
                    Console.WriteLine(process.PrivateMemorySize64);
                    process.Kill();
                }
            }
            runspace.Close();
        }

        private void runPSremotely(string machineAddress)
        {
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo();
            connectionInfo.ComputerName = machineAddress;
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            runspace.Open();
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = runspace;
                ps.AddScript("Get-Service");
                var results = ps.Invoke();
                // Do something with result ... 
            }
            runspace.Close();
        }

        private void getShellWithPowerShell()
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "C:\\Windows\\System32\\cmd.exe ",
                    Arguments = "ipconfig",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                Console.WriteLine(line);
                // do something with line
            }
        }
    }
}
