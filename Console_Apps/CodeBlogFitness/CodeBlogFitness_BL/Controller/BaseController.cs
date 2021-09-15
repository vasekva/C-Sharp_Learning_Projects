using System.IO;
using System.Runtime.Serialization.Json;

namespace CodeBlogFitness_BL.Controller
{
    public abstract class BaseController
    {
        //TODO: сделать создание файла при его отсутствии
        private protected T LoadData<T>(string fileName)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (file.Length == 0)
                   return default(T);
                var readObject = jsonFormatter.ReadObject(file);

                if (readObject is T item)
                    return item;
                else
                    return default(T);
            }
        }

        private protected void SaveData<T>(string fileName, object item)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, item);
            }
        }
    }
}
