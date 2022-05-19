using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Final
{
    
    public abstract class Person
    {
        #region constructors

        public Person()
        {
            List<Contacts> contacts = new List<Contacts>();
            Contacts = contacts;
            CountPeople ++;
            Name = "";            
            birthDate = new DateTime(1900, 1, 1);            
        }

        #endregion
        #region atributes
        private int id;
        private string name;        
        private DateTime birthDate;
        private List<Contacts> contacts;
        private static int countPeople = 0;
        private string nif;              

        #endregion
        #region properties

        public byte age
        {
            get
            {
                byte idade = (byte)(DateTime.Now.Year - birthDate.Year);

                if (birthDate.Date > DateTime.Now.AddYears(-idade))
                    idade--;

                return idade;
            }
        }
        

        public string Name { get => name; set => name = value; }      
        public DateTime BirthDate { get => birthDate ; set => birthDate = value; }
        public List<Contacts> Contacts { get => contacts; set => contacts = value; }
        public static int CountPeople { get => countPeople; set => countPeople = value; }         
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => id; set => id = value; }

        #endregion
    }
}
