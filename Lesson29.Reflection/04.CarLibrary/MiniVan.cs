using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CarLibrary
{
    public class MiniVan : Car
    {
        public MiniVan()
        {
        }

        public MiniVan(string name, short maxSpeed, short currentSpeed)
            : base(name, maxSpeed, currentSpeed)
        {
        }

        public override void Acceleration()
        {
            // Minivan sürəti zəif yığır.
            state = EngineState.EngineDead;
            Console.WriteLine("MINIVAN:  mühərrik yararsızdır!");
        }
    }
}
