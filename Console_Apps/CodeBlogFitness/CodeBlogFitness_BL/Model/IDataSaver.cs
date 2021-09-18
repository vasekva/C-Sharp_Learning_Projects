using System;
namespace CodeBlogFitness_BL.Model
{
    public interface IDataSaver
    {
        public T LoadData<T>(string fileName);

        public void SaveData<T>(string fileName, object item);
    }
}
