using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain.Validators
{
    public interface IValidator<E>
    {
        public void Validate(E entity, Vet vet = null);
    }
}
