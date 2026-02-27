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

namespace Student_Study_Planner
{

    public partial class Form1 : Form
    {
        private List<PlannerItem> items = new List<PlannerItem>();
        public Form1()
        {
            InitializeComponent();
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            // Validate Title: Must not be empty
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.");
                return;
            }

            // Title must contain both letters and numbers, not just numbers
            if (txtTitle.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Title cannot contain only numbers.");
                return;
            }

            // Title must not contain symbols
            if (!txtTitle.Text.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Title cannot contain symbols.");
                return;
            }

            // Validate Category: Must not be empty
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Category is required.");
                return;
            }

            // Category must contain both letters and numbers, not just numbers
            if (txtCategory.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Category cannot be numbers only.");
                return;
            }

            // Category must not contain symbols
            if (!txtCategory.Text.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Category cannot contain symbols.");
                return;
            }

            // Validate Date (should not be in the past): Date must be today or in the future
            if (datePicker.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Date cannot be in the past.");
                return;
            }

            // Validate Estimated Time: Hours and Minutes must be valid numbers and greater than 0
            if (!int.TryParse(numHours.Text, out int hours) || hours <= 0)
            {
                MessageBox.Show("Hours must be a valid number and greater than 0.");
                return;
            }
            if(int.Parse(numHours.Text)<1||int.Parse(numHours.Text)>60)
            {
                MessageBox.Show("Hours must be between 1 and 60.");
                return;
            }

            if (!int.TryParse(numMinutes.Text, out int minutes) || minutes < 0 || minutes >= 60)
            {
                MessageBox.Show("Minutes must be a valid number between 0 and 59.");
                return;
            }

            // Validate Priority: Ensure user selects a priority
            if (!(rbLow.Checked || rbMedium.Checked || rbHigh.Checked))
            {
                MessageBox.Show("Please select a priority.");
                return;
            }

            // Create new task object based on the selected type
            PlannerItem task;

            if (cmbType.SelectedItem == null || string.IsNullOrWhiteSpace(cmbType.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a task type.");
                return;
            }

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
                    datePicker.Value.Date.AddDays(7), // Example of deadline
                    "Sample description",
                    TaskType.Assignment);
            }

            // Add task to list
            items.Add(task);

            MessageBox.Show("Task added successfully!");
            ClearFields();
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            txtCategory.Clear();
            cmbType.SelectedIndex = -1;
            rbLow.Checked = false;
            rbMedium.Checked = false;
            rbHigh.Checked = false;
            numHours.Text = " ";
            numMinutes.Text = " ";
            datePicker.Value = DateTime.Now;
        }

        // Get selected priority
        private Priority GetPriority()
        {
            if (rbLow.Checked) return Priority.Low;
            if (rbMedium.Checked) return Priority.Medium;
            return Priority.High;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Validate Title: Must not be empty
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.");
                return;
            }

            // Title must contain both letters and numbers, not just numbers
            if (txtTitle.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Title cannot contain only numbers.");
                return;
            }

            // Title must not contain symbols
            if (!txtTitle.Text.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Title cannot contain symbols.");
                return;
            }
            // Find task by title
            var task = items.FirstOrDefault(t => t.Title == txtTitle.Text.Trim());

            if (task == null)
            {
                MessageBox.Show("Task not found.");
                return;
            }

            // Validate Category: Must not be empty
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Category is required.");
                return;
            }

            // Category must contain both letters and numbers, not just numbers
            if (txtCategory.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Category cannot be numbers only.");
                return;
            }

            // Category must not contain symbols
            if (!txtCategory.Text.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Category cannot contain symbols.");
                return;
            }

            // Validate Date (should not be in the past): Date must be today or in the future
            if (datePicker.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Date cannot be in the past.");
                return;
            }

            // Validate Estimated Time: Hours and Minutes must be valid numbers and greater than 0
            if (!int.TryParse(numHours.Text, out int hours) || hours <= 0)
            {
                MessageBox.Show("Hours must be a valid number and greater than 0.");
                return;
            }
            if (int.Parse(numHours.Text) < 1 || int.Parse(numHours.Text) > 60)
            {
                MessageBox.Show("Hours must be between 1 and 60.");
                return;
            }

            if (!int.TryParse(numMinutes.Text, out int minutes) || minutes < 0 || minutes >= 60)
            {
                MessageBox.Show("Minutes must be a valid number between 0 and 59.");
                return;
            }

            // Validate Priority: Ensure user selects a priority
            if (!(rbLow.Checked || rbMedium.Checked || rbHigh.Checked))
            {
                MessageBox.Show("Please select a priority.");
                return;
            }

            if (cmbType.SelectedItem == null || string.IsNullOrWhiteSpace(cmbType.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a task type.");
                return;
            }
            // Update task properties with new values
            task.Category = txtCategory.Text.Trim();
            task.Date = datePicker.Value.Date;
            task.Priority = GetSelectedPriority(); // Updated function name here
            task.IsCompleted = false; // Reset completed status

            MessageBox.Show("Task updated successfully!");
            ClearAllFields(); // Renamed method to ClearAllFields
        }

        // Updated function name
        private Priority GetSelectedPriority()
        {
            if (rbLow.Checked) return Priority.Low;
            if (rbMedium.Checked) return Priority.Medium;
            return Priority.High;
        }

        // Renamed ClearFields method to ClearAllFields
        private void ClearAllFields()
        {
            txtTitle.Clear();
            txtCategory.Clear();
            cmbType.SelectedIndex = -1;
            rbLow.Checked = false;
            rbMedium.Checked = false;
            rbHigh.Checked = false;
            numHours.Text = " ";
            numMinutes.Text = " ";
            datePicker.Value = DateTime.Now;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Validate Title: Ensure Title is not empty
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter the title of the task to delete.");
                return;
            }

            // Title must contain both letters and numbers, not just numbers
            if (txtTitle.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Title cannot contain only numbers.");
                return;
            }

            // Title must not contain symbols
            if (!txtTitle.Text.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Title cannot contain symbols.");
                return;
            }

            // Find task by title
            var task = items.FirstOrDefault(t => t.Title == txtTitle.Text.Trim());

            if (task == null)
            {
                MessageBox.Show("Task not found.");
                return;
            }

            // Remove task from the list
            items.Remove(task);

            MessageBox.Show("Task deleted successfully!");
            ClearFields();  // Clear the input fields after deletion
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Clear all text fields
            txtTitle.Clear();
            txtCategory.Clear();

            // Reset ComboBox selection
            cmbType.SelectedIndex = -1;

            // Uncheck all radio buttons (Priority)
            rbLow.Checked = false;
            rbMedium.Checked = false;
            rbHigh.Checked = false;

            // Reset numeric up-down values (Estimated Time)
            numHours.Text = " ";
            numMinutes.Text = " ";

            // Reset DatePicker to today's date
            datePicker.Value = DateTime.Now;
        }
    }
    
}
