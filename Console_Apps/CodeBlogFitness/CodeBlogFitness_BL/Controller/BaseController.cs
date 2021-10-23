using System.Collections.Generic;

namespace CodeBlogFitness_BL.Controller
{
    public abstract class BaseController
    {
        private readonly IDataSaver manager = new SerializeDataSaver();
        //private readonly IDataSaver manager = new DatabaseDataSaver();

        protected List<T> LoadData<T>() where T : class
        {
            return manager.LoadData<T>();
        }

        protected void SaveData<T>(List<T> item) where T : class
        {
            manager.SaveData(item);
        }
    }
}
