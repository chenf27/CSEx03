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

        public override Dictionary<string, string> GetFilledParameters()
        {
            Dictionary<string, string> parameters = base.GetFilledParameters();

            parameters.Add("Engine type", "Fuel");
            parameters.Add("Fuel type", k_FuelType.ToString());
            parameters.Add("Energy left:", m_Engine.EnergyLeftInTank.ToString());
            return parameters;
        }

        protected override void InitializeCarSpecificParameters(Dictionary<string, object> i_Parameters)
        {
            //float currentAmountOfFuelInTank = (float)iParameters["Current Amount of Fuel In Tank"];
            bool remainingfuelParsedSuccessfully = float.TryParse(i_Parameters["Current Amount of Fuel In Tank"].ToString(), out float currentAmountOfFuelInTank);

            if (!remainingfuelParsedSuccessfully)
            {
                throw new FormatException("Current amount of fuel in tank must be a number");
            }

            ((FuelEngine)m_Engine).CurrentAmountOfFuelInTank = currentAmountOfFuelInTank;
        }
    }
}
