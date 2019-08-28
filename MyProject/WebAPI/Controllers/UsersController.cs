using MyProject;
using MyProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        RepositoryUser repo = new RepositoryUser();

        [HttpGet]
        public IHttpActionResult Get()
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            return Ok(repo.FindAll().Select(e => Mappers.MapUser.MappingUserToWeb(e)));
        }

        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            repo.Save(user);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MyDbContext())
            {
                var existingUser = ctx.Users.Where(s => s.Name == user.Name)
                                                        .FirstOrDefault<User>();

                if (existingUser != null)
                {
                    existingUser.Adress = user.Adress;
                    existingUser.BirthDate = user.BirthDate;
                    existingUser.Phone = user.Phone;
                    existingUser.Password = user.Password;
                    existingUser.MyTasks = user.MyTasks;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(string name)
        {
            if (name == "")
                return BadRequest("Not a valid user name");

            using (var ctx = new MyDbContext())
            {
                var user = ctx.Users
                    .Where(s => s.Name == name)
                    .FirstOrDefault();

                ctx.Users.Remove(user);
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}
