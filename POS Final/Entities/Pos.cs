using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Final
{
    public class Pos
    {
        public CultureInfo pt = new CultureInfo("pt-PT");
        
        #region static declarations
        public static string[] menuHome => new[] {
            "Add Customer (Register customer information data)",
            "Search Product",
            "New Sale"
        };
        public static string[] menuAddCustomerData => new[]
        {
            "First and last name:",            
            "Birthdate 'dd,mm,yyyy':"
        };         
        public static string[] menuNewSale => new[] {
            "NAME",
            "BRAND",
            "CATEGORY",
            "PRICE/U",
            "STOCK",
            "QUANTITY",
            "PRICE/T"            
        };
        #endregion
        #region atributos

        private bool isRunning;
        //private List<Product> sale;        
        private string user;
        
        
        #endregion
        #region propriedades

        public bool IsRunning { get; set; }
        public string User { get => user; set => user = value; }


        #endregion
        #region Main Methods
        public void Start()
        {
            Console.WriteLine("POS Starting...");
            
            while (!Login())
            {
                Console.WriteLine("Login failed. Try again.");
            }

            IsRunning = true;
        }      
        public void Stop()
        {
            Console.WriteLine("POS stopping...");
            IsRunning = false;
            
        }
        public void Execute()
        {
            var option = SelectOptionHomeMenu(); // op = 0, 1 ou 2: 0= add customer, 1=whatever, 2=whatever              
                            
                    ProcessHomeMenuOption(option); //after picking choice it resets to start of execute
            
        }                
        private void ProcessHomeMenuOption(string option)//leva o argumento 0,1 ou 2
        {
            switch (option)
            {
                case "1":                    
                        AddCustomer();                                
                    break;
                case "2":
                    SearchProducts();
                    break;
                case "3":
                    AddProduct();
                    break;                        
            }
        }       
        public void AddProduct()
        {            
            Console.Clear();
            Product product = SearchProducts();           
            //shows searched product                            
                Console.WriteLine("{0, -20} {1, -40}{2,-10}{3,-10}{4, -10}{5, -7}{6, -13}{7, -10}", "", product.Name, product.Brand,
                product.Category, product.Price, product.Stock, product.Quantity, product.Price * product.Quantity);            
            // select quantity of the item
            Console.WriteLine("How many to Add?");
             string input0 = Console.ReadLine();
            /* OPÇÃO DE SAÍDA
            if (input0 == "x")
            {
                return;
            }    */            
            //instanciar objeto sale e definir o valor igual ao produto procurado            
            var quantity = 0;
            quantity = Convert.ToInt32(input0);
            var shoppingList = Repository.shoppinglist;
            //verifica disponibilidade em stock para esse produto
            //se true, adiciona produto à shopping List            
                if (quantity <= product.Stock)
                {
                    product.Stock = product.Stock - quantity;
                    product.Quantity = quantity;
                    Repository.shoppinglist.Add(product);
                    foreach (var P1 in shoppingList)
                    {
                        Console.WriteLine("{0, -19} {1, -40}{2,-10}{3,-10}{4, -10}{5, -7}{6, -13}{7, -10}", "", "NAME",
                        menuNewSale[1], menuNewSale[2], menuNewSale[3], menuNewSale[4], menuNewSale[5], menuNewSale[6]);
                        Console.WriteLine("{0, -20} {1, -40}{2,-10}{3,-10}{4, -10}{5, -7}{6, -13}{7, -10}", "",
                           P1.Name, P1.Brand,
                            P1.Category, P1.Price, P1.Stock,
                               P1.Quantity, P1.Price * P1.Quantity);
                    }                
                }            //se false, indica que não existem produtos suficientes em stock e
            //questiona utilizador se quer continuar a adicionar produtos 
            //à lista.
            else
                Console.WriteLine("Not enough items in stock");
                Console.WriteLine("\n\n\n\n\nAdd new product? 'yes' or 'no'");
            // se true, continua  a adicionar
            NewProduct();
        }  
        public void NewProduct()
        {
            var input = Console.ReadLine();
            if (input != "no")
            {
                AddProduct();
            }
            else
                Checkout();
        }
        public void DescriptionItemsPropertiesTitle()
        {
            Console.Clear();
            Console.WriteLine("{0, -19} {1, -40}{2,-10}{3,-10}{4, -10}{5, -7}{6, -13}{7, -10}", "", "NAME",
                menuNewSale[1], menuNewSale[2], menuNewSale[3], menuNewSale[4], menuNewSale[5], menuNewSale[6]);
        }
        public void DescriptionCheckout() //Ultimo a correr no Add product branch -- VOLTA AO EXECUTE
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var shoppingList = Repository.shoppinglist;
            double total = 0;
            string user = Repository.Name;
            var date = DateTime.Now;
            Console.WriteLine("CHECKOUT\n\n");
            DescriptionItemsPropertiesTitle();
            foreach (var P1 in shoppingList)
            {
                total = total + (P1.Price * P1.Quantity);                
                Console.WriteLine("{0, -20} {1, -40}{2,-10}{3,-10}{4, -10}{5, -7}{6, -13}{7, -10}", "",
                    P1.Name, P1.Brand,
                    P1.Category, P1.Price.ToString("C2", pt), P1.Stock,
                    P1.Quantity, P1.Price * P1.Quantity);
            }
            Console.WriteLine("Total = " + total.ToString("C2", pt) + "\n\n");
            Console.WriteLine("\n\n" + user.ToString() + "\n\n" + date.ToString("dd-mm-yyyy"));
            Console.ReadKey();
            Console.Clear();
            Execute();
        }
        public void Checkout() 
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double total = 0;
            List<Product> shoppingList = Repository.shoppinglist;
            DescriptionItemsPropertiesTitle();
            foreach (var P1 in shoppingList)
                {
                    total = total + (P1.Price * P1.Quantity);                   
                    Console.WriteLine("{0, -20} {1, -40}{2,-10}{3,-10}{4, -10}{5, -7}{6, -13}{7, -10}", "",
                        P1.Name, P1.Brand,
                        P1.Category, P1.Price,P1.Stock,
                        P1.Quantity, P1.Price * P1.Quantity);                    
                }            
            Console.WriteLine("TOTAL €\t" + total +"\n\n Finalizar venda? 's' ou 'n'");
            var input = Console.ReadLine();
                if (input == "s")
                 {
                    DescriptionCheckout();                    
                 } // reset quantidade mas não do stock. IAS AQUI PARCEIRO
            
        }
        private Product SearchProducts()//Interface Search product; Returns a List of searched on products based, based on user input and searched for name, brand and category.
        {
            Console.Clear();
            List<Product> products = Repository.products;
            Console.WriteLine("\tSearch Product:\n");
            string input = Console.ReadLine().ToLower();
            var searchedProducts = from p in products
                                   where p.Name.Contains(input) || p.Brand.Contains(input) || p.Category.Contains(input)
                                   orderby p.Name
                                   select p;
            var listProducts = searchedProducts.ToList();

            Console.WriteLine("{0, -19} {1, -40}{2,-10}{3,-10}{4, -10}{5, -7}{6, -13}{7, -10}", "", "NAME",
                     menuNewSale[1], menuNewSale[2], menuNewSale[3], menuNewSale[4], menuNewSale[5], menuNewSale[6]);
            var count = 0;
            foreach (var item in searchedProducts)
            {
                count++;
                Console.WriteLine("{0, -20} {1, -40}{2,-10}{3,-10}{4, -10}{5, -7}{6, -13}{7, -10}", "PRESS " + count + " TO ADD",
                    item.Name, item.Brand, item.Category, item.Price, item.Stock, item.Quantity, item.Price*item.Quantity);
            }        
            
            
            int searchedProductOrder = Convert.ToInt32(Console.ReadLine());            
            var searchedProductId = listProducts[searchedProductOrder-1].ID;
            var searchRepository = from p in Repository.products
                                             where p.ID == searchedProductId
                                             select p;

            var batata = searchRepository.ToList();
            var final = batata[0];
            return final;
        }
        //Devolve lista de productos existentes em repositório, baseada no input de pesquisa introduzido pelo utilizador      
        
        static public bool Login()//Interface de Login; faz query para comparar propriedades de username e password do mesmo employee com aquelas introduzidas pelo utilizador. Devolve True se encontrar; False se não.
        {
            Console.Clear();
            var employees = Repository.employees;
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password");
            string password = Console.ReadLine();
            var queryLogin = employees.FirstOrDefault(e => e.Username == username &&
            e.Password == password);            

            if (queryLogin != null)
            {
                Console.Clear();
                Console.WriteLine("Login sucessfull\n\n");
                //guardar nome de utilizador logado em pos
                var userRealName = (from e in employees
                                    where e.Username == username                   
                                    select new { e.Name }).FirstOrDefault();
                Repository.Name = userRealName.Name;
                Console.WriteLine("Welcome " + userRealName.Name + "\n\n");
                return true;
            }
            else
                Console.WriteLine("Login failed");
                Console.ReadKey();
            return false;
        }        
                
        private string SelectOptionHomeMenu() //shows HomeMenu's 3 options to user and waits for user to chose 1 of 3 given values
        {
            for (int i = 0; i < menuHome.Length; i++)
            {
                Console.WriteLine($"{i+1} - {menuHome[i]}");
            }
            
            var selectedOption = Console.ReadLine();

            return selectedOption;
        }         
       
        #region add customer
        private Customer AskCustomerData() //returns a "customer" object with attributes given by user input
        {
            Customer c1 = new Customer();
            var name = "";           
            DateTime birthdate = new DateTime(); //Instance variables

            Console.WriteLine($"{menuAddCustomerData[0]}\n"); //ask  name
            name = Console.ReadLine();       //save user input as first name                           
            Console.WriteLine($"{menuAddCustomerData[1]}\n"); // ask birthdate
            DateTime.TryParse( Console.ReadLine(), out birthdate);   //save user input as datetime      

            c1.Name = name;            
            c1.BirthDate = birthdate;  
            
            return c1;
        }        
        private void AddCustomer() //Loops until input = 'no'; Picks Objected created by user input and adds it to repository
        {            
            Customer newCustomer = AskCustomerData(); 
            Repository.customers.Add(newCustomer);
            Console.WriteLine("yey");
            Console.WriteLine("Add new costumer? 'yes' or 'no'");
            string input = Console.ReadLine();
            if(input != "no")
            {
                AddCustomer();
            }//throw new NotImplementedException();
        }
        

        #endregion
    }

}
#endregion
