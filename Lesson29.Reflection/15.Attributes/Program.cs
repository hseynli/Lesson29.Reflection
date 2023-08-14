using System;
using System.Reflection;

// Bütün assembly üçün olan qlobal atriburlar.
[assembly: AssemblyVersionAttribute("1.0.2000.0")]      // Assebmly versiyası.
[assembly: AssemblyTitle("AssemblySmpl")]               // Adı.
[assembly: AssemblyDescription("")]                     // Təyinatı.
[assembly: AssemblyConfiguration("")]                   // Konfuqurasiya, misal üçün Release və ya Debug.
[assembly: AssemblyCompany("CyberBionic Systematics")]  // Proqramı yaradan şirkətin adı.
[assembly: AssemblyProduct("AssemblySmpl")]             // Produktun adı.
[assembly: AssemblyCopyright("Copyright 2009")]         // Kopiraytlar.
[assembly: AssemblyTrademark("")]                       // Trandemark.
[assembly: AssemblyCulture("")]                         // Proqramın dəstəklədiyi mədəniyyətlər.

namespace AssemblySmpl
{
    public class Program
    {
        public static void Main()
        {
            // Cari icra olunan proqramı əldə edirik.
            Assembly assembly = Assembly.GetExecutingAssembly();            
            Console.WriteLine("Assembly Full Name:\n{0}", assembly.FullName);

            // Ad haqqında dolğun məlumat
            AssemblyName assemblyName = assembly.GetName();

            Console.WriteLine("\nName: {0}", assemblyName.Name);                                           // Adı
            Console.WriteLine("Version: {0}.{1}", assemblyName.Version.Major, assemblyName.Version.Minor); // Versiyası.
            Console.WriteLine("\nAssembly CodeBase: \n{0}", assembly.CodeBase);                            // Saxlanılma yeri

            // Proqramı giriş nöqtəsi.
            Console.WriteLine("\nAssembly entry point:");

            Console.WriteLine(assembly.EntryPoint);

            // Delay.
            Console.ReadKey();
        }
    }
}
