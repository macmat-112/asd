using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sortowania
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void BubbleSort(int[] input)
        {
            int len = input.Length - 1;
            while (len > 0)
            {
                for (int i = 0; i < len; i++) if (input[i] > input[i + 1]) Swap(input, i, i + 1);
                len--;
            }
        }

        public void InsertionSort(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (input[j - 1] > input[j]) Swap(input, j - 1, j);
                    else break;
                }
            }
        }

        public void MergeSort(int[] input, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                MergeSort(input, p, q);
                MergeSort(input, q + 1, r);
                Merge(input, p, q, r);
            }
        }

        public void Merge(int[] input, int p, int q, int r)
        {
            int s = q + 1;
            int h;
            while (p < s && s <= r)
            {
                if (input[p] > input[s])
                {
                    h = input[s];
                    Array.Copy(input, p, input, p + 1, s - p);
                    input[p] = h;
                    s++;
                }
                p++;
            }
        }

        public void CountingSort(int[] input)
        {
            int max = input.Max();
            int[] count = new int[max + 1];
            int j = 0;
            for (int i = 0; i <= max; i++) count[i] = 0;
            for (int i = 0; i < input.Length; i++) count[input[i]]++;
            for (int i = 0; i <= max; i++)
            {
                while (count[i] > 0)
                {
                    input[j] = i;
                    j++;
                    count[i]--;
                }
            }
        }

        public void SelectionSort(int[] input)
        {
            int len = input.Length;
            int min;
            for (int i = 0; i < len; i++)
            {
                min = i;
                for(int j = i + 1; j < len; j++) if (input[j] < input[min]) min = j;
                Swap(input, i, min);
            }
        }

        public void QuickSort(int[] input, int p, int r)
        {
            if (r - p > 0)
            {
                int i = p + 1;
                int j = r;
                while (true)
                {
                    while (i <= r && input[i] <= input[p]) i++;
                    while (j > p && input[j] >= input[p]) j--;
                    if (i < j) Swap(input, i, j);
                    else
                    {
                        Swap(input, p, j);
                        break;
                    }
                }
                if (j > p) QuickSort(input, p, j - 1);
                if (j < r) QuickSort(input, j + 1, r);
            }
        }

        public void Swap(int[] input, int i, int j)
        {
            int h = input[i];
            input[i] = input[j];
            input[j] = h;
        }

        public int[] Generate(int len)
        {
            int[] input = new int[len];
            Random rnd = new Random();
            for (int i = 0; i < len; i++) input[i] = rnd.Next(0, 10);
            return input;
        }

        public int[] Initialize(string text)
        {
            int[] input = new int[text.Length];
            char a;
            for (int i = 0; i < text.Length; i++)
            {
                a = text[i];
                input[i] = a - '0';
            }
            return input;
        }

        public char[] Change(int len, int[] input)
        {
            char a;
            int b;
            char[] conv = new char[len];
            for (int i = 0; i < len; i++)
            {
                b = input[i] + (int)'0';
                a = (char)b;
                conv[i] = a;
            }
            return conv;
        }

        public void Print(char[] conv)
        {
            string output = new string(conv);
            MessageBox.Show($"Lista po sortowaniu: {output}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            int len = Convert.ToInt32(text);
            char[] conv = Change(len, Generate(len));
            textBox1.Text = new string(conv);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string text = textBox1.Text;
            int[] tab = Initialize(text);
            BubbleSort(tab);
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("Ticki: {0}, Milisekundy: {1}", ts.Ticks, ts.Milliseconds);
            label5.Text = elapsedTime;
            stopWatch.Stop();
            char[] conv = Change(text.Length, tab);
            Print(conv);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string text = textBox1.Text;
            int[] tab = Initialize(text);
            InsertionSort(tab);
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("Ticki: {0}, Milisekundy: {1}", ts.Ticks, ts.Milliseconds);
            label5.Text = elapsedTime;
            stopWatch.Stop();
            char[] conv = Change(text.Length, tab);
            Print(conv);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string text = textBox1.Text;
            int[] tab = Initialize(text);
            MergeSort(tab, 0, text.Length - 1);
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("Ticki: {0}, Milisekundy: {1}", ts.Ticks, ts.Milliseconds);
            label5.Text = elapsedTime;
            stopWatch.Stop();
            char[] conv = Change(text.Length, tab);
            Print(conv);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string text = textBox1.Text;
            int[] tab = Initialize(text);
            CountingSort(tab);
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("Ticki: {0}, Milisekundy: {1}", ts.Ticks, ts.Milliseconds);
            label5.Text = elapsedTime;
            stopWatch.Stop();
            char[] conv = Change(text.Length, tab);
            Print(conv);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string text = textBox1.Text;
            int[] tab = Initialize(text);
            SelectionSort(tab);
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("Ticki: {0}, Milisekundy: {1}", ts.Ticks, ts.Milliseconds);
            label5.Text = elapsedTime;
            stopWatch.Stop();
            char[] conv = Change(text.Length, tab);
            Print(conv);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string text = textBox1.Text;
            int[] tab = Initialize(text);
            QuickSort(tab, 0, text.Length - 1);
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("Ticki: {0}, Milisekundy: {1}", ts.Ticks, ts.Milliseconds);
            label5.Text = elapsedTime;
            stopWatch.Stop();
            char[] conv = Change(text.Length, tab);
            Print(conv);
        }
    }
}
