using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_ContainsHazardousMaterials {  get; set; }
        private readonly float r_CargoVolume;
        private FuelTypeVehicleAttributes m_FuelTypeAttributes;
        public const float k_MaxAirPressure = 28;
        public const int k_NumOfTires = 12;

        public Truck(bool i_ContainsHazardousMaterials, float i_CargoVolume, FuelTypeVehicleAttributes i_FuelTypeAttributes, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires) 
        :base(i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        {
            m_ContainsHazardousMaterials = i_ContainsHazardousMaterials;
            r_CargoVolume = i_CargoVolume;
            m_FuelTypeAttributes = i_FuelTypeAttributes;
        }

        public float CarVolume
        {
            get
            {
                return r_CargoVolume;
            }
        }

        
    }
}
