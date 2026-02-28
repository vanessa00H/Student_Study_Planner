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

        // Add this method to fix CS1061
        public string ToCSV()
        {
            // Format: Kind,Title,Category,Date,Priority,Hours,Minutes,IsCompleted,Type
            return $"StudySession,{Title},{Category},{Date:dd/MM/yyyy},{Priority},{EstimatedHours},{EstimatedMinutes},{IsCompleted},{Type}";
        }

        public StudySession(DateTime date,DateTime EndDte, string title, string category, Priority priority,
            int estimatedHours, int estimatedMinutes, TaskType type)
            : base(date, EndDte, title, category, type, priority)
        {
            EstimatedHours = estimatedHours;
            EstimatedMinutes = estimatedMinutes;
        }

        public static StudySession FromCSV(string line)
        {
            string[] p = line.Split(',');

            if (p.Length < 9) return null;

            // 0=Kind, 1=Title, 2=Category, 3=Date, 4=Priority, 5=Hours, 6=Minutes, 7=IsCompleted, 8=Type
            DateTime date = DateTime.ParseExact(p[3], "dd/MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture);
            string title = p[1];
            string category = p[2];
            Priority pr = (Priority)Enum.Parse(typeof(Priority), p[4]);
            int hours = int.Parse(p[5]);
            int minutes = int.Parse(p[6]);
            bool done = bool.Parse(p[7]);
            TaskType type = (TaskType)Enum.Parse(typeof(TaskType), p[8]);

            StudySession s = new StudySession(date, date, title, category, pr, hours, minutes, type);
            s.IsCompleted = done;
            return s;
        }

        public override string GetDetails()
        {
            // Implementation as needed
            return $"{Title} - {Category} - {Date:dd/MM/yyyy} - {Priority} - {EstimatedHours}h {EstimatedMinutes}m";
        }
    }
}
