using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_sklepu
{
    public class ProductModel
    {
        public ProductModel()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Price = 0;
            this.numOfProd = 0;
        }

        public ProductModel(string name, string description, double price, int numOfProd)
        {
            Name = name;
            Description = description;
            Price = price;
            this.numOfProd = numOfProd;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int numOfProd {  get; set; }
        
    }
}
