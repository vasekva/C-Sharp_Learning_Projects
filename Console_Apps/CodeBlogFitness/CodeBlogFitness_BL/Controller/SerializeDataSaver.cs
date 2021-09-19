using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CodeBlogFitness_BL.Controller
{
    public class SerializeDataSaver : IDataSaver
    {
        public List<T> LoadData<T>() where T : class
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            var fileName = typeof(T).Name + ".json";

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (file.Length == 0)
                    return new List<T>();
                var readObject = jsonFormatter.ReadObject(file);
            
                if (readObject is List<T> items)
                    return items;
                else
                    return new List<T>();
            }
        }
        public void SaveData<T>(List<T> item) where T : class
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            var fileName = typeof(T).Name + ".json";

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, item);
            }
        }
    }
}
