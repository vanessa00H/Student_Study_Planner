using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Student_Study_Planner
{

    public partial class Form1 : Form
    {
        private bool isAdding = false;
        private bool isEditing = false;
        private bool isFiltering = false;
        private List<PlannerItem> items = new List<PlannerItem>();
        private int weeklyGoalHours = 0; // Example weekly goal (can be made dynamic)
        private const string SettingsFile = "settings.txt"; // File to save settings like weekly goal
        private bool deadlineWarningsEnabled = false;
        private bool dailySummaryEnabled = false;
      
        public Form1()
        {
            InitializeComponent();
  
            LoadNotificationSettings();
            ApplyNotificationSettingsToUI();
            chkDeadlineWarnings.CheckedChanged += (s, e) => SaveNotificationSettings();
            chkDailySummary.CheckedChanged += (s, e) => SaveNotificationSettings();

            cmbFilter.SelectionChangeCommitted+=(s,e)=>ApplyFilter();

            LoadTasks(); // Load tasks when the form initializes
            InitializHome();
            UpdateStreak();
        }
        // Save tasks to a CSV file
        private void SaveTasks()
        {
            using (StreamWriter sw = new StreamWriter("tasks.csv"))
            {
                sw.WriteLine("Kind,Title,Category,Date,Priority,Hours,Minutes,IsCompleted,Type");

                foreach (var task in items)
                {
                    if (task is StudySession s)
                        sw.WriteLine(s.ToCSV());
                    else
                        sw.WriteLine($"DeadlineTask,{task.Title},{task.Category},{task.Date:dd/MM/yyyy},{task.Priority},0,0,{task.IsCompleted},{task.Type}");
                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTasks(); // Save tasks when the form is closing
        }

        // Load tasks from a CSV file
        private void LoadTasks()
        {
            items.Clear();
            lvTasks.Items.Clear();
            lvTasks.Columns[0].Width = 80;
            lvTasks.Columns[1].Width = 150;
            lvTasks.Columns[2].Width = 120;
            lvTasks.Columns[3].Width = 100;
            lvTasks.Columns[4].Width = 120;
            lvTasks.Columns[5].Width = 120;

            lvDashboard.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            if(File.Exists("goal.txt"))
            {
                string SavedGoal = File.ReadAllText("goal.txt");
                int.TryParse(SavedGoal, out weeklyGoalHours);
                weeklyGoalHours=(int)numWeeklyHours.Value;
            }

            if (File.Exists("tasks.csv"))
            {
                var lines = File.ReadAllLines("tasks.csv");

                foreach (var line in lines.Skip(1))
                {
                    var values = line.Split(',');
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    try
                    {
                        items.Add(StudySession.FromCSV(line));
                    }
                    catch { continue; }
                }
            }


            foreach (var task in items)
            {
                
                string status = task.IsCompleted ? "✔ " : "✖ ";
                ListViewItem item = new ListViewItem(status);
                item.SubItems.Add(task.Title);
                item.SubItems.Add(task.Category);
                item.SubItems.Add(task.Priority.ToString());
                item.SubItems.Add(task.Date.ToShortDateString());
                item.SubItems.Add(task.Type.ToString());
                lvTasks.Items.Add(item);
            }
            ApplyFilter(); // Apply filter after loading tasks
            UpdateDashboard();
            ShowStartupReminders();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            lvTasks.View = View.Details;
            lvTasks.FullRowSelect = true;
            lvTasks.GridLines = true;
            lvTasks.Scrollable = true;
            lvTasks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvDashboard.View = View.Details;
            lvDashboard.FullRowSelect = true;
            lvDashboard.GridLines = true;
            lvDashboard.Scrollable = true;
            lvDashboard.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (lvTasks.Columns.Count > 0)
            {
                int columnWidth = lvTasks.ClientSize.Width / lvTasks.Columns.Count;

                foreach (ColumnHeader col in lvTasks.Columns)
                {
                    col.Width = columnWidth;
                }
            }

            if (lvDashboard.Columns.Count > 0)
            {
                int columnWidth = lvDashboard.ClientSize.Width / lvDashboard.Columns.Count;

                foreach (ColumnHeader col in lvDashboard.Columns)
                {
                    col.Width = columnWidth;
                }
            }


        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void LblProgressValue_Click(object sender, EventArgs e)
        {

        }

        private void LblProgressStatus_Click(object sender, EventArgs e)
        {

        }

        private void LblDeadLinesValue_Click(object sender, EventArgs e)
        {

        }





        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (isFiltering) return; // Skip validation when filtering
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.");
                txtTitle.ForeColor = Color.Red;
                e.Cancel = true;
                return;
            }

            bool onlyNumbers = true;

            foreach (char c in txtTitle.Text)
            {
                if (!char.IsDigit(c) && !char.IsWhiteSpace(c))
                {
                    onlyNumbers = false;
                    break;
                }
            }

            if (onlyNumbers)
            {
                MessageBox.Show("Title cannot contain only numbers.");
                txtTitle.ForeColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                txtTitle.ForeColor = Color.Black;
            }
        }

        private void txtCategory_Validating(object sender, CancelEventArgs e)
        {
            if (isFiltering) return; // Skip validation when filtering
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Category is required.");
                txtCategory.ForeColor = Color.Red;
                e.Cancel = true;
                return;
            }

            bool onlyNumbers = true;

            foreach (char c in txtCategory.Text)
            {
                if (!char.IsDigit(c))
                {
                    onlyNumbers = false;
                    break;
                }
            }

            if (onlyNumbers)
            {
                MessageBox.Show("Category cannot be numbers only.");
                txtCategory.ForeColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                txtCategory.ForeColor = Color.Black;
            }
        }



        private void cmbType_Validating(object sender, CancelEventArgs e)
        {
            if (isFiltering) return; // Skip validation when filtering
            if (cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a task type.");
                cmbType.BackColor = Color.LightPink;
                e.Cancel = true;
            }
            else
            {
                cmbType.BackColor = Color.White;
            }
        }



        private void grpPriority_Validating(object sender, CancelEventArgs e)
        {
            if (isFiltering) return; // Skip validation when filtering
            if (!rbLow.Checked && !rbMedium.Checked && !rbHigh.Checked)
            {
                MessageBox.Show("Please select a priority.");
                grpPriority.BackColor = Color.MistyRose;
                e.Cancel = true;
            }
            else
            {
                grpPriority.BackColor = Color.Transparent;
            }
        }


        private void cmbFilter_Validating(object sender, CancelEventArgs e)
        {
            if (isAdding) return; // Skip validation when adding a new task
            if(isEditing) return; // Skip validation when editing a task
            ApplyFilter();
            if (cmbFilter.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a filter option.");
                cmbFilter.BackColor = Color.LightPink;
                e.Cancel = true;
            }
            else
            {
                cmbFilter.BackColor = Color.White;
                e.Cancel = false;
            }
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            if (isAdding) return; // Skip validation when adding a new task
            if(isEditing) return; // Skip validation when editing a task

            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                e.Cancel =false;
                return;
            }
            if(!txtSearch.Text.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Search cannot contain symbols.");
                txtSearch.ForeColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                txtSearch.ForeColor = Color.Black;
                e.Cancel = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdding = true;
            // Required Fields Check
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                cmbType.SelectedIndex == -1 ||
                (!r1.Checked && !r3.Checked && !r.Checked) ||
                (numHours.Value == 0 && numMinutes.Value == 0))
            {
                MessageBox.Show("Please fill all required fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check if EndDate is not in the past
            if (endDatePicker.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("End date cannot be in the past.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check if EndDate is the same as StartDate
            if (endDatePicker.Value.Date == StartDatePicker.Value.Date)
            {
                MessageBox.Show("End date cannot be the same as start date.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            // Check if EndDate is before StartDate
            if (endDatePicker.Value.Date < StartDatePicker.Value.Date)
            {
                MessageBox.Show("End date cannot be before start date.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            // Run All Field Validations
            if (!ValidateChildren()&&(cmbFilter.CausesValidation=false)&&(txtSearch.CausesValidation=false))
                return;

            // Get Time Values
            int hours = (int)numHours.Value;
            int minutes = (int)numMinutes.Value;

            // Create Task Object
            PlannerItem task;

            if (cmbType.SelectedItem.ToString() == "StudySession")
            {
                task = new StudySession(
                    StartDatePicker.Value.Date,
                    endDatePicker.Value.Date,
                    txtTitle.Text.Trim(),
                    txtCategory.Text.Trim(),
                    GetPriority(),
                    hours,
                    minutes,
                    TaskType.StudySession);

            }
            else
            {
                task = new DeadlineTask(
                    StartDatePicker.Value.Date,
                    endDatePicker.Value.Date,
                    txtTitle.Text.Trim(),
                    txtCategory.Text.Trim(),
                    GetPriority(),
                    StartDatePicker.Value.Date.AddDays(7), // Example deadline
                    "Sample description",
                    TaskType.Assignment);

            }

            // Add To List
            items.Add(task);
            isAdding = false;
            // Success Message
            MessageBox.Show("Task added successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Save + Refresh + Clear
            SaveTasks();
            LoadTasks();
            ClearFields();
        }
        // Clear All Fields
        private void ClearFields()
        {
            txtTitle.Clear();
            txtCategory.Clear();
            cmbType.SelectedIndex = -1;

            r1.Checked = false;
            r3.Checked = false;
            r.Checked = false;

            numHours.Value = 1;
            numMinutes.Value = 0;

            StartDatePicker.Value = DateTime.Today;
        }

        // Get Selected Priority
        private Priority GetPriority()
        {
            if (r1.Checked) return Priority.Low;
            if (r3.Checked) return Priority.Medium;
            return Priority.High;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditing = true;
            // Check if Title is provided
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter the task title to edit.");
                return;
            }

            // Run Validating Events
            if (!ValidateChildren())
                return;

            // Find task by title
            var task = items.FirstOrDefault(t =>
                t.Title.Equals(txtTitle.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                MessageBox.Show("Task not found.");
                return;
            }

            // Validate End Date: Ensure End Date is not in the past
            if (endDatePicker.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("End date cannot be in the past.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validate End Date: Ensure End Date is not the same as Start Date
            if (endDatePicker.Value.Date == StartDatePicker.Value.Date)
            {
                MessageBox.Show("End date cannot be the same as start date.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            // Check if EndDate is before StartDate
            if (endDatePicker.Value.Date < StartDatePicker.Value.Date)
            {
                MessageBox.Show("End date cannot be before start date.",
                    "Invalid Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Update Properties
            task.Category = txtCategory.Text.Trim();
            task.Date = StartDatePicker.Value.Date;
            task.Priority = GetPriority();
            task.IsCompleted = false;

            // Update EndDate for StudySession or DeadlineTask
            if (task is StudySession studyTask)
            {
                studyTask.EstimatedHours = (int)numHours.Value;
                studyTask.EstimatedMinutes = (int)numMinutes.Value;
                studyTask.EndDate = endDatePicker.Value.Date;  // Update EndDate
            }
            else if (task is DeadlineTask deadlineTask)
            {
                deadlineTask.EndDate = endDatePicker.Value.Date;  // Update EndDate
            }
            isEditing = false;
            MessageBox.Show("Task edit successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Save and Refresh Tasks
            SaveTasks();
            LoadTasks();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter the title of the task to delete.");
                return;
            }

            var task = items.FirstOrDefault(t =>
                t.Title.Equals(txtTitle.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                MessageBox.Show("Task not found.");
                return;
            }

            items.Remove(task);

            MessageBox.Show("Task deleted successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            SaveTasks();
            LoadTasks();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            isFiltering = true;

            string keyword = txtSearch.Text.Trim();

            // If search box is empty → apply the selected filter only
            if (string.IsNullOrWhiteSpace(keyword))
            {
                isFiltering = false;
                ApplyFilter();
                return;
            }

            // Validate only the search textbox (not the whole form)
            if (!keyword.All(c=>char.IsLetterOrDigit(c)||char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Search cannot contain symbols.");
                isFiltering = false;
                return;
            }

            List<PlannerItem> results = new List<PlannerItem>();

            // ---------- Search by Priority (1-3) ----------
            if (int.TryParse(keyword, out int number))
            {
                if (number >= 1 && number <= 3)
                {
                    results = items
                        .Where(i => (int)i.Priority == number)
                        .OrderBy(i => i.Date)
                        .ToList();
                }
                else
                {
                    MessageBox.Show("Priority must be 1 (Low), 2 (Medium), or 3 (High).");
                    isFiltering = false;
                    return;
                }
            }
            // ---------- Search by Date ----------
            else if (DateTime.TryParse(keyword, out DateTime date))
            {
                results = items
                    .Where(i => i.Date.Date == date.Date)
                    .OrderBy(i => i.Date)
                    .ToList();
            }
            // ---------- Search by Title or Category ----------
            else
            {
                // Prevent symbols in search input
                if (!keyword.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
                {
                    MessageBox.Show("Search cannot contain symbols.");
                    isFiltering = false;
                    return;
                }

                results = items
                    .Where(i =>
                        i.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        i.Category.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                    )
                    .OrderBy(i => i.Date)
                    .ToList();
            }

            lvTasks.Items.Clear();

            if (results.Count == 0)
            {
                MessageBox.Show("No matching tasks found.");
                isFiltering = false;
                return;
            }

            // Display search results in ListView
            foreach (var task in results)
            {
                string status = task.IsCompleted ? "Completed" : "Pending";

                ListViewItem item = new ListViewItem(status);
                item.SubItems.Add(task.Title);
                item.SubItems.Add(task.Category);
                item.SubItems.Add(task.Priority.ToString());
                item.SubItems.Add(task.Date.ToShortDateString());
                item.SubItems.Add(task.Type.ToString());

                lvTasks.Items.Add(item);
            }

            isFiltering = false;
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            if (items.Count == 0)
            {
                MessageBox.Show("No tasks available.");
                return;
            }


            if (lvTasks.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            int index = lvTasks.CheckedItems[0].Index;

            if (items[index].IsCompleted)
            {
                MessageBox.Show("Task is already completed.");
                return;
            }

            items[index].IsCompleted = true;

            MessageBox.Show("Task marked as completed successfully!");

            SaveTasks();
            LoadTasks();
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            {
                txtSearch.Clear();
                cmbFilter.SelectedIndex = -1;
      
            }
        }


        private void tabPage2_Resize(object sender, EventArgs e)
        {
            if (lvTasks.Columns.Count > 0)
            {
                int columnWidth = lvTasks.ClientSize.Width / lvTasks.Columns.Count;

                foreach (ColumnHeader col in lvTasks.Columns)
                {
                    col.Width = columnWidth;
                }
            }

            if (lvDashboard.Columns.Count > 0)
            {
                int columnWidth = lvDashboard.ClientSize.Width / lvDashboard.Columns.Count;

                foreach (ColumnHeader col in lvDashboard.Columns)
                {
                    col.Width = columnWidth;
                }
            }
        }

        private void dataGridViewReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgvReport = new DataGridView();
            dgvReport.Location = new Point(20, 130);
            dgvReport.Size = new Size(940, 480);

            // Properties
            dgvReport.RowHeadersVisible = false;
            dgvReport.AutoGenerateColumns = false;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.ReadOnly = true;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void StartDatePicker_Validating(object sender, CancelEventArgs e)
        {
            int currentYear = DateTime.Now.Year;

            if (StartDatePicker.Value.Year < currentYear || StartDatePicker.Value.Year > 2030)
            {
                MessageBox.Show($"Year must be between {currentYear} and 2030.");
                e.Cancel = true;
                return;
            }

            if (StartDatePicker.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Start date cannot be in the past.");
                e.Cancel = true;
                return;
            }

            if (endDatePicker.Value < StartDatePicker.Value)
            {
                MessageBox.Show("End date must be after start date.");
                e.Cancel = true;
            }
        }

        private void endDatePicker_Validating(object sender, CancelEventArgs e)
        {
            int currentYear = DateTime.Now.Year;

            if (endDatePicker.Value.Year < currentYear || endDatePicker.Value.Year > 2030)
            {
                MessageBox.Show($"Year must be between {currentYear} and 2030.");
                e.Cancel = true;
                return;
            }

            if (endDatePicker.Value < StartDatePicker.Value)
            {
                MessageBox.Show("End date must be after start date.");
                e.Cancel = true;
            }
        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            endDatePicker.MinDate = StartDatePicker.Value;
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            int currentYear = DateTime.Now.Year;

            if (dateTimePicker1.Value.Year < currentYear ||
                dateTimePicker1.Value.Year > 2030)
            {
                MessageBox.Show($"Year must be between {currentYear} and 2030.");
                e.Cancel = true;
                return;
            }
        }

        private void dateTimePicker2_Validating(object sender, CancelEventArgs e)
        {
            int currentYear = DateTime.Now.Year;

            if (dateTimePicker2.Value.Year < currentYear ||
                dateTimePicker2.Value.Year > 2030)
            {
                MessageBox.Show($"Year must be between {currentYear} and 2030.");
                e.Cancel = true;
                return;
            }

            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("To date cannot be before From date.");
                e.Cancel = true;
                return;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            // Get selected dates from DateTimePickers
            DateTime fromDate = dateTimePicker1.Value.Date;
            DateTime toDate = dateTimePicker2.Value.Date;

            // Validate date range
            if (toDate < fromDate)
            {
                MessageBox.Show("To date cannot be before From date.");
                return;
            }

            // Filter tasks within selected date range
            var filtered = items
                .Where(t => t.Date.Date >= fromDate && t.Date.Date <= toDate)
                .ToList();

            // If no tasks found in this period
            if (filtered.Count == 0)
            {
                MessageBox.Show("No tasks found in this period.");
                dataGridViewReport.Rows.Clear();
                return;
            }

            // Clear old report data
            dataGridViewReport.Rows.Clear();

            // Group tasks by Category
            dataGridViewReport.Rows.Clear();
            foreach (var t in filtered)
            {
                dataGridViewReport.Rows.Add(
                    t.Title,
                    t.Category,
                    t.IsCompleted ? 1 : 0,
                    t.IsCompleted ? 0 : 1,
                    t.IsCompleted ? "100%" : "0%"
                    );
            }
            MessageBox.Show("Report Generated Successfully!");
        }
        private void ApplyFilter()
        {
            if (items == null || items.Count == 0)
            {
                lvTasks.Items.Clear();
                return;
            }

            string filter = cmbFilter.Text;

            IEnumerable<PlannerItem> filtered = items;

            if (filter == "All Tasks")
            {
                filtered = items;
            }
            else if (filter == "Today")
            {
                filtered = items.Where(i => i.Date.Date == DateTime.Today);
            }
            else if (filter == "This Week")
            {
                var start = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                var end = start.AddDays(7);

                filtered = items.Where(i =>
                    i.Date.Date >= start.Date &&
                    i.Date.Date < end.Date);
            }
            else if (filter == "This Month")
            {
                var start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                var end = start.AddMonths(1);

                filtered = items.Where(i =>
                    i.Date.Date >= start.Date &&
                    i.Date.Date < end.Date);
            }
            else if (filter == "Completed")
            {
                filtered = items.Where(i => i.IsCompleted);
            }
            else if (filter == "Overdue")
            {
                filtered = items.Where(i =>
                    !i.IsCompleted &&
                    i.Date.Date < DateTime.Today);
            }

            // show results
            lvTasks.Items.Clear();

            foreach (var task in filtered.OrderBy(i => i.Date))
            {
                string status = task.IsCompleted ? "Completed" : "Pending";

                ListViewItem row = new ListViewItem(status);

                row.SubItems.Add(task.Title);
                row.SubItems.Add(task.Category);
                row.SubItems.Add(task.Priority.ToString());
                row.SubItems.Add(task.Date.ToShortDateString());
                row.SubItems.Add(task.GetType().Name);

                //RED: Highlight overdue tasks in red 
                if (!task.IsCompleted && task.Date.Date < DateTime.Today)
                {
                    row.ForeColor = Color.Red;
                }

                lvTasks.Items.Add(row);
            }

        }
        private void UpdateDashboard()
        {
            int total = items.Count;
            int completed = items.Count(t => t.IsCompleted);
            int pending = total - completed;
            int percent = (total == 0) ? 0 : (int)Math.Round((completed * 100.0) / total);

            lblProgressValue.Text = percent + "%";
            lblProgressStatus.Text = $"Completed: {completed} | Pending: {pending}";

            var next = items
                .Where(t => !t.IsCompleted)
                .OrderBy(t => t.Date)
                .FirstOrDefault();

            if (next == null)
            {
                lblDeadLinesValue.Text = "No upcoming tasks";
            }
            else
            {
                int daysLeft = (next.Date.Date - DateTime.Today).Days;

                string when =
                    daysLeft < 0 ? $"Overdue by {-daysLeft} day(s)" :
                    daysLeft == 0 ? "Due today" :
                    $"Due in {daysLeft} day(s)";

                lblDeadLinesValue.Text =
                    $"{next.Title}\n{next.Date.ToShortDateString()}\n({when})";
            }

            // ---------- Weekly Goal Section ----------

            // Read saved goal from file
            if (File.Exists("goal.txt"))
            {
                string savedGoal = File.ReadAllText("goal.txt");
                int.TryParse(savedGoal, out weeklyGoalHours);
            }

            // Get start and end of week (Sunday to Saturday)
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7);

            // Calculate completed study hours this week
            int hoursDone = items
                .Where(t => t.IsCompleted
                            && t.Date >= startOfWeek
                            && t.Date < endOfWeek
                            && t is StudySession)
                .Sum(t => ((StudySession)t).EstimatedHours);

            // Calculate completed minutes
            int minutesDone = items
                .Where(t => t.IsCompleted
                            && t.Date >= startOfWeek
                            && t.Date < endOfWeek
                            && t is StudySession)
                .Sum(t => ((StudySession)t).EstimatedMinutes);

            // Convert minutes into hours
            hoursDone += minutesDone / 60;
            int remainingMinutes = minutesDone % 60;

            // Calculate percentage
            double weeklyPercent = (weeklyGoalHours <= 0)
                ? 0
                : (hoursDone * 100.0) / weeklyGoalHours;

            // Show result in your ONLY label
            lblGoalTitle.Text = $"{hoursDone}h {remainingMinutes}m / {weeklyGoalHours}h";

            // Change color automatically
            if (weeklyGoalHours <= 0)
            {
                lblGoalTitle.ForeColor = Color.Gray;
            }
            else if (weeklyPercent >= 100)
            {
                lblGoalTitle.ForeColor = Color.Green;
            }
            else if (weeklyPercent >= 80)
            {
                lblGoalTitle.ForeColor = Color.Orange;
            }
            else
            {
                lblGoalTitle.ForeColor = Color.Red;
            }
            // -------------------------------

            lvDashboard.Items.Clear();

            var topTasks = items
             
                .OrderBy(t => t.Date)
                .Take(5)
                .ToList();

            foreach (var t in topTasks)
            {
                ListViewItem row = new ListViewItem(t.Title);
                row.SubItems.Add(t.Priority.ToString());
                row.SubItems.Add(t.Date.ToShortDateString());
                row.SubItems.Add(t.IsCompleted? "Completed" : "Pending");

                if (t.Date.Date < DateTime.Today)
                    row.ForeColor = Color.Red;

                lvDashboard.Items.Add(row);
            }
        }

        private void lblWeeklyGoal_Click(object sender, EventArgs e)
        {

        }

        private void pnlDeadlines_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            weeklyGoalHours= (int)numWeeklyHours.Value;
            if(weeklyGoalHours <= 0)
            {
                MessageBox.Show("Please enter a Valid number for weekly goal hours.");
                return;
            }
            File.WriteAllText("goal.txt", weeklyGoalHours.ToString());
            UpdateDashboard();
    
            MessageBox.Show($"Weekly goal set to {weeklyGoalHours} hours!");
        }
        // Load saved notification settings from file
        private void LoadNotificationSettings()
        {
            deadlineWarningsEnabled = false;
            dailySummaryEnabled = false;

            if (!File.Exists(SettingsFile))
                return;

            foreach (var line in File.ReadAllLines(SettingsFile))
            {
                var parts = line.Split('=');
                if (parts.Length != 2) continue;

                string key = parts[0].Trim();
                string val = parts[1].Trim();

                bool isOn = val.Equals("true", StringComparison.OrdinalIgnoreCase);

                if (key == "deadlineWarnings") deadlineWarningsEnabled = isOn;
                if (key == "dailySummary") dailySummaryEnabled = isOn;
            }
        }

        // Save notification settings to file
        private void SaveNotificationSettings()
        {
            var lines = new List<string>
    {
        $"deadlineWarnings={chkDeadlineWarnings.Checked}",
        $"dailySummary={chkDailySummary.Checked}"
    };

            File.WriteAllLines(SettingsFile, lines);
        }

        // Sync UI checkboxes from loaded flags
        private void ApplyNotificationSettingsToUI()
        {
            chkDeadlineWarnings.Checked = deadlineWarningsEnabled;
            chkDailySummary.Checked = dailySummaryEnabled;
        }

        // Show reminders automatically on app start
        private void ShowStartupReminders()
        {
            DateTime today = DateTime.Today;

            // =========================
            // 1️⃣ Deadline Warning Window
            // =========================
            if (chkDeadlineWarnings.Checked)
            {
               var dueSoon=items
                    .Where(t=>!t.IsCompleted)
                    .Where(t=>
                    {
                        int daysLeft = (t.EndDate.Date - DateTime.Today).Days;
                        return daysLeft >= 0 && daysLeft <= 3;
                    })
                    .OrderBy(t=>t.EndDate)
                    .ToList();

                if (dueSoon.Count > 0)
                {
                    string msg = "⚠ Deadline Warning (3 days before)\n\n";

                    foreach (var t in dueSoon)
                        msg += $"- {t.Title} ({t.Date:dd/MM/yyyy})\n";

                    MessageBox.Show(
                        msg,
                        "Deadline Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            // =========================
            // 2️⃣ Daily Summary Window
            // =========================
            if (chkDailySummary.Checked)
            {
                int totalToday = items.Count(t => t.Date.Date == today);
                int completedToday = items.Count(t => t.Date.Date == today && t.IsCompleted);
                int pendingToday = totalToday - completedToday;
                int overdue = items.Count(t => !t.IsCompleted && t.Date.Date < today);

                string msg =
                    $"📊 Daily Summary ({today:dd/MM/yyyy})\n\n" +
                    $"Today tasks: {totalToday}\n" +
                    $"Completed: {completedToday}\n" +
                    $"Pending: {pendingToday}\n\n" +
                    $"Overdue (all): {overdue}";

                MessageBox.Show(
                    msg,
                    "Daily Summary",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
         "Are you sure you want to delete ALL tasks?",
         "Warning",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // Clear list
                items.Clear();

                // Delete tasks file
                if (File.Exists("tasks.csv"))
                    File.Delete("tasks.csv");

                // Refresh UI
                LoadTasks();

                MessageBox.Show("All tasks deleted successfully!",
                                "Cleared",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
        

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            // Save tasks to CSV
            SaveTasks();

            // Save weekly goal
            File.WriteAllText("goal.txt", weeklyGoalHours.ToString());

            // Save notification settings
            SaveNotificationSettings();

            MessageBox.Show("All data saved successfully!",
                            "Saved",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            // Close the application
            Application.Exit();
        }
        private void InitializHome()
        {
            // Show one random motivational message on home tab
            ShowRandomMotivation();
            
        }

        private void lblMinutes_Click(object sender, EventArgs e)
        {

        }
        // =============================
        // Show one random motivational message
        // =============================
        private void ShowRandomMotivation()
        {
            string[] messages =
            {
        "Small steps every day = big results 💪",
        "Discipline beats motivation. Keep going 🔥",
        "Finish today strong. Your future self is watching 👀",
        "One task now is better than ten later 🚀",
        "Progress > Perfection. Just move forward 🎯"
    };

            Random rnd = new Random();
            string selected = messages[rnd.Next(messages.Length)];

            // IMPORTANT: change this to your actual label name
            lblMotivationText.Text = selected;

            lblMotivationText.AutoSize = false;
            lblMotivationText.Visible = true;
            lblMotivationText.BringToFront();
        }

        private void lblMotivationTitle_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
      
        private void UpdateStreak()
        {
            int streak = 0;
            DateTime checkDate = DateTime.Now.Date;

           
            while (checkDate >= DateTime.Now.AddMonths(-3))
            {
                var dayTasks = items
                    .Where(i => i.Date.Date == checkDate)
                    .ToList();

                if (dayTasks.Count > 0 && dayTasks.All(t => t.IsCompleted))
                {
                    streak++;
                    checkDate = checkDate.AddDays(-1);
                }
                else if (dayTasks.Count > 0)
                {
                    break;
                }
                else
                {
                    checkDate = checkDate.AddDays(-1);
                }
            }

            
            var todayTasks = items
                .Where(i => i.Date.Date == DateTime.Now.Date)
                .ToList();

            bool todayCompleted =
                todayTasks.Count > 0 &&
                todayTasks.All(t => t.IsCompleted);

            

            if (streak == 0 && !todayCompleted)
            {
                lblStreak.Text =
                    "💔 STREAK LOST" + Environment.NewLine +
                    Environment.NewLine +
                    "Start again today 🔥" + Environment.NewLine +
                    "You can do it!";
                Console.Beep(900,150);
                Console.Beep(700, 200);
                Console.Beep(500,300);
            }
            else if (streak == 0 && todayCompleted)
            {
                lblStreak.Text =
                    "🔥 DAY 1 STARTED!" + Environment.NewLine +
                    Environment.NewLine +
                    "Keep it going 💪";
                Console.Beep(700, 120);
                Console.Beep(900, 120);
                Console.Beep(1100, 150);
            }
            else
            {
                lblStreak.Text =
                    "🔥 STREAK 🔥" + Environment.NewLine +
                    Environment.NewLine +
                    streak + " Days" + Environment.NewLine +
                    Environment.NewLine +
                    "You’re on fire 🚀";
                Console.Beep(900, 100);
                Console.Beep(1100, 100);
                Console.Beep(1300, 120);
                Console.Beep(1500, 180);
            }

        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbLow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numMinutes_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
    
 