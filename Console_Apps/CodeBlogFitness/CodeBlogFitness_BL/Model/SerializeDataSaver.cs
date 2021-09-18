using System.IO;
using System.Runtime.Serialization.Json;

namespace CodeBlogFitness_BL.Model
{
    public class SerializeDataSaver : IDataSaver
    {
        public T LoadData<T>(string fileName)
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

        public void SaveData<T>(string fileName, object item)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, item);
            }
        }
    }
}
