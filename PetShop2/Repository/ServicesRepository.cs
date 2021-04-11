using PetShop2.Domain;
using PetShop2.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Repository
{
    public class ServicesRepository : FileRepository<int,Service>
    {
        public ServicesRepository(IValidator<Service> validator, string filename) : base(validator, filename, EntityToFileMapping.createService) 
        {
            loadFromFile();
        }

        public override IEnumerable<Service> FindAll()
        {
            loadFromFile();
            return base.FindAll();
        }

        public override Service FindOne(int serviceId)
        {
            loadFromFile();
            return base.FindOne(serviceId);
        }

        /*
         * input: a service
         * returns the given service if saved, null otherwise
        */
        public override Service Save(Service service)
        {
            validator.Validate(service);
            Service toReturn = base.Save(service);
            writeToFile();
            return toReturn;
        }
    }
}
