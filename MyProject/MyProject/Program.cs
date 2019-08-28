using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext dbContext = new MyDbContext();
            User user = new User("paul","cluj",new DateTime(1998,1,27),"0751939819","password");
            MyTask myTask = new MyTask(1,"myTask","cea mai tare",new DateTime(2019,8,23));
            User user2 = dbContext.Users.FirstOrDefault();           
            //dbContext.Users.Add(user2);
            user2.MyTasks.Add(myTask);
            //dbContext.MyTasks.AddOrUpdate(myTask);
            dbContext.SaveChanges();
        }
    }
}
