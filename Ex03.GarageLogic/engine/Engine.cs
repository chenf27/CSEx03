using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.engine
{
    public abstract class Engine
    {
        protected float m_EnergyLeftInTank;

        public float EnergyLeftInTank 
        { 
            get 
            {  
                return m_EnergyLeftInTank; 
            }
            protected set
            {
                m_EnergyLeftInTank = value;
            }
        }

        public abstract void RefuelOrRecharge(Dictionary<string, object> i_Parameters);

        public abstract Dictionary<string, Type> GetParameters();

        public virtual Dictionary<string, string> GetFilledParameters()
        {
            return new Dictionary<string, string>
            {
                { "Energy left", string.Format($"{EnergyLeftInTank}%") }
            };
        }

        public abstract void Initialize(Dictionary<string, object> i_Parameters);
    }
}
