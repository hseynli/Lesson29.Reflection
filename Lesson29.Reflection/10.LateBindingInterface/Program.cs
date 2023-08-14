using System;
using System.Text;
using System.Reflection;
using _04.CarLibrary;
using ICarLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Assembly assembly = null;

            try
            {
                assembly = Assembly.LoadFrom("08.CarLibrary.dll");

                Type type = assembly.GetType("_04.CarLibrary.MiniVan");

                ICar carInstance = Activator.CreateInstance(type) as ICar;

                if (carInstance != null)
                {
                    carInstance.Acceleration();

                    carInstance.Driver("Shumaher", 30);
                }

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
