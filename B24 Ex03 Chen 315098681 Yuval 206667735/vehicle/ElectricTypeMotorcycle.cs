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

        public override Dictionary<string, string> GetFilledParameters()
        {
            Dictionary<string, string> parameters = base.GetFilledParameters();

            parameters.Add("Engine type", "Electricity");
            parameters.Add("Remaining Energy", m_Engine.EnergyLeftInTank.ToString());

            return parameters;
        }

        protected override void InitializeMotorcycleSpecificParameters(Dictionary<string, object> i_Parameters)
        {
            //float remainingBatteryHoursLeft = (float)i_Parameters["Remaining Battery Hours Left"];
            float.TryParse(((string)i_Parameters["Remaining Battery Hours Left"]), out float remainingBatteryHoursLeft);


            ((ElectricEngine)m_Engine).RemainingBatteryHoursLeft = remainingBatteryHoursLeft;
        }
    }
}
