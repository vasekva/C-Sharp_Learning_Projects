using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Interfaces
{
    interface ICarsCategory
    {
       IEnumerable<Category> AllCategories { get; }
    }
}
