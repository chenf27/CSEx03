using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricTypeMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryLifeInHours = 2.5f;
        private ElectricEngine m_Engine = new ElectricEngine(k_MaxBatteryLifeInHours);

        public override Dictionary<string, Type> GetParameters()
        {
            return new Dictionary<string, Type>
            {
                { "License Plate", typeof(string) },
                { "Model Name", typeof(string) },
                { "License Type", typeof(string) },
                { "Engine Capacity", typeof(int) },
                { "Remaining Battery Hours Left", typeof(float) }
            };
        }

        public override void Initialize(Dictionary<string, object> parameters)
        {
            m_LicensePlate = parameters["License Plate"] as string;
            m_ModelName = parameters["Model Name"] as string;
            m_LicenseType = (eLicenseType)parameters["License Type"];        //Add input tests
            m_EngineCapacity = (int)parameters["Engine Capacity"];
            m_Engine.RemainingBatteryHoursLeft = (float)parameters["Remaining Battery Hours Left"];
        }
    }
}
