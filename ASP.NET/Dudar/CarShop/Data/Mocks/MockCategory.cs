using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Mocks
{
    class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Электромобили", description = "Современный вид транспорта"},
                    new Category { categoryName = "Автомобили с ДВС", description = "Машины с двигателем внутреннего сгорания"},
                };
            }
        }
    }
}
