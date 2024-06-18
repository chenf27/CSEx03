using Ex03.GarageLogic.engine;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        protected eCarColor m_CarColor;
        protected int m_NumOfDoors;
        private const int k_MinNumOfDoors = 2;
        private const int k_MaxNumOfDoors = 5;
        private const int k_NumOfTires = 5;
        private const float k_MaxAirTirePressure = 31;

        internal Car(Engine i_Engine)
        {
            base.m_Engine = i_Engine;
        }

        public enum eCarColor
        {
            Yellow = 1,
            White,
            Red,
            Black
        }

        public override Dictionary<string, Type> GetParameters()
        {
            Dictionary<string, Type> parameters = base.GetParameters();
            Dictionary<string, Type> engineParameters = m_Engine.GetParameters();

            parameters.Add("Car Color", typeof(eCarColor));
            parameters.Add("Number Of Doors", typeof(int));
            foreach (KeyValuePair<string, Type> param in engineParameters)
            {
                parameters.Add(param.Key, param.Value);
            }

            return parameters;
        }

        public override Dictionary<string, string> GetFilledParameters()
        {
            Dictionary<string, string> parameters = base.GetFilledParameters();
            Dictionary<string, string> engineParameters = m_Engine.GetFilledParameters();

            parameters.Add("Vehicle Type", "Car");
            parameters.Add("Car Color", m_CarColor.ToString());
            parameters.Add("Number Of Doors", m_NumOfDoors.ToString());
            foreach (KeyValuePair<string, string> param in engineParameters)
            {
                parameters.Add(param.Key, param.Value);
            }

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
            bool carColorParsedSuccessfully = int.TryParse(i_Parameters["Car Color"].ToString(), out int carColor);
            bool numOfDoorsParsedSuccessfully = int.TryParse(i_Parameters["Number Of Doors"].ToString(), out int numOfDoors);
            
            validateCarParameters(carColorParsedSuccessfully, numOfDoorsParsedSuccessfully, numOfDoors);
            m_CarColor = (eCarColor)carColor;
            m_NumOfDoors = numOfDoors;
            m_Engine.Initialize(i_Parameters);
        }

        private void validateCarParameters(bool i_CarColorParsedSuccessfully, bool i_NumOfDoorsParsedSuccessfully, int i_NumOfDoors)
        {
            if(!i_CarColorParsedSuccessfully)
            {
                throw new ArgumentException("Color must be one of these values: Yellow, White, Red, Black");
            }
            
            if(!i_NumOfDoorsParsedSuccessfully)
            {
                throw new FormatException("Number of doors must be an integer");
            }

            if(i_NumOfDoors < k_MinNumOfDoors || i_NumOfDoors > k_MaxNumOfDoors)
            {
                throw new ValueOutOfRangeException(k_MinNumOfDoors, k_MaxNumOfDoors, "number of doors");
            }
        }
    }
}
