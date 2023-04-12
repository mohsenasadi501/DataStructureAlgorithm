using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part2
{
    internal class Tree
    {
        internal class Node
        {
            public int value;
            public Node leftChild;
            public Node rightChild;
            public Node(int value)
            {
                this.value = value;
            }
        }
        private Node root;
        public Tree()
        {
        }

        public void insert(int item)
        {
            // if root is null add first item to the root item
            if (root == null)
                root = new Node(item);
            else
            {
                var current = root;
                while (current != null)
                {
                    if (current.value < item)
                    {
                        if (current.rightChild != null)
                            current = current.rightChild;
                        else
                        {
                            current.rightChild = new Node(item);
                            break;
                        }

                    }
                    else
                    {
                        if (current.leftChild != null)
                            current = current.leftChild;
                        else
                        {
                            current.leftChild = new Node(item);
                            break;
                        }
                    }
                }
            }
        }
        public bool find(int value)
        {
            var current = root;
            while (current != null)
            {
                if (current.value < value)
                    current = current.rightChild;
                else if (current.value > null)
                    current = current.leftChild;
                else
                    return true;
            }
            return false;
        }
        public void traversePreorder()
        {
            traversePreorder(root);
        }
        private void traversePreorder(Node root)
        {
            if (root == null)
                return;
            Console.WriteLine(root.value);
            traversePreorder(root.leftChild);
            traversePreorder(root.rightChild);
        }
        public void traverseInorder()
        {
            traverseInorder(root);
        }
        public void traverseInorder(Node root)
        {
            if (root == null)
            {
                return;
            }
            traverseInorder(root.leftChild);
            Console.WriteLine(root.value);
            traverseInorder(root.rightChild);
        }
        public int height()
        {
            return height(root);
        }
        public int height(Node root)
        {
            if (root == null) return -1;
            if (root.leftChild == null && root.rightChild == null)
                return 0;
            return 1 + Math.Max(height(root.leftChild), height(root.rightChild));
        }
    }
}
