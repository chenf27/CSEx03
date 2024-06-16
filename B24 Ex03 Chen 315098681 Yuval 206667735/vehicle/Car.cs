using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_CarColor;
        protected int m_NumOfDoors;
        private const int k_NumOfTires = 5;
        private const float k_MaxAirTirePressure = 31;

        public enum eCarColor
        {
            Yellow = 1,
            White,
            Red,
            Black
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
        }

        public int NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();

            parameters.Add("Car Color", typeof(eCarColor));
            parameters.Add("Number Of Doors", typeof(int));
            return parameters;
        }

        public override Dictionary<string, string> GetFilledParameters()
        {
            Dictionary<string, string> parameters = base.GetFilledParameters();

            parameters.Add("Car Color", m_CarColor.ToString());
            parameters.Add("Number Of Doors", m_NumOfDoors.ToString());
            return parameters;
        }

        protected override void InitializeUniqueParameters(Dictionary<string, object> i_Parameters)
        {
            bool carColorParsedSuccessfully = Enum.TryParse((string)i_Parameters["Car Color"], out eCarColor carColor);
            //int numOfDoors = (int)i_Parameters["Number Of Doors"];
            int.TryParse(((string)i_Parameters["Number Of Doors"]), out int numOfDoors);
            
            validateCarParameters(carColorParsedSuccessfully);

            m_CarColor = carColor;
            m_NumOfDoors = numOfDoors;

            InitializeCarSpecificParameters(i_Parameters);
        }

        protected abstract void InitializeCarSpecificParameters(Dictionary<string, object> i_Parameters);

        private void validateCarParameters(bool i_carColorParsedSuccessfully)
        {
            if (!i_carColorParsedSuccessfully)
            {
                throw new ArgumentException("Color must be one of these values: Yellow, White, Red, Black");
            }
        }
    }
}
