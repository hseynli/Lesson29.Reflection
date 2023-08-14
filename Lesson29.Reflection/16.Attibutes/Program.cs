using System;
using System.Reflection;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Assembly assembly = Assembly.GetExecutingAssembly();
object[] attributes = assembly.GetCustomAttributes(false);

foreach (Attribute attr in attributes)
{
    Console.WriteLine("Attribute: {0}", attr.GetType().Name);
}

var appVersion = attributes.OfType<AssemblyFileVersionAttribute>().Single();

Console.WriteLine("Proqramın versiyas {0}", appVersion.Version);

// Delay.
Console.ReadKey();