﻿using System;
using System.Collections.Generic;
using System.Linq;

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

        public eVehicleType[] GetSupportedVehicleTypes()
        {
            eVehicleType[] supportedVehicleTypes = { eVehicleType.ElectricCar, eVehicleType.FuelCar, eVehicleType.ElectricMotorcycle, eVehicleType.FuelMotorcycle, eVehicleType.Truck };
            return supportedVehicleTypes;
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

        public Vehicle InitializeVehicle(eVehicleType i_VehicleType)
        {
            // TODO need to switch to string instead of eVehicleType in parameter type? and do the parsing inside
            //      also check if we need to return car to UI or not
            Vehicle vehicle = createVehicle(i_VehicleType); // This method assumes input is valid, need to check it before calling the method

            // TODO: put the new vehicle inside a VehicleInGarage object and send it to GarageManager

            return vehicle;
        }

        public eVehicleType ParseUserChoice(int i_UserChoice)
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

        public void FillVehicleParameters(Vehicle i_Vehicle, Dictionary<string, object> parameters)
        {
            i_Vehicle.Initialize(parameters);
        }
    }
}
