using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part2
{
    internal class AvlTree
    {
        internal class AvlNode
        {
            public int value;
            public AvlNode leftChild;
            public AvlNode rightChild;
            public AvlNode(int value)
            {
                this.value = value;
            }
        }
        private AvlNode root;
        public void insert(int val)
        {
            root = insert(root, val);
        }
        public AvlNode insert(AvlNode root, int val)
        {
            if (root == null)
                return new AvlNode(val);
            if (val < root.value)
                root.leftChild = insert(root.leftChild, val);
            else
                root.rightChild = insert(root.rightChild, val);
            return root;
        }
    }
}
