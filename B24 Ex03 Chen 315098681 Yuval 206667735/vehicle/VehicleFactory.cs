using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.vehicle
{
    public class VehicleFactory
    {
        private readonly Dictionary<eVehicleType, Type> r_VehicleTypes;
        
        public enum eVehicleType
        {
            ElectricCar,
            FuelCar,
            ElectricMotorcycle,
            FuelMotorcycle,
            Truck
        }

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

        private Vehicle createVehicle(eVehicleType i_VehicleType) 
        {
            if (r_VehicleTypes.TryGetValue(i_VehicleType, out Type VehicleType))
            {
                return Activator.CreateInstance(VehicleType) as Vehicle;
            }
            throw new ArgumentException("Unsupported vehicle type!");
        }

        public Dictionary<string, Type> InitializeVehicle(eVehicleType i_VehicleType)
        {
            // TODO need to switch to string instead of eVehicleType in parameter type? and do the parsing inside
            //      also check if we need to return car to UI or not
            Vehicle vehicle = createVehicle(i_VehicleType);
            return vehicle.GetParameters();
        }

        public void FillVehicleParameters(Vehicle i_Vehicle, Dictionary<string, object> parameters)
        {
            i_Vehicle.Initialize(parameters);
        }
    }
}
