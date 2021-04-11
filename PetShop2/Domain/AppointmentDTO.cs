using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain
{
    public class AppointmentDTO
    {
        public string ServiceName { get; set; }
        public string VetName { get; set; }
        public DateTime Date { get; set; }
        public string Medicine { get; set; }
        public int Price { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return ServiceName + " | " + VetName + " | " + Date + " | " + Medicine + " | " + Price;
        }
    }
}
