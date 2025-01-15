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
            using (FileStream fs = new FileStream(path: Environment.CurrentDirectory + "\\Artykuły.xml", FileMode.Open, FileAccess.Read))
            {
                tablica = serializer.Deserialize(fs) as ProductModel[];
            }
            for (uint j = 0; j < i; j++)
            {
                this.arty.AddFirst(tablica[j].Name, tablica[j].Price, tablica[j].numOfProd);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            artyDod.AddFirst(textBox1.Text, double.Parse(textBox2.Text), int.Parse(textBox3.Text));
            MessageBox.Show("utworzono produkt");
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        
    }
}
