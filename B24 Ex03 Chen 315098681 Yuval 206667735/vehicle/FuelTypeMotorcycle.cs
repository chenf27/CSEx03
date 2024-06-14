using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    internal class FuelTypeMotorcycle: Motorcycle
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan98;
        private const float k_MaxFuelTankCapacity = 5.5f;
        private FuelEngine m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTankCapacity);

        public override Dictionary<string, Type> GetParameters()
        {
            return new Dictionary<string, Type>
            {
                { "LicensePlate", typeof(string) },
                { "ModelName", typeof(string) },
                { "LicenseType", typeof(string) },
                { "EngineCapacity", typeof(int) },
                { "CurrentFuelTankCapacity", typeof(float) }
            };
        }

        public override void Initialize(Dictionary<string, object> parameters)
        {
            m_LicensePlate = parameters["LicensePlate"] as string;
            m_ModelName = parameters["ModelName"] as string;
            m_LicenseType = (eLicenseType)parameters["LicenseType"];        //Add input tests
            m_EngineCapacity = (int)parameters["EngineCapacity"];
            m_Engine.CurrentFuelTankCapacity = (float)parameters["CurrentFuelTankCapacity"];
        }
    }
}
