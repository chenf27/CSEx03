using Ex03.GarageLogic.engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_LicensePlate;
        protected string m_ModelName;
        protected Tire[] m_Tires;
        protected Engine m_Engine;

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
                { "License Plate", typeof(string) },
                { "Model Name", typeof(string) }
               // { "Tires Air Pressure", typeof(float) }
            };
        }

        public virtual Dictionary<string, string> GetFilledParameters()
        {
            return new Dictionary<string, string>
            {
                { "License Plate", m_LicensePlate },
                { "Model Name", m_ModelName }
               // { "Tires Air Pressure", typeof(float) }
            };
        }

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

        public void RefuelOrRecharge(Dictionary<string, object> i_Parameters)
        {
            m_Engine.RefuelOrRecharge(i_Parameters);
        }

    }
}
