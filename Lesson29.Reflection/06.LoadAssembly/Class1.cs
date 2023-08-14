using System;
using System.IO;
using System.Reflection;
using System.Text;

// Bu nümunəni yoxlamaq üçünü,
// 04_CarLibrary proyektində olan CarLibrary.dll kitabxanasını *.ехе faylı olan direktoriyaya kopyalamaq lazımdır.

namespace LoadAssembly
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Assembly klasının köməkliyi ilə dinamik olaraq kirabxanaları yükləmək olar, 
            // daha sonra proqramın icarası zamanı həmin klasların üzvlərinə müraciət etmək olar.
            // Həmçinin assebly haqqında məlumat əldə etmək olar.  
            Assembly assembly = null;

            try
            {
                // Assembly.Load() - assembly-in yükləmək üçün metoddur.
                assembly = Assembly.LoadFrom("04.CarLibrary.dll");
                Console.WriteLine("CarLibrary kitabxanası - uğurlu yüklənildi.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            // Bütün tiplər haqqında məlumatı ekranda əks elətdiririk.
            ListAllTypes(assembly);
            // Klasın bütün üzvləri.
            ListAllMembers(assembly);
            // Metodun bütün parametrləri.
            GetParams(assembly);

            //Delay.
            Console.ReadKey();
        }

        // Kitabxanda olan bütün tipləri əldə etmək üçün metod.
        private static void ListAllTypes(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));
            Console.WriteLine("\nTiplər в: {0} \n", assembly.FullName);

            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
                Console.WriteLine("Tip: {0}", t);
        }

        // Klasın üzvləri haqqında məlumatları əldə etmək üçün metod.
        private static void ListAllMembers(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));

            Type type = assembly.GetType("_04.CarLibrary.MiniVan");

            Console.WriteLine("\nKlasın üzvləri: {0} \n", type);

            MemberInfo[] members = type.GetMembers();

            foreach (MemberInfo element in members)
                Console.WriteLine("{0,-15}:  {1}", element.MemberType, element);
        }

        // TurboBoost() metodunun parameterləri haqqında məlumat əldə edirik 
        private static void GetParams(Assembly assembly)
        {
            Console.WriteLine(new string('_', 80));

            Type type = assembly.GetType("_04.CarLibrary.MiniVan");
            MethodInfo method = type.GetMethod("Driver"); // Equals, Acceleration, Driver

            // Parametrlərin sayı haqqında məlumatı ekranda əks elətdiririk.
            Console.WriteLine("\n{0} metodunun paramterləri haqqında məlumat", method.Name);
            ParameterInfo[] parameters = method.GetParameters();
            Console.WriteLine("Metodun " + parameters.Length + " sayda parametri vardır");

            // Hər bir parametrin bəzi xarakteristikalarını ekranda əks elətidirik. 
            foreach (ParameterInfo parameter in parameters)
            {
                Console.WriteLine("Parametrin adı: {0}", parameter.Name);
                Console.WriteLine("Metodda parametrin pozisiyası: {0}", parameter.Position);
                Console.WriteLine("Parametrin tipi: {0}", parameter.ParameterType);
            }
        }
    }
}
