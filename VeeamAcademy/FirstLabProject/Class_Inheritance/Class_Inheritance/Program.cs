using System;

namespace Class_Inheritance
{
    class BaseClass
    {
        internal virtual string GetInfo()
        {
            return ("This is an info from Base Class");
        }
    }

    class DerivedClass : BaseClass
    {
        internal override string GetInfo()
        {
            return ("This is an info from Derived Class");
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            BaseClass myObject = new DerivedClass();

            Console.WriteLine(myObject.GetInfo());
        }
    }
}
