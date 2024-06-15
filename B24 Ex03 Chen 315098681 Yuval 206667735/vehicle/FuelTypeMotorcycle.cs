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

        internal FuelTypeMotorcycle()
        {
            base.m_Engine = new FuelEngine(k_FuelType, k_MaxFuelTankCapacity);
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();
            parameters.Add("Current Amount of Fuel In Tank", typeof(float));
            return parameters;
        }

        protected override void InitializeMotorcycleSpecificParameters(Dictionary<string, object> i_Parameters)
        {
            float currentFuelTankCapacity = (float)i_Parameters["Current Amount of Fuel In Tank"];

            ((FuelEngine)m_Engine).CurrentAmountOfFuelInTank = currentFuelTankCapacity;
        }
    }
}
