using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPlanner.Domain.Entity
{
    public class MyDay
    {
        public int Id { get; set; }
        public DateTime TaskStart { get; set; }
        public DateTime TaskEnd { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsComplited { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is MyDay day &&
                   Id == day.Id &&
                   TaskStart == day.TaskStart &&
                   TaskEnd == day.TaskEnd &&
                   IsAllDay == day.IsAllDay &&
                   IsComplited == day.IsComplited &&
                   Name == day.Name &&
                   Description == day.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, TaskStart, TaskEnd, IsAllDay, IsComplited, Name, Description);
        }
    }
}
