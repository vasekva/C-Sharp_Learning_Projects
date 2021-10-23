using CodeBlogFitness_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness_BL.Controller
{
    public class MealController : BaseController
    {
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
                //Meal.Add(product, weight); //TODO: проверить разницу
                Meal.Add(food, weight);
                Save();
            }
        }

        private Meal GetMeal() 
        {
            return LoadData<Meal>().FirstOrDefault() ?? new Meal(currentUser);
        }

        private List<Food> GetAllProducts()
        {
            return LoadData<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            SaveData(Products);
            SaveData(new List<Meal>() { Meal }); 
        }
    }
}
