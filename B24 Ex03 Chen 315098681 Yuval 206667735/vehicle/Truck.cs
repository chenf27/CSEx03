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
        private FuelEngine m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTankCapacity);

        

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
            return new Dictionary<string, Type>
            {
                { "License Plate", typeof(string) },
                { "Model Name", typeof(string) },
                { "Energy Left In Tank", typeof(float) },
                { "Contains Hazardous Materials", typeof(bool) },
                { "Cargo Volume", typeof(float) },
                { "Current Fuel Tank Capacity", typeof(float) }
            };
        }

        public override void Initialize(Dictionary<string, object> parameters)
        {
            m_LicensePlate = parameters["License Plate"] as string;
            m_ModelName = parameters["Model Name"] as string;
            m_EnergyLeftInTank = (float)parameters["Energy Left In Tank"];
            m_ContainsHazardousMaterials = (bool)parameters["Contains Hazardous Materials"];
            m_CargoVolume = (float)parameters["Cargo Volume"];
            m_Engine.CurrentFuelTankCapacity = (float)parameters["Current Fuel Tank Capacity"];
        }
    }
}
