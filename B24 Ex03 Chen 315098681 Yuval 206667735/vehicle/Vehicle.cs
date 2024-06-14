﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicensePlate;
        protected float m_EnergyLeftInTank;
        protected Tire[] m_Tires;


        //public Vehicle(string i_ModelName, string i_LicensePlate, float i_EnergyLeftInTank, Tire[] i_Tires)
        //{
        //    r_ModelName = i_ModelName;
        //    r_LicensePlate = i_LicensePlate;
        //    EnergyLeftInTank = i_EnergyLeftInTank;
        //    m_Tires = i_Tires;
        //}

        public float EnergyLeftInTank
        {
            get
            {
                return m_EnergyLeftInTank;
            }
            set
            {
                m_EnergyLeftInTank = value;
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

        public abstract Dictionary<string, Type> GetParameters();

        public abstract void Initialize(Dictionary<string, object> parameters);
    }
}
