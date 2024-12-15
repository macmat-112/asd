using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrafSpójnyj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Dodawanie do kolejki
        public void Put(int value, int priority, SortedDictionary<int, Queue<int>> priorityQueue)
        {
            if(!priorityQueue.ContainsKey(priority)) priorityQueue[priority] = new Queue<int>();
            priorityQueue[priority].Enqueue(value);
        }

        // Zabieranie z kolejki
        public int Get(SortedDictionary<int, Queue<int>> priorityQueue)
        {
            if(priorityQueue.Count == 0) throw new InvalidOperationException("Queue is empty.");
            var firstKey = priorityQueue.Keys.Min();
            var value = priorityQueue[firstKey].Dequeue();
            if(priorityQueue[firstKey].Count == 0) priorityQueue.Remove(firstKey);
            return value;
        }

        public List<Element> AlgorytmDijkstryPrawda(int start, int[,] graph)
        {
            // Zmienne
            var tab = new List<Element>(); // Zwracana tabelka
            var visited = new HashSet<int>(); // Zbiór odwiedzonych już wierzchołków
            var priorityQueue = new SortedDictionary<int, Queue<int>>(); // Kolejka
            int current = start; // Obecny wierzchołek
            int len = (int)Math.Sqrt(graph.Length); // Długość jednego wymiaru macierzy grafu

            // Wypełnienie tabelki -1 i max_intami
            for(int i = 0; i < len; i++)
            {
                var e = new Element();
                e.node = i;
                e.cost = int.MaxValue;
                e.prev = -1;
                tab.Add(e);
            }
            tab[start].cost = 0; // Koszt przejścia do startu ustawiony jest na 0

            // Suma maksymalna zbioru wierzchołków odwiedzonych
            var sum = 0;
            for(int i = 0; i < len; i++) sum += i;

            while(visited.Sum() < sum) // Powtarzaj, dopóki są jakieś nieodwiedzone wierzchołki
            {
                if(!visited.Contains(current)) // Przejdź dalej, jeżeli wierzchołek nie został odwiedzony
                {
                    for(int i = 0; i < len; i++) // Sprawdź wszystkie krawędzie odchodzące z wierzchołka
                    {
                        if(graph[current, i] >= 0) // Przejdź dalej, jeżeli krawędź istnieje
                        {
                            var cost = tab[current].cost + graph[current, i];
                            Put(i, cost, priorityQueue); // Dodaj przejście do kolejki
                            if(tab[i].cost > cost) // Zamień przejście w tabelce, jeżeli kosztuje mniej niż poprzednie
                            {
                                tab[i].cost = cost;
                                tab[i].prev = current;
                            }
                        }
                    }
                    visited.Add(current); // Dodaj wierzchołek do zbioru wierzchołków odwiedzonych
                }
                current = Get(priorityQueue); // Zabierz wierzchołek z kolejki i rozpatrz go
            }
            return tab;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] graph = {{0, 3, -1, -1, 3, -1}, {-1, 0, 1, -1, -1, -1}, {-1, -1, 0, 3, -1, 1}, {-1, 3, -1, 0, -1, -1}, {-1, -1, -1, -1, 0, 2}, {6, -1, -1, 1, -1, 0}};
            var tab = AlgorytmDijkstryPrawda(0, graph);
            var list1 = new List<int>();
            var list2 = new List<int>();
            var list3 = new List<int>();
            for(int i = 0; i < 6; i++)
            {
                list1.Add(tab[i].node);
                list2.Add(tab[i].cost);
                list3.Add(tab[i].prev);
            }
            MessageBox.Show($"Tabelka:\n{string.Join(",", list1.ToArray())}\n{string.Join(",", list2.ToArray())}\n{string.Join(",", list3.ToArray())}");
        }
    }
}
