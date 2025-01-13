using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huffman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Dodawanie do kolejki
        public void Put(Node node, SortedDictionary<int, Queue<Node>> priorityQueue)
        {
            if (!priorityQueue.ContainsKey(node.amount)) priorityQueue[node.amount] = new Queue<Node>();
            priorityQueue[node.amount].Enqueue(node);
        }

        // Zabieranie z kolejki
        public Node Get(SortedDictionary<int, Queue<Node>> priorityQueue)
        {
            
            if (priorityQueue.Count == 0) throw new InvalidOperationException("Queue is empty.");
            int firstKey = priorityQueue.Keys.Min();
            Node value = priorityQueue[firstKey].Dequeue();
            if (priorityQueue[firstKey].Count == 0) priorityQueue.Remove(firstKey);
            return value;
        }

        public Node HuffmanCreate(List<Tuple<int, char>> input)
        {
            SortedDictionary<int, Queue<Node>> queue = new SortedDictionary<int, Queue<Node>>();
            for(var i = 0; i < input.Count; i += 1)
            {
                var next = input[i];
                Put(new Node(input[i].Item1, input[i].Item2), queue);
            }
            while(queue.Count > 1)
            {
                var first = Get(queue);
                var second = Get(queue);
                Put(new Node(first.amount + second.amount, '\0', first, second), queue);
            }
            return Get(queue);
        }

        public void PrintCodes(Node root, string str)
        {
            if(root == null) return;
            if (root.data != '\0') Console.WriteLine(root.data + ": " + str);
            PrintCodes(root.left, str + "0");
            PrintCodes(root.right, str + "1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Tuple<int, char>> list = new List<Tuple<int, char>>();
            list.Add(new Tuple<int, char>(13, 'e'));
            list.Add(new Tuple<int, char>(9, 'a'));
            list.Add(new Tuple<int, char>(13, 'f'));
            list.Add(new Tuple<int, char>(10, 'c'));
            list.Add(new Tuple<int, char>(9, 'b'));
            list.Add(new Tuple<int, char>(12, 'd'));
            PrintCodes(HuffmanCreate(list), "");
        }
    }
}
