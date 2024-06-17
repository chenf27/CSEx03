using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class FuelTypeMotorcycle: Motorcycle
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan98;
        private const float k_MaxFuelTankCapacity = 5.5f;

        internal FuelTypeMotorcycle()
        {
            base.m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTankCapacity);
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
