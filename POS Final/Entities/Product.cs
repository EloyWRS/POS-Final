using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Final
{

    
    
    public class Product
    {

        public Product()
        {
            name = "";
            Brand = "";
            Price = 0;
            Category = "utilities";
        }
        #region attributes

        private string name;
        private string brand;
        public string category;
        private double price;
        private int stock;
        private int id;
        private int quantity;

        #endregion
        #region properties

        public string Name { get => name; set => name = value; }
        public string Brand { get => brand; set => brand = value; }
        public double Price { get => price; set => price = value; }
        public int Stock { get => stock; set => stock = value; }
        public int ID { get => id; set => id = value; }        
        public string Category
        {
            get => category;
            set
            {
                if (value == "food" || value == "housing" || value == "utilities" ||
                    value == "medicine" || value == "communications")
                {
                    category = value;
                }
                else
                    category = "error";
            }
        }
        public int Quantity { get => quantity; set => quantity = value; }

        static public double operator +(Product product1, Product product2)
        {
            double resultado = product1.Price + product2.Price;
            return resultado;
        }
        





        #endregion
    }
}
