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
            Run();
        }

        public static void Run() 
        {
            UIManager uiManager = new UIManager();

            while (true)
            {
                try
                {
                    uiManager.PrintMenuAndGetChoice();
                    // continue here
                }
                catch // need to think about that 
                {

                }
            }
        }
    }
}
