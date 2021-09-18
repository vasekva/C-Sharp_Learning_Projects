using System;
using System.Linq;
using CodeBlogFitness_BL.Controller;

namespace CodeBlogFitness_BL.Model
{
    public class DatabaseDataSaver : IDataSaver
    {
        public T LoadData<T>(string fileName) where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().FirstOrDefault();
                return result;
            }
        }

        public void SaveData<T>(string fileName, object item)
        {
            using (var db = new FitnessContext())
            {
                var type = item.GetType();

                if (type == typeof(User))
                {
                    db.Users.Add(item as User);
                }
                else if (type == typeof(Gender))
                {
                    db.Genders.Add(item as Gender);
                }
                else if (type == typeof(Food))
                {
                    db.Food.Add(item as Food);
                }
                else if (type == typeof(Meal))
                {
                    db.Meal.Add(item as Meal);
                }
                else if (type == typeof(Exercise))
                {
                    db.Exercise.Add(item as Exercise);
                }
                else if (type == typeof(Activity))
                {
                    db.Activities.Add(item as Activity);
                }
                db.SaveChanges();
            }
        }
    }
}
