namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private Vehicle m_Vehicle;
        private readonly Owner r_Owner;
        private eStatus m_VehicleStatus = eStatus.UnderRepair;

        public enum eStatus
        {
            UnderRepair = 1,
            Repaired,
            PaidUp
        }

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

        public struct Owner
        {
            private readonly string r_Name;
            private readonly string r_Phone;

            public Owner(string i_Name, string i_Phone)
            {
                r_Name = i_Name;
                r_Phone = i_Phone;
            }

            public string Name
            {
                get
                {
                    return r_Name;
                }
            }
            
            public string Phone
            {
                get
                {
                    return r_Phone;
                }
            }
        }
    }
}
