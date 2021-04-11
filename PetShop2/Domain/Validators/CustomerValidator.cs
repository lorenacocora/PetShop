using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain.Validators
{
    public class CustomerValidator : IValidator<Customer>
    {

        public void Validate(Customer customer, Vet optionalVet)
        {
            string errors = "";

            if (customer.Name.Length == 0)
                errors += "Invalid name!\n";
            if (customer.Contact.Length == 0)
                errors += "Invalid contact!\n";
            if (customer.Address.Length == 0)
                errors += "Invalid address!\n";

            if (errors.Length > 0)
                throw new ValidationException(errors);
        }
    }
}
