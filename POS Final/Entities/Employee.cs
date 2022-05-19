using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Final
{
    [Table("Employee")]   
    public class Employee : Person
    {
        #region Constructors
        public Employee()
        {
                     
            
            CountPeople++;
            CountEmployees++;
            Name = "";            
            BirthDate = new DateTime(1900, 1, 1);
            
        }

        #endregion
        #region Atributes


        private static int countEmployees = 0;       
        private int id;

        #endregion
        #region Properties

        public static int CountEmployees { get => countEmployees; set => countEmployees = value; }
       
        public int Id { get => id; }

        public Store Store { get; set; }
        public string Username
        {
            get
            {
                string username = "wtf" + Name;
                return username;
            }
        }
        public string Password
        {
            get
            {
                string password = Name + "ftw!";
                return password;
            }
        }



        #endregion


    }
}
