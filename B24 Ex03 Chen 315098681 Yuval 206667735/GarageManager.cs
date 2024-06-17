using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesByLicensePlate = new Dictionary<string, VehicleInGarage>();

        public bool IsVehicleInGarage(string i_LicensePlate)
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

        public void InstallTiresOnVehicle(Vehicle io_Vehicle, float i_CurrentTireAirPressure, string i_Manufacturer)
        {
            Dictionary<string, string> parameters = io_Vehicle.GetTiresKnownInfo();
            int.TryParse(parameters["Number Of Tires"],out int numOfTires);
            float.TryParse(parameters["Max Air Pressure In Tires"], out float maxAirPressure);
            Tire[] tires = new Tire[numOfTires];

            //TODO CHECKS THAT CURR AIR PRESSURE ISNT MORE THAN MAX
            //TODO MAYBE FOREACH, DIDNT WORK OUT LAST TIME
            for(int i = 0; i < numOfTires; i++)
            {
                tires[i] = new Tire(i_Manufacturer, i_CurrentTireAirPressure, maxAirPressure);
            }

            io_Vehicle.Tires = tires;
        }
    }
}
