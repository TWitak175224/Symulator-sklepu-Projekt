using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_sklepu
{
    internal class NodeL
    {
        public NodeL next, prev;
        public int ilosc;
        public string nazwa;
        public int cena_w_gr;
        public NodeL(string nazwa,int cena,int liczba)
        {
            this.cena_w_gr = cena;
            this.nazwa = nazwa;
            this.ilosc = liczba;
        }
        public String PrintCena()
        {
            return ((Double)(cena_w_gr/100)).ToString();
        }
    }
}
