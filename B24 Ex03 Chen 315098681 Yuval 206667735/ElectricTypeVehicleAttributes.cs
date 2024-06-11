using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public struct ElectricTypeVehicleAttributes
    {
        private readonly float r_MaxBatteryHoursLeft;
        private float m_RemainingBatteryHoursLeft;


        public ElectricTypeVehicleAttributes(float i_MaxBatteryHoursLeft, float i_RemainingBatteryHoursLeft)
        {
            r_MaxBatteryHoursLeft = i_MaxBatteryHoursLeft;
            m_RemainingBatteryHoursLeft = i_RemainingBatteryHoursLeft;
        }
        //TODO
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

    }
}
