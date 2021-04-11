using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain.Validators
{

    public class ValidationException : Exception
    {
        String Errors { get;}
        public ValidationException(String errors)
        {
            this.Errors = errors;
        }

        public override string Message => Errors;
    }
}
