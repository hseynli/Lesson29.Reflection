using TypeTest;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var my = new MyClass();
Type type;

// Type klasının insance-nın alınma yolları.
// 1.
type = my.GetType();
Console.WriteLine("1-ci üsul: " + type);

// 2.
type = Type.GetType("TypeTest.MyClass"); // Full clasification name.
Console.WriteLine("2-ci üsul: " + type);

// 3.
type = typeof(MyClass);
Console.WriteLine("3-cü üsul: " + type);

// Delay.
Console.ReadKey();


namespace TypeTest
{
    class MyClass
    {
    }
}