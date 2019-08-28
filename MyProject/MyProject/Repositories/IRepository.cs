using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories
{
    public interface IRepository<E,ID> where E : class
    {
        E FindOne(ID id);
        IEnumerable<E> FindAll();
        E Save(E entity);
        E Delete(ID id);
        E Update(E entity);
    }
}
