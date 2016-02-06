using BTreeVisualization.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BTreeVisualization.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            BTree<int> tree = new BTree<int>();

            while (!exit)
            {
                PrintHeader();
                PrintReadOptions();
                PrintExit();
                var input = Console.ReadLine();

                switch (input.Trim().ToLower())
                {
                    case "1": 
                        ReadFile(tree);
                        break;
                    case "2":
                        ReadFromConsole(tree);
                        break;
                    case "e":
                    case "exit":
                        exit = true;
                        break;
                    default:
                        PrintUnrecognized();
                    break;
                }
            }
            
        }

        private static void ReadFromConsole(BTree<int> tree)
        {
            PrintInputFormat();
            string input = Console.ReadLine();

            try
            {
                BTreeReader.ReadInputIntoTree(tree, input);
                Console.WriteLine("Successfully read into tree");
            }
            catch (Exception)
            {
                Console.WriteLine("Error reading into tree, recheck input.");
            }
            
        }

        private static void ReadFile(BTree<int> tree)
        {
            string currDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string inputPath = Path.Combine(currDir, "input.txt");
            PrintInputFormat();
            Console.WriteLine("Reading from filepath:\n{0}\n...", inputPath);
            string input = ReadFileInput(inputPath);

            try
            {
                BTreeReader.ReadInputIntoTree(tree, input);
            }
            catch (Exception)
            {
                Console.WriteLine("Error reading into tree, recheck input. Make sure file is in the correct path.");
            }
            
            Console.WriteLine("Successfully read into tree");
        }

        private static string ReadFileInput(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadLine();   
            }
        }

        private static void PrintInputFormat()
        {
            Console.WriteLine("\n\nInput comma seperated integers. Ex: 234,33,343");
        }

        private static void PrintReadOptions()
        {
            Console.WriteLine("1 - Read from file");
            Console.WriteLine("2 - Input to console");
        }

        private static void PrintExit()
        {
            Console.WriteLine("\nInput \"e\" or exit to exit.");
        }

        public static void PrintOutputOptions()
        {
            Console.WriteLine("1. Output to file");
            Console.WriteLine("2. Output to console");
        }

        private static void PrintUnrecognized()
        {
            Console.WriteLine("Unrecognized option: Type in the number next to the option.");
        }
        private static void PrintHeader()
        {
            Console.WriteLine("\n\n====================================================================");
            Console.WriteLine("BTree Presentation Application");
            Console.WriteLine("Integer values supported only");
            Console.WriteLine("Type in the number next to the desired option:");
        }
    }
}
