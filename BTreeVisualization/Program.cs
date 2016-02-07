using BTreeVisualization.Logic;
using BTreeVisualization.Presentation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static BTreeVisualization.Presentation.BTreeMenuPrinter;

namespace BTreeVisualization
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            BTree<int> tree = null;

            while (!exit)
            {
                PrintHeader();
                PrintReadOptions();
                if (tree != null)
                {
                    PrintParentFinderOptions();
                    PrintOutOptions();
                }
                PrintExit();

                string input = Console.ReadLine();

                switch (input.Trim().ToLower())
                {
                    case "1":
                        tree = ReadFile();
                        break;
                    case "2":
                        tree = ReadFromConsole();
                        break;
                    case "3":
                        if (tree != null)
                        {
                            NodeSelection(tree);
                        }
                        else
                        {
                            PrintUnrecognized();
                        }
                        break;
                    case "4":
                        if (tree != null)
                        {
                            PrintToConsole(tree);                            
                        }
                        else
                        {
                            PrintUnrecognized();
                        }
                        break;
                    case "5":
                        if (tree != null)
                        {
                            PrintToFile(tree);
                        }
                        else
                        {
                            PrintUnrecognized();
                        }
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

        public static void PrintToConsole(BTree<int> tree)
        {
            Console.WriteLine("\n\nPrinting to Console.");
            PrintParentIndetifier();
            ConsolePrinter printer = new ConsolePrinter();
            BTreePrinter<int> treePrinter = new BTreePrinter<int>(printer);

            treePrinter.PrintBTree(tree);
        }

        public static void PrintToFile(BTree<int> tree)
        {
            Console.WriteLine("\n\nPrinting to file.");
            PrintParentIndetifier();
            string outPath = GetWorkingDirPath("output.txt");

            try
            {
                using (FilePrinter printer = new FilePrinter(outPath))
                {
                    BTreePrinter<int> treePrinter = new BTreePrinter<int>(printer);
                    treePrinter.PrintBTree(tree);
                    Console.WriteLine("Wrote to file at {0}", outPath);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error writing to file, make sure the file {0} is available for writing.", outPath);
            }
        }

        public static void NodeSelection(BTree<int> tree)
        {
            tree.ClearSelected();
            PrintSelectionInputFormat();
            string input = Console.ReadLine();

            try
            {
                Queue<int> values = BTreeReader.ReadParentFinderInput(input);
                BTreeOperations<int> treeOps = new BTreeOperations<int>();
                BTreeNode<int> parent = treeOps.ParentFinder(tree, new BTreeNode<int>(values.Dequeue()), new BTreeNode<int>(values.Dequeue()));
                if (parent != null)
                {
                    Console.WriteLine("Parent value of {0} has been found.", parent.Value);
                }
                else
                {
                    Console.WriteLine("Parent value was not found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading input for parent finder, recheck input.");
                Console.WriteLine("Details: {0}", e.Message);
            }            
        }

        private static BTree<int> ReadFromConsole()
        {
            BTree<int> tree = new BTree<int>();
            PrintInputFormat();
            string input = Console.ReadLine();

            try
            {
                BTreeReader.ReadInputIntoTree(tree, input);
                Console.WriteLine("Successfully read into tree");
                return tree;
            }
            catch (Exception)
            {
                Console.WriteLine("Error reading into tree, recheck input.");
                return null;
            }
            
        }

        private static BTree<int> ReadFile()
        {
            BTree<int> tree = new BTree<int>();
            string inputPath = GetWorkingDirPath("input.txt");
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
                return null;
            }
            
            Console.WriteLine("Successfully read into tree");
            return tree;
        }
        private static string ReadFileInput(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadLine();
            }
        }

        private static string GetWorkingDirPath(string filename)
        {
            string currDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(currDir, filename);
        }
    }
}
