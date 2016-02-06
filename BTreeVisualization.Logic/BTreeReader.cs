using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
 