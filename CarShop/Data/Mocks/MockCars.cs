using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Mocks
{
    class MockCars : IManageCars
    {
        private readonly ICarsCategory carsCategory = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car { name = "Tesla", shortDesc = "", longDesc = "", img = "", price = 45000,
                        isFavourite = true, available = true, Category = carsCategory.AllCategories.First() },
                };
            }
        }
        public IEnumerable<Car> getFavouriteCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
