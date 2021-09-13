using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using CodeBlogFitness_BL.Model;

namespace CodeBlogFitness_BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> User { get; }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns> Пользователь приложения. </returns>
        public UserController()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));

            using (var file = new FileStream("users.json", FileMode.Create))
            {
                var readObject = jsonFormatter.ReadObject(file) as List<User>;

                if (readObject == null)
                {
                    throw new FileLoadException("Не удалось получить данные пользователя из файла", "users.json");
                }
            }
        }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName,
            DateTime birthDate, double weight, double height)
        {
            //TODO: Проверка

            var gender = new Gender(genderName);
            User = new List<User>();
            User.Add(new User(userName, gender, birthDate, weight, height));
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));

            using (var file = new FileStream("users.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(file, User);
            }
        }
    }
}
