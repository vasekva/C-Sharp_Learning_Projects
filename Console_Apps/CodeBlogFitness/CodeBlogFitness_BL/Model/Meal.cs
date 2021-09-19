using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CodeBlogFitness_BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [DataContract]
    public class Meal
    {
        #region Свойства
        public int Id { get; set; }

        /// <summary>
        /// Время приема пищи
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public DateTime MealTime { get; set; }

        /// <summary>
        /// Словарь продуктов и порции
        /// </summary>
        [DataMember]
        public Dictionary<Food, double> Products { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        [DataMember]
        public virtual User CurrentUser { get; set; }
        #endregion

        public Meal() { }

        public Meal(User currentUser)
        {
            CurrentUser = currentUser ?? throw new ArgumentNullException("Пользователь не может быть равен Null", nameof(currentUser));
            MealTime = DateTime.UtcNow;
            Products = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            if (food == null)
                throw new ArgumentNullException("Поле пищи не может быть пустым!", nameof(food));
            var product = Products.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Products.Add(food, weight);
            }
            else
            {
                Products[product] += weight;
            }
        }
    }
}
