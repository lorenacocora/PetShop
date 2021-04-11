using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain.Validators
{
    public class ServiceValidator : IValidator<Service>
    {

        public void Validate(Service service, Vet optionalVet)
        {
            string errors = "";
            if (service.Name == "")
                errors += "Invalid name!\n";
            if (service.Price < 0)
                errors += "Invalid price!\n";
            if (service.Duration < 0)
                errors += "Invalid duration!\n";
            if (service.Medicine == "")
                errors += "Invalid medicine!\n";

            if (errors.Length > 0)
                throw new ValidationException(errors);
        }
    }
}
