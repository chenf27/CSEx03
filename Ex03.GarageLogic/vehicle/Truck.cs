using Ex03.GarageLogic.engine;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_ContainsHazardousMaterials;
        private float m_CargoVolume;
        private const float k_MaxAirTirePressure = 28;
        private const int k_NumOfTires = 12;

        internal Truck(Engine i_Engine)
        {
            base.m_Engine = i_Engine;
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();
            Dictionary<string, Type> engineParameters = m_Engine.GetParameters();

            parameters.Add("Contains Hazardous Materials", typeof(bool));
            parameters.Add("Cargo Volume", typeof(float));
            foreach(KeyValuePair<string, Type> param in engineParameters)
            {
                parameters.Add(param.Key, param.Value);
            }

            return parameters;
        }

        public override Dictionary<string, string> GetTiresKnownInfo()
        {
            return new Dictionary<string, string>
            {
                { "Max Air Pressure In Tires", k_MaxAirTirePressure.ToString() },
                { "Number Of Tires", k_NumOfTires.ToString() }
            };
        }

        public override Dictionary<string, string> GetFilledParameters()
        {
            Dictionary<string, string> parameters = base.GetFilledParameters();
            Dictionary<string, string> engineParameters = m_Engine.GetFilledParameters();

            parameters.Add("Vehicle Type", "Truck");
            parameters.Add("Contains Hazardous Materials", m_ContainsHazardousMaterials.ToString());
            parameters.Add("Cargo Volume", m_CargoVolume.ToString());
            foreach(KeyValuePair<string, string> param in engineParameters)
            {
                parameters.Add(param.Key, param.Value);
            }
            
            return parameters;
        }

        protected override void InitializeUniqueParameters(Dictionary<string, object> i_Parameters)
        {
            bool cargoParsedSuccessfully;
            bool containsHazardousMaterials;

            containsHazardousMaterials = (bool)i_Parameters["Contains Hazardous Materials"];
            cargoParsedSuccessfully = float.TryParse(i_Parameters["Cargo Volume"].ToString(), out float cargoVolume);
            validateTruckParameters(cargoParsedSuccessfully, cargoVolume);
            m_ContainsHazardousMaterials = containsHazardousMaterials;
            m_Engine.Initialize(i_Parameters);
            m_CargoVolume = cargoVolume;
        }

        private void validateTruckParameters(bool i_CargoParsedSuccessfully, float i_CargoVolume)
        {
            if(!i_CargoParsedSuccessfully)
            {
                throw new FormatException("Cargo volume must be a number!");
            }
            
            if (i_CargoVolume < 0)
            {
                throw new ValueOutOfRangeException(0, int.MaxValue, "cargo volume");
            }
        }
    }
}

