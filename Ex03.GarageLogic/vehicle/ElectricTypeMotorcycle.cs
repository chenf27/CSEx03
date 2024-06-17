using System;
using System.Collections.Generic;

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
            Dictionary<string, Type> engineParameters = m_Engine.GetParameters();

            foreach(KeyValuePair<string, Type> param in engineParameters)
            {
                parameters.Add(param.Key, param.Value);
            }

            return parameters;
        }

        public override Dictionary<string, string> GetFilledParameters()
        {
            Dictionary<string, string> parameters = base.GetFilledParameters();
            Dictionary<string, string> engineParameters = m_Engine.GetFilledParameters();

            foreach(KeyValuePair<string, string> param in engineParameters)
            {
                parameters.Add(param.Key, param.Value);
            }

            return parameters;
        }
    }
}
