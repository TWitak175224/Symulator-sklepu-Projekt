using System.Diagnostics;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Symulator_sklepu
{
    public partial class Form1 : Form
    {
        public List arty = new List();

        int alfab = 0, cen = 0;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            zamykanie();
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
        public Form1()
        {
            InitializeComponent();
            czytanie();
            String[] nazwy = { "a", "b", "x", "z", "y" };
            int[] ceny = { 100, 23, 15, 234, 80 };


            for (int i = 0; i < 5; i++)
            {
                //arty.AddFirst(nazwy[i], ceny[i], 3);
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
            if (alfab != 1)
            {
                cen = 0;
                arty.InsertionSortAlf();
                alfab = 1;
                ZmianaText();
                button1.Text = "A-Z";


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cen != -1)
            {
                alfab = 0;
                arty.InsertionSortPrice();
                cen = 1;
                ZmianaText();

                button2.Text = "1-10";

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
