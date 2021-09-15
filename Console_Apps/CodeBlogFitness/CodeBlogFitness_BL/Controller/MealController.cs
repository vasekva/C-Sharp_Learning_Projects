using CodeBlogFitness_BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace CodeBlogFitness_BL.Controller
{
    public class MealController : BaseController
    {
        private const string PRODUCTS_FILENAME = "products.json";
        private const string MEALS_FILENAME = "meals.json";

        private readonly User currentUser;

        public List<Food> Products { get; }

        public Meal Meal { get; }

        public MealController(User currentUser)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException("Пользователь не может быть равен Null", nameof(currentUser));

            Products = GetAllProducts();
            Meal = GetMeal();
        }

        public void Add(Food food, double weight)
        {
            var product = Products.SingleOrDefault(p => p.Name == food.Name);
            if (product == null)
            {
                Products.Add(food);
                Meal.Add(food, weight);
                Save();
            }
            else
            {
                Meal.Add(product, weight);
                Save();
            }
        }

        private Meal GetMeal() 
        {
            return LoadData<Meal>(MEALS_FILENAME) ?? new Meal(currentUser);
        }

        private List<Food> GetAllProducts()
        {
            return LoadData<List<Food>>(PRODUCTS_FILENAME) ?? new List<Food>();
        }

        private void Save()
        {
            SaveData<List<Food>>(PRODUCTS_FILENAME, Products);
            SaveData<Meal>(MEALS_FILENAME, Meal); 
        }
    }
}
