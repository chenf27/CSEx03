using Ex03.GarageLogic.engine;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_LicensePlate;
        protected string m_ModelName;
        protected Tire[] m_Tires;
        protected Engine m_Engine;
        private const int k_FirstTire = 0;

        public float EnergyLeftInTank
        {
            get
            {
                return m_Engine.EnergyLeftInTank;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
        }

        public Tire[] Tires
        {
            get
            {
                return m_Tires;
            }
            set
            {
                m_Tires = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public virtual Dictionary<string, Type> GetParameters()
        {
            return new Dictionary<string, Type>
            {
                { "Model Name", typeof(string) }
            };
        }

        public virtual Dictionary<string, string> GetFilledParameters()
        {
            return new Dictionary<string, string>
            {
                { "License Plate", m_LicensePlate },
                { "Model Name", m_ModelName },
                { "Number Of Tires", m_Tires.Length.ToString() },
                { "Tires Manufacturer", m_Tires[k_FirstTire].Manufacturer },
                { "Tires Current Air Pressure", m_Tires[k_FirstTire].CurrentAirPressure.ToString() },
                { "Tires Max Air Pressure", m_Tires[k_FirstTire].MaxAirPressure.ToString() },
            };
        }

        public abstract Dictionary<string, string> GetTiresKnownInfo();
            
        public virtual void Initialize(Dictionary<string, object> i_Parameters)
        {
            try
            {
                string licensePlate = i_Parameters["License Plate"] as string;
                string modelName = i_Parameters["Model Name"] as string;

                ValidateCommonParameters(licensePlate, modelName);

                m_LicensePlate = licensePlate;
                m_ModelName = modelName;

                InitializeUniqueParameters(i_Parameters);
            }
            catch (InvalidCastException ex)
            {
                throw new FormatException("Parameter type mismatch.", ex);
            }
            catch (KeyNotFoundException ex)
            {
                throw new ArgumentException("Missing parameter in the initialization dictionary.", ex);
            }
        }

        protected abstract void InitializeUniqueParameters(Dictionary<string, object> i_Parameters);

        protected void ValidateCommonParameters(string licensePlate, string modelName)
        {
            if (string.IsNullOrWhiteSpace(licensePlate) || string.IsNullOrWhiteSpace(modelName))
            {
                throw new ArgumentException("License Plate and Model Name cannot be null or empty.");
            }
        }
        //TODO unused method - delete?
        public void RefuelOrRecharge(Dictionary<string, object> i_Parameters)
        {
            m_Engine.RefuelOrRecharge(i_Parameters);
        }

    }
}
