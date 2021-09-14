using System;
using System.Linq;
using CodeBlogFitness_BL.Controller;

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
