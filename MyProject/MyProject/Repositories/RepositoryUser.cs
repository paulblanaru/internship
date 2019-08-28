using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories
{
    public class RepositoryUser : IRepository<User,string>
    {
        public RepositoryUser()
        {
        }

        public User Delete(string name)
        {
            using (var Context = new MyDbContext())
            {
                
                if (FindOne(name) == null)
                    return null;
                var ab = new User { Name = name };
                Context.Users.Attach(ab);
                Context.Users.Remove(ab);
                Context.SaveChanges();
                return new User();
            }
        }

        public IEnumerable<User> FindAll()
        {
            using (var Context = new MyDbContext())
            {
                
                List<User> result = new List<User>();
                var all = Context.Users;
                foreach (var User in all)
                {
                    result.Add(User);
                }
                return result;
            }
        }

        public User FindOne(string name)
        {
            using (var Context = new MyDbContext())
            { 
                User result = Context.Users.FirstOrDefault(c => c.Name == name);
                if (result == default(User))
                    return null;
                return result;
            }
        }

        public User Save(User entity)
        {
            using (var Context = new MyDbContext())
            {
                
                if (FindOne(entity.Name) != null)
                    return null;
                Context.Users.Add(entity);
                Context.SaveChanges();
                return entity;
            }
        }

        public User Update(User entity)
        {
            using (var Context = new MyDbContext())
            {
                
                if (FindOne(entity.Name) == null)
                    return null;
                var ab = Context.Users.First();
                ab = entity;
                Context.SaveChanges();
                Context.SaveChanges();
                return entity;
            }
        }
    }
}
