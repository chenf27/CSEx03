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
