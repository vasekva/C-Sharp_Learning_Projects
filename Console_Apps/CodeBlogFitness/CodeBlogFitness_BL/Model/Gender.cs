using System;
namespace CodeBlogFitness_BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="name">Название пола</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Необходимо указать пол!", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
