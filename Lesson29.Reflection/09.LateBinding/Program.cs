using System;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

// Late Binding - proqramın icrası zamanı tipləri,
// onların adlarını və üzvlərini müəyyən etməyə imkan verən texnologiyadır.

namespace LateBinding
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
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            // MiniVan klasının late binding texnologiyasından istifadə edərək instance-nın yaradılması.
            // Activator klasının köməkliyi ilə biz instance yarada bilərik.
            // CreateInstance() - metodu proqramın icrası zamanı instance-ın yaradılması üçün istifadə olunuur.
            Type type = assembly.GetType("_04.CarLibrary.MiniVan");

            object instance = Activator.CreateInstance(type);

            // Acceleration metodu üçün MethodInfo klasının instance-nı əldə edirik. 
            MethodInfo method = type.GetMethod("Acceleration");

            // Acceleration() metodunun çağırılması.
            // Birinci parameter - Acceleration metodunun hansı instance-da yaradılacağını müəyyən edir.
            // İkinci parameter - Acceleration metodunun qəbul edəcəyini arqumentləri müəyyən edir
            // (Cari vəziyyətdə bu metod heç bir arqument qəbul etmir, ona görə - null)
            method.Invoke(instance, null);

            // Driver metodu üçün MethodInfo klasının instance-nı əldə edirik. 
            method = type.GetMethod("Driver");

            // Driver metodunun qəbul edəcəyi array arqumentlər. 
            object[] parameters = { "Shumaher", 36 };

            // Driver() metodunun çağırılması..
            // Birinci parameter - Driver metodunun hansı instance-da yaradılacağını müəyyən edir.
            // İkinci parameter - Driver metodunun qəbul edəcəyi parameterləri müəyyən edir
            // (Cari halda - name:"Shumaher", age:36 )
            method.Invoke(instance, parameters);

            // Delay.
            Console.ReadKey();
        }
    }
}
