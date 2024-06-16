using Ex03.GarageLogic.vehicle;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesByLicensePlate = new Dictionary<string, VehicleInGarage>();
        public const float k_CarMaxAirPressure = 31;
        public const int k_CarNumOfTires = 5;
        public const float k_CarMaxBatteryHoursLeft = 3.5f;


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

        // ------------------------------DELETE? we dont use it------------------------------
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

        public List<string> GetLicensePlatesByStatus(int i_Status)
        {
            List<string> licensePlates = new List<string>();

            foreach(KeyValuePair<string, VehicleInGarage> vehicleInGarage in m_VehiclesByLicensePlate)
            {
                if(vehicleInGarage.Value.VehicleStatus.Equals((VehicleInGarage.eStatus)i_Status))
                {
                    licensePlates.Add(vehicleInGarage.Key);
                }
            }

            return licensePlates;
        }

        public void EnterVehicleToGarage(Vehicle i_Vehicle, VehicleInGarage.Owner i_Owner)
        {
            VehicleInGarage vehicleInGarage = new VehicleInGarage(i_Vehicle, i_Owner);

            m_VehiclesByLicensePlate.Add(vehicleInGarage.Vehicle.LicensePlate, vehicleInGarage);
        }

        public void SetVehicleInGarageStatus(string licensePlate, int newStatus)
        {
            m_VehiclesByLicensePlate[licensePlate].VehicleStatus = (VehicleInGarage.eStatus)(newStatus);
        }

        public Dictionary<string, VehicleInGarage> VehiclesByLicensePlate
        {
            get
            {
                return m_VehiclesByLicensePlate;
            }
        }
    }
}
