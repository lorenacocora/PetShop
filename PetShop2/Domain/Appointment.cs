using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain
{
    public class Appointment : Entity<int>
    {
        public int PetID { get; set; }
        public int CustomerID { get; set; }

        public int ServiceID { get; set; }
        public int VetID { get; set; }

        public DateTime Date { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Appointment appointment &&
                   ID == appointment.ID &&
                   PetID == appointment.PetID &&
                   CustomerID == appointment.CustomerID &&
                   ServiceID == appointment.ServiceID &&
                   VetID == appointment.VetID &&
                   Date == appointment.Date;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, PetID, CustomerID, ServiceID, VetID, Date);
        }

        public override string ToString()
        {
            return PetID+","+CustomerID+","+ServiceID+","+VetID+","+Date;
        }
    }
}
