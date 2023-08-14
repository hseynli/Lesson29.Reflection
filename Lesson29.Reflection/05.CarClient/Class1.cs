using _04.CarLibrary;
using System.Text;

// CarLibrary-də olan tiplərdən istifadə.

namespace CSharpCarClient
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Sport avtomobil yaradırıq.
            SportsCar sportcar = new SportsCar("Viper", 240, 40);
            sportcar.Acceleration();

            // Mini-ven yaradırıq.
            MiniVan minivan = new MiniVan();
            minivan.Acceleration();

            // Delay.
            Console.ReadKey();
        }
    }
}