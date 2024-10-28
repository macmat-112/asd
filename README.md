Zrób program demonstrujący działanie list dwukierunkowych.
Stwórz klasy: lista i node, możliwość dodawania, usuwania, przechodzenia i wyświetlania danych. (ToString)
Stworzyć klasę NodeT i BST i podobnie.
    
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
    
    internal class NodeT
    {
        NodeT rodzic;
        NodeT lewe;
        NodeT prawe;
        int data;
    }
    
    internal class BST
    {
        NodeT root;
    }

        public String toString()
        {
            Node temp = Head;
            String wynik = "";
            while (temp != null)
            {
                wynik += " " + temp.Data;
                temp = temp.Next;
            }
            wynik.Trim();
            return wynik;
        }
