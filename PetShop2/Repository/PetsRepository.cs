using System;
using System.Collections.Generic;
using System.Text;
using PetShop2.Domain;
using PetShop2.Domain.Validators;

namespace PetShop2.Repository
{

    public class PetsRepository : FileRepository<int, Pet>
    {

        public PetsRepository(IValidator<Pet> validator, String filename) : base(validator, filename, EntityToFileMapping.createPet) 
        { 
            loadFromFile();
        }


        public override IEnumerable<Pet> FindAll()
        {
            loadFromFile();
            return base.FindAll();
        }

        public override Pet FindOne(int petId)
        {
            loadFromFile();
            return base.FindOne(petId);
        }

        /*
         * input: a pet
         * returns the given pet if saved, null otherwise
         */
        public override Pet Save(Pet pet)
        {
            validator.Validate(pet);
            Pet toReturn = base.Save(pet);
            writeToFile();
            return toReturn;
        }
    }
}
