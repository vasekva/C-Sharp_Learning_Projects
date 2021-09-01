using System;
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
            var name = Console.ReadLine();

            Console.WriteLine("Введите ваш пол:");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите вашу дату рождения:");
            var birthDate = DateTime.Parse(Console.ReadLine()); //TODO: переписать на try-parse

            Console.WriteLine("Введите ваш вес:");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите ваш рост:");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate,
                weight, height);
            userController.Save();
        }
    }
}
