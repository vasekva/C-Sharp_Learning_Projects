using System.Collections.Generic;

namespace CodeBlogFitness_BL.Controller
{
    public interface IDataSaver
    {
        List<T> LoadData<T>() where T : class;

        void SaveData<T>(List<T> item) where T : class;
    }
}
