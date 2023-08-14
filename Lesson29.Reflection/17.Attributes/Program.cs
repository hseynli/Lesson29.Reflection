//#define TRIAL
#define PREMIUM

using System;
using System.Diagnostics;
using System.Reflection;

namespace Attributes
{
    [Obsolete("This is an old class. Use new class instead!")] // Bu klası köhnəlmiş hesab etmək olar.
    class Test
    {
        [Conditional("TRIAL")]
        void Trial()
        {
            Console.WriteLine("Yoxlanış versiya.");
        }

        [Conditional("PREMIUM")]
        void Release()
        {
            Console.WriteLine("Ödənişli versiya.");
        }

#if DEBUG
        private void Initialize()
        {
            Console.WriteLine("Proqramın DEBUG rejimdə inisializasiya edilməsi");
        }
#else
        private void Initialize()
        {
            Console.WriteLine("Proqramın RELEASE rejimdə inisializasiya edilməsi");
        }
#endif

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Test test = new Test();

            test.Initialize();
            test.Trial();   // Ancaq TRIAL identifikatoru təyin edildiyi zaman çağırılacaqdır 
            test.Release(); // Ancaq RELEASE identifikatoru təyin edildiyi zaman çağırılacaqdır 
            Console.WriteLine(new string('-', 20));

            Type type = typeof(Test);

            MethodInfo[] methodInfo = type.GetMethods(
                BindingFlags.Public |         // Axtarışa public üzlər daxil olmalıdır. 
                BindingFlags.NonPublic |      // Axtarışa public olmayan üzlər daxil olmalıdır.
                BindingFlags.Instance         // Axtarışa public olmayan klasın üzvləri daxil olmalıdrı.
                                    );

            foreach (MethodInfo method in methodInfo)
            {
                Console.WriteLine(method.Name);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
