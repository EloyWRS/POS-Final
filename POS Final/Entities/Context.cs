using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Final
{
    class Context: DbContext
    {
        public Context() : base("name=bdConnection") { }        
        public DbSet<Person> People { get; set; }   
        public DbSet<Product> Products { get; set; }
    }

    
    

}
