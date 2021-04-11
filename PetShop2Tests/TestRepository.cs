using NUnit.Framework;
using PetShop2.Domain;
using PetShop2.Domain.Validators;
using PetShop2.Repository;
using System.Collections.Generic;

namespace PetShopTests
{
    class TestRepository
    {
        PetValidator petValidator = new PetValidator();
        string petsFilename = "D:\\Semestru 2\\Software Engineering\\PetShop2\\PetShop2Tests\\TestData\\petsTest.txt";
        PetsRepository petsRepository;

        CustomerValidator customerValidator = new CustomerValidator();
        string customersFilename = "D:\\Semestru 2\\Software Engineering\\PetShop2\\PetShop2Tests\\TestData\\customersTest.txt";
        CustomersRepository customersRepository;

        ServiceValidator serviceValidator = new ServiceValidator();
        string servicesFilename = "D:\\Semestru 2\\Software Engineering\\PetShop2\\PetShop2Tests\\TestData\\servicesTest.txt";
        ServicesRepository servicesRepository;

        VetValidator vetValidator = new VetValidator();
        string vetsFilename = "D:\\Semestru 2\\Software Engineering\\PetShop2\\PetShop2Tests\\TestData\\vetsTest.txt";
        VetsRepository vetsRepository;

        AppointmentValidator appointmentValidator = new AppointmentValidator();
        string appointmentsFilename = "D:\\Semestru 2\\Software Engineering\\PetShop2\\PetShop2Tests\\TestData\\appointmentsTest.txt";
        AppointmentsRepository appointmentsRepository;

        [SetUp]
        public void SetUp()
        {
            petsRepository = new PetsRepository(petValidator, petsFilename);
            customersRepository = new CustomersRepository(customerValidator, customersFilename);
            servicesRepository = new ServicesRepository(serviceValidator, servicesFilename);
            vetsRepository = new VetsRepository(vetValidator, vetsFilename);
            appointmentsRepository = new AppointmentsRepository(appointmentValidator, appointmentsFilename);
        }

        [TearDown]
        public void TearDown()
        {
            petsRepository.cleanFile();
            customersRepository.cleanFile();
            servicesRepository.cleanFile();
            vetsRepository.cleanFile();
            appointmentsRepository.cleanFile();
        }


        //testing saving valid pets
        //testing the find all functionality
        //testing the find one functionality
        [Test]
        public void TestPetRepository()
        {
            
            Assert.AreEqual(0,petsRepository.Size());

            Pet pet1 = new Pet()
            {
                ID = 1,
                Name = "kiki",
                Age = 12,
                Gender = GenderEnum.FEMININ,
                Species = "koala"
            };

            Pet pet2 = new Pet()
            {
                ID = 2,
                Name = "mimi",
                Age = 2,
                Gender = GenderEnum.FEMININ,
                Species = "cat"
            };

            //test the save function
            petsRepository.Save(pet1);
            petsRepository.Save(pet2);
            Assert.AreEqual(2, petsRepository.Size());

            //test the find all
            List<Pet> allPets = new List<Pet>();
            foreach(Pet pet in petsRepository.FindAll())
            {
                allPets.Add(pet);
            }
            Assert.AreEqual(allPets[0].ID,1);
            Assert.AreEqual(allPets[1].ID,2);

            //test the find one
            Pet petFound = petsRepository.FindOne(1);
            Assert.AreEqual(petFound, pet1);

        }


        //testing saving valid customers
        //testing the find all functionality
        //testing the find one functionality
        [Test]
        public void TestCustomerRepository()
        {
            
            Assert.AreEqual(0, customersRepository.Size());

            Customer customer1 = new Customer()
            {
                ID=1,
                Name = "Zenia Pappa",
                Contact = "+40 17685774",
                Address = "Santa Ana Street"
            };

            Customer customer2 = new Customer()
            {
                ID=2,
                Name = "Giusy Letitzia",
                Contact = "+40 1054573820944",
                Address = "Rua Maria"
            };

            //test the save function
            customersRepository.Save(customer1);
            customersRepository.Save(customer2);
            Assert.AreEqual(2, customersRepository.Size());

            //test the find all
            List<Customer> allCustomers = new List<Customer>();
            foreach (Customer customer in customersRepository.FindAll())
            {
                allCustomers.Add(customer);
            }
            Assert.AreEqual(allCustomers[0].ID, 1);
            Assert.AreEqual(allCustomers[1].ID, 2);

            //test the find one
            Customer customerFound = customersRepository.FindOne(1);
            Assert.AreEqual(customerFound, customer1);
            
        }


