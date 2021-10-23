using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness_BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public List<T> LoadData<T>() where T : class
        {
             using (var db = new FitnessContext())
             {
                 var result = db.Set<T>().Where(data => true).ToList();
                 return result;
             }
        }

        public void SaveData<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
