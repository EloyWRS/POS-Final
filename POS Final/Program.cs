using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var store = Repository.Stores();
            Console.WriteLine(store[0].Name + );*/
            /*var employee = Repository.Employee();
            var customer = Repository.Customer();

            foreach (Employee item in employee)
            {
                Console.WriteLine("{0,-15}{1,15}{2,10}", item.FirstName, item.LastName, item.age.ToString());

                foreach (Contacts c in item.Contacts)
                {
                    Console.WriteLine("{0,-10}{1,10}", c.Number, c.Designation);
                }
            }
            Console.WriteLine("Count people = " + Person.CountPeople);
            Console.WriteLine("Count employee = " + Employee.CountEmployees);
            Console.WriteLine("Count customers = " + Customer.CountCustomer);*/
            using (Context x = new Context())
            {
                var pos = new Pos();

                pos.Start();
                // pos.IsRunning = true;

                while (pos.IsRunning)
                {
                    pos.Execute();
                }
            }
             /*
         foreach (Employee p in Repository.employees)
         {

             Console.WriteLine("{0, -40}{1, -20}", p.Username, p.Password);
         }*/           
        }
        
    }
}
