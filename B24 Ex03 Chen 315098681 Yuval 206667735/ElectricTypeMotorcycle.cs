using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricTypeMotorcycle : Motorcycle
    {
        private ElectricTypeVehicleAttributes m_ElectricMotorcycle {  get; set; }

        public ElectricTypeMotorcycle(ElectricTypeVehicleAttributes i_ElectricMotorcycle, eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        : base(i_LicenseType, i_EngineCapacity,i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        {
            m_ElectricMotorcycle = i_ElectricMotorcycle;
        }
    }
}
