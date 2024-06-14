using Ex03.GarageLogic.vehicle;
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


        public Vehicle CreateVehicle(VehicleFactory.eVehicleType i_VehicleType)
        {
            Vehicle vehicle;

            switch(i_VehicleType)
            {
                case VehicleFactory.eVehicleType.ElectricCar:
                    vehicle = new ElectricTypeCar();
                    break;
                case VehicleFactory.eVehicleType.FuelCar:
                    vehicle = new FuelTypeCar();
                    break;
                case VehicleFactory.eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricTypeMotorcycle();
                    break;
                case VehicleFactory.eVehicleType.FuelMotorcycle:
                    vehicle = new FuelTypeMotorcycle();
                    break;
                case VehicleFactory.eVehicleType.Truck:
                    vehicle = new Truck();
                    break;
                default:
                    //TODO EXEPTION
                    vehicle = new ElectricTypeMotorcycle();
                    break;
            }

            return vehicle;
        }

        public void CreateNewVehicleInTheGarage(VehicleFactory.eVehicleType i_VehicleType, VehicleInGarage.Owner i_Owner)
        {
            switch (i_VehicleType)
            {
                case VehicleFactory.eVehicleType.ElectricCar:
                    //ElectricTypeCar Car = new ElectricTypeCar();
                    break;

            }
        }

        public void CreateCar(VehicleFactory.eVehicleType i_VehicleType, Car.eCarColor i_CarColor, int i_NumOfDoors, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        {
            float energyRemains = 0;
            if (i_VehicleType == VehicleFactory.eVehicleType.ElectricCar)
            {
                energyRemains = generateCurrentEnergyLevel(VehicleFactory.eVehicleType.ElectricCar, i_EnergyLeftInTank);
                //ElectricEngine electricCar = new ElectricTypeVehicleAttributes(k_CarMaxBatteryHoursLeft, energyRemains);
                //ElectricTypeCar car = new ElectricTypeCar(electricCar, i_CarColor, i_NumOfDoors, i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires);
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

        public void InflatingTireToMax(string i_LicensePlate)
        {
            VehicleInGarage vehicleInGarage = m_VehiclesByLicensePlate[i_LicensePlate];
            float maxCapacity = vehicleInGarage.Vehicle.Tires[0].MaxAirPressure;
            float currentCapacity = vehicleInGarage.Vehicle.Tires[0].CurrentAirPressure;
            float missingValueForMaxCapacity = maxCapacity - currentCapacity;

            foreach(Tire tire in vehicleInGarage.Vehicle.Tires)
            {
                tire.InflatingTire(missingValueForMaxCapacity);
            }
        }


        private float generateCurrentEnergyLevel(VehicleFactory.eVehicleType i_VehicleType, float i_EnergyLeftInTank)
        {
            float energyLevel = 0;
            switch (i_VehicleType)
            {
                case VehicleFactory.eVehicleType.ElectricCar:
                    energyLevel = k_CarMaxBatteryHoursLeft * i_EnergyLeftInTank / 100;
                    break;

                case VehicleFactory.eVehicleType.FuelCar:
                    break;

            }

            return energyLevel;
        }

        public List<string> GetLicensePlatesByStatus(VehicleInGarage.eStatus i_Status)
        {
            List<string> licensePlates = new List<string>();

            foreach(KeyValuePair<string, VehicleInGarage> vehicleInGarage in m_VehiclesByLicensePlate)
            {
                if(vehicleInGarage.Value.VehicleStatus.Equals(i_Status))
                {
                    licensePlates.Add(vehicleInGarage.Key);
                }
            }

            return licensePlates;
        }
    }
}
