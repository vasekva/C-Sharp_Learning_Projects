﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness_BL.Controller
{
    public abstract class BaseController
    {
        private protected T LoadData<T>(string fileName)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            if (!File.Exists(fileName)
                || (File.ReadAllLines(fileName).Length == 0))
                return default(T);

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
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

            using (var file = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, item);
            }
        }
    }
}
