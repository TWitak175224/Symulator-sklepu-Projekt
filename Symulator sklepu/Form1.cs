using System.Diagnostics;

namespace Symulator_sklepu
{
    public partial class Form1 : Form
    {
        List arty = new List();
        
        int alfab = 0, cen = 0;
        public Form1()
        {
            InitializeComponent();
            String[] nazwy = { "a", "b", "x", "z", "y" };
            int[] ceny = { 100, 23, 15, 234, 80 };
            

            for (int i = 0; i < 5; i++)
            {
                arty.AddFirst(nazwy[i], ceny[i], 3);
            }

            ZmianaText();
        }

        private void ZmianaText()
        {
            { 
            nazwa1.Text = arty.head.nazwa;
            nazwa2.Text = arty.head.next.nazwa;
            nazwa3.Text = arty.head.next.next.nazwa;
            nazwa4.Text = arty.head.next.next.next.nazwa;

            }

            {
                cena1.Text = arty.head.PrintCena();
                cena2.Text = arty.head.next.PrintCena();
                cena3.Text = arty.head.next.next.PrintCena();
                cena4.Text = arty.head.next.next.next.PrintCena();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (alfab == 0)
            {
                cen = 0;
                arty.InsertionSortAlf();
                alfab = 1;
                ZmianaText();

                

            }
            else
            {
                arty.OdwrocKol();
                alfab *= -1;
                ZmianaText();
                if (alfab == -1) { button1.Text = "Z-A"; }
                else
                {
                    button1.Text = "A-Z";
                }

                
            }

            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cen == 0)
            {
                alfab = 0;
                arty.InsertionSortPrice(); 
                cen = 1;
                ZmianaText();



            }
            else
            {
                arty.OdwrocKol();
                cen *= -1;
                ZmianaText();
                if (cen == -1) { button2.Text = "10-1"; }
                else
                {
                    button2.Text = "1-10";
                }

                
            }
            
        }
    }
}
