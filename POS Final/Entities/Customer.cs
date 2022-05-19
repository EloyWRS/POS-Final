using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Final
{
    [Table("Customer")]
    public class Customer : Person
    {
        public Customer()
        {
            List<Contacts> contactos = new List<Contacts>();
            Contacts = contactos;
            CountCustomer++;
            CountPeople++;
            Name = "";
            BirthDate = new DateTime(1900, 1, 1);
        }
        #region Atributos

        private static int countCustomer = 0;
        public static int CountCustomer { get => countCustomer; set => countCustomer = value; }       

        #endregion

        /*public Customer(List<Contacto> aContactos, string aFistName, string aLastName, DateTime aDataNascimento)

        {
            
            CountPeople++;
            FirstName = aFistName;
            LastName = aLastName ;
            DataNascimento = aDataNascimento;
        }*/


    }
}
