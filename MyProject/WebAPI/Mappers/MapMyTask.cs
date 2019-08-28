using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Mappers
{
    public class MapMyTask
    {
        public static Models.MyTask MappingMyTaskToWeb(MyProject.MyTask myTask)
        {
            var res = new MyTask
            {
                Id = myTask.Id,
                TaskName = myTask.TaskName,
                Description = myTask.Description,
                Deadline = myTask.Deadline
            };
            return res;
        }
    }
}