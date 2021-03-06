﻿using System;

namespace BTreeVisualization.Logic
{
    public class BTree<T> where T : IComparable
    {
        public BTreeNode<T> Root { get; set; }
        public int Height = 0;

        public void Insert(T value)
        {
            Root = InsertValue(Root, value, 0);
        }

        public void ClearSelected()
        {
            TraversalFunc(Root, x => x.IsParent = x.IsSelected = false);
        }

        private BTreeNode<T> InsertValue(BTreeNode<T> node, T value, int level)
        {
            if (node == null)
            {
                if (level > Height)
                {
                    Height = level;
                }
                return new BTreeNode<T>(value, level);
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                node.Right = InsertValue(node.Right, value, level + 1);
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                node.Left = InsertValue(node.Left, value, level + 1);
            }

            return node;
        }

        private void TraversalFunc(BTreeNode<T> node, Action<BTreeNode<T>> ProcessNode)
        {
            if (node == null)
            {
                return;
            }
            else
            {
                ProcessNode(node);
                TraversalFunc(node.Left, ProcessNode);
                TraversalFunc(node.Right, ProcessNode);
            }
        }
    }
    public class BTreeNode<T> where T : IComparable
    {
        public T Value { get; set; }
        public BTreeNode<T> Right { get; set; }
        public BTreeNode<T> Left { get; set; }
        public bool IsParent { get; set; } = false;
        public bool IsSelected { get; set; } = false;
        public int Level { get; set; }
        public BTreeNode(T value)
        {
            Value = value;
        }
        public BTreeNode(T value, int level)
        {
            Value = value;
            Level = level;
        }
    }

    
}
