using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesByLicensePlate = new Dictionary<string, VehicleInGarage>();
        public const float k_CarMaxAirPressure = 31;
        public const int k_CarNumOfTires = 5;
        public const float k_CarMaxBatteryHoursLeft = 3.5f;
        

        public void CreateNewVehicleInTheGarage(eVehicleType i_VehicleType, VehicleInGarage.Owner i_Owner)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    //ElectricTypeCar Car = new ElectricTypeCar();
                    break;

            }
        }

        public void CreateCar(eVehicleType i_VehicleType, Car.eCarColor i_CarColor, int i_NumOfDoors, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        {
            float energyRemains = 0;
            if (i_VehicleType == eVehicleType.ElectricCar)
            {
                energyRemains = generateCurrentEnergyLevel(eVehicleType.ElectricCar, i_EnergyLeftInTank);
                ElectricTypeVehicleAttributes electricCar = new ElectricTypeVehicleAttributes(k_CarMaxBatteryHoursLeft, energyRemains);
                ElectricTypeCar car = new ElectricTypeCar(electricCar, i_CarColor, i_NumOfDoors, i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires);
            }
        }

        public void AddVehicleInGarage(VehicleInGarage i_Vehicle)
        {
           m_VehiclesByLicensePlate.Add(i_Vehicle.Vehicle.LicensePlate, i_Vehicle);
        }

        public bool AlreadyInGarage(string i_LicensePlate)
        {
            return m_VehiclesByLicensePlate.ContainsKey(i_LicensePlate);
        }

        public void SetVehicleInGarageStatus(string i_LicensePlate, VehicleInGarage.eStatus i_Status)
        {
            VehicleInGarage vehicleInGarage = m_VehiclesByLicensePlate[i_LicensePlate];
            vehicleInGarage.VehicleStatus = i_Status;
        }

        private float generateCurrentEnergyLevel(eVehicleType i_VehicleType, float i_EnergyLeftInTank)
        {
            float energyLevel = 0;
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    energyLevel = k_CarMaxBatteryHoursLeft * i_EnergyLeftInTank / 100;
                    break;

                case eVehicleType.FuelCar:
                    break;

            }

            return energyLevel;
        }

        public enum eVehicleType
        {
            ElectricCar,
            FuelCar,
            ElectricMotorcycle,
            FuelMotorcycle,
            Truck
        }

    }
}
