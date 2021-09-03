using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using Serialization_Lesson;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

/*
 * Для сериализации полей необходимы свойства set
 */

/*
 * Если класс(Student) отмечается атрибутом [DataContract], то все свойства, которые нужно
 * сохранить необходимо помечать атрибутом [DataMember]
 * 
 * С атрибутом [Serializeble] все поля автоматически сохраняются, нежелательные
 * для сохраннения необходимо помечать атрибутом [NotSerialized].
 * 
 * [NotSerialized] можно применять только к полям
 */

/*
 * Размерность полученных файлов:
 * bin: 971 bytes
 * soap: 4478 bytes
 * xml: 835 bytes
 * json: 640 bytes
 */

//TODO: Создать четыре типа сериалиазации для других классов (другое сочетание объектов и полей)

namespace SerializationLesson
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            var groups = new List<Group>();
            var students = new List<Student>();

            for (int i = 1; i < 10; i++)
            {
                groups.Add(new Group(i, "Группа " + i));
            }

            for (int i = 0; i < 300; i++)
            {
                var student = new Student(Guid.NewGuid().ToString().Substring(0, 5), i % 100)
                {
                    Group = groups[i % 9]
                };

                students.Add(student);
            }

            #region Binary_Serialization

            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream("groups.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, groups);
            }

            using (var file = new FileStream("groups.bin", FileMode.OpenOrCreate))
            {
                var newGroups = binFormatter.Deserialize(file) as List<Group>;

                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }
            #endregion

            Console.ReadLine();

            #region SOAP_Serialization

            // soap - Simple Object Access Protocol
            var soapFormatter = new SoapFormatter();

            using (var file = new FileStream("groups.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(file, groups.ToArray());
            }

            using (var file = new FileStream("groups.soap", FileMode.OpenOrCreate))
            {
                var newGroups = soapFormatter.Deserialize(file) as Group[];

                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }
            #endregion

            Console.ReadLine();

            #region XML_Serialization

            var xmlFormatter = new XmlSerializer(typeof(List<Group>));

            using (var file = new FileStream("groups.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, groups);
            }

            using (var file = new FileStream("groups.xml", FileMode.OpenOrCreate))
            {
                var newGroups = xmlFormatter.Deserialize(file) as List<Group>;

                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }

            #endregion

            Console.ReadLine();

            #region JSON_Serialization

            var jsonFormatter_gr = new DataContractJsonSerializer(typeof(List<Group>));

            using (var file = new FileStream("groups.json", FileMode.Create))
            {
                jsonFormatter_gr.WriteObject(file, groups);
            }

            using (var file = new FileStream("groups.json", FileMode.OpenOrCreate))
            {
                var newGroups = jsonFormatter_gr.ReadObject(file) as List<Group>;

                if (newGroups != null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine(group);
                    }
                }
            }

            Console.ReadLine();
             
            var jsonFormatter_st = new DataContractJsonSerializer(typeof(List<Student>));

            using (var file = new FileStream("students.json", FileMode.Create))
            {
                jsonFormatter_st.WriteObject(file, students);
            }

            using (var file = new FileStream("students.json", FileMode.OpenOrCreate))
            {
                var newStudents = jsonFormatter_st.ReadObject(file) as List<Student>;

                if (newStudents != null)
                {
                    foreach (var student in newStudents)
                    {
                        Console.WriteLine(student);
                    }
                }
            }

            #endregion

            Console.ReadLine();

        }
    }
}
