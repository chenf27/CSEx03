using System;

namespace Ex03.GarageLogic.vehicle
{
    public class VehicleFactory
    {
        public enum eVehicleType
        {
            ElectricCar = 1,
            FuelCar,
            ElectricMotorcycle,
            FuelMotorcycle,
            Truck
        }
        
        private Vehicle createVehicle(eVehicleType i_VehicleType) 
        {
            Vehicle newVehicle;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    newVehicle = new ElectricTypeCar();
                    break;
                case eVehicleType.FuelCar:
                    newVehicle = new FuelTypeCar();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new ElectricTypeMotorcycle();
                    break;
                case eVehicleType.FuelMotorcycle:
                    newVehicle = new FuelTypeMotorcycle();
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck();
                    break;
                default:
                    throw new ArgumentException("Unsupported vehicle type!");
            }

            return newVehicle;
        }

        public Vehicle CreateUninitializesVehicle(int i_UserChoiceVehicleType)
        {
            eVehicleType vehicleType = parseUserChoice(i_UserChoiceVehicleType);
            Vehicle vehicle = createVehicle(vehicleType); 

            return vehicle;
        }

        private eVehicleType parseUserChoice(int i_UserChoice)
        {
            eVehicleType vehicleType;

            switch (i_UserChoice)
            {
                case 1:
                    vehicleType = eVehicleType.ElectricCar;
                    break;
                case 2:
                    vehicleType = eVehicleType.FuelCar;
                    break;
                case 3:
                    vehicleType = eVehicleType.ElectricMotorcycle;
                    break;
                case 4:
                    vehicleType = eVehicleType.FuelMotorcycle;
                    break;
                case 5:
                    vehicleType = eVehicleType.Truck;
                    break;
                default:
                    throw new ArgumentException("Unsupported vehicle type!");
            }

            return vehicleType;
        }
    }
}
