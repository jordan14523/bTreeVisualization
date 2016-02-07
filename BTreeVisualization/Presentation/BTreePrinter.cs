using BTreeVisualization.Logic;
using System;
using BTreeVisualization.Interfaces;

namespace BTreeVisualization.Presentation
{
    public class BTreePrinter<T> where T : IComparable
    {
        private IPrinter _printer;

        public BTreePrinter(IPrinter printer)
        {
            _printer = printer;
        }

        public void PrintBTree(BTree<T> tree)
        {
            _printer.PrintLine("");
            Print(tree.Root, "", true);
        }

        private void Print(BTreeNode<T> node, string prefix, bool tail)
        {
            string tailString = tail ? "`--" : "|--";
            _printer.PrintLine(prefix + tailString + GetIdentifier(node) + "(" + node.Value + ")");

            string childTail = tail ? "    " : "|   ";
            if (node.Left != null)
            {
                if (node.Right != null)
                {
                    Print(node.Left, prefix + childTail, false);
                }
                else
                {
                    Print(node.Left, prefix + childTail, true);
                }
                
            }

            if (node.Right != null)
            {
                Print(node.Right, prefix + childTail, true);
            }
        }

        private string GetIdentifier(BTreeNode<T> node)
        {
            string prefix = "";
            if (node.IsParent)
            {
                prefix += "*";
            }
            if (node.IsSelected)
            {
                prefix += "%";
            }
            return prefix;
        }
    }
}
