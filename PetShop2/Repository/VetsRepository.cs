using PetShop2.Domain;
using PetShop2.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Repository
{
    public class VetsRepository : FileRepository<int,Vet>
    {
        public VetsRepository(IValidator<Vet> validator, string filename) : base(validator,filename,EntityToFileMapping.createVet)
        {
            loadFromFile();
        }

        public override IEnumerable<Vet> FindAll()
        {
            loadFromFile();
            return base.FindAll();
        }

        public override Vet FindOne(int vetId)
        {
            loadFromFile();
            return base.FindOne(vetId);
        }

        /*
         * input: a vet
         * returns the given vet if saved, null otherwise
         */
        public override Vet Save(Vet vet)
        {
            validator.Validate(vet);
            Vet toReturn = base.Save(vet);
            writeToFile();
            return toReturn;
        }
    }
}
