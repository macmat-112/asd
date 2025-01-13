using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class Node
    {
        public int amount;
        public char data;
        public Node left, right;

        public Node(int amount, char data)
        {
            left = null;
            right = null;
            this.amount = amount;
            this.data = data;
        }

        public Node(int amount, char data, Node left, Node right) : this(amount, data)
        {
            this.left = left;
            this.right = right;
        }
    }
}
