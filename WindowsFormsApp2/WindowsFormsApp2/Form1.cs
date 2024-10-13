using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int[] list = new int[text.Length];
            char a;
            int b;
            char[] output = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                a = text[i];
                list[i] = a - '0';
            }
            bool check = true;
            while (check)
            {
                int c;
                check = false;
                for (int i = 0; i < text.Length - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        c = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = c;
                        check = true;
                    }
                }
            }
            for (int i = 0; i < text.Length; i++)
            {
                b = list[i] + (int) '0';
                a = (char) b;
                output[i] = a;
            }
            string output2 = new string(output);
            MessageBox.Show($"Lista przed sortowaniem: {text}\nLista po sortowaniu: {output2}");
        }
    }
}
