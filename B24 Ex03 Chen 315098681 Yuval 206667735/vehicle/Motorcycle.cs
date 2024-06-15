using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLicenseType m_LicenseType;
        protected int m_EngineCapacity;
        
        public const float k_MaxAirPressure = 33;
        public const int k_NumOfTires = 2;

        //public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        //:base(i_ModelName, i_LicensePlate, i_EnergyLeftInTank, i_Tires)
        //{
        //    e_LicenseType = i_LicenseType;
        //    r_EngineCapacity = i_EngineCapacity;
        //}
        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B1
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();
            parameters.Add("License Type", typeof(string));
            parameters.Add("Engine Capacity", typeof(int));
            return parameters;
        }

        protected override void InitializeUniqueParameters(Dictionary<string, object> i_Parameters)
        {
            bool licenseParsedSuccessfully = Enum.TryParse((string)i_Parameters["License Type"], out eLicenseType licenseType);
            int engineCapacity = (int)i_Parameters["Engine Capacity"];

            ValidateMotorcycleParameters(licenseParsedSuccessfully);

            m_LicenseType = licenseType;
            m_EngineCapacity = engineCapacity;

            InitializeMotorcycleSpecificParameters(i_Parameters);
        }

        protected abstract void InitializeMotorcycleSpecificParameters(Dictionary<string, object> i_Parameters);

        private void ValidateMotorcycleParameters(bool i_licenseParsedSuccessfully)
        {
            if (!i_licenseParsedSuccessfully)
            {
                throw new ArgumentException("License Type must be one of these values: A, A1, AA, B1");
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }
    }
}
