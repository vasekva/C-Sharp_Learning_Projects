using System;
using System.Globalization;
using System.Linq;
using System.Resources;
using CodeBlogFitness_BL.Controller;
using CodeBlogFitness_BL.Model;

//TODO: изменить формат принимаего времени для активностей
namespace CodeBlogFitness
{
    public class Program
    {
        CultureInfo culture;
        ResourceManager resourсeManager
            = new ResourceManager("CodeBlogFitness.Languages.Messages", typeof(Program).Assembly);

        static void Main(string[] args)
        {
            Program program = new Program();
            
            Console.WriteLine("Пожалуйста, выберите локализацию приложения: ");
            Console.WriteLine("Please select the localization of the application: ");
            Console.WriteLine("R - ru");
            Console.WriteLine("E - en");
            var key = Console.ReadKey(true);
            Console.Clear();

            switch (key.Key)
            {
                case ConsoleKey.R:
                    program.culture = CultureInfo.CreateSpecificCulture("ru-ru");
                    break;
                case ConsoleKey.E:
                    program.culture = CultureInfo.CreateSpecificCulture("en-us");
                    break;
            }

            Console.WriteLine(GetStrFromDictionary("Greeting", program));
            Console.Write(GetStrFromDictionary("UserName_Input", program));

            var userName = Console.ReadLine();
            var userController = new UserController(userName);

            if (userController.IsNewUser)
            {
                Console.Write(GetStrFromDictionary("UserGender_Input", program));

                var gender = Console.ReadLine();
                var birthDate = ParseDateTime(program, GetStrFromDictionary("Birthday_User", program));
                var weight = ParseDouble(program, GetStrFromDictionary("Weight_User", program));
                var height = ParseDouble(program, GetStrFromDictionary("Height_User", program));

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.Users.SingleOrDefault(u => u.Name == userName));

            ReadUserActions(program, userController);
        }

        private static void ReadUserActions(Program program, UserController userController)
        {
            var mealController = new MealController(userController.CurrentUser);
            var exersiceController = new ExerciseController(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine(GetStrFromDictionary("ActionSelection", program));
                Console.WriteLine(GetStrFromDictionary("Choise_E", program));
                Console.WriteLine(GetStrFromDictionary("Choise_A", program));
                Console.WriteLine(GetStrFromDictionary("Choise_Q", program));

                var key = Console.ReadKey(true);
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var food = EnterMeal(program);
                        mealController.Add(food.Food, food.Weight);

                        //TODO: сделать вывод приемов пищи только одного пользователя
                        foreach (var item in mealController.Meal.Products)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exerciseValues = EnterExercise(program);
                        exersiceController.Add(exerciseValues.activity, exerciseValues.startTime, exerciseValues.finishTime);

                        //TODO: сделать вывод активностей только одного пользователя
                        foreach (var item in exersiceController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} " +
                                GetStrFromDictionary("From", program) +
                                $" {item.StartTime.ToShortTimeString()} " +
                                GetStrFromDictionary("To", program) +
                                $" {item.FinishTime.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static (DateTime startTime, DateTime finishTime, Activity activity) EnterExercise(Program program)
        {
            Console.Write(GetStrFromDictionary("ActivityName_Input", program));
            var name = Console.ReadLine();

            var energy = ParseDouble(program, GetStrFromDictionary("Energy", program));
            var startTime = ParseDateTime(program, GetStrFromDictionary("StartTime", program));
            var finishTime = ParseDateTime(program, GetStrFromDictionary("FinishTime", program));
            var activity = new Activity(name, energy);

            return (startTime, finishTime, activity);
        }

        public static string GetStrFromDictionary(string str, Program program)
        {
            return program.resourсeManager.GetString(str, program.culture);
        }

        private static (Food Food, double Weight) EnterMeal(Program program)
        {
            Console.Write(GetStrFromDictionary("FoodName_Input", program));
            var food = Console.ReadLine();

            var calories = ParseDouble(program, GetStrFromDictionary("Calories", program));
            var proteins = ParseDouble(program, GetStrFromDictionary("Proteins", program));
            var fats = ParseDouble(program, GetStrFromDictionary("Fats", program));
            var carbs = ParseDouble(program, GetStrFromDictionary("Carbs", program));
            var weight = ParseDouble(program, GetStrFromDictionary("Weight_Serving", program));

            var product = new Food(food, calories, proteins, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(Program program, string value)
        {
            DateTime birthDate;
         
            while (true)
            {
                // TODO: На MacOS формат даты MM.DD.YYYY, у винды DD.MM.YYYY 
                Console.Write(GetStrFromDictionary("Input", program) + $" {value}" + " (dd.MM.yyyy): ");
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
                    Console.WriteLine(GetStrFromDictionary("Incorrect_FieldFormat", program));
                }
            }
            return birthDate;
        }

        private static double ParseDouble(Program program, string name)
        {
            while (true)
            {
                Console.Write(GetStrFromDictionary("Input", program) + $" {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine(GetStrFromDictionary("Incorrect_Format", program));
                }
            }
        }
    }
}
