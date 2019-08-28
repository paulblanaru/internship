using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories
{
    public class RepositoryMyTask : IRepository<MyTask, int>
    {
        public RepositoryMyTask()
        {
        }

        public MyTask Delete(int id)
        {
            using (var Context = new MyDbContext())
            {

                if (FindOne(id) == null)
                    return null;
                var ab = new MyTask { Id = id };
                Context.MyTasks.Attach(ab);
                Context.MyTasks.Remove(ab);
                Context.SaveChanges();
                return new MyTask();
            }
        }

        public IEnumerable<MyTask> FindAll()
        {
            using (var Context = new MyDbContext())
            {

                List<MyTask> result = new List<MyTask>();
                var all = Context.MyTasks;
                foreach (var MyTask in all)
                {
                    result.Add(MyTask);
                }
                return result;
            }
        }

        public MyTask FindOne(int id)
        {
            using (var Context = new MyDbContext())
            {
                MyTask result = Context.MyTasks.FirstOrDefault(c => c.Id == id);
                if (result == default(MyTask))
                    return null;
                return result;
            }
        }

        public MyTask Save(MyTask entity)
        {
            using (var Context = new MyDbContext())
            {

                if (FindOne(entity.Id) != null)
                    return null;
                Context.MyTasks.Add(entity);
                Context.SaveChanges();
                return entity;
            }
        }

        public MyTask Update(MyTask entity)
        {
            using (var Context = new MyDbContext())
            {

                if (FindOne(entity.Id) == null)
                    return null;
                var ab = Context.MyTasks.First();
                ab = entity;
                Context.SaveChanges();
                Context.SaveChanges();
                return entity;
            }
        }
    }
}
