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
                { "License Plate", typeof(string) },
                { "Model Name", typeof(string) },
                { "License Type", typeof(string) },
                { "Engine Capacity", typeof(int) },
                { "Current Fuel Tank Capacity", typeof(float) }
            };
        }

        public override void Initialize(Dictionary<string, object> parameters)
        {
            m_LicensePlate = parameters["License Plate"] as string;
            m_ModelName = parameters["Model Name"] as string;
            m_LicenseType = (eLicenseType)parameters["License Type"];        //Add input tests
            m_EngineCapacity = (int)parameters["Engine Capacity"];
            m_Engine.CurrentFuelTankCapacity = (float)parameters["Current Fuel Tank Capacity"];
        }
    }
}
