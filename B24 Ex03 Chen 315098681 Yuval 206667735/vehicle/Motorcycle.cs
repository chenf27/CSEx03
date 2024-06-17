﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLicenseType m_LicenseType;
        protected int m_EngineCapacity;        
        public const float k_MaxAirTirePressure = 33;
        public const int k_NumOfTires = 2;

        public enum eLicenseType
        {
            A = 1,
            A1,
            AA,
            B1
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();

            parameters.Add("License Type", typeof(eLicenseType));
            parameters.Add("Engine Capacity", typeof(int));

            return parameters;
        }

        public override Dictionary<string, string> GetFilledParameters()
        {
            Dictionary<string, string> parameters = base.GetFilledParameters();

            parameters.Add("License Type", m_LicenseType.ToString());
            parameters.Add("Engine Capacity", m_EngineCapacity.ToString());

            return parameters;
        }

        public override Dictionary<string, string> GetTiresKnownInfo()
        {
            return new Dictionary<string, string>
            {
                { "Max Air Pressure In Tires", k_MaxAirTirePressure.ToString() },
                { "Number Of Tires", k_NumOfTires.ToString() }
            };
        }


        protected override void InitializeUniqueParameters(Dictionary<string, object> i_Parameters)
        {
            bool licenseParsedSuccessfully = int.TryParse(i_Parameters["License Type"].ToString(), out int licenseType);
            bool capacityParsedSuccessfully = int.TryParse(i_Parameters["Engine Capacity"].ToString(), out int engineCapacity);

            validateMotorcycleParameters(licenseParsedSuccessfully, capacityParsedSuccessfully);
            m_LicenseType = (eLicenseType)licenseType;
            m_EngineCapacity = engineCapacity;
            m_Engine.Initialize(i_Parameters);
        }

        private void validateMotorcycleParameters(bool i_licenseParsedSuccessfully, bool i_capacityParsedSuccessfully)
        {
            if(!i_licenseParsedSuccessfully)
            {
                throw new FormatException("License Type must be one of these values: A, A1, AA, B1");
            }

            if(!i_capacityParsedSuccessfully)
            {
                throw new FormatException("Capacity must be an integer");
            }
        }
    }
}
