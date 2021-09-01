using System;
using System.IO;
using CodeBlogFitness_BL.Model;

namespace CodeBlogFitness_BL.Controller
{
    public class UserController
    {
        public User User { get; }

        public UserController(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException("Пользователь не может быть равен null", nameof(user));
            }
        }

        public bool Save()
        {
            var formatter = new BinaryFormatter

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

            }
        }
    }
}
