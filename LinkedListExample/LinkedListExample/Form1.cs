using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedListExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Plan działania
        /*
         * button1/2 czyta z textBoxa1 i wrzuca wartość na początek/koniec listy
         * button3 czyta z textBoxa1 i wrzuca na indeks podany w textBoxie2
         * button4/5 usuwa z początku/końca listy
         * button6 usuwa z indeksu w textBoxie3
         * label1 wyświetla zawartość listy
         */
        
        private List costam = new List();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int liczba = int.Parse(textBox1.Text);
                costam.AddFirst(liczba);
                label1.Text = "Zawartość listy: " + costam.ReturnString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Podaj poprawną wartość!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int liczba = int.Parse(textBox1.Text);
                costam.AddLast(liczba);
                label1.Text = "Zawartość listy: " + costam.ReturnString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Podaj poprawną wartość!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int liczba = int.Parse(textBox1.Text);
                int indeks = int.Parse(textBox2.Text);
                costam.AddIndex(liczba, indeks);
                label1.Text = "Zawartość listy: " + costam.ReturnString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Podaj poprawną wartość!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            costam.RemoveFirst();
            label1.Text = "Zawartość listy: " + costam.ReturnString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            costam.RemoveLast();
            label1.Text = "Zawartość listy: " + costam.ReturnString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (costam.Count > 0)
                {
                    int indeks = int.Parse(textBox2.Text);
                    costam.RemoveIndex(indeks);
                }
                label1.Text = "Zawartość listy: " + costam.ReturnString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Podaj poprawną wartość!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            costam.Clear();
            label1.Text = "Zawartość listy: " + costam.ReturnString();
        }
    }
}
