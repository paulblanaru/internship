using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories
{
    public class AbstractRepository<E, ID> : IRepository<E, ID> where E : class
    {
        public E Delete(ID id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<E> FindAll()
        {
            throw new NotImplementedException();
        }

        public E FindOne(ID id)
        {
            throw new NotImplementedException();
        }

        public E Save(E entity)
        {
            throw new NotImplementedException();
        }

        public E Update(E entity)
        {
            throw new NotImplementedException();
        }
    }
}
