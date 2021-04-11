using PetShop2.Domain;
using PetShop2.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Repository
{
    public class AppointmentsRepository : FileRepository<int,Appointment>
    {
        public AppointmentsRepository(AppointmentValidator validator, string filename) : base(validator,filename,EntityToFileMapping.createAppointment)
        {
            loadFromFile();
        }

        public override IEnumerable<Appointment> FindAll()
        {
            loadFromFile();
            return base.FindAll();
        }

        public override Appointment FindOne(int appointmentId)
        {
            loadFromFile();
            return base.FindOne(appointmentId);
        }


        /*
         * input: an appointment
         * returns the given appointment if saved, null otherwise
         */
        public override Appointment Save(Appointment appointment)
        {
            validator.Validate(appointment);
            Appointment toReturn = base.Save(appointment);
            writeToFile();
            return toReturn;
        }

        /*
         * input: an appointment
         * returns the given appointment if saved, null otherwise
         */
        public Appointment SaveWithVet(Appointment appointment, Vet vet)
        {
            validator.Validate(appointment,vet);
            Appointment toReturn = base.Save(appointment);
            writeToFile();
            return toReturn;
        }
    }
}
