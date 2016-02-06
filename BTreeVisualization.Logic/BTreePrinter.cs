using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeVisualization.Logic
{
    public class BTreePrinter<T> where T : IComparable
    {

        public void PrintBTree(BTree<T> tree)
        {
        }
        private void PrintBranch()
        {
            //Queue<BTreeNode<T>> 
        }


        /*

        private void print(BTreeNode<T> node, string prefix, bool isTail)
        {
            Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + node.Value);
            for (int i = 0; i < node.size() - 1; i++)
            {
                children.get(i).print(prefix + (isTail ? "    " : "│   "), false);
            }
            if (children.size() > 0)
            {
                children.get(children.size() - 1).print(prefix + (isTail ? "    " : "│   "), true);
            }
        }
        */
    }
}
