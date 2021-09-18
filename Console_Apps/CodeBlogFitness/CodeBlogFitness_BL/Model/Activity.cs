﻿using System;
using System.Runtime.Serialization;

namespace CodeBlogFitness_BL.Model
{
    [Serializable]
    public class Activity
    {
        #region Свойства
        //[DataMember]
        public string Name { get; set; }

        //[DataMember]
        public double CaloriesPerMinute { get; set; }
        #endregion

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