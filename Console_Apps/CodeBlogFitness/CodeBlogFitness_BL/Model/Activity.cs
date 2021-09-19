using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CodeBlogFitness_BL.Model
{
    [Serializable]
    public class Activity
    {
        #region Свойства
        public int Id { get; set; }

        //[DataMember]
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        //[DataMember]
        public double CaloriesPerMinute { get; set; }
        #endregion

        public Activity() { }

        public Activity(string name, double caloriesPerMin)
        {
            //TODO: проверка

            Name = name;
            CaloriesPerMinute = caloriesPerMin;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
