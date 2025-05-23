﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedListExample
{
    internal class List
    {
        public Node Head;
        public Node Tail;
        public int Count = 0;

        public void AddLast(int liczba)
        {
            Node node = new Node();
            node.Data = liczba;
            if (Count == 0)
            {
                Tail = node;
                Head = node;
            }
            else
            {
                node.Prev = Tail;
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        public void AddFirst(int liczba)
        {
            Node node = new Node();
            node.Data = liczba;
            if (Count == 0)
            {
                Tail = node;
                Head = node;
            }
            else
            {
                node.Next = Head;
                Head.Prev = node;
                Head = node;
            }
            Count++;
        }

        public void AddIndex(int liczba, int index)
        {
            if (index == 0) AddFirst(liczba);
            else if (Count == index) AddLast(liczba);
            else if (index > 0 && index < Count)
            {
                Node node = new Node();
                node.Data = liczba;
                node.Next = Head;
                for (int i = 0; i < index - 1; i++) node.Next = node.Next.Next;
                node.Prev = node.Next;
                node.Next = node.Next.Next;
                node.Prev.Next = node;
                node.Next.Prev = node;
                Count++;
            }
            else MessageBox.Show("Indeks wychodzi poza listę...");
        }

        public void RemoveLast()
        {
            if (Count > 1)
            {
                Tail = Tail.Prev;
                Tail.Next = null;
                Count--;
            }
            else if (Count == 1)
            {
                Tail = null;
                Count--;
            }
        }

        public void RemoveFirst()
        {
            if (Count > 1)
            {
                Head = Head.Next;
                Head.Prev = null;
                Count--;
            }
            else if (Count == 1)
            {
                Head = null;
                Count--;
            }
        }

        public void RemoveIndex(int index)
        {
            if (index == 0) RemoveFirst();
            else if (Count - 1 == index) RemoveLast();
            else if (index > 0 && index < Count - 1)
            {
                if (Count > 0)
                {
                    Node node = new Node();
                    node = Head;
                    for (int i = 0; i < index - 1; i++) node = node.Next;
                    node.Next = node.Next.Next;
                    node = node.Next;
                    node.Prev = node.Prev.Prev;
                    Count--;
                }
            }
            else MessageBox.Show("Indeks wychodzi poza listę...");
        }

        public string ReturnString()
        {
            Node temp = Head;
            string wynik = "";
            while (temp != null)
            {
                wynik += temp.Data + " ";
                temp = temp.Next;
            }
            wynik.Trim();
            return wynik;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
    }
}
