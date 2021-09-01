using CarShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IManageCars _manageCars;
        private readonly ICarsCategory _carsCategories;

        CarsController(IManageCars manage, ICarsCategory _categories)
        {
            _manageCars = manage;
            _carsCategories = _categories;
        }

        public ViewResult List()
        {
            var cars = _manageCars.Cars;
            return View(cars);
        }
    }
}
