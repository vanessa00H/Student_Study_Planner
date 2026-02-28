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
            if (string.IsNullOrWhiteSpace(line))
                return null;

            string[] p = line.Split(',');

            // NEW FORMAT (9 fields)
            if (p.Length >= 9)
            {
                try
                {
                    DateTime date = DateTime.ParseExact(p[3].Trim(), "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);

                    string title = p[1].Trim();
                    string category = p[2].Trim();
                    Priority pr = (Priority)Enum.Parse(typeof(Priority), p[4].Trim());
                    int hours = int.Parse(p[5].Trim());
                    int minutes = int.Parse(p[6].Trim());
                    bool done = bool.Parse(p[7].Trim());
                    TaskType type = (TaskType)Enum.Parse(typeof(TaskType), p[8].Trim());

                    StudySession s = new StudySession(date, date, title, category, pr, hours, minutes, type);
                    s.IsCompleted = done;
                    return s;
                }
                catch
                {
                    return null;
                }
            }

            // OLD FORMAT (6 fields): Title,Category,Date,Priority,Hours,Minutes
            if (p.Length >= 6)
            {
                try
                {
                    string title = p[0].Trim();
                    string category = p[1].Trim();
                    DateTime date = DateTime.Parse(p[2].Trim());
                    Priority pr = (Priority)Enum.Parse(typeof(Priority), p[3].Trim());
                    int hours = int.Parse(p[4].Trim());
                    int minutes = int.Parse(p[5].Trim());

                    StudySession s = new StudySession(date, date, title, category, pr, hours, minutes, TaskType.StudySession);
                    s.IsCompleted = false; // default = Pending
                    return s;
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        public override string GetDetails()
        {
            // Implementation as needed
            return $"{Title} - {Category} - {Date:dd/MM/yyyy} - {Priority} - {EstimatedHours}h {EstimatedMinutes}m";
        }
    }
}
