using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Final
{
    public class Store
    {
        public Store()
        {
            id = "";
            address = "";
            city = "";
            comercialName = "";            
        }
        
        #region Atributes

        private string id;
        private string address;
        private string city;
        private string comercialName;       

        #endregion
        #region Properties      


        public string Name
        {
            get
            {
                string s = City + id.ToString(); // exemplo: Benfica001
                return s;
            }
        }
        

        public string ID { get => id; set => id = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string ComercialName { get => comercialName; set => comercialName = value; }
        
    }
    #endregion
}