using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
