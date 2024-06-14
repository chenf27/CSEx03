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

        //public FuelTypeCar(FuelTypeVehicleAttributes i_FuelCar, eCarColor i_CarColor, int i_NumOfDoors, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        //: base(i_CarColor, i_NumOfDoors, i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        //{
        //    m_FuelTypeAttributes = i_FuelCar;
        //}

        public override Dictionary<string, Type> GetParameters()
        {
            return new Dictionary<string, Type>
            {
                { "LicensePlate", typeof(string) },
                { "ModelName", typeof(string) },
                { "CarColor", typeof(eCarColor) },
                { "NumOfDoors", typeof(int) },
                { "CurrentFuelTankCapacity", typeof(float) }
            };
        }

        public override void Initialize(Dictionary<string, object> parameters)
        {
            m_LicensePlate = parameters["LicensePlate"] as string;
            m_ModelName = parameters["ModelName"] as string;
            m_CarColor = (eCarColor)parameters["CarColor"];
            m_NumOfDoors = (int)parameters["NumOfDoors"];
            m_Engine.CurrentFuelTankCapacity = (float)parameters["CurrentFuelTankCapacity"];
        }
    }
}
