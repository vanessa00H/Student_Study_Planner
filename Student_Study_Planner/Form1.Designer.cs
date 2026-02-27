namespace Student_Study_Planner
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.MainTap = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpPriority = new System.Windows.Forms.GroupBox();
            this.rbLow = new System.Windows.Forms.RadioButton();
            this.rbMedium = new System.Windows.Forms.RadioButton();
            this.rbHigh = new System.Windows.Forms.RadioButton();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblEstimatedTime = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear2 = new System.Windows.Forms.Button();
            this.btnMark = new System.Windows.Forms.Button();
            this.lvTasks = new System.Windows.Forms.ListView();
            this.clmStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.lvDashboard = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGoalStatus = new System.Windows.Forms.Label();
            this.lblGoalTitle = new System.Windows.Forms.Label();
            this.lblWeeklyGoal = new System.Windows.Forms.Label();
            this.cardDeadlines = new System.Windows.Forms.Panel();
            this.lblDeadlinesStatus = new System.Windows.Forms.Label();
            this.lblDeadLinesValue = new System.Windows.Forms.Label();
            this.lblDeadlineTitle = new System.Windows.Forms.Label();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.lblProgressValue = new System.Windows.Forms.Label();
            this.lblProgressTitle = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.MainTap.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpPriority.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.cardDeadlines.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(28, 84);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "AddTask";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(365, 84);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reports";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(199, 84);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 48);
            this.button3.TabIndex = 2;
            this.button3.Text = "ViewTask";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(502, 86);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 48);
            this.button4.TabIndex = 3;
            this.button4.Text = "DeleteTask";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(680, 86);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 48);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // MainTap
            // 
            this.MainTap.Controls.Add(this.tabPage1);
            this.MainTap.Controls.Add(this.tabPage2);
            this.MainTap.Controls.Add(this.tabPage3);
            this.MainTap.Controls.Add(this.tabPage4);
            this.MainTap.Controls.Add(this.tabPage5);
            this.MainTap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTap.Location = new System.Drawing.Point(0, 0);
            this.MainTap.Margin = new System.Windows.Forms.Padding(2);
            this.MainTap.Name = "MainTap";
            this.MainTap.SelectedIndex = 0;
            this.MainTap.Size = new System.Drawing.Size(1096, 798);
            this.MainTap.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.numHours);
            this.tabPage1.Controls.Add(this.numMinutes);
            this.tabPage1.Controls.Add(this.grpPriority);
            this.tabPage1.Controls.Add(this.datePicker);
            this.tabPage1.Controls.Add(this.btnEdit);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.cmbType);
            this.tabPage1.Controls.Add(this.lblType);
            this.tabPage1.Controls.Add(this.lblMinutes);
            this.tabPage1.Controls.Add(this.txtCategory);
            this.tabPage1.Controls.Add(this.txtTitle);
            this.tabPage1.Controls.Add(this.lblTitle);
            this.tabPage1.Controls.Add(this.lblDate);
            this.tabPage1.Controls.Add(this.lblHours);
            this.tabPage1.Controls.Add(this.lblCategory);
            this.tabPage1.Controls.Add(this.lblEstimatedTime);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1088, 766);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AddTask";
            // 
            // grpPriority
            // 
            this.grpPriority.Controls.Add(this.rbLow);
            this.grpPriority.Controls.Add(this.rbMedium);
            this.grpPriority.Controls.Add(this.rbHigh);
            this.grpPriority.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPriority.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpPriority.Location = new System.Drawing.Point(57, 332);
            this.grpPriority.Name = "grpPriority";
            this.grpPriority.Size = new System.Drawing.Size(348, 96);
            this.grpPriority.TabIndex = 22;
            this.grpPriority.TabStop = false;
            this.grpPriority.Text = "Priority";
            this.grpPriority.Validating += new System.ComponentModel.CancelEventHandler(this.grpPriority_Validating);
            // 
            // rbLow
            // 
            this.rbLow.AutoSize = true;
            this.rbLow.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLow.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbLow.Location = new System.Drawing.Point(17, 25);
            this.rbLow.Margin = new System.Windows.Forms.Padding(2);
            this.rbLow.Name = "rbLow";
            this.rbLow.Size = new System.Drawing.Size(69, 29);
            this.rbLow.TabIndex = 9;
            this.rbLow.TabStop = true;
            this.rbLow.Text = "Low";
            this.rbLow.UseVisualStyleBackColor = true;
            // 
            // rbMedium
            // 
            this.rbMedium.AutoSize = true;
            this.rbMedium.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMedium.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbMedium.Location = new System.Drawing.Point(109, 25);
            this.rbMedium.Margin = new System.Windows.Forms.Padding(2);
            this.rbMedium.Name = "rbMedium";
            this.rbMedium.Size = new System.Drawing.Size(103, 29);
            this.rbMedium.TabIndex = 10;
            this.rbMedium.TabStop = true;
            this.rbMedium.Text = "Medium";
            this.rbMedium.UseVisualStyleBackColor = true;
            // 
            // rbHigh
            // 
            this.rbHigh.AutoSize = true;
            this.rbHigh.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHigh.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbHigh.Location = new System.Drawing.Point(237, 25);
            this.rbHigh.Margin = new System.Windows.Forms.Padding(2);
            this.rbHigh.Name = "rbHigh";
            this.rbHigh.Size = new System.Drawing.Size(75, 29);
            this.rbHigh.TabIndex = 11;
            this.rbHigh.TabStop = true;
            this.rbHigh.Text = "High";
            this.rbHigh.UseVisualStyleBackColor = true;
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(135, 193);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(251, 27);
            this.datePicker.TabIndex = 21;
            this.datePicker.Validating += new System.ComponentModel.CancelEventHandler(this.datePicker_Validating);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnEdit.Location = new System.Drawing.Point(279, 553);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(126, 56);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "EditTask";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Symbol", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnDelete.Location = new System.Drawing.Point(526, 553);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 56);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "DeleteTask";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkGray;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Symbol", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(802, 553);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(126, 56);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Symbol", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(49, 554);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 56);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "AddTask";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "StudySession",
            "Assignment",
            "Quiz",
            "Exam"});
            this.cmbType.Location = new System.Drawing.Point(617, 186);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(292, 40);
            this.cmbType.TabIndex = 16;
            this.cmbType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbType_Validating);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(489, 186);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(76, 32);
            this.lblType.TabIndex = 15;
            this.lblType.Text = "Type:";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Segoe UI Symbol", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblMinutes.Location = new System.Drawing.Point(699, 382);
            this.lblMinutes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(87, 30);
            this.lblMinutes.TabIndex = 14;
            this.lblMinutes.Text = "minutes";
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(617, 69);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(2);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(292, 39);
            this.txtCategory.TabIndex = 8;
            this.txtCategory.Validating += new System.ComponentModel.CancelEventHandler(this.txtCategory_Validating);
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(135, 69);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(251, 39);
            this.txtTitle.TabIndex = 6;
            this.txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtTitle_Validating);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(51, 69);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(71, 32);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Title:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(51, 192);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(74, 32);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Segoe UI Symbol", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblHours.Location = new System.Drawing.Point(500, 382);
            this.lblHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(65, 30);
            this.lblHours.TabIndex = 3;
            this.lblHours.Text = "hours";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(489, 69);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(124, 32);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category:";
            // 
            // lblEstimatedTime
            // 
            this.lblEstimatedTime.AutoSize = true;
            this.lblEstimatedTime.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedTime.Location = new System.Drawing.Point(489, 332);
            this.lblEstimatedTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstimatedTime.Name = "lblEstimatedTime";
            this.lblEstimatedTime.Size = new System.Drawing.Size(198, 32);
            this.lblEstimatedTime.TabIndex = 0;
            this.lblEstimatedTime.Text = "Estimated Time:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.btnClear2);
            this.tabPage2.Controls.Add(this.btnMark);
            this.tabPage2.Controls.Add(this.lvTasks);
            this.tabPage2.Controls.Add(this.lblSearch);
            this.tabPage2.Controls.Add(this.cmbFilter);
            this.tabPage2.Controls.Add(this.txtSearch);
            this.tabPage2.Controls.Add(this.lblFilter);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1088, 766);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ViewTask";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnSearch.Location = new System.Drawing.Point(920, 60);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 36);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnClear2
            // 
            this.btnClear2.BackColor = System.Drawing.Color.DarkGray;
            this.btnClear2.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnClear2.Location = new System.Drawing.Point(316, 671);
            this.btnClear2.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Size = new System.Drawing.Size(190, 48);
            this.btnClear2.TabIndex = 6;
            this.btnClear2.Text = "Clear";
            this.btnClear2.UseVisualStyleBackColor = false;
            // 
            // btnMark
            // 
            this.btnMark.BackColor = System.Drawing.Color.LimeGreen;
            this.btnMark.Font = new System.Drawing.Font("Segoe UI Symbol", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMark.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnMark.Location = new System.Drawing.Point(60, 671);
            this.btnMark.Margin = new System.Windows.Forms.Padding(2);
            this.btnMark.Name = "btnMark";
            this.btnMark.Size = new System.Drawing.Size(190, 48);
            this.btnMark.TabIndex = 5;
            this.btnMark.Text = "MarkTaskComleted";
            this.btnMark.UseVisualStyleBackColor = false;
            // 
            // lvTasks
            // 
            this.lvTasks.CheckBoxes = true;
            this.lvTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmStatus,
            this.clmTitle,
            this.clmCategory,
            this.clmPriority,
            this.clmTime,
            this.clmType});
            this.lvTasks.FullRowSelect = true;
            this.lvTasks.GridLines = true;
            this.lvTasks.HideSelection = false;
            this.lvTasks.Location = new System.Drawing.Point(52, 158);
            this.lvTasks.Margin = new System.Windows.Forms.Padding(2);
            this.lvTasks.Name = "lvTasks";
            this.lvTasks.Size = new System.Drawing.Size(973, 465);
            this.lvTasks.TabIndex = 4;
            this.lvTasks.UseCompatibleStateImageBehavior = false;
            this.lvTasks.View = System.Windows.Forms.View.Details;
            // 
            // clmStatus
            // 
            this.clmStatus.Text = "Status";
            this.clmStatus.Width = 150;
            // 
            // clmTitle
            // 
            this.clmTitle.Text = "Title";
            this.clmTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmTitle.Width = 250;
            // 
            // clmCategory
            // 
            this.clmCategory.Text = "Category";
            this.clmCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmCategory.Width = 250;
            // 
            // clmPriority
            // 
            this.clmPriority.Text = "Priority";
            this.clmPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmPriority.Width = 200;
            // 
            // clmTime
            // 
            this.clmTime.Text = "Time";
            this.clmTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmTime.Width = 200;
            // 
            // clmType
            // 
            this.clmType.Text = "Type";
            this.clmType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmType.Width = 250;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(550, 58);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(97, 32);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search:";
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "All Tasks",
            "Today",
            "This Week",
            "This Month",
            "Completed"});
            this.cmbFilter.Location = new System.Drawing.Point(142, 63);
            this.cmbFilter.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(180, 27);
            this.cmbFilter.TabIndex = 2;
            this.cmbFilter.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFilter_Validating);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(650, 57);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 39);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Validating += new System.ComponentModel.CancelEventHandler(this.txtSearch_Validating);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(64, 54);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(79, 32);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter:";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(1088, 766);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reports";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lblDashboard);
            this.tabPage4.Controls.Add(this.lvDashboard);
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.Controls.Add(this.cardDeadlines);
            this.tabPage4.Controls.Add(this.pnlProgress);
            this.tabPage4.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(1088, 766);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Dashboard";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI Symbol", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.Location = new System.Drawing.Point(449, 28);
            this.lblDashboard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(160, 38);
            this.lblDashboard.TabIndex = 4;
            this.lblDashboard.Text = "Dashboard";
            // 
            // lvDashboard
            // 
            this.lvDashboard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvDashboard.FullRowSelect = true;
            this.lvDashboard.GridLines = true;
            this.lvDashboard.HideSelection = false;
            this.lvDashboard.Location = new System.Drawing.Point(72, 309);
            this.lvDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.lvDashboard.Name = "lvDashboard";
            this.lvDashboard.Size = new System.Drawing.Size(935, 286);
            this.lvDashboard.TabIndex = 3;
            this.lvDashboard.UseCompatibleStateImageBehavior = false;
            this.lvDashboard.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 330;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Priority";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "DueDate";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 310;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 300;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblGoalStatus);
            this.panel3.Controls.Add(this.lblGoalTitle);
            this.panel3.Controls.Add(this.lblWeeklyGoal);
            this.panel3.Location = new System.Drawing.Point(814, 106);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(192, 140);
            this.panel3.TabIndex = 2;
            // 
            // lblGoalStatus
            // 
            this.lblGoalStatus.AutoSize = true;
            this.lblGoalStatus.Font = new System.Drawing.Font("Segoe UI Symbol", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblGoalStatus.Location = new System.Drawing.Point(15, 101);
            this.lblGoalStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGoalStatus.Name = "lblGoalStatus";
            this.lblGoalStatus.Size = new System.Drawing.Size(25, 30);
            this.lblGoalStatus.TabIndex = 2;
            this.lblGoalStatus.Text = "  ";
            // 
            // lblGoalTitle
            // 
            this.lblGoalTitle.AutoSize = true;
            this.lblGoalTitle.Font = new System.Drawing.Font("Segoe UI Symbol", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalTitle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblGoalTitle.Location = new System.Drawing.Point(27, 55);
            this.lblGoalTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGoalTitle.Name = "lblGoalTitle";
            this.lblGoalTitle.Size = new System.Drawing.Size(20, 30);
            this.lblGoalTitle.TabIndex = 1;
            this.lblGoalTitle.Text = " ";
            // 
            // lblWeeklyGoal
            // 
            this.lblWeeklyGoal.AutoSize = true;
            this.lblWeeklyGoal.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeeklyGoal.ForeColor = System.Drawing.Color.Gray;
            this.lblWeeklyGoal.Location = new System.Drawing.Point(4, 16);
            this.lblWeeklyGoal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWeeklyGoal.Name = "lblWeeklyGoal";
            this.lblWeeklyGoal.Size = new System.Drawing.Size(121, 25);
            this.lblWeeklyGoal.TabIndex = 0;
            this.lblWeeklyGoal.Text = "WEEKLYGOAL";
            // 
            // cardDeadlines
            // 
            this.cardDeadlines.BackColor = System.Drawing.Color.Transparent;
            this.cardDeadlines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardDeadlines.Controls.Add(this.lblDeadlinesStatus);
            this.cardDeadlines.Controls.Add(this.lblDeadLinesValue);
            this.cardDeadlines.Controls.Add(this.lblDeadlineTitle);
            this.cardDeadlines.Location = new System.Drawing.Point(435, 106);
            this.cardDeadlines.Margin = new System.Windows.Forms.Padding(2);
            this.cardDeadlines.Name = "cardDeadlines";
            this.cardDeadlines.Size = new System.Drawing.Size(192, 140);
            this.cardDeadlines.TabIndex = 1;
            // 
            // lblDeadlinesStatus
            // 
            this.lblDeadlinesStatus.AutoSize = true;
            this.lblDeadlinesStatus.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeadlinesStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblDeadlinesStatus.Location = new System.Drawing.Point(16, 101);
            this.lblDeadlinesStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeadlinesStatus.Name = "lblDeadlinesStatus";
            this.lblDeadlinesStatus.Size = new System.Drawing.Size(22, 25);
            this.lblDeadlinesStatus.TabIndex = 2;
            this.lblDeadlinesStatus.Text = "  ";
            // 
            // lblDeadLinesValue
            // 
            this.lblDeadLinesValue.AutoSize = true;
            this.lblDeadLinesValue.Font = new System.Drawing.Font("Segoe UI Symbol", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeadLinesValue.ForeColor = System.Drawing.Color.Orange;
            this.lblDeadLinesValue.Location = new System.Drawing.Point(27, 59);
            this.lblDeadLinesValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeadLinesValue.Name = "lblDeadLinesValue";
            this.lblDeadLinesValue.Size = new System.Drawing.Size(27, 30);
            this.lblDeadLinesValue.TabIndex = 1;
            this.lblDeadLinesValue.Text = "  ";
            this.lblDeadLinesValue.Click += new System.EventHandler(this.lblDeadLinesValue_Click);
            // 
            // lblDeadlineTitle
            // 
            this.lblDeadlineTitle.AutoSize = true;
            this.lblDeadlineTitle.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeadlineTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblDeadlineTitle.Location = new System.Drawing.Point(3, 16);
            this.lblDeadlineTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeadlineTitle.Name = "lblDeadlineTitle";
            this.lblDeadlineTitle.Size = new System.Drawing.Size(94, 25);
            this.lblDeadlineTitle.TabIndex = 0;
            this.lblDeadlineTitle.Text = "DEADLINE";
            // 
            // pnlProgress
            // 
            this.pnlProgress.BackColor = System.Drawing.Color.Transparent;
            this.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProgress.Controls.Add(this.lblProgressStatus);
            this.pnlProgress.Controls.Add(this.lblProgressValue);
            this.pnlProgress.Controls.Add(this.lblProgressTitle);
            this.pnlProgress.Location = new System.Drawing.Point(72, 106);
            this.pnlProgress.Margin = new System.Windows.Forms.Padding(2);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(192, 140);
            this.pnlProgress.TabIndex = 0;
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.AutoSize = true;
            this.lblProgressStatus.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblProgressStatus.Location = new System.Drawing.Point(20, 101);
            this.lblProgressStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(22, 25);
            this.lblProgressStatus.TabIndex = 2;
            this.lblProgressStatus.Text = "  ";
            this.lblProgressStatus.Click += new System.EventHandler(this.lblProgressStatus_Click);
            // 
            // lblProgressValue
            // 
            this.lblProgressValue.AutoSize = true;
            this.lblProgressValue.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressValue.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblProgressValue.Location = new System.Drawing.Point(27, 55);
            this.lblProgressValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgressValue.Name = "lblProgressValue";
            this.lblProgressValue.Size = new System.Drawing.Size(30, 32);
            this.lblProgressValue.TabIndex = 1;
            this.lblProgressValue.Text = "  ";
            this.lblProgressValue.Click += new System.EventHandler(this.lblProgressValue_Click);
            // 
            // lblProgressTitle
            // 
            this.lblProgressTitle.AutoSize = true;
            this.lblProgressTitle.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblProgressTitle.Location = new System.Drawing.Point(11, 16);
            this.lblProgressTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgressTitle.Name = "lblProgressTitle";
            this.lblProgressTitle.Size = new System.Drawing.Size(99, 25);
            this.lblProgressTitle.TabIndex = 0;
            this.lblProgressTitle.Text = "PROGRESS";
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 28);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage5.Size = new System.Drawing.Size(1088, 766);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Setting";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // numMinutes
            // 
            this.numMinutes.Location = new System.Drawing.Point(789, 387);
            this.numMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(120, 27);
            this.numMinutes.TabIndex = 23;
            this.numMinutes.Validating += new System.ComponentModel.CancelEventHandler(this.numMinutes_Validating);
            // 
            // numHours
            // 
            this.numHours.Location = new System.Drawing.Point(567, 387);
            this.numHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(120, 27);
            this.numHours.TabIndex = 24;
            this.numHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHours.Validating += new System.ComponentModel.CancelEventHandler(this.numHours_Validating);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 798);
            this.Controls.Add(this.MainTap);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainTap.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpPriority.ResumeLayout(false);
            this.grpPriority.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.cardDeadlines.ResumeLayout(false);
            this.cardDeadlines.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabControl MainTap;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblEstimatedTime;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.RadioButton rbHigh;
        private System.Windows.Forms.RadioButton rbMedium;
        private System.Windows.Forms.RadioButton rbLow;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ListView lvTasks;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ColumnHeader clmStatus;
        private System.Windows.Forms.ColumnHeader clmTitle;
        private System.Windows.Forms.ColumnHeader clmCategory;
        private System.Windows.Forms.ColumnHeader clmPriority;
        private System.Windows.Forms.ColumnHeader clmTime;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.Button btnClear2;
        private System.Windows.Forms.Button btnMark;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel cardDeadlines;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblDeadlineTitle;
        private System.Windows.Forms.Label lblProgressValue;
        private System.Windows.Forms.Label lblProgressTitle;
        private System.Windows.Forms.Label lblDeadLinesValue;
        private System.Windows.Forms.Label lblGoalTitle;
        private System.Windows.Forms.Label lblWeeklyGoal;
        private System.Windows.Forms.ListView lvDashboard;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblProgressStatus;
        private System.Windows.Forms.Label lblDeadlinesStatus;
        private System.Windows.Forms.Label lblGoalStatus;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.GroupBox grpPriority;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.NumericUpDown numHours;
    }
}

