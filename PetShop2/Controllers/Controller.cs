using PetShop2.Domain;
using PetShop2.Domain.Validators;
using PetShop2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop2.Services
{
    public class Controller
    {
        private PetsRepository petsRepository;
        private CustomersRepository customersRepository;
        private ServicesRepository servicesRepository;
        private VetsRepository vetRepository;
        private AppointmentsRepository appointmentsRepository;

        public Controller(PetsRepository petsRepository, CustomersRepository customersRepository, ServicesRepository servicesRepository, VetsRepository vetRepository, AppointmentsRepository appointmentsRepository)
        {
            this.petsRepository = petsRepository;
            this.customersRepository = customersRepository;
            this.servicesRepository = servicesRepository;
            this.vetRepository = vetRepository;
            this.appointmentsRepository = appointmentsRepository;
        }


        //PET FUNCTIONALITIES
        public Pet savePet(string name, int age, GenderEnum gender, string species)
        {
            Pet petToSave = new Pet()
            {
                ID = idGenerator<Pet>(petsRepository),
                Name = name,
                Age = age,
                Gender = gender,
                Species = species
            };
            return petsRepository.Save(petToSave);
        }


        public IEnumerable<Pet> findAllPets()
        {
            return petsRepository.FindAll();
        }

        public int countPets()
        {
            return petsRepository.Size();
        }

        public Pet findPet(int petId)
        {
            return petsRepository.FindOne(petId);
        }


        //CUSTOMER FUNCTIONALITIES
        public Customer saveCustomer(string name, string contact, string address)
        {
            Customer customerToSave = new Customer()
            {
                ID = idGenerator<Customer>(customersRepository),
                Name = name,
                Contact = contact,
                Address = address
            };
            return customersRepository.Save(customerToSave);
        }

        public IEnumerable<Customer> findAllCustomers()
        {
            return customersRepository.FindAll();
        }

        public int countCustomers()
        {
            return customersRepository.Size();
        }

        public Customer findCustomer(int customerId)
        {
            return customersRepository.FindOne(customerId);
        }


        //SERVICES FUNCTIONALITIES
        public Service saveService(string name, int price, int duration, string medicine)
        {
            Service serviceToSave = new Service()
            {
                ID = idGenerator<Service>(servicesRepository),
                Name = name,
                Price = price,
                Duration = duration,
                Medicine = medicine
            };

            return servicesRepository.Save(serviceToSave);
        }

        public IEnumerable<Service> findAllServices()
        {
            return servicesRepository.FindAll();
        }

        public int countServices()
        {
            return servicesRepository.Size();
        }

        public Service findService(int serviceId)
        {
            return servicesRepository.FindOne(serviceId);
        }


        //VET FUNCTIONALITIES
        public Vet saveVet(string name, string schedule)
        {
            Vet vetToSave = new Vet()
            {
                ID = idGenerator<Vet>(vetRepository),
                Name = name,
                Schedule = schedule
            };

            return vetRepository.Save(vetToSave);
        }

        public IEnumerable<Vet> findAllVets()
        {
            return vetRepository.FindAll();
        }

        public int countVets()
        {
            return vetRepository.Size();
        }

        public Vet findVet(int vetId)
        {
            return vetRepository.FindOne(vetId);
        }


        //APPOINTMENT FUNCTIONALITIES
        public Appointment saveAppointment(int petId, int customerId, int serviceId, int vetId, DateTime date)
        {
            Appointment appointment = new Appointment
            {
                ID = idGenerator<Appointment>(appointmentsRepository),
                PetID = petId,
                CustomerID = customerId,
                ServiceID = serviceId,
                VetID = vetId,
                Date = date
            };

            Vet vet = vetRepository.FindOne(vetId);
            return appointmentsRepository.SaveWithVet(appointment, vet);
        }

        public IEnumerable<Appointment> FindAllAppointments()
        {
            return appointmentsRepository.FindAll();
        }

        public int countAppointments()
        {
            return appointmentsRepository.Size();
        }


        //OTHER FUNCTIONALITIES
        public List<Appointment> getAppointmentsByCustomer(int customerId)
        {
            List<Appointment> appointments = appointmentsRepository.FindAll().ToList();

            var result = from app in appointments
                          where app.CustomerID == customerId
                          select app;

            return result.ToList();
        }


        public List<AppointmentDTO> getAppointmentsDTO(int customerId)
        {
            List<Appointment> appointments = getAppointmentsByCustomer(customerId);
            List<AppointmentDTO> appointmentsDTO = new List<AppointmentDTO>();
            foreach (Appointment app in appointments)
            {
                Service service = findService(app.ServiceID);
                Vet vet = findVet(app.VetID);

                AppointmentDTO appDTO = new AppointmentDTO()
                {
                    ServiceName = service.Name,
                    VetName = vet.Name,
                    Date = app.Date,
                    Price = service.Price,
                    Medicine = service.Medicine
                };

                appointmentsDTO.Add(appDTO);
            }

            return appointmentsDTO;
        }


        public IDictionary<int, int> getNumberAppointmentsByCustomerPerYear(int customerId)
        {

            IDictionary<int, int> appsByYears = new Dictionary<int, int>();

            foreach (Appointment app in getAppointmentsByCustomer(customerId))
            {
                if (appsByYears.ContainsKey(app.Date.Year))
                    appsByYears[app.Date.Year] = appsByYears[app.Date.Year] + 1;
                else appsByYears.Add(app.Date.Year, 1);
            }

            return appsByYears;
        }


        public IDictionary<string,int> getServicesByFrequence(int customerId)
        {
            IDictionary<string, int> servicesAndFrequence = new Dictionary<string, int>();

            foreach(Appointment app in getAppointmentsByCustomer(customerId))
            {
                Service service = findService(app.ServiceID);
                if (servicesAndFrequence.ContainsKey(service.Name))
                    servicesAndFrequence[service.Name] = servicesAndFrequence[service.Name] + 1;
                else servicesAndFrequence.Add(service.Name,1);

            }

            return servicesAndFrequence;
        }

        
        private int idGenerator<E>(IRepository<int, E> repository) where E : Entity<int>
        {
            bool ok = true;
            for (int i = 1; ok; i++)
            {
                bool taken = false;
                foreach (var entity in repository.FindAll())
                {
                    if (entity.ID == i)
                    {
                        taken = true;
                        break;
                    }
                }
                if (taken == false)
                    return i;
            }
            return 0;
        }

        public Customer getCustomerById(int customerId)
        {
            return customersRepository.FindOne(customerId);
        }

        public Pet getPetById(int petId)
        {
            return petsRepository.FindOne(petId);
        }

        public Service getServiceById(int serviceId)
        {
            return servicesRepository.FindOne(serviceId);
        }

        public Vet getVetById( int vetId)
        {
            return vetRepository.FindOne(vetId);
        }

    }
}
