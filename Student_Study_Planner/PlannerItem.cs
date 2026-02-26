using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Study_Planner
{
    // Priority Enum
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    // TaskType Enum
    public enum TaskType
    {
        StudySession,
        Assignment,
        Quiz,
        Exam
    }
    public abstract class PlannerItem
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public TaskType Type { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; }

        public PlannerItem(DateTime date, string title, string category, TaskType type, Priority priority)
        {
            Date = date;
            Title = title;
            Category = category;
            Type = type;
            Priority = priority;
            IsCompleted = false;
        }

        public abstract string GetDetails();
    }
}
