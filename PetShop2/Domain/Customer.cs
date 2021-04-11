using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain
{
    public class Customer : Entity<int>
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   ID == customer.ID &&
                   Name == customer.Name &&
                   Contact == customer.Contact &&
                   Address == customer.Address;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name, Contact, Address);
        }

        public override string ToString()
        {
            return Name + "," + Contact + "," + Address;
        }
    }
}
