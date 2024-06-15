using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricTypeCar : Car
    {
        private const float k_MaxBatteryLifeInHours = 3.5f;

        internal ElectricTypeCar()
        {
            m_Engine = new ElectricEngine(k_MaxBatteryLifeInHours);
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();
            parameters.Add("Remaining Battery Hours Left", typeof(float));
            return parameters;
        }

        protected override void InitializeCarSpecificParameters(Dictionary<string, object> i_Parameters)
        {
            float remainingBatteryHoursLeft = (float)i_Parameters["Remaining Battery Hours Left"];
            
            ((ElectricEngine)m_Engine).RemainingBatteryHoursLeft = remainingBatteryHoursLeft;
        }


        /*ElectricEngine ElectricEngine
        {
            get 
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }*/     // Do we need this?

    }
}
