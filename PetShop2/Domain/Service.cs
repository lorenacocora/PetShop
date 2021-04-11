using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain
{
    public class Service : Entity<int>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        public string Medicine { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Service service &&
                   ID == service.ID &&
                   Name == service.Name &&
                   Price == service.Price &&
                   Duration == service.Duration &&
                   Medicine == service.Medicine;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name, Price, Duration, Medicine);
        }

        public override string ToString()
        {
            return Name+","+Price+","+Duration+","+Medicine;
        }
    }
}
