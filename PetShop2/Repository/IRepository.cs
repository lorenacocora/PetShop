using PetShop2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Repository
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);
        IEnumerable<E> FindAll();
        E Save(E entity);
        int Size();
    }
}
