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
            if (File.Exists("tasks.csv"))
            {
                var lines = File.ReadAllLines("tasks.csv");

                // Skip header line
                foreach (var line in lines.Skip(1))
                {
                    var values = line.Split(',');

                        var task = new StudySession(
                               DateTime.Parse(values[2]),    //  DateTime
                               values[0],                    // Title
                               values[1],                    // Category
                               (Priority)Enum.Parse(typeof(Priority), values[3]),  // Priority
                               int.Parse(values[4]),         // Hours
                               int.Parse(values[5]),         // Minutes
                               TaskType.StudySession         // TaskType
                         );

                            items.Add(task);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void datePicker_Validating(object sender, CancelEventArgs e)
        {
            int currentYear = DateTime.Now.Year;

            if (datePicker.Value.Year < currentYear || datePicker.Value.Year > 2030)
            {
                MessageBox.Show($"Year must be between {currentYear} and 2030.");
                e.Cancel = true;
                return;
            }

            if (datePicker.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Date cannot be in the past.");
                e.Cancel = true;
            }
        }

        private void cmbType_Validating(object sender, CancelEventArgs e)
        {
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

        private void numHours_Validating(object sender, CancelEventArgs e)
        {
            if (numHours.Value < 1 || numHours.Value > 24)
            {
                MessageBox.Show("Hours must be between 1 and 24.");
                numHours.ForeColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                numHours.ForeColor = Color.Black;
            }

        }

        private void numMinutes_Validating(object sender, CancelEventArgs e)
        {
            if (numMinutes.Value < 0 || numMinutes.Value > 59)
            {
                MessageBox.Show("Minutes must be between 0 and 59.");
                numMinutes.ForeColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                numMinutes.ForeColor = Color.Black;
            }
        }

        private void cmbFilter_Validating(object sender, CancelEventArgs e)
        {
            if (cmbFilter.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a filter option.");
                cmbFilter.BackColor = Color.LightPink;
                e.Cancel = true; 
            }
            else
            {
                cmbFilter.BackColor = Color.White;
            }
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          
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

            // Run All Field Validations
           
            if (!ValidateChildren())
                return;

            // Get Time Values
           
            int hours = (int)numHours.Value;
            int minutes = (int)numMinutes.Value;

            // Create Task Object
          
            PlannerItem task;

            if (cmbType.SelectedItem.ToString() == "StudySession")
            {
                task = new StudySession(
                    datePicker.Value.Date,
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
                    datePicker.Value.Date,
                    txtTitle.Text.Trim(),
                    txtCategory.Text.Trim(),
                    GetPriority(),
                    datePicker.Value.Date.AddDays(7), // Example deadline
                    "Sample description",
                    TaskType.Assignment);
            }

            // Add To List
            
            items.Add(task);

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

            numHours.Value = 0;
            numMinutes.Value = 0;

            datePicker.Value = DateTime.Today;
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
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter the task title to edit.");
                return;
            }

            // Run Validating Events
            if (!ValidateChildren())
                return;

            var task = items.FirstOrDefault(t =>
                t.Title.Equals(txtTitle.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                MessageBox.Show("Task not found.");
                return;
            }

            // Update Properties
            task.Category = txtCategory.Text.Trim();
            task.Date = datePicker.Value.Date;
            task.Priority = GetPriority();
            task.IsCompleted = false;

            if (task is StudySession studyTask)
            {
                studyTask.EstimatedHours = (int)numHours.Value;
                studyTask.EstimatedMinutes = (int)numMinutes.Value;
            }

            MessageBox.Show("Task edit successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

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
    }
}
    
    

