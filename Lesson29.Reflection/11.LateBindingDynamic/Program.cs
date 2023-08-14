using System;
using System.IO;
using System.Reflection;

namespace _004_LateBinding_Dynamic
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Assembly assembly = null;

            try
            {
                assembly = Assembly.LoadFrom("08.CarLibrary.dll");

                Type type = assembly.GetType("_04.CarLibrary.MiniVan");

                dynamic carInstance = Activator.CreateInstance(type);
                carInstance.Acceleration();
                carInstance.Driver("Shumaher", 38);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
