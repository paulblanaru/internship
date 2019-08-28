using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Mappers
{
    public static class MapUser
    {
        public static Models.User MappingUserToWeb(MyProject.User user)
        {
            var res = new User
            {
                Name = user.Name,
                Adress = user.Adress,
                BirthDate = user.BirthDate,
                Phone = user.Phone,
                Password = user.Password
            };
            return res;
        }

        public static MyProject.User MappingUserToDb(Models.User user)
        {
            var res = new MyProject.User
            {
                Name = user.Name,
                Adress = user.Adress,
                BirthDate = user.BirthDate,
                Phone = user.Phone,
                Password = user.Password
            };
            return res;
        }
    }
}