using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinarySearchTree
{
    internal class NodeT
    {
        public int data;
        public NodeT root;
        public NodeT left;
        public NodeT right;

        public static NodeT Insert(NodeT node, int value)
        {

            if (node == null)
            {

                node = new NodeT();
                node.data = value;
                return node;

            }

            if (value == node.data) return node;

            if (value < node.data)
            {

                node.left = Insert(node.left, value);
                node.left.root = node;

            }
            else if (value > node.data)
            {

                node.right = Insert(node.right, value);
                node.right.root = node;

            }

            return node;

        }

        public static NodeT Delete(NodeT node, int value)
        {

            if (node == null) return node;

            if (node.data > value) node.left = Delete(node.left, value);
            else if (node.data < value) node.right = Delete(node.right, value);
            else
            {

                if (node.left == null)
                {

                    if (node.right != null) node.right.root = node.root;
                    node.root = null;
                    return node.right;

                }

                if (node.right == null)
                {

                    node.left.root = node.root;
                    node.root = null;
                    return node.left;

                }

                NodeT succ = node.right;
                while (succ != null && succ.left != null) succ = succ.left;
                node.data = succ.data;
                node.right = Delete(node.right, succ.data);

            }

            return node;

        }

        public static void CPDIn(NodeT node)
        {

            if (node == null)
            {
                return;
            }

            NodeT.CPDIn(node.left);
            Console.Write(node.data.ToString() + " ");
            NodeT.CPDIn(node.right);

        }

        public static void CPDPre(NodeT node)
        {

            if (node == null)
            {
                return;
            }

            Console.Write(node.data.ToString() + " ");
            NodeT.CPDPre(node.left);
            NodeT.CPDPre(node.right);

        }

        public static void CPDPost(NodeT node)
        {

            if (node == null)
            {
                return;
            }

            NodeT.CPDPost(node.left);
            NodeT.CPDPost(node.right);
            Console.Write(node.data.ToString() + " ");

        }
    }
}
