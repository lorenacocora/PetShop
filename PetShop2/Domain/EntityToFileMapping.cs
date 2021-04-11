using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Domain
{
    public class EntityToFileMapping
    {
        public static Pet createPet(string entityData)
        {
            string[] fields = entityData.Split(",");
            Pet pet = new Pet()
            {
                ID = int.Parse(fields[0]),
                Name = fields[1],
                Age = int.Parse(fields[2]),
                Gender = (GenderEnum)Enum.Parse(typeof(GenderEnum), fields[3], true),
                Species = fields[4]
            };

            return pet;
        }

        public static Customer createCustomer(string entityData)
        {
            string[] fields = entityData.Split(",");
            Customer customer = new Customer()
            {
                ID = int.Parse(fields[0]),
                Name = fields[1],
                Contact = fields[2],
                Address = fields[3]
            };

            return customer;
        }

        public static Service createService(string entityData)
        {
            string[] fields = entityData.Split(",");
            Service srv = new Service()
            {
                ID = int.Parse(fields[0]),
                Name = fields[1],
                Price = int.Parse(fields[2]),
                Duration = int.Parse(fields[3]),
                Medicine = fields[4]
            };

            return srv;
        }

        public static Vet createVet(string entityData)
        {
            string[] fields = entityData.Split(",");
            Vet vet = new Vet()
            {
                ID = int.Parse(fields[0]),
                Name = fields[1],
                Schedule = fields[2]
            };

            return vet;
        }

        public static Appointment createAppointment(string entityData)
        {
            string[] fields = entityData.Split(",");
            Appointment appointment = new Appointment()
            {
                ID = int.Parse(fields[0]),
                PetID = int.Parse(fields[1]),
                CustomerID = int.Parse(fields[2]),
                ServiceID = int.Parse(fields[3]),
                VetID = int.Parse(fields[4]),
                Date = DateTime.Parse(fields[5])
            };

            return appointment;
        }
    }
}
