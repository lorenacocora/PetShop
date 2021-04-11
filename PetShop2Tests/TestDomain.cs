using NUnit.Framework;
using PetShop2.Domain;

namespace PetShopTests
{
    public class Tests
    {

        /*
         * test that the pets are created corectly
         * test the setters and getters
         */
        [Test]
        public void TestPet()
        {
            Pet pet1 = new Pet()
            {
                ID = 1,
                Name = "kiki",
                Age = 12,
                Gender = GenderEnum.FEMININ,
                Species = "koala"
            };

            Assert.AreEqual(1, pet1.ID);
            Assert.AreEqual("kiki", pet1.Name);
            Assert.AreEqual(12, pet1.Age);
            Assert.AreEqual(GenderEnum.FEMININ, pet1.Gender);
            Assert.AreEqual("koala", pet1.Species);

            pet1.ID = 2;
            pet1.Name = "Kiki";
            pet1.Age = 13;
            pet1.Gender = GenderEnum.UNKNOWN;
            pet1.Species = "Koala bear";

            Assert.AreEqual(2, pet1.ID);
            Assert.AreEqual("Kiki", pet1.Name);
            Assert.AreEqual(13, pet1.Age);
            Assert.AreEqual(GenderEnum.UNKNOWN, pet1.Gender);
            Assert.AreEqual("Koala bear", pet1.Species);
        }

        /*
         * test that the customers are created corectly
         * test the setters and getters
         */
        [Test]
        public void TestCustomer()
        {
            Customer customer1 = new Customer()
            {
                ID = 1,
                Name = "Moni",
                Contact = "+49 79278628824",
                Address = "Rua de Santa Maria No.253"
            };

            Assert.AreEqual(customer1.ID, 1);
            Assert.AreEqual(customer1.Name, "Moni");
            Assert.AreEqual(customer1.Contact, "+49 79278628824");
            Assert.AreEqual(customer1.Address, "Rua de Santa Maria No.253");

            customer1.ID = 2;
            customer1.Name = "Lena";
            customer1.Contact = "+49 98421687462";
            customer1.Address = "Rua de Santa Maria No.252";

            Assert.AreEqual(customer1.ID, 2);
            Assert.AreEqual(customer1.Name, "Lena");
            Assert.AreEqual(customer1.Contact, "+49 98421687462");
            Assert.AreEqual(customer1.Address, "Rua de Santa Maria No.252");

        }


        /*
         * test that the service are created corectly
         * test the setters and getters
         */
        [Test]
        public void TestService()
        {
            Service srv1 = new Service()
            {
                ID = 1,
                Name = "washing",
                Price = 10,
                Duration = 20,
                Medicine = "shampoo"
            };

            Assert.AreEqual(srv1.ID, 1);
            Assert.AreEqual(srv1.Name, "washing");
            Assert.AreEqual(srv1.Price, 10);
            Assert.AreEqual(srv1.Duration, 20);
            Assert.AreEqual(srv1.Medicine, "shampoo");

            srv1.ID = 2;
            srv1.Name = "vaccinating";
            srv1.Price = 200;
            srv1.Duration = 5;
            srv1.Medicine = "AstraZenecca Vaccine";

            Assert.AreEqual(srv1.ID, 2);
            Assert.AreEqual(srv1.Name, "vaccinating");
            Assert.AreEqual(srv1.Price, 200);
            Assert.AreEqual(srv1.Duration, 5);
            Assert.AreEqual(srv1.Medicine, "AstraZenecca Vaccine");

        }


        /*
         * test that the vets are created corectly
         * test the setters and getters
         */
        [Test]
        public void TestVets()
        {
            Vet vet1 = new Vet()
            {
                ID = 1,
                Name = "Maria Popa",
                Schedule = "08:00-14:00"
            };

            Assert.AreEqual(vet1.ID, 1);
            Assert.AreEqual(vet1.Name, "Maria Popa");
            Assert.AreEqual(vet1.Schedule, "08:00-14:00");

            vet1.ID = 2;
            vet1.Name = "Maria Popescu";
            vet1.Schedule = "08:00-14:00";

            Assert.AreEqual(vet1.ID, 2);
            Assert.AreEqual(vet1.Name, "Maria Popescu");
            Assert.AreEqual(vet1.Schedule, "08:00-14:00");
        }

        /*
         * test that the appointments are created corectly
         * test the setters and getters
         */
        [Test]
        public void TestAppointments()
        {
            System.DateTime someDate = System.DateTime.Now;

            Appointment appointment = new Appointment()
            {
                ID = 1,
                PetID = 1,
                CustomerID = 2,
                ServiceID = 1,
                VetID = 3,
                Date = someDate
            };

            Assert.AreEqual(appointment.ID, 1);
            Assert.AreEqual(appointment.PetID, 1);
            Assert.AreEqual(appointment.CustomerID, 2);
            Assert.AreEqual(appointment.ServiceID, 1);
            Assert.AreEqual(appointment.VetID, 3);
            Assert.AreEqual(appointment.Date, someDate);
        }


        /*
         * test that the appointmentsDTO are created corectly
         * test the setters and getters
         */
        [Test]
        public void TestAppointmentsDTO()
        {
            System.DateTime someDate = System.DateTime.Now;

            AppointmentDTO appointmentDTO = new AppointmentDTO()
            {
                ServiceName="clipping nails",
                VetName="Ana Pop",
                Date=someDate,
                Medicine="-",
                Price=15
            };

            Assert.AreEqual(appointmentDTO.ServiceName, "clipping nails");
            Assert.AreEqual(appointmentDTO.VetName, "Ana Pop");
            Assert.AreEqual(appointmentDTO.Date, someDate);
            Assert.AreEqual(appointmentDTO.Medicine, "-");
            Assert.AreEqual(appointmentDTO.Price, 15);

        }

    }




}