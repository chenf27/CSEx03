using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected readonly eCarColor r_CarColor;
        protected readonly int r_NumOfDoors;

        public Car(eCarColor i_CarColor, int i_NumOfDoors, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank)
        :base(i_ModelName, i_LicensePlate, i_EnergyLeftInTank)
        {
            r_CarColor = i_CarColor;
            r_NumOfDoors = i_NumOfDoors;
        }
            

        public enum eCarColor
        {
            Yellow,
            White,
            Red,
            Black
        }

        public eCarColor CarColor
        {
            get
            {
                return r_CarColor;
            }
        }

        public int NumOfDoors
        { 
            get
            {
                return r_NumOfDoors;
            } 
        }
    }
}
