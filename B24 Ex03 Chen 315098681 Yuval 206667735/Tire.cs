using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private readonly string r_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Tire(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }


        //TODO EXCEPTIONS
        public void InflatingTire(float i_AirPressureToAdd)
        {
            if (i_AirPressureToAdd < 0)
            {
                //PROBLEM!!
            }
            else if (i_AirPressureToAdd + m_CurrentAirPressure > r_MaxAirPressure)
            {
                //ANOTHER PROBLEM!!
            }
            else
            {
                m_CurrentAirPressure += i_AirPressureToAdd;
            }
        }

        public string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            } 
        }

        public float MaxAirPressure
        {
            get
            {
                return m_CurrentAirPressure; 
            }
        }
        
        public float CurrentAirPressure
        {
            get 
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }
        

    }
}
