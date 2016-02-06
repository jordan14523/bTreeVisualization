using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeVisualization.Logic
{
    public class BTreeOperations<T> where T : IComparable
    {
        public BTreeNode<T> ParentFinder(BTree<T> tree, BTreeNode<T> n1, BTreeNode<T> n2)
        {
            var pathToN1 = RootToValuePath(tree.Root, n1.Value);
            var pathToN2 = RootToValuePath(tree.Root, n2.Value);

            if (pathToN1 == null)
            {
                throw new ArgumentException(String.Format("The value {0} is not in tree.", n1.Value));

            }

            if (pathToN2 == null)
            {
                throw new ArgumentException(String.Format("The value {0} is not in tree.", n2.Value));
            }

            foreach (var node1 in pathToN1)
            {
                foreach (var node2 in pathToN2)
                {
                    if (node1.Value.CompareTo(node2.Value) == 0)
                    {
                        node1.IsParent = true;
                        return node1;
                    }
                }
            }

            return null;
        }


        /*
        public void PrintBTree(BTree<T> tree)
        {
            Queue<BTreeNode<T>> current = new Queue<BTreeNode<T>>();
            Queue<BTreeNode<T>> next = new Queue<BTreeNode<T>>();

            current.Enqueue(tree.Root);

            while (current.Count != 0)
            {
                BTreeNode<T> currentNode = current.Dequeue();

                if (currentNode != null)
                {
                    Console.WriteLine("{0} "currentNode.Value);
                    next.Enqueue(currentNode.Left);
                    next.Enqueue(currentNode.Right);
                }
                if (current.Count == 0)
                {
                    Console.WriteLine();
                    Swap(current, next);
                }
                
            }
        }
        */

        private Stack<BTreeNode<T>> RootToValuePath(BTreeNode<T> root, T value)
        {
            var stack = new Stack<BTreeNode<T>>();
            bool done = false;
            BTreeNode<T> checkNode = root;
            while(!done)
            {
                if (checkNode == null)
                {
                    return null;
                }
                if (checkNode.Value.CompareTo(value) == 0)
                {
                    checkNode.IsSelected = true;
                    stack.Push(checkNode);
                    done = true;
                }
                else if (checkNode.Value.CompareTo(value) < 0)
                {
                    stack.Push(checkNode);
                    checkNode = checkNode.Right;
                }
                else if (checkNode.Value.CompareTo(value) > 0)
                {
                    stack.Push(checkNode);
                    checkNode = checkNode.Left;
                }
            }
            return stack;
        }
    }
}
