using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain
{
    public class Entity<TID>
    {
        public TID ID { get; set; }
    }
}
