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
        protected eCarColor m_CarColor;
        protected int m_NumOfDoors;
        private const int k_NumOfTires = 5;
        private const float k_MaxAirTirePressure = 31;

        //public Car(eCarColor i_CarColor, int i_NumOfDoors, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        //:base(i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        //{
        //    r_CarColor = i_CarColor;
        //    r_NumOfDoors = i_NumOfDoors;
        //}

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
                return m_CarColor;
            }
        }

        public int NumOfDoors
        { 
            get
            {
                return m_NumOfDoors;
            } 
        }

        
    }
}
