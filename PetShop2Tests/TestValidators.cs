using NUnit.Framework;
using PetShop2.Domain;
using PetShop2.Domain.Validators;

namespace PetShopTests
{
    class TestValidators
    {
        //test the pet validator
        [Test]
        public void TestPetValidation()
        {
            IValidator<Pet> validator = new PetValidator();

            Pet validPet = new Pet()
            {
                ID = 1,
                Name = "kiki",
                Age = 12,
                Gender = GenderEnum.FEMININ,
                Species = "koala"
            };

            Pet petInvalid = new Pet()
            {
                ID = 2,
                Name = "",
                Age = -6,
                Gender = GenderEnum.UNKNOWN,
                Species = ""
            };


            //validating a valid pet
            validator.Validate(validPet);

            //trying to validate a pet with invalid name, age and species
            try
            {
                validator.Validate(petInvalid);
                Assert.Fail();
            }
            catch (ValidationException ve)
            {
                Assert.AreEqual(ve.Message, "Invalid name!\nInvalid age!\nInvalid species!\n");
            }
        }

        [Test]
        public void TestCustomerValidation()
        {
            IValidator<Customer> validator = new CustomerValidator();

            Customer validCustomer = new Customer()
            {
                Name = "Maria Popescu",
                Contact = "+40 103820944",
                Address = "Santana Street"
            };

            Customer invalidCustomer = new Customer()
            {
                Name = "",
                Contact = "",
                Address = ""
            };

            //validating a valid customer
            validator.Validate(validCustomer);

            //trying to validate a customer with invalid name, address and contact
            try
            {
                validator.Validate(invalidCustomer);
                Assert.Fail();
            }
            catch (ValidationException ve)
            {
                Assert.AreEqual(ve.Message, "Invalid name!\nInvalid contact!\nInvalid address!\n");
            }

        }

        [Test]
        public void TestServiceValidation()
        {
            IValidator<Service> validator = new ServiceValidator();

            Service validSrv = new Service()
            {
                ID = 1,
                Name = "washing",
                Price = 10,
                Duration = 20,
                Medicine = "shampoo"
            };

            Service invalidSrv = new Service()
            {
                ID = 1,
                Name = "",
                Price = -10,
                Duration = -20,
                Medicine = ""
            };

            //validating a valid service
            validator.Validate(validSrv);

            //trying to validate a service with invalid name, price, duration and medicie
            try
            {
                validator.Validate(invalidSrv);
                Assert.Fail();
            }
            catch (ValidationException ve)
            {
                Assert.AreEqual(ve.Message, "Invalid name!\nInvalid price!\nInvalid duration!\nInvalid medicine!\n");
            }
        }

        [Test]
        public void TestVetValidation()
        {
            IValidator<Vet> validator = new VetValidator();

            Vet validVet = new Vet()
            {
                ID = 1,
                Name = "Maria Popa",
                Schedule = "08:00-14:00"
            };

            Vet invalidVet = new Vet()
            {
                ID = 1,
                Name = "",
                Schedule = ""
            };

            //validating the valid vet
            validator.Validate(validVet);

            //trying to validate the vet with invalid name and schedule
            try
            {
                validator.Validate(invalidVet);
                Assert.Fail();
            }
            catch (ValidationException ve)
            {
                Assert.AreEqual(ve.Message, "Invalid name!\nInvalid schedule!\n");
            }


        }

        [Test]
        public void TestAppointmentValidation()
        {
            IValidator<Appointment> validator = new AppointmentValidator();

            Vet validVet = new Vet()
            {
                ID = 1,
                Name = "Maria Popa",
                Schedule = "08:00-16:00"
            };

            Appointment appValid = new Appointment()
            {
                ID = 1,
                PetID = 1,
                CustomerID = 1,
                ServiceID = 1,
                VetID = 1,
                Date = System.DateTime.Parse("03/12/2021 14:50")
            };

            Appointment appInvalid = new Appointment()
            {
                ID = 1,
                PetID = 1,
                CustomerID = 1,
                ServiceID = 1,
                VetID = 1,
                Date = System.DateTime.Parse("03/12/2021 22:00")
            };

            //validating a valid appointment
            validator.Validate(appValid, validVet);

            //trying to validate an appoinment with an invalid hour
            try
            {
                validator.Validate(appInvalid, validVet);
                Assert.Fail();
            }
            catch(ValidationException ve)
            {
                Assert.AreEqual(ve.Message, "Choose an hour that is in the schedule of the choosen vet!\n");
            }

        }
    }
}