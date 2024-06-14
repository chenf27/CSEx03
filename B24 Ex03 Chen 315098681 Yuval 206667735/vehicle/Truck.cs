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

        //public Truck(bool i_ContainsHazardousMaterials, float i_CargoVolume, FuelTypeVehicleAttributes i_FuelTypeAttributes, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires) 
        //:base(i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        //{
        //    m_ContainsHazardousMaterials = i_ContainsHazardousMaterials;
        //    r_CargoVolume = i_CargoVolume;
        //    m_FuelTypeAttributes = i_FuelTypeAttributes;
        //}

        public Truck()
        {
            
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
            return new Dictionary<string, Type>
            {
                { "LicensePlate", typeof(string) },
                { "ModelName", typeof(string) },
                { "EnergyLeftInTank", typeof(float) },
                { "ContainsHazardousMaterials", typeof(bool) },
                { "CargoVolume", typeof(float) },
                { "CurrentFuelTankCapacity", typeof(float) }
            };
        }

        public override void Initialize(Dictionary<string, object> parameters)
        {
            m_LicensePlate = parameters["LicensePlate"] as string;
            m_ModelName = parameters["ModelName"] as string;
            m_EnergyLeftInTank = (float)parameters["EnergyLeftInTank"];
            m_ContainsHazardousMaterials = (bool)parameters["ContainsHazardousMaterials"];
            m_CargoVolume = (float)parameters["CargoVolume"];
            m_Engine.CurrentFuelTankCapacity = (float)parameters["CurrentFuelTankCapacity"];
        }
    }
}
