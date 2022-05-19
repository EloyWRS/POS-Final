using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Final
{
    
    public class Repository
    {
        public static List<Customer> customers = new List<Customer>();
        public static List<Employee> employees = new List<Employee>();
        public static List<Store> stores = new List<Store>();
        public static string Name  { get; set; }
        public static List<Product> products = new List<Product>();
        public static List<Product> shoppinglist = new List<Product>();

        static Repository()
        {
            #region stores

            Store s1 = new Store();
            s1.Address = "Av. Lusíada, 1500-392 Lisboa";
            s1.City = "Benfica";
            s1.ComercialName = "Colombo";
            s1.ID = "001";
            stores.Add(s1);



            #endregion            
            #region employees

            Employee e1 = new Employee();
            e1.Name = "Harry Potter";            
            e1.BirthDate = new DateTime(1993, 10, 11);            
            e1.Contacts.Add(new Contacts() { Designation = "pessoal", Number = "914586248" });
            e1.Store = s1;
            employees.Add(e1);
            
            #endregion
            #region customers

            Customer c1 = new Customer();
            c1.Name = "Tomás Eloy";          
            c1.BirthDate = new DateTime(1993, 5, 1);
            c1.Contacts.Add(new Contacts() { Designation = "pessoal", Number = "967858585" });
            c1.Contacts.Add(new Contacts() { Designation = "profissional", Number = "937858585" });
            customers.Add(c1);


            #endregion
            #region products

            Product p1 = new Product();
            p1.Brand = "mimosa";
            p1.Category = "food";
            p1.Name = "manteiga";
            p1.Price = 1.79;
            p1.Stock = 118;
            p1.ID = 1;


            Product p2 = new Product();
            p2.Brand = "mimosa";
            p2.Category = "food";
            p2.Name = "leite meio gordo";
            p2.Price = 0.49;
            p2.Stock = 24;
            p2.ID = 2;

            Product p4 = new Product();
            p4.Brand = "mimosa";
            p4.Category = "food";
            p4.Name = "iogurte líquido morango";
            p4.Price = 0.45;
            p4.Stock = 20;
            p4.ID = 3;

            Product p3 = new Product();
            p3.Brand = "nestle";
            p3.Category = "food";
            p3.Name = "iogurte líquido morango";
            p3.Price = 0.59;
            p3.Stock = 4;
            p3.ID = 4;

            Product p5 = new Product();
            p5.Brand = "nestle";
            p5.Category = "food";
            p5.Name = "iogurte líquido cereais";
            p5.Price = 0.65;
            p5.Stock = 40;
            p5.ID = 5;

            Product p6 = new Product();
            p6.Brand = "pescanova";
            p6.Category = "food";
            p6.Name = "salmão fumado 300g";
            p6.Price = 4.49;
            p6.Stock = 17;
            p6.ID = 6;

            Product p7 = new Product();
            p7.Brand = "rowenta";
            p7.Category = "housing";
            p7.Name = "hairdryer 2000W";
            p7.Price = 28.99;
            p7.Stock = 3;
            p7.ID = 7;

            Product p8 = new Product();
            p8.Brand = "rowenta";
            p8.Category = "housing";
            p8.Name = "iron Silence Steam";
            p8.Price = 218.99;
            p8.Stock = 0;
            p8.ID = 8;


            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);
            products.Add(p6);
            products.Add(p7);
            products.Add(p8);
            #endregion
            #region sales



            /*Sale S2 = new Sale();
            S2.ProductToSell = p1;
            shoppinglist.Add(S2);


            /*
            shopping.Add(S2);
            Sale S3 = new Sale();
            S3.ID = 3;
            Sale S4 = new Sale();
            S4.Id = 4;
            Sale S5 = new Sale();
            S5.Id = 5;
            Sale S6 = new Sale();
            S6.Id = 6;
            Sale S7 = new Sale();
            S7.Id = 7;
            Sale S8 = new Sale();
            S8.Id = 8;
            Sale S9 = new Sale();
            S9.Id = 9;
            Sale S10 = new Sale();
            S10.Id = 10;
            sales.Add(S1);
            sales.Add(S2);
            sales.Add(S3);
            sales.Add(S4);
            sales.Add(S5);
            sales.Add(S6);
            sales.Add(S7);
            sales.Add(S8);
            sales.Add(S9);*/








            #endregion
        }










    }
}