        //testing saving valid services
        //testing the find all functionality
        //testing the find one functionality
        [Test]
        public void TestServiceRepository()
        {
            Assert.AreEqual(servicesRepository.Size(), 0);

            Service srv1 = new Service()
            {
                ID = 1,
                Name = "washing",
                Price = 10,
                Duration = 20,
                Medicine = "shampoo"
            };

            Service srv2 = new Service()
            {
                ID = 2,
                Name = "clipping nails",
                Price = 25,
                Duration = 20,
                Medicine = "-"
            };

            //adding 2 services to the repository
            servicesRepository.Save(srv1);
            servicesRepository.Save(srv2);

            Assert.AreEqual(servicesRepository.Size(), 2);

            //test the find all
            List<Service> allServices = new List<Service>();
            foreach (Service srv in servicesRepository.FindAll())
            {
                allServices.Add(srv);
            }
            Assert.AreEqual(allServices[0].ID, 1);
            Assert.AreEqual(allServices[1].ID, 2);

            //test the find one
            Service serviceFound = servicesRepository.FindOne(1);
            Assert.AreEqual(serviceFound, srv1);

        }


        //testing saving valid vets
        //testing the find all functionality
        //testing the find one functionality
        [Test]
        public void TestVetsRepository()
        {
            Assert.AreEqual(vetsRepository.Size(), 0);

            Vet vet1 = new Vet()
            {
                ID = 1,
                Name = "Sisi Rocky",
                Schedule = "09:00-10:15"
            };

            Vet vet2 = new Vet()
            {
                ID = 2,
                Name = "Lori Cori",
                Schedule = "14:00-18:00"
            };

            //adding 2 vets to the repository
            vetsRepository.Save(vet1);
            vetsRepository.Save(vet2);

            Assert.AreEqual(vetsRepository.Size(), 2);

            //test the find all
            List<Vet> allVets = new List<Vet>();
            foreach (Vet vet in vetsRepository.FindAll())
            {
                allVets.Add(vet);
            }
            Assert.AreEqual(allVets[0].ID, 1);
            Assert.AreEqual(allVets[1].ID, 2);

            //test the find one
            Vet vetFound = vetsRepository.FindOne(1);
            Assert.AreEqual(vetFound, vet1);

        }

        //testing saving valid appointments
        //testing the find all functionality
        //testing the find one functionality
        [Test]
        public void TestAppointmentsRepository()
        {
            Assert.AreEqual(appointmentsRepository.Size(), 0);
            System.DateTime dateTime1 = System.DateTime.Parse("12/10/2021 09:10");
            System.DateTime dateTime2 = System.DateTime.Parse("02/01/2026 15:00");

            Appointment app1 = new Appointment()
            {
                ID = 1,
                PetID = 1,
                CustomerID = 1,
                ServiceID = 1,
                VetID = 1,
                Date = dateTime1
            };

            Vet vet1 = new Vet()
            {
                ID = 1,
                Name = "Sisi Rocky",
                Schedule = "09:00-10:15"
            };

            Appointment app2 = new Appointment()
            {
                ID = 2,
                PetID = 2,
                CustomerID = 2,
                ServiceID = 2,
                VetID = 2,
                Date = dateTime2
            };

            Vet vet2 = new Vet()
            {
                ID = 2,
                Name = "Lori Cori",
                Schedule = "14:00-18:00"
            };

            //adding 2 appointments to the repository
            appointmentsRepository.SaveWithVet(app1,vet1);
            appointmentsRepository.SaveWithVet(app2,vet2);

            Assert.AreEqual(appointmentsRepository.Size(), 2);

            //test the find all
            List<Appointment> allApointments = new List<Appointment>();
            foreach(Appointment app in appointmentsRepository.FindAll())
            {
                allApointments.Add(app);
            }
            Assert.AreEqual(allApointments[0], app1);
            Assert.AreEqual(allApointments[1], app2);

            //test the find one
            Appointment appointmentFound = appointmentsRepository.FindOne(app1.ID);
            Assert.AreEqual(appointmentFound, app1);
        }
    }
}
