using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_ContainsHazardousMaterials {  get; set; }
        private readonly float r_CargoVolume;

        public Truck(string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, bool i_ContainsHazardousMaterials, float i_CargoVolume) 
        :base(i_ModelName, i_LicensePlate, i_EnergyLeftInTank)
        {
            m_ContainsHazardousMaterials = i_ContainsHazardousMaterials;
            r_CargoVolume = i_CargoVolume;
        }

        public float CarVolume
        {
            get
            {
                return r_CargoVolume;
            }
        }

        
    }
}
