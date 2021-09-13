using System;
namespace Serialization_Lesson
{
    [Serializable]
    public class Group
    {
        [NonSerialized]
        private readonly Random rdm_num = new Random(DateTime.Now.Millisecond); 

        public int Number { get; set; }

        public string Name { get; set; }

        public Group()
        {
            Number = rdm_num.Next(1, 10);
            Name = "Группа " + rdm_num;
        }

        public Group(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
