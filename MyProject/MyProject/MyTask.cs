using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class MyTask
    {
        public MyTask(int id, string taskName, string description, DateTime deadline)
        {
            Id = id;
            TaskName = taskName;
            Description = description;
            Deadline = deadline;
        }

        public MyTask()
        {
        }

        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public virtual User User { get; set; }
    }
}
