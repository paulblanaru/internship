using MyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class MyTasksController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var dbContext = new MyDbContext())
            {
                return Ok(dbContext.MyTasks.ToList().Select(e => Mappers.MapMyTask.MappingMyTaskToWeb(e)));
            }

        }

        [HttpGet]
        [Route("api/Users/{name}/MyTasks")]
        public IHttpActionResult GetTasksByUser(string name)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var dbContext = new MyDbContext())
            {
                var list = dbContext.MyTasks.Where(s => s.User.Name == name).ToList();
                return Ok(list.Select(e => Mappers.MapMyTask.MappingMyTaskToWeb(e)));
            }
        }

        [Route("api/Users/{name}/MyTasks")]
        [HttpPost]
        public IHttpActionResult AssignTask(string name, [FromBody] int myTaskId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using(var ctx = new MyDbContext())
            {
                var user = ctx.Users.Find(name);
                var myTask = ctx.MyTasks.Find(myTaskId);
                if (user == null)
                {
                    return BadRequest("Invalid name.");
                }
                else
                {
                    if (myTask == null)
                        return BadRequest("Invalid task.");    
                }

                myTask.User = user;
                ctx.SaveChanges();
                return Ok();
            }
        }

        [HttpPost]
        public IHttpActionResult Post(MyTask myTask)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new MyDbContext())
            {
                ctx.MyTasks.Add(new MyTask
                {
                    Id = myTask.Id,
                    TaskName = myTask.TaskName,
                    Description = myTask.Description,
                    Deadline = myTask.Deadline
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(MyTask myTask)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new MyDbContext())
            {
                var existingMyTask = ctx.MyTasks.Where(s => s.Id == myTask.Id)
                                                        .FirstOrDefault<MyTask>();

                if (existingMyTask != null)
                {
                    existingMyTask.Id = myTask.Id;
                    existingMyTask.TaskName = myTask.TaskName;
                    existingMyTask.Description = myTask.Description;
                    existingMyTask.Deadline = myTask.Deadline; 
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
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id");

            using (var ctx = new MyDbContext())
            {
                var myTask = ctx.MyTasks
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                ctx.MyTasks.Remove(myTask);
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}

