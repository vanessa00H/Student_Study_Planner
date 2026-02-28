using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Student_Study_Planner
{

    public partial class Form1 : Form
    {
        private bool isAdding = false;
        private bool isEditing = false;
        private bool isFiltering = false;
        private List<PlannerItem> items = new List<PlannerItem>();
        public Form1()
        {
            InitializeComponent();
           
            cmbFilter.SelectionChangeCommitted+=(s,e)=>ApplyFilter();
            LoadTasks(); // Load tasks when the form initializes
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
                (!rbLow.Checked && !rbMedium.Checked && !rbHigh.Checked) ||
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

            rbLow.Checked = false;
            rbMedium.Checked = false;
            rbHigh.Checked = false;

            numHours.Value = 1;
            numMinutes.Value = 0;

            StartDatePicker.Value = DateTime.Today;
        }

        // Get Selected Priority
        private Priority GetPriority()
        {
            if (rbLow.Checked) return Priority.Low;
            if (rbMedium.Checked) return Priority.Medium;
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


            if (lvTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            int index = lvTasks.SelectedItems[0].Index;

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
            ClearFields();
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

            CancelEventArgs fromArgs = new CancelEventArgs();
            dateTimePicker1_Validating(dateTimePicker1, fromArgs);

            CancelEventArgs toArgs = new CancelEventArgs();
            dateTimePicker2_Validating(dateTimePicker2, toArgs);

            if (fromArgs.Cancel || toArgs.Cancel)
                return;

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
                    $"{next.Title} - {next.Date.ToShortDateString()} ({when})";
            }

            // ---------- Weekly Goal ----------
            int weeklyGoal = 5; // change this number if you want (e.g., 10)

            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7);

            int doneThisWeek = items.Count(t =>
                t.IsCompleted &&
                t.Date >= startOfWeek &&
                t.Date < endOfWeek);

            lblGoalTitle.Text = $"WEEKLY GOAL\n{doneThisWeek}/{weeklyGoal}";
            lblGoalTitle.TextAlign = ContentAlignment.MiddleCenter;
            // -------------------------------

            lvDashboard.Items.Clear();

            var topTasks = items
                .Where(t => !t.IsCompleted)
                .OrderBy(t => t.Date)
                .Take(5)
                .ToList();

            foreach (var t in topTasks)
            {
                ListViewItem row = new ListViewItem(t.Title);
                row.SubItems.Add(t.Priority.ToString());
                row.SubItems.Add(t.Date.ToShortDateString());

                if (t.Date.Date < DateTime.Today)
                    row.ForeColor = Color.Red;

                lvDashboard.Items.Add(row);
            }
        }

        private void lblWeeklyGoal_Click(object sender, EventArgs e)
        {

        }
    }
}
    
    

