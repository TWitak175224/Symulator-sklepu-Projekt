using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Symulator_sklepu
{
    public class List
    {
        public NodeL? head;
        public NodeL? tail;
        public uint count;
        private bool sortedAlph = false;
        private bool sortedPrice = false;

        public List()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
            this.sortedAlph = false;
            this.sortedPrice = false;

        }
        public void AddFirst(string nazwa, double cena, int liczba)
        {
            var nowy = new NodeL(nazwa, cena, liczba);
            nowy.next = this.head;
            if (this.count > 0)
            {
                this.head.prev = nowy;
            }
            else
            {
                this.tail = nowy;
            }
            this.head = nowy;
            nowy.prev = null;

            count++;
        }
        public void AddLast(string nazwa, double cena, int liczba)
        {
            var nowy = new NodeL(nazwa, cena, liczba);
            nowy.prev = this.tail;
            if (this.count > 0)
            {
                this.tail.next = nowy;
            }
            else
            {
                this.head = nowy;
            }
            this.tail = nowy;
            nowy.next = null;

            count++;
        }
        public void RemoveFirst()
        {
            count--;
            if (count == 0)
            {
                this.tail = null;
            }
            else
            {
                this.head = this.head.next;
                this.head.prev.next = null;
                this.head.prev = null;
            }

        }
        public void RemoveLast()
        {
            count--;
            if (count == 0)
            {
                this.head = null;
            }
            else
            {

                this.tail = this.tail.prev;
                this.tail.next.prev = null;
                this.tail.next = null;
            }

        }
        public void Dodaj(List l)
        {
            NodeL look = l.head;
            for (int i = 0; i < l.count; i++)
            {
                this.AddLast(look.nazwa, look.cena_w_gr, look.ilosc);
            }
        }




        public NodeL InsertionSortAlf()
        {
            if (this.head == null) return this.head;

            if (sortedAlph == false)
            {
                NodeL sorted = null;
                NodeL curr = head;

                this.sortedPrice = false;

                while (curr != null)
                {
                    NodeL next = curr.next;

                    
                    if (sorted == null || sorted.nazwa.CompareTo(curr.nazwa) >= 0)
                    {
                        curr.next = sorted;
                        if (sorted != null)
                        {
                            sorted.prev = curr;
                        }
                        sorted = curr;
                        sorted.prev = null; 
                    }
                    else
                    {
                        
                        NodeL currentSorted = sorted;

                        while (currentSorted.next != null &&
                               currentSorted.next.nazwa.CompareTo(curr.nazwa) < 0)
                        {
                            currentSorted = currentSorted.next;
                        }

                        
                        curr.next = currentSorted.next;
                        if (currentSorted.next != null)
                        {
                            currentSorted.next.prev = curr;
                        }
                        currentSorted.next = curr;
                        curr.prev = currentSorted;
                    }

                    curr = next;
                }

                
                this.head = sorted;
                NodeL checker = head;

                while (checker.next != null)
                {
                    checker = checker.next;
                }

                this.tail = checker;
                this.sortedAlph = true;
                return this.head;
            }

            return this.head;
        }
        public NodeL InsertionSortPrice()
        {
            if (this.head == null || this.head.next == null)
                return this.head;

            if (!this.sortedPrice)
            {
                NodeL sorted = null;
                NodeL curr = this.head;

                this.sortedAlph = false;

                while (curr != null)
                {
                    NodeL next = curr.next;

                    if (sorted == null || sorted.cena_w_gr >= curr.cena_w_gr)
                    {

                        curr.next = sorted;
                        if (sorted != null)
                            sorted.prev = curr;

                        sorted = curr;
                        sorted.prev = null;
                    }
                    else
                    {

                        NodeL temp = sorted;
                        while (temp.next != null && temp.next.cena_w_gr < curr.cena_w_gr)
                        {
                            temp = temp.next;
                        }


                        curr.next = temp.next;
                        if (temp.next != null)
                            temp.next.prev = curr;

                        temp.next = curr;
                        curr.prev = temp;
                    }

                    curr = next;
                }


                this.head = sorted;
                NodeL tempTail = sorted;
                while (tempTail.next != null)
                {
                    tempTail = tempTail.next;
                }
                this.tail = tempTail;

                this.sortedPrice = true;
            }

            return this.head;
        }



        public string ToStringi()
        {
            string stringowana = "";
            NodeL node = this.head;
            for (int i = 0; i < this.count; i++)
            {
                stringowana += node.nazwa + " " + (double)(node.cena_w_gr / 100) + "zł " + node.ilosc + "\n";
                node = node.next;
            }
            return stringowana;
        }
        //public void OdwrocKol() { 
        //    NodeL poczatek = this.head;
        //    NodeL koniec = this.tail;
        //    NodeL edytowany = koniec;
        //    for (int i = 0; i < this.count; i++) {
        //        if (edytowany == null)
        //        {
        //            break;
        //        }
        //        if (edytowany.next == null)
        //        {
        //            break;
        //        }
        //        NodeL temp = edytowany.prev;
        //        edytowany.prev = edytowany.next;
        //        edytowany.next = temp;

        //        edytowany = edytowany.next;

        //    }
        //    this.tail = poczatek;
        //    this.head = koniec;
        //}
        // To be fixed later
    }
}