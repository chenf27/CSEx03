using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    internal class FuelTypeMotorcycle: Motorcycle
    {
        private FuelTypeVehicleAttributes m_FuelTypeAttributes {  get; set; }

        public FuelTypeMotorcycle(FuelTypeVehicleAttributes i_FuelMotorcycle, eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        : base(i_LicenseType, i_EngineCapacity, i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        {
            m_FuelTypeAttributes = i_FuelMotorcycle;
        }
    }
}
