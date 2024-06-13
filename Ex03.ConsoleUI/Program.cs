using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            Vehicle v = new Truck();
            Truck t = v as Truck;

            t.EnergyLeftInTank = 50;
        }
    }
}
