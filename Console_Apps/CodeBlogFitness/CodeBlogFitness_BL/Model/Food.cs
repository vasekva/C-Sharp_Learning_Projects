using System.Runtime.Serialization;

namespace CodeBlogFitness_BL.Model
{
    [DataContract]
    public class Food
    {
        #region Свойства
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Белки
        /// </summary>
        [DataMember]
        public double Proteins { get; set; }

        /// <summary>
        /// Жиры
        /// </summary>
        [DataMember]
        public double Fats { get; set; }

        /// <summary>
        /// Углеводы
        /// </summary>
        [DataMember]
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Калории на 100 грамм продукта
        /// </summary>
        [DataMember]
        public double Calories { get; set; }
        #endregion

        public Food() { }

        public Food(string name) : this(name, 0, 0, 0, 0)
        {
            //TODO: проверка

            Name = name;
        }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            //TODO: проверка

            Name = name;
            Calories = calories / 100.0;            
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
