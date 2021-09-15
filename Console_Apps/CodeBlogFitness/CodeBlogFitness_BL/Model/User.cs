using System;
using System.Runtime.Serialization;

namespace CodeBlogFitness_BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    ///
    //[Serializable]
    [DataContract]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        [DataMember]
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Вес.
        /// </summary>
        [DataMember]
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        [DataMember]
        public double Height { get; set; }

        [DataMember]
        public int Age
        {
            get { return GetAge(BirthDate); }
            set { GetAge(BirthDate); }
        }

        public int GetAge(DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }
        #endregion

        public User(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            Name = userName;
        }

        /// <summary>
        /// Конструктор создания пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name, Gender gender, DateTime birthDate,
            double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым, либо null!", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть равен null!", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1921") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Указана некорректная дата рождения!", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше, либо равен нулю!", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше, либо равен нулю!", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
