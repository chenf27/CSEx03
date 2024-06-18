using Ex03.GarageLogic.engine;
using System;

namespace Ex03.GarageLogic.vehicle
{
    public class VehicleFactory
    {
        private const float k_ElectricCarMaxBatteryLifeInHours = 3.5f;
        private const float k_ElectricMotorcycleMaxBatteryLifeInHours = 2.5f;
        private const float k_CarFuelMaxFuelTankCapacity = 45;
        private const float k_MotorcycleFuelMaxFuelTankCapacity = 5.5f; 
        private const float k_TruckMaxFuelTankCapacity = 120;
        private const FuelEngine.eFuelType k_CarFuelType = FuelEngine.eFuelType.Octan95;
        private const FuelEngine.eFuelType k_MotorcycleFuelType = FuelEngine.eFuelType.Octan98;
        private const FuelEngine.eFuelType k_TruckFuelType = FuelEngine.eFuelType.Soler;


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
            Engine engine;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    engine = new ElectricEngine(k_ElectricCarMaxBatteryLifeInHours);
                    newVehicle = new Car(engine);
                    break;
                case eVehicleType.FuelCar:
                    engine = new FuelEngine(k_CarFuelType, k_CarFuelMaxFuelTankCapacity);
                    newVehicle = new Car(engine);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    engine = new ElectricEngine(k_ElectricMotorcycleMaxBatteryLifeInHours);
                    newVehicle = new Motorcycle(engine);
                    break;
                case eVehicleType.FuelMotorcycle:
                    engine = new FuelEngine(k_MotorcycleFuelType, k_MotorcycleFuelMaxFuelTankCapacity);
                    newVehicle = new Motorcycle(engine);
                    break;
                case eVehicleType.Truck:
                    engine = new FuelEngine(k_TruckFuelType, k_TruckMaxFuelTankCapacity);
                    newVehicle = new Truck(engine);
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
