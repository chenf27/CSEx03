using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricTypeMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryLifeInHours = 2.5f;

        internal ElectricTypeMotorcycle()
        {
            base.m_Engine = new ElectricEngine(k_MaxBatteryLifeInHours);
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();
            parameters.Add("Remaining Battery Hours Left", typeof(float));
            return parameters;
        }

        protected override void InitializeMotorcycleSpecificParameters(Dictionary<string, object> i_Parameters)
        {
            float remainingBatteryHoursLeft = (float)i_Parameters["Remaining Battery Hours Left"];

            ((ElectricEngine)m_Engine).RemainingBatteryHoursLeft = remainingBatteryHoursLeft;
        }
    }
}
