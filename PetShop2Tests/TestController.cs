using NUnit.Framework;
using PetShop2.Domain;
using PetShop2.Domain.Validators;
using PetShop2.Repository;
using PetShop2.Services;
using System.Collections.Generic;

namespace PetShopTests
{

    class TestController
    {

        PetValidator petValidator = new PetValidator();
        string filename = "D:\\Semestru 2\\Software Engineering\\PetShop2\\PetShop2Tests\\TestData\\petsTest.txt";
        PetsRepository petsRepository;

        CustomerValidator customerValidator = new CustomerValidator();
        string customersFilename = "D:\\Semestru 2\\Software Engineering\\PetShop2\\PetShop2Tests\\TestData\\customersTest.txt";
        CustomersRepository customersRepository;

        ServiceValidator serviceValidator = new ServiceValidator();
        string servicesFilename = "D:\\Semestru 2\\Software Engineering\\PetShop2\\PetShop2Tests\\TestData\\servicesTest.txt";
        ServicesRepository serviceRepository;

        VetValidator vetValidator = new VetValidator();
        string vetsFilename = "D:\\Semestru 2\\Software Engineering\\PetShop2\\PetShop2Tests\\TestData\\vetsTest.txt";
        VetsRepository vetsRepository;

        AppointmentValidator appointmentValidator = new AppointmentValidator();
        string appointmentsFilename = "D:\\Semestru 2\\Software Engineering\\PetShop2\\PetShop2Tests\\TestData\\appointmentsTest.txt";
        AppointmentsRepository appointmentsRepository;

        Controller controller;


        [SetUp]
        public void SetUp()
        {
            petsRepository = new PetsRepository(petValidator, filename);
            customersRepository = new CustomersRepository(customerValidator, customersFilename);
            serviceRepository = new ServicesRepository(serviceValidator, servicesFilename);
            vetsRepository = new VetsRepository(vetValidator, vetsFilename);
            appointmentsRepository = new AppointmentsRepository(appointmentValidator, appointmentsFilename);
            controller = new Controller(petsRepository, customersRepository, serviceRepository, vetsRepository, appointmentsRepository);

        }

        [TearDown]
        public void TearDown()
        {
            petsRepository.cleanFile();
            customersRepository.cleanFile();
            serviceRepository.cleanFile();
            vetsRepository.cleanFile();
            appointmentsRepository.cleanFile();
        }


        //trying to save a pet
        [Test]
        public void TestSavePet()
        {

            //saving a valid pet
            controller.savePet("kiki", 24, PetShop2.Domain.GenderEnum.FEMININ, "koala");
            controller.savePet("mimi", 12, PetShop2.Domain.GenderEnum.MASCULINE, "cat");
            Assert.AreEqual(controller.countPets(), 2);

            //saving an invalid pet
            try
            {
                controller.savePet("", -5, PetShop2.Domain.GenderEnum.UNKNOWN, "");
                Assert.Fail();
            }
            catch (ValidationException ve)
            {
                Assert.AreEqual(ve.Message, "Invalid name!\nInvalid age!\nInvalid species!\n");
            }

        }



        //trying to save a customer
        [Test]
        public void TestSaveCustomer()
        {
            //saving a valid customer
            controller.saveCustomer("Maria", "+05983625", "Radu Poepscu Street");
            controller.saveCustomer("Coco", "+0556453625", "Mariela Street");

            Assert.AreEqual(controller.countCustomers(), 2);

            //trying to save an invalid customer
            try
            {
                controller.saveCustomer("", "", "");
                Assert.Fail();
            }
            catch (ValidationException ve)
            {
                Assert.AreEqual(ve.Message, "Invalid name!\nInvalid contact!\nInvalid address!\n");
            }


        }


        //trying to save a service
        [Test]
        public void TestSaveService()
        {

            //saving valid services
            controller.saveService("cleaning", 10, 20, "shampoo");
            controller.saveService("trimming", 15, 15, "medicinal oil");

            Assert.AreEqual(controller.countServices(), 2);

            //trying to save an invalid service
            try
            {
                controller.saveService("", -4, -2, "");
                Assert.Fail();
            }
            catch (ValidationException ve)
            {
                Assert.AreEqual(ve.Message, "Invalid name!\nInvalid price!\nInvalid duration!\nInvalid medicine!\n");
            }

        }


