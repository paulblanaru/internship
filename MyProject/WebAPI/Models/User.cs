using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class User
    {
        public User(string name, string adress, DateTime birthDate, string phone, string password)
        {
            Name = name;
            Adress = adress;
            BirthDate = birthDate;
            Phone = phone;
            Password = password;
        }

        public User()
        {
        }

        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public virtual List<MyTask> MyTasks { get; set; }
        
    }
}