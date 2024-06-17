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
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Soler;
        private const float k_MaxFuelTankCapacity = 120;

        internal Truck()
        {
            base.m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTankCapacity);
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();

            parameters.Add("Contains Hazardous Materials", typeof(bool));
            parameters.Add("Cargo Volume", typeof(float));
            parameters.Add("Current Amount of Fuel In Tank", typeof(float));

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

            parameters.Add("Contains Hazardous Materials", m_ContainsHazardousMaterials.ToString());
            parameters.Add("Cargo Volume", m_CargoVolume.ToString());
            parameters.Add("Engine type", "Fuel");
            parameters.Add("Fuel type", k_FuelType.ToString());
            parameters.Add("Energy left", m_Engine.EnergyLeftInTank.ToString());

            return parameters;
        }

        protected override void InitializeUniqueParameters(Dictionary<string, object> i_Parameters)
        {
            m_ContainsHazardousMaterials = (bool)i_Parameters["Contains Hazardous Materials"];
            bool cargoParsedSuccessfully = float.TryParse(i_Parameters["Cargo Volume"].ToString(), out float cargoVolume);
            bool remainingfuelParsedSuccessfully = float.TryParse(i_Parameters["Current Amount of Fuel In Tank"].ToString(), out float currentAmountOfFuelInTank);
            validateTruckParameters(cargoParsedSuccessfully, remainingfuelParsedSuccessfully);

            if (cargoVolume < 0)
            {
                throw new ValueOutOfRangeException(0, int.MaxValue, "cargo volume");
            }

            m_CargoVolume = cargoVolume;
            ((FuelEngine)m_Engine).CurrentAmountOfFuelInTank = currentAmountOfFuelInTank;
        }

        private void validateTruckParameters(bool i_CargoParsedSuccessfully, bool i_RemainingfuelParsedSuccessfully)
        {
            if (!i_CargoParsedSuccessfully)
            {
                throw new FormatException("Cargo volume must be a number");
            }
            if (!i_RemainingfuelParsedSuccessfully)
            {
                throw new FormatException("Current amount of fuel in tank must be a number");
            }
        }
    }
}

