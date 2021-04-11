using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain
{
    public enum GenderEnum
    {
        FEMININ,
        MASCULINE,
        UNKNOWN
    }

    public class Pet : Entity<int>
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }
        public string Species { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Pet pet &&
                   ID == pet.ID &&
                   Name == pet.Name &&
                   Age == pet.Age &&
                   Gender == pet.Gender &&
                   Species == pet.Species;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name, Age, Gender, Species);
        }

        public override string ToString()
        {
            return Name+","+Age+","+Gender.ToString()+","+Species;
        }
    }
}
