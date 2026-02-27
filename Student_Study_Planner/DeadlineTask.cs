using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Study_Planner
{
    public class DeadlineTask : PlannerItem
    {
        public DateTime Deadline { get; set; }
        public string Description { get; set; }

        public DeadlineTask(DateTime date,DateTime EndDte, string title, string category, Priority priority, DateTime deadline, string description, TaskType type)
            : base(date , EndDte, title, category, type, priority)
        {
            Deadline = deadline;
            Description = description;
        }

        public override string GetDetails()
        {
            return $"{Title} | {Category} | {Deadline:dd/MM/yyyy} | {Priority} | {Description}";
        }
    }
}
