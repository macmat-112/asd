using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string NWP(string first, string second)
        {
            string output = "";
            int rows = first.Length + 1;
            int cols = second.Length + 1;
            int[,] array = new int[rows, cols];
            for (var i = 0; i < cols; i += 1) array[i, 0] = 0;
            for (var i = 0; i < cols; i += 1) array[0, i] = 0;
            for (var i = 1; i < rows; i += 1)
            {
                for (var j = 1; j < cols; j += 1)
                {
                    if (first[i - 1] == second[j - 1]) array[i, j] = array[i - 1, j - 1] + 1;
                    else array[i, j] = Math.Max(array[i - 1, j], array[i, j - 1]);
                }
            }
            Print2DArray(array);
            int a = rows - 1;
            int b = cols - 1;
            while (a > 0 && b > 0)
            {
                var current = array[a, b];
                var left = array[a, b - 1];
                var up = array[a - 1, b];
                if (current == left) b -= 1;
                else if (current == up) a -= 1;
                else
                {
                    a -= 1;
                    b -= 1;
                    try
                    {
                        output = first[a] + output;
                    }
                    catch(Exception e)
                    {
                        output = second[b] + output;
                    }
                }
            }
            return output;
        }

        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string first = "XMJYAUZ";
            string second = "MZJAWXU";
            Console.WriteLine(NWP(first, second));
        }
    }
}
