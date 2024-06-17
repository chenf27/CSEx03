using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, VehicleInGarage> r_VehiclesByLicensePlate = new Dictionary<string, VehicleInGarage>();

        public Dictionary<string, VehicleInGarage> VehiclesByLicensePlate
        {
            get
            {
                return r_VehiclesByLicensePlate;
            }
        }

        public bool IsVehicleInGarage(string i_LicensePlate)
        {
            return r_VehiclesByLicensePlate.ContainsKey(i_LicensePlate);
        }

        public void SetVehicleInGarageStatus(string i_LicensePlate, VehicleInGarage.eStatus i_Status)
        {
            VehicleInGarage vehicleInGarage = r_VehiclesByLicensePlate[i_LicensePlate];
            vehicleInGarage.VehicleStatus = i_Status;
        }

        public void InflateTiresToMax(string i_LicensePlate)
        {
            VehicleInGarage vehicleInGarage = r_VehiclesByLicensePlate[i_LicensePlate];
            float maxCapacity = vehicleInGarage.Vehicle.Tires[0].MaxAirPressure;
            float currentCapacity = vehicleInGarage.Vehicle.Tires[0].CurrentAirPressure;
            float missingValueForMaxCapacity = maxCapacity - currentCapacity;

            foreach(Tire tire in vehicleInGarage.Vehicle.Tires)
            {
                tire.InflateTire(missingValueForMaxCapacity);
            }
        }

        public List<string> GetLicensePlatesByStatus(int i_Status)
        {
            List<string> licensePlates = new List<string>();

            foreach(KeyValuePair<string, VehicleInGarage> vehicleInGarage in r_VehiclesByLicensePlate)
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

            r_VehiclesByLicensePlate.Add(i_Vehicle.LicensePlate, vehicleInGarage);
        }

        public void SetVehicleInGarageStatus(string i_LicensePlate, int i_NewStatus)
        {
            r_VehiclesByLicensePlate[i_LicensePlate].VehicleStatus = (VehicleInGarage.eStatus)(i_NewStatus);
        }

        public void InstallTiresOnVehicle(Vehicle io_Vehicle, float i_CurrentTireAirPressure, string i_Manufacturer)
        {
            Dictionary<string, string> parameters = io_Vehicle.GetTiresKnownInfo();
            int numOfTires = int.Parse(parameters["Number Of Tires"]);
            float maxAirPressure = float.Parse(parameters["Max Air Pressure In Tires"]);
            Tire[] tires = new Tire[numOfTires];
            
            if(i_CurrentTireAirPressure > maxAirPressure)
            {
                throw new ValueOutOfRangeException(0, maxAirPressure, "air pressure");
            }
            
            for(int i = 0; i < numOfTires; i++)
            {
                tires[i] = new Tire(i_Manufacturer, i_CurrentTireAirPressure, maxAirPressure);
            }

            io_Vehicle.Tires = tires;
        }
    }
}
