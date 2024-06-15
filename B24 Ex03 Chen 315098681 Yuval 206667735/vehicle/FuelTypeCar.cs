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

        internal FuelTypeCar()
        {
            base.m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTankCapacity);
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();
            parameters.Add("Current Amount of Fuel In Tank", typeof(float));
            return parameters;
        }

        protected override void InitializeCarSpecificParameters(Dictionary<string, object> iParameters)
        {
            float currentAmountOfFuelInTank = (float)iParameters["Current Amount of Fuel In Tank"];
            
            ((FuelEngine)m_Engine).CurrentAmountOfFuelInTank = currentAmountOfFuelInTank;
        }
    }
}
