using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain.Validators
{
    public class PetValidator : IValidator<Pet>
    {
        public void Validate(Pet pet, Vet optionalVet)
        {
            string errors = "";

            if (pet.Name.Length == 0)
                errors += "Invalid name!\n";
            if (pet.Age <= 0)
                errors += "Invalid age!\n";
            if (pet.Gender != GenderEnum.MASCULINE && pet.Gender != GenderEnum.UNKNOWN && pet.Gender != GenderEnum.FEMININ)
                errors += "Invalid gender!\n";
            if (pet.Species.Length == 0)
                errors += "Invalid species!\n";

            if (errors.Length > 0)
                throw new ValidationException(errors);

        }
    }
}
