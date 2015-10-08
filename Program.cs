using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learing C# and the .NET Framework");
            Console.WriteLine("");
            Console.WriteLine("Console needs -> using System");
            Console.WriteLine("");
            Console.WriteLine("What is a namespace?");
            
            loopingPractice();
            Console.ReadKey();  // Console.ReadLine();
        }

        public void arrayPractice()
        {
            //datatype[] arrayName
            
            string[] shortcut = new string[1];
            double[] arDouble = { 100.1, 200.5 };
            shortcut[1] = "(Crtl + L) -> cuts a line";


            
            //multidemensional
        }

        public void learingSyntax()
        {
            Console.WriteLine("Key words: ");
            string[] keywords = { "abstract", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "in (generic modifier)", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "out (generic modifier)", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };
        }

        static public void loopingPractice()
        {
            Console.WriteLine();
            Console.Write("Counting to ten -> ");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
        }


        public void formating() { }

        /*
        */
        public void printResources()
        {
            string[] resources = { "http://www.tutorialspoint.com/csharp/csharp_arrays.htm" };
        }
    }
    //Random
    // it takes about 700 hours of programming to even be considered employable
    //microsoft account

}


//TODO   what is .NET a consistent object-oriented programming enviroment
//Notes Monodevelop allows you to use .NET in linux
//Windows store applications
//Windows applications
