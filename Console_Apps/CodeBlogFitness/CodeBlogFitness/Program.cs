using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using CodeBlogFitness_BL.Controller;
using CodeBlogFitness_BL.Model;

//TODO: сделать получение единственного объекта класса во всех методах
namespace CodeBlogFitness
{
    public class Program
    {
        CultureInfo culture
            = CultureInfo.CreateSpecificCulture("ru-ru");
        ResourceManager resourсeManager
            = new ResourceManager("CodeBlogFitness.Languages.Messages", typeof(Program).Assembly);

        static void Main(string[] args)
        {
            Program prog = new Program();
            Console.WriteLine(GetCultureString("Greeting", prog.culture));
            Console.Write(GetCultureString("UserName_Input", prog.culture));

            var userName = Console.ReadLine();
            var userController = new UserController(userName);
            var mealController = new MealController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(GetCultureString("UserGender_Input", prog.culture));

                var gender = Console.ReadLine();
                var birthDate = ParseDateTime(); ;
                var weight = ParseDouble(GetCultureString("Weight_User", prog.culture)); 
                var height = ParseDouble(GetCultureString("Height_User", prog.culture));

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.Users.SingleOrDefault(u => u.Name == userName));

            Console.WriteLine(GetCultureString("ActionSelection", prog.culture));
            Console.WriteLine(GetCultureString("Choise_E", prog.culture)); 
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterMeal();
                mealController.Add(foods.Food, foods.Weight);

                //TODO: сделать вывод приемов пищи только одного пользователя
                foreach (var item in mealController.Meal.Products)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
            Console.ReadLine();
        }

        public static string GetCultureString(string str, CultureInfo culture)
        {
            Program prog = new Program();

            return prog.resourсeManager.GetString(str, culture);
        }

        private static (Food Food, double Weight) EnterMeal()
        {
            Program prog = new Program();

            Console.Write(GetCultureString("FoodName_Input", prog.culture));
            var food = Console.ReadLine();

            var calories = ParseDouble(GetCultureString("Calories", prog.culture));
            var proteins = ParseDouble(GetCultureString("Proteins", prog.culture));
            var fats = ParseDouble(GetCultureString("Fats", prog.culture));
            var carbs = ParseDouble(GetCultureString("Carbs", prog.culture));
            var weight = ParseDouble(GetCultureString("Weight_Serving", prog.culture));

            var product = new Food(food, calories, proteins, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            Program prog = new Program();
         
            while (true)
            {
                Console.Write(GetCultureString("Birthday_Input", prog.culture) + " (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    if (DateTime.Now.Year - birthDate.Year >= 60
                        || DateTime.Now.Year - birthDate.Year <= 14)
                        Console.WriteLine(GetCultureString("Incorrect_Age", prog.culture)); 
                    else
                        break;
                }
                else
                {
                    Console.WriteLine(GetCultureString("Incorrect_AgeFormat", prog.culture));
                }
            }
            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            Program prog = new Program();

            while (true)
            {
                Console.Write(GetCultureString("Input", prog.culture) + $" {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine(GetCultureString("Incorrect_Format", prog.culture));
                }
            }
        }
    }
}
