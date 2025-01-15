using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_sklepu
{
    public class NodeL
    {
        public NodeL next { get; set; }
        public NodeL prev { get; set; }
        public int ilosc { get; set; }
        public string nazwa { get; set; }
        public int cena_w_gr { get; set; }
        public NodeL(string nazwa,double cena,int liczba)
        {
            this.cena_w_gr = (int)cena*100;
            this.nazwa = nazwa;
            this.ilosc = liczba;
        }

        public NodeL()
        {
            this.ilosc = 0;
            this.nazwa = null;
            this.cena_w_gr = 0;
        }

        public String PrintCena()
        {
            return ((double)(cena_w_gr/100)).ToString();
        }
        
    }
}
