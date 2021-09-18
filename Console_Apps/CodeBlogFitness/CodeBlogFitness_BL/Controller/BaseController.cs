using CodeBlogFitness_BL.Model;

namespace CodeBlogFitness_BL.Controller
{
    public abstract class BaseController
    {
        protected IDataSaver saver = new SerializeDataSaver();

        private protected T LoadData<T>(string fileName)
        {
            return saver.LoadData<T>(fileName);
        }

        private protected void SaveData<T>(string fileName, object item)
        {
            saver.SaveData<T>(fileName, item);
        }
    }
}
