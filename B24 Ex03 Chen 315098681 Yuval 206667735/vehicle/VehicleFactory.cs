using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.vehicle
{
    public class VehicleFactory
    {
        public enum eVehicleType
        {
            ElectricCar,
            FuelCar,
            ElectricMotorcycle,
            FuelMotorcycle,
            Truck
        }

        private readonly Dictionary<eVehicleType, Type> r_VehicleTypes;

        public VehicleFactory()
        {
            r_VehicleTypes = new Dictionary<eVehicleType, Type>
            {
                { eVehicleType.ElectricCar, typeof(ElectricTypeCar) },
                { eVehicleType.FuelCar, typeof(FuelTypeCar) },
                { eVehicleType.ElectricMotorcycle, typeof(ElectricTypeMotorcycle) },
                { eVehicleType.FuelMotorcycle, typeof(FuelTypeMotorcycle) },
                { eVehicleType.Truck, typeof(Truck) }
            };
        }

        public Vehicle CreateVehicle(eVehicleType i_VehicleType)
        {
            if (r_VehicleTypes.TryGetValue(i_VehicleType, out Type VehicleType))
            {
                return Activator.CreateInstance(VehicleType) as Vehicle;
            }
            throw new ArgumentException("Unsupported vehicle type!");
        }

        public Dictionary<string, Type> CreateVehicleAndGetParameters(eVehicleType i_VehicleType)
        {
            Vehicle vehicle = CreateVehicle(i_VehicleType);
            return vehicle.GetParameters();
        }

        public void InitializeVehicle(Vehicle i_Vehicle, Dictionary<string, object> parameters)
        {
            i_Vehicle.Initialize(parameters);
        }
    }
}
