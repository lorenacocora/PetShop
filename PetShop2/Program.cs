using PetShop2.Domain;
using PetShop2.Domain.Validators;
using PetShop2.Repository;
using PetShop2.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop
{
    class Program
    {
        static int tableWidth = 110;
        static void Main(string[] args)
        {
            PetValidator petValidator = new PetValidator();
            string petsFilename = "..\\..\\..\\data\\pets.txt";
            PetsRepository petsRepository = new PetsRepository(petValidator, petsFilename);

            CustomerValidator customerValidator = new CustomerValidator();
            string customersFilename = "..\\..\\..\\data\\customers.txt";
            CustomersRepository customersRepository = new CustomersRepository(customerValidator, customersFilename);

            ServiceValidator serviceValidator = new ServiceValidator();
            string servicesFilename = "..\\..\\..\\data\\services.txt";
            ServicesRepository servicesRepository = new ServicesRepository(serviceValidator, servicesFilename);

            VetValidator vetValidator = new VetValidator();
            string vetsFilename = "..\\..\\..\\data\\vets.txt";
            VetsRepository vetsRepository = new VetsRepository(vetValidator, vetsFilename);

            AppointmentValidator appointmentValidator = new AppointmentValidator();
            string appointmentsFilename = "..\\..\\..\\data\\appointments.txt";
            AppointmentsRepository appointmentsRepository = new AppointmentsRepository(appointmentValidator, appointmentsFilename);

            Controller controller = new Controller(petsRepository, customersRepository, servicesRepository, vetsRepository,appointmentsRepository);

            runApp(controller);

        }

        static void runApp(Controller controller)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("1.Register pet");
                Console.WriteLine("2.Register costumer");
                Console.WriteLine("3.Get appointment");
                Console.WriteLine("4.View your appointments");
                Console.WriteLine("5.View appointments report");
                Console.WriteLine("0.Exit");
                Console.WriteLine("-------------------------------------------------");

                Console.Write("Your command: ");
                string fromConsole = Console.ReadLine();
                try
                {
                    int cmd = int.Parse(fromConsole);
                    if (cmd == 1)
                    {
                        savePet(controller);
                    }
                    else if (cmd == 2)
                    {
                        saveCustomer(controller);
                    }
                    else if (cmd == 3)
                    {
                        getAppointment(controller);
                    }
                    else if (cmd == 4)
                    {
                        viewAppointments(controller);
                    }
                    else if (cmd ==5)
                    {
                        viewReport(controller);
                    }
                    else if (cmd == 0)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid command!");
                }

            }
        }

        public static void savePet(Controller controller)
        {
            Console.Clear();
            try
            {
                Console.Write("Insert the name of the pet: ");
                string name = Console.ReadLine();
                Console.Write("Insert the age of the pet in months: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Gender:");
                Console.WriteLine("1.Feminin\n2.Masculine\n3.Unknown");
                Console.Write("Choose the gender: ");
                int genderChoice = int.Parse(Console.ReadLine());
                GenderEnum gender;
                switch (genderChoice)
                {
                    case 1:
                        gender = GenderEnum.FEMININ;
                        break;
                    case 2:
                        gender = GenderEnum.MASCULINE;
                        break;
                    case 3:
                        gender = GenderEnum.UNKNOWN;
                        break;
                    default:
                        gender = GenderEnum.UNKNOWN;
                        break;
                }

                Console.Write("Insert the species: ");
                string species = Console.ReadLine();

                controller.savePet(name, age, gender, species);
                Console.WriteLine("Pet saved!");
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void saveCustomer(Controller controller)
        {

            Console.Clear();
            try
            {
                Console.Write("Insert the name: ");
                string name = Console.ReadLine();
                Console.Write("Insert the contact: ");
                string contact = Console.ReadLine();
                Console.Write("Insert the address: ");
                string address = Console.ReadLine();

                controller.saveCustomer(name, contact, address);
                Console.WriteLine("Customer saved!");
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve.Message);
            }

        }

        public static void getAppointment(Controller controller)
        {
            int customerId, petId, serviceId, vetId;
            DateTime date;
            Console.Clear();

            //choosing the customer
            while (true)
            {
                Console.WriteLine("Customers:");
                foreach (Customer customer in controller.findAllCustomers())
                {
                    Console.WriteLine(customer.ID + ". " + customer.Name);
                }
                Console.Write("Choose your account: ");
                customerId = int.Parse(Console.ReadLine());

                //check if the choosen customer actually exists
                List < Customer > customers = controller.findAllCustomers().ToList();
                if (customers.Contains(controller.getCustomerById(customerId)))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose an existing customer account!");
                    Console.WriteLine();
                }

            }

            //choosing the pet
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Pets:");
                foreach (Pet pet in controller.findAllPets())
                {
                    Console.WriteLine(pet.ID + ". " + pet.Name);
                }
                Console.Write("Choose your pet: ");
                petId = int.Parse(Console.ReadLine());

                //check if the choosen pet actually exists
                List<Pet> pets = controller.findAllPets().ToList();
                if (pets.Contains(controller.getPetById(petId)))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose an existing pet!");
                    Console.WriteLine();
                }

            }

            //choosing the service
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Services:");
                foreach (Service service in controller.findAllServices())
                {
                    Console.WriteLine(service.ID + ". " + service);
                }
                Console.Write("Choose a service: ");
                serviceId = int.Parse(Console.ReadLine());

                //check if the choosen service actually exists
                List<Service> services = controller.findAllServices().ToList();
                if(services.Contains(controller.getServiceById(serviceId)))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose an existing service!");
                    Console.WriteLine();
                        
                }
            }

            //choosing the vet
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Vets:");
                foreach (Vet vet in controller.findAllVets())
                {
                    Console.WriteLine(vet.ID + ". " + vet);
                }
                Console.Write("Choose a vet: ");
                vetId = int.Parse(Console.ReadLine());

                //check if the choosen vet actually exists
                List<Vet> vets = controller.findAllVets().ToList();
                if(vets.Contains(controller.getVetById(vetId)))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose an existing vet!");
                    Console.WriteLine();
                }
            }


            //choosing a date
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Insert a date for your appointment [MM/dd/yy hh:mm] : ");
                try
                {
                    date = DateTime.Parse(Console.ReadLine());
                    controller.saveAppointment(petId, customerId, serviceId, vetId, date);
                    Console.WriteLine("Appointment saved!");
                    break;
                }
                catch (ValidationException ve)
                {
                    Console.WriteLine(ve.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date format! Try again: [MM/dd/yy hh:mm]");
                }
            }
        }

        public static void viewAppointments(Controller controller)
        {

            //choosing the customer
            Console.WriteLine("Customers:");
            foreach (Customer customer in controller.findAllCustomers())
            {
                Console.WriteLine(customer.ID + ". " + customer.Name);
            }
            Console.Write("Choose your account: ");
            int customerId = int.Parse(Console.ReadLine());

            //printing the data
            Console.Clear();
            List<AppointmentDTO> appointmentsDTO = controller.getAppointmentsDTO(customerId);
            Console.WriteLine("Your appointments: ");
            PrintTable(appointmentsDTO);
            
        }

        public static void viewReport(Controller controller)
        {
            //choosing the customer
            Console.WriteLine("Customers:");
            foreach (Customer customer in controller.findAllCustomers())
            {
                Console.WriteLine(customer.ID + ". " + customer.Name);
            }
            Console.Write("Choose the customer for the report: ");
            int customerId = int.Parse(Console.ReadLine());


            //printing the data
            Console.Clear();
            Customer choosenCustomer = controller.getCustomerById(customerId);
            Console.WriteLine();
            Console.WriteLine("Customer Information:");
            Console.WriteLine("Name: " + choosenCustomer.Name);
            Console.WriteLine("Contact: " + choosenCustomer.Contact);
            Console.WriteLine("Address: " + choosenCustomer.Address);
            Console.WriteLine();

            //frequence on year
            Console.WriteLine("Number of appointments for each year:");
            IDictionary<int, int> appointmentsByYear = controller.getNumberAppointmentsByCustomerPerYear(customerId);
            foreach(KeyValuePair<int,int> yearApp in appointmentsByYear)
            {
                Console.WriteLine(yearApp.Key+": "+yearApp.Value);
            }
            Console.WriteLine();

            //frequence on service
            Console.WriteLine("Number of attendences by service: ");
            IDictionary<string, int> servicesAndFrequence = controller.getServicesByFrequence(customerId);
            foreach(KeyValuePair<string,int> srvFreq in servicesAndFrequence)
            {
                Console.WriteLine(srvFreq.Key+": "+srvFreq.Value+" times");
            }

        }

        static void PrintTable(List<AppointmentDTO> appointmentDTOs)
        {
            PrintLine();
            PrintRow("SERVICE", "VET", "DATE", "MEDICINE", "PRICE");
            PrintLine();
            foreach(AppointmentDTO appDTO in appointmentDTOs)
            {
                PrintRow(appDTO.ServiceName, appDTO.VetName, appDTO.Date.ToString(), appDTO.Medicine, appDTO.Price.ToString());
                PrintLine();
            }

        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-',tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach(string column in columns)
            {
                row += AlignCenter(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCenter(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if(string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }

}
