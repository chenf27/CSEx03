using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine
    {
        private readonly float r_MaxBatteryHoursLeft;
        private float m_RemainingBatteryHoursLeft;


        public ElectricEngine(float i_MaxBatteryHoursLeft)
        {
            r_MaxBatteryHoursLeft = i_MaxBatteryHoursLeft;
        }
        

        public void CharceVechile(float i_HoursToCharge)
        {
            
        }
        public float MaxBatteryHoursLeft
        {
            get
            {
               return r_MaxBatteryHoursLeft;
            }
        }

        public float RemainingBatteryHoursLeft
        {
            get
            {
                return m_RemainingBatteryHoursLeft;
            }

            set
            {
                m_RemainingBatteryHoursLeft = value;
            }
        }

        public void Charging(float i_HoursToCharge)
        {
            if (i_HoursToCharge < 0)
            {
                //PROBLEM!!
            }
            else if (i_HoursToCharge + m_RemainingBatteryHoursLeft > r_MaxBatteryHoursLeft)
            {
                //ANOTHER PROBLEM!!
            }
            else
            {
                m_RemainingBatteryHoursLeft += i_HoursToCharge;
            }

        }

    }
}
