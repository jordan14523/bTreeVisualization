using System;
using System.IO;

namespace BTreeVisualization.Presentation
{
    public class BTreeMenuPrinter
    {
        public static void PrintInputFormat()
        {
            Console.WriteLine("\n\nInput comma seperated integers. Ex: 234,33,343");
        }
        public static void PrintSelectionInputFormat()
        {
            Console.WriteLine("\n\nInput two nodes that exist in the tree for parent finder.");
            Console.WriteLine("Use comma seperated integers. Ex: 234,33");
        }

        public static void PrintParentIndetifier()
        {
            Console.WriteLine("The parent node will be identified by a \"*\".");
            Console.WriteLine("Selected nodes are identified by a \"%\"");
        }

        public static void PrintReadOptions()
        {
            Console.WriteLine("1 - Read from file");
            Console.WriteLine("2 - Input to console");
        }
        public static void PrintParentFinderOptions()
        {
            Console.WriteLine("3 - Find parent node");
        }

        public static void PrintOutOptions()
        {
            Console.WriteLine("4 - Output to console");
            Console.WriteLine("5 - Output to file");
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
