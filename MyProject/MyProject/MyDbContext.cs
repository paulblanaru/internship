using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MyTask> MyTasks { get; set; }

        public MyDbContext() :base("name = connectionString")
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(k => k.Name);
            modelBuilder.Entity<MyTask>()
                .HasKey(k => k.Id);
        }
    }
}
