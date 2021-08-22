using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Interfaces
{
    interface IManageCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFavouriteCars { get; set; }
        Car GetObjectCar(int carId);

    }
}
