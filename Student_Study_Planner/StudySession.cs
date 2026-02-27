using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Study_Planner
{
    public class StudySession : PlannerItem
    {
        public int EstimatedHours { get; set; }
        public int EstimatedMinutes { get; set; }

        public StudySession(DateTime date,DateTime EndDte, string title, string category, Priority priority,
            int estimatedHours, int estimatedMinutes, TaskType type)
            : base(date, EndDte, title, category, type, priority)
        {
            EstimatedHours = estimatedHours;
            EstimatedMinutes = estimatedMinutes;
        }

        public override string GetDetails()
        {
            return $"{Title} | {Category} | {EstimatedHours}h {EstimatedMinutes}m | {Priority}";
        }
    }
}
