using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        protected readonly string r_LicensePlate;
        protected float m_EnergyLeftInTank;
        //protected Tire[] m_Tires;
        //TODO TIRES

        public Vehicle(string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank) 
        {
            r_ModelName = i_ModelName;
            r_LicensePlate = i_LicensePlate;
            EnergyLeftInTank = i_EnergyLeftInTank;
            //m_Tires = tires;
        }
        
        public float EnergyLeftInTank
        {
            get
            {
                return m_EnergyLeftInTank;
            }
            set
            {
                m_EnergyLeftInTank = value;
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            } 
        }

        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            } 
        }
    }
}
