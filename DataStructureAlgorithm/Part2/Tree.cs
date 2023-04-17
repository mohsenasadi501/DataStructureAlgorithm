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
        public void traversePostorder()
        {
            traversePostorder(root);
        }
        public void traversePostorder(Node root)
        {
            if (root == null)
            {
                return;
            }
            traversePostorder(root.leftChild);
            traversePostorder(root.rightChild);
            Console.WriteLine(root.value);
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
            int leftHeight = height(root.leftChild);
            int rightHeight = height(root.rightChild);

            return 1 + Math.Max(leftHeight, rightHeight);
        }
        public int min()
        {
            if (root == null)
                throw new Exception();

            var current = root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.leftChild;
            }
            return last.value;
        }
        public int min(Node root)
        {
            if (root.leftChild == null && root.rightChild == null) return root.value;

            var left = min(root.leftChild);
            var right = min(root.rightChild);

            return Math.Min(Math.Min(left, right), root.value);
        }
        public bool equals(Tree tree)
        {
            return equals(tree.root, root);
        }
        public bool equals(Node first, Node second)
        {
            if (first == null && second == null) return true;
            if (first != null && second != null)
            {
                return first.value == second.value
                    && equals(first.leftChild, second.leftChild)
                    && equals(first.rightChild, second.rightChild);
            }
            return false;
        }
        public bool isBinarySearchTree()
        {
            return isBinarySearchTree(root, int.MinValue, int.MaxValue);
        }
        public bool isBinarySearchTree(Node root, int min, int max)
        {
            if (root == null) return true;
            if (root.value < min || root.value > max) return false;

            return isBinarySearchTree(root.leftChild, min, root.value - 1)
                && isBinarySearchTree(root.leftChild, root.value + 1, max);
        }
    }
}
