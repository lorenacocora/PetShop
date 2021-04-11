using PetShop2.Domain;
using PetShop2.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop2.Repository
{

    public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
    {
        protected IDictionary<ID, E> entities = new Dictionary<ID, E>();
        protected IValidator<E> validator;

        public InMemoryRepository(IValidator<E> validator)
        {
            this.validator = validator;
        }

        public virtual IEnumerable<E> FindAll()
        {
            return entities.Values;
        }

        public virtual E FindOne(ID id)
        {
            if (entities.ContainsKey(id))
                return entities[id];
            return default(E);
        }


        /*
         * input: an entity
         * return the given entity if saved, null otherwise
         */
        public virtual E Save(E entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity cannot be null!");
            if (entities.ContainsKey(entity.ID))
                return entity;
            else entities.Add(entity.ID, entity);
            return null;
        }

        public int Size()
        {
            return entities.Count;
        }
    }
}
