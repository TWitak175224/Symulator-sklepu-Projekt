using System.Diagnostics;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace Symulator_sklepu
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public List arty = new List();

        private NodeL pierwszyCzytany = new NodeL();
        int alfab = 0, cen = 0;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            zamykanie();
        }
        private void Form1_Activated(object sender, System.EventArgs e)
        {
            czytanie();
            ZmianaText();
            pierwszyCzytany = arty.head;
        }
        public Form1()
        {
            InitializeComponent();
            instance = this;
            //czytanie();
            String[] nazwy = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j","k" };
            int[] ceny = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1,0 };
            for (int i = 0; i < nazwy.Length; i++)
            {
                arty.AddLast(nazwy[i], ceny[i], 21);
            }
            pierwszyCzytany = arty.head;
            button5.Visible = false;
            button5.Enabled = false;

            ZmianaText();
        }
        private int SprawdzIleDoWyswietlenia()
        {
            NodeL p = this.pierwszyCzytany;
            int i = 0;
            for (; i < 5 && p != null; i++) { }
            return i;
        }
        private void zamykanie()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProductModel[]));
            ProductModel[] tablica = new ProductModel[arty.count];
            NodeL produkt = arty.head;
            for (int i = 0; i < arty.count; i++)
            {

                tablica[i] = new ProductModel(produkt.nazwa, "", produkt.cena_w_gr, produkt.ilosc);
                produkt = produkt.next;
            }
            using (FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Artyku³y.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, tablica);

                MessageBox.Show("Created");
            }
            serializer = new XmlSerializer(typeof(String));
            using (FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Ile.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, arty.count.ToString());
            }
        }

        public void czytanie()
        {
            String? ile = "";
            uint i = 0;
            XmlSerializer serializer = new XmlSerializer(typeof(String));
            try
            {
                using (FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Ile.xml", FileMode.Open, FileAccess.Read))
                {
                    ile = serializer.Deserialize(fs) as String;
                    if (ile != null)
                    {
                        i = uint.Parse(ile);
                    }

                }
            }
            catch (System.IO.FileNotFoundException)
            {
                return;
            }
            ProductModel[]? tablica = new ProductModel[i];
            serializer = new XmlSerializer(typeof(ProductModel[]));
            using (FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Artyku³y.xml", FileMode.Open, FileAccess.Read))
            {
                tablica = serializer.Deserialize(fs) as ProductModel[];
            }
            for (uint j = 0; j < i; j++)
            {
                this.arty.AddFirst(tablica[j].Name, tablica[j].Price, tablica[j].numOfProd);
            }
        }

        public void czytanie_dodanych()
        {
            String? ile = "";
            uint i = 0;
            XmlSerializer serializer = new XmlSerializer(typeof(String));
            try
            {
                using (FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Ile.xml", FileMode.Open, FileAccess.Read))
                {
                    ile = serializer.Deserialize(fs) as String;
                    if (ile != null)
                    {
                        i = uint.Parse(ile);
                    }

                }
            }
            catch (System.IO.FileNotFoundException)
            {
                return;
            }
            ProductModel[]? tablica = new ProductModel[i];
            serializer = new XmlSerializer(typeof(ProductModel[]));
            using (FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Artyku³y_dodane.xml", FileMode.Open, FileAccess.Read))
            {
                tablica = serializer.Deserialize(fs) as ProductModel[];
            }
            for (uint j = 0; j < i; j++)
            {
                this.arty.AddFirst(tablica[j].Name, tablica[j].Price, tablica[j].numOfProd);
            }
        }
        private void ZmianaText()
        {
            {
                System.Windows.Forms.Label[] labelki_nazw = { nazwa1, nazwa2, nazwa3, nazwa4, nazwa5 };
                System.Windows.Forms.Label[] labelki_cen = { cena1, cena2, cena3, cena4, cena5 };
                System.Windows.Forms.Label[] labelki_ilosci = { ilosc1, ilosc2, ilosc3, ilosc4, ilosc5 };
                Button[] przyciski = { button6, button7, button8, button9, button10 };
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
                        przyciski[i].Visible = false;

                    }
                    else
                    {
                        labelki_nazw[i].Text = czytany.nazwa;
                        labelki_cen[i].Text = czytany.PrintCena();
                        labelki_ilosci[i].Text = czytany.ilosc.ToString();
                        przyciski[i].Visible = true;
                        czytany = czytany.next;
                    }
                }

                
                //for (; i < check; i++)
                //{

                //}

            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (alfab != 1)
            {
                cen = 0;
                arty.InsertionSortAlf();
                pierwszyCzytany = this.arty.head;
                alfab = 1;
                ZmianaText();
                button1.Text = "A-Z";
                button4.Visible = true;
                button4.Enabled = true;

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cen != -1)
            {
                alfab = 0;
                arty.InsertionSortPrice();
                pierwszyCzytany = this.arty.head;
                cen = 1;
                ZmianaText();

                button2.Text = "1-10";
                button4.Visible = true;
                button4.Enabled = true;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            zamykanie();
            Form2 f2 = new Form2();
            f2.FormClosing += new FormClosingEventHandler(this.Form2_FormClosing);
            f2.Show();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            arty.Dodaj(Form2.instance.artyDod);
            ZmianaText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                pierwszyCzytany = pierwszyCzytany.next.next.next.next.next;
            }
            catch (System.NullReferenceException)
            {
                button4.Visible = false;
                button4.Enabled = false;
                pierwszyCzytany = arty.tail;
            }
            if (pierwszyCzytany == null)
            {
                button4.Visible = false;
                button4.Enabled = false;
                pierwszyCzytany = arty.tail;
                return;
            }
            else if (pierwszyCzytany.next == null)
            {
                button4.Visible = false;
                button4.Enabled = false;

            }
            button5.Visible = true;
            button5.Enabled = true;
            ZmianaText();

        }

        private void button5_Click(object sender, EventArgs e)
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
                button5.Visible = false;
                button5.Enabled = false;
                pierwszyCzytany = arty.head;
                return;
            }
            else if (pierwszyCzytany.prev == null)
            {
                button5.Visible = false;
                button5.Enabled = false;
            }

            button4.Visible = true;
            button4.Enabled = true;

            ZmianaText();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pierwszyCzytany.ilosc--;
            ilosc1.Text = pierwszyCzytany.ilosc.ToString();
            if (pierwszyCzytany.ilosc == 0)
            {
                button6.Visible = false;
            }
            

        }
        private void button7_Click(object sender, EventArgs e)
        {
           
                pierwszyCzytany.next.ilosc--;
                ilosc1.Text = pierwszyCzytany.next.ilosc.ToString();
                if (pierwszyCzytany.next.ilosc == 0)
                {
                    button7.Visible = false;
                }
           
            

        }
        private void button8_Click(object sender, EventArgs e)
        {
            
                pierwszyCzytany.next.next.ilosc--;
                ilosc1.Text = pierwszyCzytany.next.next.ilosc.ToString();
                if (pierwszyCzytany.next.next.ilosc == 0)
                {
                    button8.Visible = false;
                }
            
            

        }
        private void button9_Click(object sender, EventArgs e)
        {
            
                pierwszyCzytany.next.next.next.ilosc--;
                ilosc1.Text = pierwszyCzytany.next.next.next.ilosc.ToString();
                if (pierwszyCzytany.next.next.next.ilosc == 0)
                {
                    button9.Visible = false;
                }
            

        }
    }
}
