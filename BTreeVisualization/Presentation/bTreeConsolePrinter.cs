using System;
using System.IO;

namespace BTreeVisualization.Presentation
{
    public class BTreeConsolePrinter
    {
        public static string ReadFileInput(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadLine();
            }
        }

        public static void PrintInputFormat()
        {
            Console.WriteLine("\n\nInput comma seperated integers. Ex: 234,33,343");
        }

        public static void PrintReadOptions()
        {
            Console.WriteLine("1 - Read from file");
            Console.WriteLine("2 - Input to console");
        }

        public static void PrintExit()
        {
            Console.WriteLine("\nInput \"e\" or exit to exit.");
        }

        public static void PrintOutputOptions()
        {
            Console.WriteLine("1. Output to file");
            Console.WriteLine("2. Output to console");
        }

        public static void PrintUnrecognized()
        {
            Console.WriteLine("Unrecognized option: Type in the number next to the option.");
        }

        public static void PrintHeader()
        {
            Console.WriteLine("\n\n====================================================================");
            Console.WriteLine("BTree Presentation Application");
            Console.WriteLine("Integer values supported only");
            Console.WriteLine("Type in the number next to the desired option:");
        }
    }
}
