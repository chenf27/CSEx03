using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
        }

        public bool ContainsHazardousMaterials
        {
            get
            {
                return m_ContainsHazardousMaterials;
            }
            set
            {
                m_ContainsHazardousMaterials = value;
            }
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();
            parameters.Add("Contains Hazardous Materials", typeof(bool));
            parameters.Add("Cargo Volume", typeof(float));
            parameters.Add("Current Amount of Fuel In Tank", typeof(float));
            return parameters;
        }

        protected override void InitializeUniqueParameters(Dictionary<string, object> i_Parameters)
        {
            m_ContainsHazardousMaterials = (bool)i_Parameters["Contains Hazardous Materials"];
            float cargoVolume = (float)i_Parameters["Cargo Volume"];
            float currentAmountOfFuelInTank = (float)i_Parameters["Current Amount of Fuel In Tank"];

            if (cargoVolume < 0)
            {
                throw new ValueOutOfRangeException(0, int.MaxValue);
            }

            m_CargoVolume = cargoVolume;
            ((FuelEngine)m_Engine).CurrentAmountOfFuelInTank = currentAmountOfFuelInTank;
        }
    }
}

