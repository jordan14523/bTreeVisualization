using System;
using System.Collections.Generic;
using System.Text;

namespace BTreeVisualization.Logic
{
    public class BTreeReader
    {
        public static void ReadInputIntoTree(BTree<int> tree, string input)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];

                //check for comma seperated value
                if ((currentChar == ','))
                {
                    tree.Insert(Int32.Parse(builder.ToString()));
                    builder.Clear();
                }
                else
                {
                    builder.Append(currentChar);
                }
                if (i == (input.Length - 1))
                {
                    tree.Insert(Int32.Parse(builder.ToString()));
                }
            }
        }

        public static Queue<int> ReadParentFinderInput(string input)
        {
            Queue<int> nodeValues = new Queue<int>();
            int expectedCount = 2;

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];

                //check for comma seperated value
                if ((currentChar == ','))
                {
                    CountCheck(nodeValues, expectedCount);
                    nodeValues.Enqueue(Int32.Parse(builder.ToString()));
                    builder.Clear();
                }
                else
                {
                    builder.Append(currentChar);
                }
                if (i == (input.Length - 1))
                {
                    CountCheck(nodeValues, expectedCount);
                    nodeValues.Enqueue(Int32.Parse(builder.ToString()));
                }
            }
            if (nodeValues.Count == expectedCount)
            {
                return nodeValues;
            }

            else
            {
                throw new ArgumentException("Not enough nodes for Parent Finder.");
            }

        }

        private static void CountCheck(Queue<int> nodeValues, int max)
        {
            if (nodeValues.Count > max -1)
            {
                throw new ArgumentException("Inputed too many nodes to Parent Finder.");
            }
        }
    }
}
 