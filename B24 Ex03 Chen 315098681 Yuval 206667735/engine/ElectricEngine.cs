using Ex03.GarageLogic.engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        private readonly float r_MaxBatteryHoursLeft;
        private float m_RemainingBatteryHoursLeft;


        public ElectricEngine(float i_MaxBatteryHoursLeft)
        {
            r_MaxBatteryHoursLeft = i_MaxBatteryHoursLeft;
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
                if (value < 0 || value > r_MaxBatteryHoursLeft)
                {
                    throw new ValueOutOfRangeException(0, r_MaxBatteryHoursLeft);
                }
                m_RemainingBatteryHoursLeft = value;
                m_EnergyLeftInTank = (m_RemainingBatteryHoursLeft / r_MaxBatteryHoursLeft) * 100;
            }
        }

        public override void RefuelOrRecharge(Dictionary<string, object> i_Parameters)
        {
            float hoursToCharge;

            if (!i_Parameters.ContainsKey("Hours To Charge"))
            {
                throw new ArgumentException("Missing parameter for recharging.");
            }

            hoursToCharge = (float)i_Parameters["HoursToCharge"];
            RemainingBatteryHoursLeft += hoursToCharge;
        }


        /*public void Charging(float i_HoursToCharge)
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

        }*/

        /*public void CharceVechile(float i_HoursToCharge)
        {
            
        }*/
    }
}