        //trying to save a vet
        [Test]
        public void TestSaveVet()
        {

            //saving valid vets
            controller.saveVet("Sisi Mimi", "08:00-09:00");
            controller.saveVet("Coco Lolo", "12:00-14:30");

            Assert.AreEqual(controller.countVets(), 2);

            //trying to save an invalid vet
            try
            {
                controller.saveVet("", "");
                Assert.Fail();
            }
            catch (ValidationException ve)
            {
                Assert.AreEqual(ve.Message, "Invalid name!\nInvalid schedule!\n");
            }

        }

        //trying to save an appointment
        [Test]
        public void TestSaveAppointment()
        {
            System.DateTime dateTime1 = System.DateTime.Parse("12/10/2021 08:35");
            System.DateTime dateTime2 = System.DateTime.Parse("02/01/2026 13:55");

            //saving vets
            controller.saveVet("Sisi Mimi", "08:00-09:00");
            controller.saveVet("Coco Lolo", "12:00-14:30");

            //saving valid appointments
            controller.saveAppointment(1, 1, 1, 1, dateTime1);
            controller.saveAppointment(2, 2, 2, 2, dateTime2);

            Assert.AreEqual(controller.countAppointments(), 2);
        }


        [Test]
        public void TestGetAppoinmentsByCustomer()
        {
            System.DateTime dateTime1 = System.DateTime.Parse("12/10/2021 13:45");
            System.DateTime dateTime2 = System.DateTime.Parse("02/01/2026 10:23");

            //saving vets
            controller.saveVet("Sisi Mimi", "13:00-14:00");
            controller.saveVet("Coco Lolo", "10:00-14:30");

            //saving valid appointments
            controller.saveAppointment(1, 1, 1, 1, dateTime1);
            controller.saveAppointment(2, 1, 3, 2, dateTime2);
            controller.saveAppointment(1, 1, 5, 1, dateTime1);
            controller.saveAppointment(2, 2, 2, 2, dateTime2);

            List<Appointment> appointmentsCustomer1 = controller.getAppointmentsByCustomer(1);

            Assert.AreEqual(appointmentsCustomer1[0].PetID, 1);
            Assert.AreEqual(appointmentsCustomer1[1].PetID, 2);
            Assert.AreEqual(appointmentsCustomer1[2].PetID, 1);

            List<Appointment> appointmentsCustomer2 = controller.getAppointmentsByCustomer(2);
            Assert.AreEqual(appointmentsCustomer2[0].PetID, 2);

        }


        //geting number of appointments for a given customer sorted by year
        [Test]
        public void TestNumberAppointmentsByCustomerPerYear()
        {
            System.DateTime dateTime1 = System.DateTime.Parse("12/10/2021 13:45");
            System.DateTime dateTime2 = System.DateTime.Parse("02/01/2026 10:23");
            System.DateTime dateTime3 = System.DateTime.Parse("02/01/2026 10:23");

            //saving vets
            controller.saveVet("Sisi Mimi", "13:00-14:00");
            controller.saveVet("Coco Lolo", "10:00-14:30");

            //adding 3 appointments for customer with id 1
            controller.saveAppointment(1, 1, 1, 1, dateTime1);
            controller.saveAppointment(2, 1, 2, 2, dateTime2);
            controller.saveAppointment(1, 1, 2, 2, dateTime3);


            IDictionary<int, int> customer1 = controller.getNumberAppointmentsByCustomerPerYear(1);

            Assert.AreEqual(customer1[2021], 1);
            Assert.AreEqual(customer1[2026], 2);

        }

        //getting the number of attendence to each service attended by a given user
        [Test]
        public void TestNumberServicesByCustomer()
        {
            System.DateTime dateTime1 = System.DateTime.Parse("12/10/2021 13:45");
            System.DateTime dateTime2 = System.DateTime.Parse("02/01/2026 10:23");
            System.DateTime dateTime3 = System.DateTime.Parse("02/01/2026 10:23");

            //saving vets
            controller.saveVet("Sisi Mimi", "13:00-14:00");
            controller.saveVet("Coco Lolo", "10:00-14:30");

            //saving services
            controller.saveService("cleaning", 10, 20, "shampoo");
            controller.saveService("trimming", 15, 15, "medicinal oil");

            //adding 3 appointments for customer with id 1
            //one for service with id 1
            controller.saveAppointment(1, 1, 1, 1, dateTime1);
            //two for service with id 2
            controller.saveAppointment(2, 1, 2, 2, dateTime2);
            controller.saveAppointment(1, 1, 2, 2, dateTime3);

            IDictionary<string, int> services = controller.getServicesByFrequence(1);
            Assert.AreEqual(services["cleaning"], 1);
            Assert.AreEqual(services["trimming"], 2);

        }

    }
}
