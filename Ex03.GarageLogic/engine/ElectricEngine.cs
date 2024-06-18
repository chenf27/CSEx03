using Ex03.GarageLogic.engine;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private readonly float r_MaxBatteryHoursLeft;
        private float m_RemainingBatteryHoursLeft = 0;


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
                if(value < 0 || value > r_MaxBatteryHoursLeft || value < m_RemainingBatteryHoursLeft)
                {
                    throw new ValueOutOfRangeException(0, r_MaxBatteryHoursLeft - m_RemainingBatteryHoursLeft, "remaining battery hours left");
                }

                m_RemainingBatteryHoursLeft = value;
                m_EnergyLeftInTank = (m_RemainingBatteryHoursLeft / r_MaxBatteryHoursLeft) * 100;
            }
        }

        public override void RefuelOrRecharge(Dictionary<string, object> i_Parameters)
        {
            bool hoursToChargeParsedSuccessfully;

            if(!i_Parameters.ContainsKey("Hours To Charge"))
            {
                throw new ArgumentException("Missing parameter for recharging. Make sure the selected vehicle has a fuel type engine");
            }

            hoursToChargeParsedSuccessfully = float.TryParse(i_Parameters["Hours To Charge"].ToString(), out float hoursToCharge);
            if(!hoursToChargeParsedSuccessfully)
            {
                throw new FormatException("Hours to charge must be a valid number");
            }

            RemainingBatteryHoursLeft += hoursToCharge;
        }

        public override Dictionary<string, Type> GetParameters()
        {
            return new Dictionary<string, Type>()
            {
                { "Remaining Battery Hours Left", typeof(float) }
            };
        }

        public override Dictionary<string, string> GetFilledParameters()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "Engine type", "Electric" },
                { "Maximum Battery Hours", MaxBatteryHoursLeft.ToString() },
                { "Remaining Battery Hours", RemainingBatteryHoursLeft.ToString() }
            };

            foreach(KeyValuePair<string, string> pair in base.GetFilledParameters())
            {
                parameters[pair.Key] = pair.Value;
            }
            
            return parameters;
        }

        public override void Initialize(Dictionary<string, object> i_Parameters)
        {
            bool remainingBatteryParsedSuccessfully = float.TryParse(i_Parameters["Remaining Battery Hours Left"].ToString(), out float remainingBatteryHoursLeft);

            if(!remainingBatteryParsedSuccessfully)
            {
                throw new FormatException("Current amount of fuel in tank must be a number");
            }

            RemainingBatteryHoursLeft = remainingBatteryHoursLeft;
        }
    }
}
