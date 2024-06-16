using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;
        private readonly string r_Message;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_ParameterName) 
        {
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
            r_Message = $"The value of {i_ParameterName} is out of range. It should be between {i_MinValue} and {i_MaxValue}.";
        }

        public float MinValue
        { 
            get { return r_MinValue; } 
        } 

        public float MaxValue
        {
            get { return r_MaxValue; }
        }

        public override string Message
        {
            get { return r_Message; }
        }
    }
}
