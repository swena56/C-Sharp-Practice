using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//powershell
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Diagnostics;
using System.IO;

namespace C_Sharp_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //how to run project hidden
            //right click on project -> properties -> application -> application output -> windowed application
            

            //  ExecuteShellCode shell = new ExecuteShellCode();
            FileOperations file = new FileOperations();

            //TODO set the title of the Console
            Console.WriteLine();
            Console.WriteLine("");
            Console.WriteLine("Console needs -> using System");
            Console.WriteLine("");
            string namespaceComment = " _____ ";
            Console.WriteLine("What is a namespace? {0}", namespaceComment);


            // HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run
            loopingPractice();

            //Start-Process notepad -WindowStyle Hidden
            //Get-Process notepad

            /*

            Console.Write("Enter a number: ");
            string userInput = Console.ReadLine();
            */

            string[] starray = new string[]{"Down the way nights are dark",
         "And the sun shines daily on the mountain top",
         "I took a trip on a sailing ship",
         "And when I reached Jamaica",
         "I made a stop"};

            string str = String.Join("\n", starray);
            Console.WriteLine(str);

            formating();
            drawMenu();
            //what is the datatype

            //int num = int.Parse(userInput);

            Console.ReadKey();  // Console.ReadLine();
        }

        static public void drawMenu()
        {
            Console.Clear();
            Console.WriteLine("Title");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("(0) Exit");
            Console.WriteLine("");
            Console.Write("Please make a selection: ");
            Console.ReadKey();  // Console.ReadLine();

        }

        public void arrayPractice()
        {
            //datatype[] arrayName

            string[] shortcut = new string[1];
            double[] arDouble = { 100.1, 200.5 };
            shortcut[1] = "(Crtl + L) -> cuts a line";

            int[,] a = new int[3, 4]
            {
               {0, 1, 2, 3} ,   /*  initializers for row indexed by 0 */
               {4, 5, 6, 7} ,   /*  initializers for row indexed by 1 */
               {8, 9, 10, 11}   /*  initializers for row indexed by 2 */
            };

            //multidemensional
        }

        public void learingSyntax()
        {
            Console.WriteLine("Key words: ");
            string[] keywords = { "abstract", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "in (generic modifier)", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "out (generic modifier)", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };
            string[,] keywords_definitions = new string[1, 2]
            {
                {"var", " unexplicitly defining a data type for a variable" }
            };
        }

        static public void loopingPractice()
        {
            Console.WriteLine();
            Console.Write("Counting to ten -> ");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        /* Demonstrate string formating*/
        static public void formating()
        {

            Console.WriteLine("Demonstation of right align, enter a string");
            Console.WriteLine("c format: {0:c}", Console.ReadLine());
            //e - scientific representation
            //x - hex format
            Console.WriteLine();
            string formating = "{0,-15} {1,-2} {2,-5}";    //negative numbers right alight, positive numbers left align
            Console.WriteLine(formating, "John Doe", "OH", "45554");

            Console.ReadKey();
        }

        static public void runCommandHidden()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Path.Combine("cmd.exe", "");

            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.CreateNoWindow = true;

            proc.StartInfo.RedirectStandardOutput = true;

            proc.StartInfo.UseShellExecute = false;
            proc.Start();
        }

        static public void addService()
        {
            //sc create <servicename> binpath= "<pathtobinaryexecutable>" [option1] [option2] [optionN]
            //sc create cp2pservice binpath= "C:\Users\Andy2014\Downloads\CollaborativeNotes_Sources\CollaborativeNotesService\bin\Debug\CollaborativeNotesService.exe" start= auto
            //sc create svnserve
            //binpath = "\"C:\Program Files\CollabNet Subversion Server\svnserve.exe\" --service -r \"C:\my repositories\"  "
            //displayname = "Subversion Server" depend = Tcpip start = auto

            //to start
            //sc start cp2pservice
        }

        public void printResources()
        {
            string[] resources = {
                                    "http://www.tutorialspoint.com/csharp/csharp_arrays.htm",
                                    "http://visualstudioshortcuts.com/2015/"
                                 };
        }

    }
}

    
//TODO   what is .NET a consistent object-oriented programming enviroment
//set icon
//p2p


//Notes Monodevelop allows you to use .NET in linux
//Windows store applications
//Windows applications
//Random
// it takes about 700 hours of programming to even be considered employable
//microsoft account

//Literals are numbers or strings typed directly into the source code, aka hardcoded
//int literal 1024
//double literal 3.14
//float literal 3.14F
/*  \0 null,  \a beep, \b backspace, \t tab, \n newline, \f form feed, \r return, \" double quote \' single quote \\ backslash */
//operators methods, indexers, x++ x--, new, +, -, !, ~, ++x, --x, * , / , %, + , - , < , >, <=,>=, ==, =!, &&, ||, =, *=, /=, %= +=,-= ---these are in the correct order of operation

//operands are data elements used as input for operands