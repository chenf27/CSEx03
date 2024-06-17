
namespace Ex03.GarageLogic
{
    public class Tire
    {
        private readonly string r_Manufacturer;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressure;

        public Tire(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public void InflatingTire(float i_AirPressureToAdd)
        {
            if (i_AirPressureToAdd < 0 || i_AirPressureToAdd + m_CurrentAirPressure > r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressure - m_CurrentAirPressure, "air pressure left to inflate");
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
                return r_MaxAirPressure; 
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
