using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain.Validators
{
    public class VetValidator : IValidator<Vet>
    {

        public void Validate(Vet entity, Vet optionalVet)
        {
            string errors = "";
            if (entity.Name == "")
                errors += "Invalid name!\n";
            if (entity.Schedule == "")
                errors += "Invalid schedule!\n";

            if (errors.Length > 0)
                throw new ValidationException(errors);
        }
    }
}
