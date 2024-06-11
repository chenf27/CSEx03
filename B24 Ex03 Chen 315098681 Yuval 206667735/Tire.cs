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
        private float m_CurrentAirPressure {  get; set; }
        private readonly float r_MaxAirPressure;

        public Tire(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }


        //TODO
        public void InflatingTire(float i_AirPressureToAdd)
        {

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
        
        

    }
}
