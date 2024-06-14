using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricTypeCar : Car
    {
        private const float k_MaxBatteryLifeInHours = 3.5f;
        private ElectricEngine m_Engine = new ElectricEngine(k_MaxBatteryLifeInHours);

        public override Dictionary<string, Type> GetParameters()
        {
            return new Dictionary<string, Type>
            {
                { "License Plate", typeof(string) },
                { "Model Name", typeof(string) },
                { "Car Color", typeof(eCarColor) },
                { "Number Of Doors", typeof(int) },
                { "Remaining Battery Hours Left", typeof(float) }
            };
        }

        public override void Initialize(Dictionary<string, object> parameters)
        {
            m_LicensePlate = parameters["License Plate"] as string;
            m_ModelName = parameters["Model Name"] as string;
            m_CarColor = (eCarColor)parameters["Car Color"];
            m_NumOfDoors = (int)parameters["Number Of Doors"];
            m_Engine.RemainingBatteryHoursLeft = (float)parameters["Remaining Battery Hours Left"];
        }


        ElectricEngine ElectricEngine
        {
            get 
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }

    }
}
