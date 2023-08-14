using System;
using System.Reflection;

// Attibutlar. 

namespace AttributeWork
{
    [My("1/31/2008", Number = 1)]
    public class MyClass
    {
        [MyAttribute("2/31/2007", Number = 2)]
        public static void Method()
        {
            Console.WriteLine("MyClass.Method()\n");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MyClass my = new MyClass();
            MyClass.Method();

            // Atributların analizi.

            Type type = typeof(MyClass);
            object[] attributes = null;

            MyAttribute attribute = null;

            // Atributun tipinin analizi.

            // Verilmiş tipin bütün atributlarını əldə edirik (false - base klasları iqnor etmək).
            attributes = type.GetCustomAttributes(false);

            foreach (object attributeType in attributes)
            {
                attribute = attributeType as MyAttribute;
                Console.WriteLine("Tipin analizi  : Number = {0}, Date = {1}", attribute.Number, attribute.Date);
            }


            // Metodun atributlarının analizi.

            // public static Method-u əldə edirik.
            MethodInfo method = type.GetMethod("Method", BindingFlags.Public | BindingFlags.Static);

            // Verilmiş tipin bütün atributlarını əldə edirik (false - base klasları iqnor etmək).
            attributes = method.GetCustomAttributes(typeof(MyAttribute), false);

            foreach (MyAttribute attrib in attributes)
            {
                Console.WriteLine("Metodun analizi: Number = {0}, Date = {1}", attrib.Number, attrib.Date);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}