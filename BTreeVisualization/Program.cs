using BTreeVisualization.Logic;
using System;
using System.IO;
using System.Reflection;
using static BTreeVisualization.Presentation.BTreeConsolePrinter;

namespace BTreeVisualization
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

    }
}
