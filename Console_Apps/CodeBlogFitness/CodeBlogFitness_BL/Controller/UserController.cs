using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public List<User> Users { get; set; }
        public User CurrentUser { get; set; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Todo: проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Получить сохраненный список пользоваталей.
        /// </summary>
        /// <returns> Пользователи приложения. </returns>
        private List<User> GetUsersData()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));
            if (!File.Exists("users.json")
                || (File.ReadAllLines("users.json").Length == 0))
                return new List<User>();

            using (var file = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                file.Position = 0;
                var readObject = jsonFormatter.ReadObject(file) as List<User>;

                if (readObject != null)
                    return readObject;
                else
                    return new List<User>();
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        private void Save()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));

            using (var file = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, Users);
            }
        }
    }
}
