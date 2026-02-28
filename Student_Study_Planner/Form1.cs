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
            LoadTasks(); // Load tasks when the form initializes
        }
        // Save tasks to a CSV file
        private void SaveTasks()
        {
            using (StreamWriter sw = new StreamWriter("tasks.csv"))
            {
                // Write the header (column names)
                sw.WriteLine("Title,Category,Date,Priority,Hours,Minutes");

                // Write each task as a CSV line
                foreach (var task in items)
                {
                    sw.WriteLine($"{task.Title},{task.Category},{task.Date.ToShortDateString()},{task.Priority},{task.Hours},{task.Minutes}");
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

                    var task = new StudySession(
                           DateTime.Parse(values[2]),    //  DateTime
                           DateTime.Parse(values[2]).AddHours(int.Parse(values[4])).AddMinutes(int.Parse(values[5])), // EndDate
                           values[0],                    // Title
                           values[1],                    // Category
                           (Priority)Enum.Parse(typeof(Priority), values[3]),  // Priority
                           int.Parse(values[4]),         // Hours
                           int.Parse(values[5]),         // Minutes
                           TaskType.StudySession         // TaskType
                     );

                    if (values.Length > 6)
                        task.IsCompleted = bool.Parse(values[6]);

                    items.Add(task);
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lblProgressValue_Click(object sender, EventArgs e)
        {

        }

        private void lblProgressStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblDeadLinesValue_Click(object sender, EventArgs e)
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
                MessageBox.Show("Search field cannot be empty.");
                txtSearch.BackColor = Color.LightPink;
                e.Cancel = true;
                return;
            }

            txtSearch.BackColor = Color.White;
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
            if (!ValidateChildren())
                return;

            string keyword = txtSearch.Text.Trim();
            List<PlannerItem> results = new List<PlannerItem>();

            // ---------- Priority (1-3) ----------
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
                    return;
                }
            }

            // ---------- Date ----------
            else if (DateTime.TryParse(keyword, out DateTime date))
            {
                results = items
                    .Where(i => i.Date.Date == date.Date)
                    .OrderBy(i => i.Date)
                    .ToList();
            }

            // ---------- Title OR Category ----------
            else
            {
                if (!keyword.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
                {
                    MessageBox.Show("Search cannot contain symbols.");
                    return;
                }

                results = items
                    .Where(i =>
                        i.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                        ||
                        i.Category.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                    )
                    .OrderBy(i => i.Date)
                    .ToList();
            }

            lvTasks.Items.Clear();

            if (results.Count == 0)
            {
                MessageBox.Show("No matching tasks found.");
                return;
            }

            foreach (var task in results)
            {
                string status = task.IsCompleted ? "Completed " : "Pending";
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
    }
}
    
    

