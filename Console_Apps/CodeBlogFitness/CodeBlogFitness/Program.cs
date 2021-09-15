using System;
using System.Linq;
using CodeBlogFitness_BL.Controller;
using CodeBlogFitness_BL.Model;

namespace CodeBlogFitness
{
    public class Program
    {
        public Program()
        {
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение CodeBlogFitness");

            Console.WriteLine("Введите имя пользователя:");
            var userName = Console.ReadLine();

            var userController = new UserController(userName);
            var mealController = new MealController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите ваш пол: ");

                var gender = Console.ReadLine();
                var birthDate = ParseDateTime(); ;
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.Users.SingleOrDefault(u => u.Name == userName));

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine("\b\b");

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterMeal();
                mealController.Add(foods.Food, foods.Weight);

                foreach (var item in mealController.Meal.Products)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterMeal()
        {
            Console.Write("Введите название еды: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность еды");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");

            var product = new Food(food, calories, proteins, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите вашу дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    if (DateTime.Now.Year - birthDate.Year >= 60
                        || DateTime.Now.Year - birthDate.Year <= 14)
                        Console.WriteLine("Приложение не расчитано на людей такого возраста");
                    else
                        break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения!");
                }
            }

            return birthDate;
        }

        private static double ParseDouble (string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}");
                }
            }

        }

    }

}
