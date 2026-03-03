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

        // UPDATED CSV FORMAT
        // Kind,Title,Category,StartDate,EndDate,Priority,Hours,Minutes,IsCompleted,Type
        public string ToCSV()
        {
            return $"StudySession,{Title},{Category},{Date:dd/MM/yyyy},{EndDate:dd/MM/yyyy},{Priority},{EstimatedHours},{EstimatedMinutes},{IsCompleted},{Type}";
        }

        public StudySession(DateTime startDate, DateTime endDate, string title, string category, Priority priority,
            int estimatedHours, int estimatedMinutes, TaskType type)
            : base(startDate, endDate, title, category, type, priority)
        {
            EstimatedHours = estimatedHours;
            EstimatedMinutes = estimatedMinutes;
        }

        public static StudySession FromCSV(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            string[] p = line.Split(',');

            // NEW FORMAT (10 fields)
            if (p.Length >= 10)
            {
                try
                {
                    DateTime startDate = DateTime.ParseExact(p[3].Trim(), "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);

                    DateTime endDate = DateTime.ParseExact(p[4].Trim(), "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);

                    string title = p[1].Trim();
                    string category = p[2].Trim();
                    Priority pr = (Priority)Enum.Parse(typeof(Priority), p[5].Trim());
                    int hours = int.Parse(p[6].Trim());
                    int minutes = int.Parse(p[7].Trim());
                    bool done = bool.Parse(p[8].Trim());
                    TaskType type = (TaskType)Enum.Parse(typeof(TaskType), p[9].Trim());

                    StudySession s = new StudySession(startDate, endDate, title, category, pr, hours, minutes, type);
                    s.IsCompleted = done;
                    return s;
                }
                catch
                {
                    return null;
                }
            }

            // OLD FORMAT (6 fields) — backward compatibility
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
                    s.IsCompleted = false;
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
            return $"{Title} - {Category} - {Date:dd/MM/yyyy} → {EndDate:dd/MM/yyyy} - {Priority} - {EstimatedHours}h {EstimatedMinutes}m";
        }
    }
}
