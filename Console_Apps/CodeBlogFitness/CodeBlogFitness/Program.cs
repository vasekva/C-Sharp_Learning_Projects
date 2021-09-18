using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using CodeBlogFitness_BL.Controller;
using CodeBlogFitness_BL.Model;

//TODO: сделать получение единственного объекта класса во всех методах
//TODO: изменить формат принимаего времени для активностей
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
            Console.WriteLine(GetStrFromDictionary("Greeting", prog.culture));
            Console.Write(GetStrFromDictionary("UserName_Input", prog.culture));

            var userName = Console.ReadLine();
            var userController = new UserController(userName);

            if (userController.IsNewUser)
            {
                Console.Write(GetStrFromDictionary("UserGender_Input", prog.culture));

                var gender = Console.ReadLine();
                var birthDate = ParseDateTime(GetStrFromDictionary("Birthday_User", prog.culture));
                var weight = ParseDouble(GetStrFromDictionary("Weight_User", prog.culture));
                var height = ParseDouble(GetStrFromDictionary("Height_User", prog.culture));

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.Users.SingleOrDefault(u => u.Name == userName));

            ReadUserActions(prog, userController);
        }

        private static void ReadUserActions(Program prog, UserController userController)
        {
            var mealController = new MealController(userController.CurrentUser);
            var exersiceController = new ExerciseController(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine(GetStrFromDictionary("ActionSelection", prog.culture));
                Console.WriteLine(GetStrFromDictionary("Choise_E", prog.culture));
                Console.WriteLine(GetStrFromDictionary("Choise_A", prog.culture));
                Console.WriteLine(GetStrFromDictionary("Choise_Q", prog.culture));

                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var food = EnterMeal();
                        mealController.Add(food.Food, food.Weight);

                        //TODO: сделать вывод приемов пищи только одного пользователя
                        foreach (var item in mealController.Meal.Products)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exerciseValues = EnterExercise();
                        exersiceController.Add(exerciseValues.activity, exerciseValues.startTime, exerciseValues.finishTime);

                        //TODO: сделать вывод активностей только одного пользователя
                        foreach (var item in exersiceController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity}" +
                                $" с {item.StartTime.ToShortTimeString()} до {item.FinishTime.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static (DateTime startTime, DateTime finishTime, Activity activity) EnterExercise()
        {
            Program prog = new Program();

            Console.Write(GetStrFromDictionary("ActivityName_Input", prog.culture));
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");
            var startTime = ParseDateTime(GetStrFromDictionary("StartTime", prog.culture));
            var finishTime = ParseDateTime(GetStrFromDictionary("FinishTime", prog.culture));
            var activity = new Activity(name, energy);

            return (startTime, finishTime, activity);
        }

        public static string GetStrFromDictionary(string str, CultureInfo culture)
        {
            Program prog = new Program();

            return prog.resourсeManager.GetString(str, culture);
        }

        private static (Food Food, double Weight) EnterMeal()
        {
            Program prog = new Program();

            Console.Write(GetStrFromDictionary("FoodName_Input", prog.culture));
            var food = Console.ReadLine();

            var calories = ParseDouble(GetStrFromDictionary("Calories", prog.culture));
            var proteins = ParseDouble(GetStrFromDictionary("Proteins", prog.culture));
            var fats = ParseDouble(GetStrFromDictionary("Fats", prog.culture));
            var carbs = ParseDouble(GetStrFromDictionary("Carbs", prog.culture));
            var weight = ParseDouble(GetStrFromDictionary("Weight_Serving", prog.culture));

            var product = new Food(food, calories, proteins, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            Program prog = new Program();
         
            while (true)
            {
                // TODO: На MacOS формат даты MM.DD.YYYY, у винды DD.MM.YYYY 
                Console.Write(GetStrFromDictionary("Input", prog.culture) + $" {value}" + " (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    //if (DateTime.Now.Year - birthDate.Year >= 60
                    //    || DateTime.Now.Year - birthDate.Year <= 14)
                    //    Console.WriteLine(GetStrFromDictionary("Incorrect_Age", prog.culture)); 
                   // else
                        break;
                }
                else
                {
                    Console.WriteLine(GetStrFromDictionary("Incorrect_FieldFormat", prog.culture));
                }
            }
            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            Program prog = new Program();

            while (true)
            {
                Console.Write(GetStrFromDictionary("Input", prog.culture) + $" {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine(GetStrFromDictionary("Incorrect_Format", prog.culture));
                }
            }
        }
    }
}
