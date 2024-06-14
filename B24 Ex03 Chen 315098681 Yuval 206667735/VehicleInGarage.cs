﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private Vehicle m_Vehicle;
        private readonly Owner r_Owner;
        private eStatus m_VehicleStatus = eStatus.UnderRepair;

        public VehicleInGarage(Vehicle i_Vehicle, Owner i_Owner)
        {
            m_Vehicle = i_Vehicle;
            r_Owner = i_Owner;
        }

        public Owner OwnerDetails
        {
            get
            {
                return r_Owner;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }


        public eStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set 
            {
                m_VehicleStatus = value;
            }
        }

        public enum eStatus
        {
            UnderRepair,
            Repaired,
            PaidUp,
        }

        public class Owner
        {
            private string m_Name;
            private string m_Phone;

            //public Owner(string i_Name, string i_Phone)
            //{
            //    r_Name = i_Name;
            //    r_Phone = i_Phone;
            //}

            public string Name
            {
                get
                {
                    return m_Name;
                }
                set
                {
                    m_Name = value;
                }
            }
            
            public string Phone
            {
                get
                {
                    return m_Phone;
                }
                set
                {
                    m_Phone = value;
                }
            }
        }
    }
}
