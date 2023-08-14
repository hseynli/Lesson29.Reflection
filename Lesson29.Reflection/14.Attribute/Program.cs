using System;
using System.Reflection;

namespace AttributeWork
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // MemberInfo - klasın üzvləri haqqında məlumatı əldə etmək üçün yaradılan abstrakt klasdır. 
            // Type type = typeof(MyClass);
            MemberInfo type = typeof(MyClass);

            // Klasda olan atributları əldə edirik.
            object[] attributes = type.GetCustomAttributes(typeof(MyAttribute), true);

            // Əgər massivdə elementlər varsa, onda ilk element MyAttribute tipində olacaqdır.
            if (attributes.GetLength(0) != 0)
            {
                // Əldə olunan dəyərin ekranda əks olunması.
                foreach (MyAttribute attribute in attributes)
                {
                    Console.WriteLine(attribute.Text);
                    Console.WriteLine(attribute.Data);
                    attribute.Method();
                }
            }

            // Delay.
            Console.ReadKey();
        }
    }
}