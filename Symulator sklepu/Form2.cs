using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Symulator_sklepu
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public List arty = new List();
        public List artyDod = new List();
        private NodeL pierwszyCzytany = new NodeL();
        int alfab = 0, cen = 0;
        public Form2()
        {
            instance = this;
            InitializeComponent();
            // czytanie();

            arty = Form1.instance.arty;
            pierwszyCzytany = arty.head;
            button1.Visible = false;
            button1.Enabled = false;

            ZmianaText();
        }
        private int SprawdzIleDoWyswietlenia()
        {
            NodeL p = this.pierwszyCzytany;
            int i = 0;
            for (; i < 5 && p != null; i++) { }
            return i;
        }

        private void ZmianaText()
        {
            {
                System.Windows.Forms.Label[] labelki_nazw = { nazwa1, nazwa2, nazwa3, nazwa4, nazwa5 };
                System.Windows.Forms.Label[] labelki_cen = { cena1, cena2, cena3, cena4, cena5 };
                System.Windows.Forms.Label[] labelki_ilosci = { ilosc1, ilosc2, ilosc3, ilosc4, ilosc5 };
                Button[] przyciskiZMin = { pierwszyMinus, drugiMinus, trzeciMinus, czwartyMinus, piatyMinus };
                Button[] przyciskiZPl = { pierwszyPlus, drugiPlus, trzeciPlus, czwartyPlus, piatyPlus };
                NodeL czytany = pierwszyCzytany;
                int i = 0;
                int check = SprawdzIleDoWyswietlenia();
                for (; i < check; i++)
                {

                    if (czytany == null)
                    {
                        labelki_cen[i].Text = null;
                        labelki_nazw[i].Text = null;
                        labelki_ilosci[i].Text = null;
                        przyciskiZMin[i].Visible = false;
                        przyciskiZPl[i].Visible = false;

                    }
                    else
                    {
                        labelki_nazw[i].Text = czytany.nazwa;
                        labelki_cen[i].Text = czytany.PrintCena();
                        labelki_ilosci[i].Text = czytany.ilosc.ToString();
                        przyciskiZMin[i].Visible = true;
                        przyciskiZPl[i].Visible = true;
                        czytany = czytany.next;
                    }
                }




            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            arty.AddFirst(poleNaNazwe.Text, double.Parse(poleNaCene.Text.Replace(".", ",")), int.Parse(poleNaIlosc.Text));

            MessageBox.Show("utworzono produkt");
            poleNaNazwe.Text = string.Empty;
            poleNaCene.Text = string.Empty;
            poleNaIlosc.Text = string.Empty;
            pierwszyCzytany = arty.head;
            ZmianaText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pierwszyCzytany.ilosc++;
            ilosc1.Text = pierwszyCzytany.ilosc.ToString();
            if (pierwszyCzytany.ilosc > 0)
            {
                pierwszyMinus.Visible = true;
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {

            pierwszyCzytany.next.ilosc++;
            ilosc2.Text = pierwszyCzytany.next.ilosc.ToString();
            if (pierwszyCzytany.next.ilosc > 0)
            {
                drugiMinus.Visible = true;
            }



        }
        private void button4_Click(object sender, EventArgs e)
        {

            pierwszyCzytany.next.next.ilosc++;
            ilosc3.Text = pierwszyCzytany.next.next.ilosc.ToString();
            if (pierwszyCzytany.next.next.ilosc > 0)
            {
                trzeciMinus.Visible = true;
            }



        }
        private void button5_Click(object sender, EventArgs e)
        {

            pierwszyCzytany.next.next.next.ilosc++;
            ilosc4.Text = pierwszyCzytany.next.next.next.ilosc.ToString();
            if (pierwszyCzytany.next.next.next.ilosc > 0)
            {
                czwartyMinus.Visible = true;
            }


        }
        private void button6_Click(object sender, EventArgs e)
        {

            pierwszyCzytany.next.next.next.next.ilosc++;
            ilosc5.Text = pierwszyCzytany.next.next.next.next.ilosc.ToString();
            if (pierwszyCzytany.next.next.next.next.ilosc > 0)
            {
                trzeciMinus.Visible = true;
            }


        }
        private void button7_Click(object sender, EventArgs e)
        {
            pierwszyCzytany.ilosc--;
            ilosc1.Text = pierwszyCzytany.ilosc.ToString();
            if (pierwszyCzytany.ilosc == 0)
            {
                pierwszyMinus.Visible = false;
            }


        }
        private void button8_Click(object sender, EventArgs e)
        {

            pierwszyCzytany.next.ilosc--;
            ilosc2.Text = pierwszyCzytany.next.ilosc.ToString();
            if (pierwszyCzytany.next.ilosc == 0)
            {
                drugiMinus.Visible = false;
            }



        }
        private void button9_Click(object sender, EventArgs e)
        {

            pierwszyCzytany.next.next.ilosc--;
            ilosc3.Text = pierwszyCzytany.next.next.ilosc.ToString();
            if (pierwszyCzytany.next.next.ilosc == 0)
            {
                trzeciMinus.Visible = false;
            }



        }
        private void button10_Click(object sender, EventArgs e)
        {

            pierwszyCzytany.next.next.next.ilosc--;
            ilosc4.Text = pierwszyCzytany.next.next.next.ilosc.ToString();
            if (pierwszyCzytany.next.next.next.ilosc == 0)
            {
                czwartyMinus.Visible = false;
            }


        }
        private void button11_Click(object sender, EventArgs e)
        {

            pierwszyCzytany.next.next.next.next.ilosc--;
            ilosc5.Text = pierwszyCzytany.next.next.next.next.ilosc.ToString();
            if (pierwszyCzytany.next.next.next.next.ilosc == 0)
            {
                piatyMinus.Visible = false;
            }


        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                pierwszyCzytany = pierwszyCzytany.next.next.next.next.next;
            }
            catch (System.NullReferenceException)
            {
                button2.Visible = false;
                button2.Enabled = false;
                pierwszyCzytany = arty.tail;
            }
            if (pierwszyCzytany == null)
            {
                button2.Visible = false;
                button2.Enabled = false;
                pierwszyCzytany = arty.tail;
                return;
            }
            else if (pierwszyCzytany.next == null)
            {
                button2.Visible = false;
                button2.Enabled = false;

            }
            button1.Visible = true;
            button1.Enabled = true;
            ZmianaText();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                pierwszyCzytany = pierwszyCzytany.prev.prev.prev.prev.prev;
            }
            catch (System.NullReferenceException)
            {
                pierwszyCzytany = arty.head;
            }
            if (pierwszyCzytany == null)
            {
                button1.Visible = false;
                button1.Enabled = false;
                pierwszyCzytany = arty.head;
                return;
            }
            else if (pierwszyCzytany.prev == null)
            {
                button1.Visible = false;
                button1.Enabled = false;
            }

            button2.Visible = true;
            button2.Enabled = true;

            ZmianaText();
        }

    }
}
