using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Final
{
    [Table("Contacts")]
    public class Contacts
    {
        public Contacts()
        {           
           number = "";
           designation= "";
        }

        private string number;
        private string designation;
        private int contactsId;

        public string Number { get => number; set => number = value; }
        public string Designation { get => designation; set => designation = value; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactsID { get => contactsId; set => contactsId = value; }
    }
}
