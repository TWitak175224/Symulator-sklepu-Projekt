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
        public List arty = new List();
        private NodeL pierwszyCzytany = new NodeL();
        int alfab = 0, cen = 0;
        public Form2()
        {
            InitializeComponent();
            czytanie();


            pierwszyCzytany = arty.head;


        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            zamykanie();
        }
        private void zamykanie()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProductModel[]));
            ProductModel[] tablica = new ProductModel[arty.count];
            for (int i = 0; i < arty.count; i++)
            {
                NodeL produkt = arty.head;
                tablica[i] = new ProductModel(produkt.nazwa, "", produkt.cena_w_gr, produkt.ilosc);
                produkt = produkt.next;
            }
            
            using (FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Artykuły.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, tablica);
                MessageBox.Show("Created");
            }
            serializer = new XmlSerializer(typeof(uint));
            using (FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Ile.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, arty.count);
            }
        }
        public void czytanie()
        {
            String? ile = "";
            uint i = 0;
                XmlSerializer serializer = new XmlSerializer(typeof(uint));
            using(FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Ile.xml", FileMode.Open, FileAccess.Read))
            {
                ile = serializer.Deserialize(fs) as String;
                if (ile != null)
                {
                    i = uint.Parse(ile);
                }

            }
            ProductModel[]? tablica = new ProductModel[i];
            serializer = new XmlSerializer(typeof(ProductModel[]));
            using (FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Artykuły.xml", FileMode.Open, FileAccess.Read))
            {
                tablica = serializer.Deserialize(fs) as ProductModel[] ;
            }
            for (int j = 0; j < i; j++) {
                arty.AddLast(tablica[j].Name, tablica[j].Price, tablica[j].numOfProd);
            }
        }
    }
}
