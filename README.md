Zrób program demonstrujący działanie list dwukierunkowych.
Stwórz klasy: lista i node, możliwość dodawania, usuwania, przechodzenia i wyświetlania danych.
    
    internal class Node
    {
        public Node Next;
        public Node Prev;
        public int Data;
    }

    internal class List
    {
        public Node Head;
        public Node Tail;
        public int Count;

        public void AddLast(int liczba)
        {
            //zrob metody dla list (dodawanie, odejmowanie)
            //gui, ktore korzysta z list
            Node node = new Node();
            node.Data = liczba;
        }
    }
