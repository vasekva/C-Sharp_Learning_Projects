using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    class Category
    {
        public int id { get; set; }
        
        public string categoryName { get; set; }

        public string description { get; set; }

        public List<Car> cars { get; set; }
    }
}
