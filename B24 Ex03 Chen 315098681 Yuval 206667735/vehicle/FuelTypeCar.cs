using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public class FuelTypeCar : Car
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
        private const float k_MaxFuelTankCapacity = 45;
        private FuelEngine m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTankCapacity);

        public override Dictionary<string, Type> GetParameters()
        {
            return new Dictionary<string, Type>
            {
                { "License Plate", typeof(string) },
                { "Model Name", typeof(string) },
                { "Car Color", typeof(eCarColor) },
                { "Number Of Doors", typeof(int) },
                { "Current Fuel Tank Capacity", typeof(float) }
            };
        }

        public override void Initialize(Dictionary<string, object> parameters)
        {
            m_LicensePlate = parameters["License Plate"] as string;
            m_ModelName = parameters["Model Name"] as string;
            m_CarColor = (eCarColor)parameters["Car Color"];
            m_NumOfDoors = (int)parameters["Number Of Doors"];
            m_Engine.CurrentFuelTankCapacity = (float)parameters["Current Fuel Tank Capacity"];
        }
    }
}
