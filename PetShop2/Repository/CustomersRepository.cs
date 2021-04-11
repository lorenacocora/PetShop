using PetShop2.Domain;
using PetShop2.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Repository

{
    public class CustomersRepository : FileRepository<int,Customer>
    {

        public CustomersRepository(IValidator<Customer> validator, String filename) : base(validator,filename,EntityToFileMapping.createCustomer) 
        {
            loadFromFile();
        }

        public override IEnumerable<Customer> FindAll()
        {
            loadFromFile();
            return base.FindAll();
        }

        public override Customer FindOne(int customerId)
        {
            loadFromFile();
            return base.FindOne(customerId);
        }

        /*
         * input: a customer
         * returns the given customer if saved, null otherwise
         */
        public override Customer Save(Customer customer)
        {
            validator.Validate(customer);
            Customer toReturn = base.Save(customer);
            writeToFile();
            return toReturn;
        }

    }
}
