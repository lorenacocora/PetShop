using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain.Validators
{
    public class AppointmentValidator : IValidator<Appointment>
    {
        public void Validate(Appointment appointment, Vet optionalVet)
        {
            string errors = "";
            int startingHour = int.Parse(optionalVet.getStartingHour());
            int startingMinute = int.Parse(optionalVet.getStartingMinute());
            int endingHour = int.Parse(optionalVet.getEndingHour());
            if (appointment.Date.Hour < startingHour ||
                (appointment.Date.Hour == startingHour && appointment.Date.Minute < startingMinute) ||
                appointment.Date.Hour >= endingHour)
                errors += "Choose an hour that is in the schedule of the choosen vet!\n";

            if (errors.Length > 0)
                throw new ValidationException(errors);
                
        }
    }
}
