using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Symulator_sklepu {  
    internal class List
    {
        public NodeL head;
        public NodeL tail;
        public uint count;
        private bool sortedAlph = false;
        private bool sortedPrice = false;


        public void AddFirst(string nazwa,double cena, int liczba)
        {
            var nowy = new NodeL(nazwa,(int)(cena*100),liczba);
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

            count++;
        }
        public void AddLast(string nazwa, double cena,int liczba)
        {
            var nowy = new NodeL(nazwa, (int)(cena * 100), liczba);
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
        


        

        public NodeL InsertionSortAlf()
        {
            if (this.head == null) return this.head;

            NodeL sorted = null;
            NodeL curr = head;

            // Traverse the list to sort each element
            while (curr != null)
            {

                // Store the next node to process
                NodeL next = curr.next;

                // Insert `curr` into the sorted part
                if (sorted == null || sorted.nazwa.CompareTo(curr.nazwa) >=0)
                {
                    curr.next = sorted;
                    if (sorted != null)
                    {
                        sorted.prev = curr;
                    }

                    // Update sorted to the new head
                    sorted = curr;
                }
                else
                {

                    // Pointer to traverse the sorted part
                    NodeL currentSorted = sorted;

                    // Find the correct position to insert
                    while (currentSorted.next != null &&
                           currentSorted.next.nazwa.CompareTo(curr.nazwa)<0)
                    {
                        currentSorted = currentSorted.next;
                    }

                    // Insert `curr` after `currentSorted`
                    curr.next = currentSorted.next;
                    currentSorted.next = curr;
                    currentSorted.prev = curr.prev;
                    curr.prev = currentSorted;
                }
                
                curr = next;
            }
            
            this.head = sorted;
            NodeL checker = head;
            
            for (int i = 0; i < this.count; i++)
            {
                
                if (checker.next == null)
                {
                    this.tail = checker;
                }
                else
                {
                    checker = checker.next;
                }
            }
            return sorted;
        }
        public NodeL InsertionSortPrice()
        {
            if (this.head == null) return this.head;

            NodeL sorted = null;
            NodeL curr = head;

            // Traverse the list to sort each element
            while (curr != null)
            {

                // Store the next node to process
                NodeL next = curr.next;

                // Insert `curr` into the sorted part
                if (sorted == null || sorted.cena_w_gr>=curr.cena_w_gr)
                {
                    curr.next = sorted;
                    if (sorted != null)
                    {
                        sorted.prev = curr;
                    }

                    // Update sorted to the new head
                    sorted = curr;
                }
                else
                {

                    // Pointer to traverse the sorted part
                    NodeL currentSorted = sorted;

                    // Find the correct position to insert
                    while (currentSorted.next != null &&
                           currentSorted.next.cena_w_gr < curr.cena_w_gr)
                    {
                        currentSorted = currentSorted.next;
                    }

                    // Insert `curr` after `currentSorted`
                    curr.next = currentSorted.next;
                    currentSorted.next = curr;
                    currentSorted.prev = curr.prev;
                    curr.prev = currentSorted;
                }
                
                curr = next;
                
            }
            this.head = sorted;
            NodeL checker = head;

            for (int i = 0; i < this.count; i++)
            {

                if (checker.next == null)
                {
                    this.tail = checker;
                }
                else
                {
                    checker = checker.next;
                }
            }
            return sorted;
        }

        public string ToStringi()
        {
            string stringowana = "";
            NodeL node = this.head;
            for (int i = 0; i < this.count; i++)
            {
                stringowana += node.nazwa+" "+(double)(node.cena_w_gr/100)+"zł "+node.ilosc + "\n";
                node = node.next;
            }
            return stringowana;
        }
        public void OdwrocKol() { 
            NodeL poczatek = this.head;
            NodeL koniec = this.tail;
            NodeL edytowany = this.tail;
            for (int i = 0; i < this.count; i++) {
                NodeL temp = edytowany.prev;
                edytowany.prev = edytowany.next;
                edytowany.next = temp;
                edytowany = edytowany.next;
            
            }
            this.tail = poczatek;
            this.head = koniec;
        }
    }
}