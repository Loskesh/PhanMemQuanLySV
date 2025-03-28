using System;
using System.Windows.Forms;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    public partial class EnrollmentForm : Form
    {
        private EnrollmentRepository enrollmentRepository;
        private StudentRepository studentRepository;
        private CourseRepository courseRepository;
        private List<Enrollment> displayedEnrollments;

        private void InitializeGridColumns()
        {
            gridEnrollments.Columns.Clear();
            gridEnrollments.Columns.Add("Id", "ID");
            gridEnrollments.Columns.Add("StudentId", "Student ID");
            gridEnrollments.Columns.Add("StudentName", "Student Name");
            gridEnrollments.Columns.Add("CourseCode", "Course Code");
            gridEnrollments.Columns.Add("CourseName", "Course Name");
            gridEnrollments.Columns.Add("Semester", "Semester");
            gridEnrollments.Columns.Add("AcademicYear", "Academic Year");
            gridEnrollments.Columns.Add("Grade", "Grade");
            gridEnrollments.Columns.Add("Status", "Status");
        }
        public EnrollmentForm(EnrollmentRepository enrollmentRepository, StudentRepository studentRepository, CourseRepository courseRepository)
        {
            InitializeComponent();
            InitializeGridColumns();
            this.enrollmentRepository = enrollmentRepository;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
            LoadData();
        }

        private void InitializeComponent()
        {
            panel1 = new Panel();
            cboSemester = new ComboBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnFilter = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            panel2 = new Panel();
            gridEnrollments = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridEnrollments).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cboSemester);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(btnFilter);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(915, 50);
            panel1.TabIndex = 0;
            // 
            // cboSemester
            // 
            cboSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSemester.FormattingEnabled = true;
            cboSemester.Items.AddRange(new object[] { "All Semesters", "Fall 2024-2025", "Spring 2024-2025", "Summer 2024-2025", "Fall 2023-2024", "Spring 2023-2024", "Summer 2023-2024" });
            cboSemester.Location = new Point(513, 15);
            cboSemester.Name = "cboSemester";
            cboSemester.Size = new Size(121, 33);
            cboSemester.TabIndex = 6;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(263, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(160, 31);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(429, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 36);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(640, 14);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 34);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(174, 14);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 36);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(93, 14);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 34);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 14);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 33);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(gridEnrollments);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(915, 485);
            panel2.TabIndex = 1;
            // 
            // gridEnrollments
            // 
            gridEnrollments.AllowUserToAddRows = false;
            gridEnrollments.AllowUserToDeleteRows = false;
            gridEnrollments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridEnrollments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEnrollments.Dock = DockStyle.Fill;
            gridEnrollments.Location = new Point(0, 0);
            gridEnrollments.MultiSelect = false;
            gridEnrollments.Name = "gridEnrollments";
            gridEnrollments.ReadOnly = true;
            gridEnrollments.RowHeadersWidth = 62;
            gridEnrollments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridEnrollments.Size = new Size(915, 485);
            gridEnrollments.TabIndex = 0;
            // 
            // EnrollmentForm
            // 
            ClientSize = new Size(915, 535);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "EnrollmentForm";
            Text = "Enrollment Management";
            Load += EnrollmentForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridEnrollments).EndInit();
            ResumeLayout(false);
        }


        private Panel panel1;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnFilter;
        private Button btnSearch;
        private TextBox txtSearch;
        private ComboBox cboSemester;
        private Panel panel2;
        private DataGridView gridEnrollments;

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {

            // Set default semester filter
            cboSemester.SelectedIndex = 0;
        }

        private void LoadData()
        {
            displayedEnrollments = new List<Enrollment>();
            gridEnrollments.Rows.Clear();

            string semesterFilter = cboSemester.SelectedItem?.ToString();
            List<Enrollment> enrollments;

            if (semesterFilter == "All Semesters" || semesterFilter == null)
            {
                enrollments = enrollmentRepository.Items;
            }
            else
            {
                string[] parts = semesterFilter.Split(' ');
                if (parts.Length >= 2)
                {
                    string semester = parts[0]; // Fall, Spring, Summer
                    string academicYear = parts[1]; // 2023-2024, 2024-2025
                    enrollments = enrollmentRepository.GetBySemester(semester, academicYear);
                }
                else
                {
                    enrollments = enrollmentRepository.Items;
                }
            }

            foreach (Enrollment enrollment in enrollments)
            {
                string searchText = txtSearch.Text.ToLower();
                bool matchesSearch = string.IsNullOrEmpty(searchText);

                if (enrollment.Student != null)
                {
                    matchesSearch = matchesSearch ||
                        enrollment.Student.StudentId.ToLower().Contains(searchText) ||
                        enrollment.Student.FullName.ToLower().Contains(searchText);
                }

                if (enrollment.Course != null)
                {
                    matchesSearch = matchesSearch ||
                        enrollment.Course.Code.ToLower().Contains(searchText) ||
                        enrollment.Course.Name.ToLower().Contains(searchText);
                }

                matchesSearch = matchesSearch ||
                    enrollment.Semester.ToLower().Contains(searchText) ||
                    enrollment.AcademicYear.ToLower().Contains(searchText) ||
                    enrollment.Status.ToLower().Contains(searchText);

                if (matchesSearch)
                {
                    displayedEnrollments.Add(enrollment);

                    string studentId = enrollment.Student != null ? enrollment.Student.StudentId : "";
                    string studentName = enrollment.Student != null ? enrollment.Student.FullName : "";
                    string courseCode = enrollment.Course != null ? enrollment.Course.Code : "";
                    string courseName = enrollment.Course != null ? enrollment.Course.Name : "";
                    string gradeValue = enrollment.Grade != null ? enrollment.Grade.ToString() : "Not graded";

                    gridEnrollments.Rows.Add(
                        enrollment.Id,
                        studentId,
                        studentName,
                        courseCode,
                        courseName,
                        enrollment.Semester,
                        enrollment.AcademicYear,
                        gradeValue,
                        enrollment.Status
                    );
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnrollmentEditForm editForm = new EnrollmentEditForm(null, enrollmentRepository, studentRepository, courseRepository);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridEnrollments.SelectedRows.Count > 0)
            {
                int selectedIndex = gridEnrollments.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < displayedEnrollments.Count)
                {
                    Enrollment selectedEnrollment = displayedEnrollments[selectedIndex];
                    EnrollmentEditForm editForm = new EnrollmentEditForm(selectedEnrollment, enrollmentRepository, studentRepository, courseRepository);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an enrollment to edit.", "Edit Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridEnrollments.SelectedRows.Count > 0)
            {
                int selectedIndex = gridEnrollments.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < displayedEnrollments.Count)
                {
                    Enrollment selectedEnrollment = displayedEnrollments[selectedIndex];

                    string studentName = selectedEnrollment.Student != null ? selectedEnrollment.Student.FullName : "Unknown";
                    string courseName = selectedEnrollment.Course != null ? selectedEnrollment.Course.Name : "Unknown";

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete enrollment for student '{studentName}' in course '{courseName}'?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            enrollmentRepository.Remove(selectedEnrollment);
                            LoadData();
                            MessageBox.Show("Enrollment deleted successfully.", "Delete Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an enrollment to delete.", "Delete Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }

    public class EnrollmentEditForm : Form
    {
        private Enrollment enrollment;
        private EnrollmentRepository enrollmentRepository;
        private StudentRepository studentRepository;
        private CourseRepository courseRepository;
        private bool isNewEnrollment;
        private bool isGradeTabVisible;

        public EnrollmentEditForm(Enrollment enrollment, EnrollmentRepository enrollmentRepository, StudentRepository studentRepository, CourseRepository courseRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
            this.isNewEnrollment = enrollment == null;

            if (isNewEnrollment)
            {
                this.enrollment = new Enrollment();
                this.Text = "Add New Enrollment";
                this.isGradeTabVisible = false;
            }
            else
            {
                this.enrollment = enrollment;
                this.Text = "Edit Enrollment";
                this.isGradeTabVisible = true;
            }

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabEnrollment = new TabPage();
            tabGrade = new TabPage();
            lblId = new Label();
            txtId = new TextBox();
            lblStudent = new Label();
            cboStudent = new ComboBox();
            lblCourse = new Label();
            cboCourse = new ComboBox();
            lblSemester = new Label();
            cboSemester = new ComboBox();
            lblAcademicYear = new Label();
            txtAcademicYear = new TextBox();
            lblStatus = new Label();
            txtStatus = new TextBox();
            lblAttendance = new Label();
            nudAttendance = new NumericUpDown();
            lblAssignment = new Label();
            nudAssignment = new NumericUpDown();
            lblMidterm = new Label();
            nudMidterm = new NumericUpDown();
            lblFinal = new Label();
            nudFinal = new NumericUpDown();
            lblGradeValue = new Label();
            txtGradeValue = new TextBox();
            lblLetterGrade = new Label();
            txtLetterGrade = new TextBox();
            btnCalculate = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            tabControl.SuspendLayout();
            tabEnrollment.SuspendLayout();
            tabGrade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAttendance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAssignment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMidterm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFinal).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabEnrollment);
            tabControl.Controls.Add(tabGrade);
            tabControl.Dock = DockStyle.Top;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(400, 280);
            tabControl.TabIndex = 0;
            // 
            // tabEnrollment
            // 
            tabEnrollment.Controls.Add(txtStatus);
            tabEnrollment.Controls.Add(lblStatus);
            tabEnrollment.Controls.Add(txtAcademicYear);
            tabEnrollment.Controls.Add(lblAcademicYear);
            tabEnrollment.Controls.Add(cboSemester);
            tabEnrollment.Controls.Add(lblSemester);
            tabEnrollment.Controls.Add(cboCourse);
            tabEnrollment.Controls.Add(lblCourse);
            tabEnrollment.Controls.Add(cboStudent);
            tabEnrollment.Controls.Add(lblStudent);
            tabEnrollment.Controls.Add(txtId);
            tabEnrollment.Controls.Add(lblId);
            tabEnrollment.Location = new Point(4, 22);
            tabEnrollment.Name = "tabEnrollment";
            tabEnrollment.Padding = new Padding(3);
            tabEnrollment.Size = new Size(392, 254);
            tabEnrollment.TabIndex = 0;
            tabEnrollment.Text = "Enrollment";
            tabEnrollment.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(8, 20);
            lblId.Name = "lblId";
            lblId.Size = new Size(21, 13);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Location = new Point(100, 17);
            txtId.Name = "txtId";
            txtId.Size = new Size(260, 20);
            txtId.TabIndex = 1;
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(8, 50);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(47, 13);
            lblStudent.TabIndex = 2;
            lblStudent.Text = "Student:";
            // 
            // cboStudent
            // 
            cboStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStudent.FormattingEnabled = true;
            cboStudent.Location = new Point(100, 47);
            cboStudent.Name = "cboStudent";
            cboStudent.Size = new Size(260, 21);
            cboStudent.TabIndex = 3;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(8, 80);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(43, 13);
            lblCourse.TabIndex = 4;
            lblCourse.Text = "Course:";
            // 
            // cboCourse
            // 
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.FormattingEnabled = true;
            cboCourse.Location = new Point(100, 77);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(260, 21);
            cboCourse.TabIndex = 5;
            // 
            // lblSemester
            // 
            lblSemester.AutoSize = true;
            lblSemester.Location = new Point(8, 110);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(54, 13);
            lblSemester.TabIndex = 6;
            lblSemester.Text = "Semester:";
            // 
            // cboSemester
            // 
            cboSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSemester.FormattingEnabled = true;
            cboSemester.Items.AddRange(new object[] { "Fall", "Spring", "Summer" });
            cboSemester.Location = new Point(100, 107);
            cboSemester.Name = "cboSemester";
            cboSemester.Size = new Size(260, 21);
            cboSemester.TabIndex = 7;
            // 
            // lblAcademicYear
            // 
            lblAcademicYear.AutoSize = true;
            lblAcademicYear.Location = new Point(8, 140);
            lblAcademicYear.Name = "lblAcademicYear";
            lblAcademicYear.Size = new Size(83, 13);
            lblAcademicYear.TabIndex = 8;
            lblAcademicYear.Text = "Academic Year:";
            // 
            // txtAcademicYear
            // 
            txtAcademicYear.Location = new Point(100, 137);
            txtAcademicYear.Name = "txtAcademicYear";
            txtAcademicYear.Size = new Size(260, 20);
            txtAcademicYear.TabIndex = 9;
            txtAcademicYear.Text = "2024-2025";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(8, 170);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(40, 13);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(100, 167);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(260, 20);
            txtStatus.TabIndex = 11;
            txtStatus.Text = "Đã đăng ký";
            // 
            // tabGrade
            // 
            tabGrade.Controls.Add(btnCalculate);
            tabGrade.Controls.Add(txtLetterGrade);
            tabGrade.Controls.Add(lblLetterGrade);
            tabGrade.Controls.Add(txtGradeValue);
            tabGrade.Controls.Add(lblGradeValue);
            tabGrade.Controls.Add(nudFinal);
            tabGrade.Controls.Add(lblFinal);
            tabGrade.Controls.Add(nudMidterm);
            tabGrade.Controls.Add(lblMidterm);
            tabGrade.Controls.Add(nudAssignment);
            tabGrade.Controls.Add(lblAssignment);
            tabGrade.Controls.Add(nudAttendance);
            tabGrade.Controls.Add(lblAttendance);
            tabGrade.Location = new Point(4, 22);
            tabGrade.Name = "tabGrade";
            tabGrade.Padding = new Padding(3);
            tabGrade.Size = new Size(392, 254);
            tabGrade.TabIndex = 1;
            tabGrade.Text = "Grade";
            tabGrade.UseVisualStyleBackColor = true;
            // 
            // lblAttendance
            // 
            lblAttendance.AutoSize = true;
            lblAttendance.Location = new Point(8, 20);
            lblAttendance.Name = "lblAttendance";
            lblAttendance.Size = new Size(95, 13);
            lblAttendance.TabIndex = 0;
            lblAttendance.Text = "Attendance Score:";
            // 
            // nudAttendance
            // 
            nudAttendance.DecimalPlaces = 1;
            nudAttendance.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudAttendance.Location = new Point(109, 18);
            nudAttendance.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudAttendance.Name = "nudAttendance";
            nudAttendance.Size = new Size(120, 20);
            nudAttendance.TabIndex = 1;
            // 
            // lblAssignment
            // 
            lblAssignment.AutoSize = true;
            lblAssignment.Location = new Point(8, 50);
            lblAssignment.Name = "lblAssignment";
            lblAssignment.Size = new Size(95, 13);
            lblAssignment.TabIndex = 2;
            lblAssignment.Text = "Assignment Score:";
            // 
            // nudAssignment
            // 
            nudAssignment.DecimalPlaces = 1;
            nudAssignment.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudAssignment.Location = new Point(109, 48);
            nudAssignment.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudAssignment.Name = "nudAssignment";
            nudAssignment.Size = new Size(120, 20);
            nudAssignment.TabIndex = 3;
            // 
            // lblMidterm
            // 
            lblMidterm.AutoSize = true;
            lblMidterm.Location = new Point(8, 80);
            lblMidterm.Name = "lblMidterm";
            lblMidterm.Size = new Size(79, 13);
            lblMidterm.TabIndex = 4;
            lblMidterm.Text = "Midterm Score:";
            // 
            // nudMidterm
            // 
            nudMidterm.DecimalPlaces = 1;
            nudMidterm.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudMidterm.Location = new Point(109, 78);
            nudMidterm.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudMidterm.Name = "nudMidterm";
            nudMidterm.Size = new Size(120, 20);
            nudMidterm.TabIndex = 5;
            // 
            // lblFinal
            // 
            lblFinal.AutoSize = true;
            lblFinal.Location = new Point(8, 110);
            lblFinal.Name = "lblFinal";
            lblFinal.Size = new Size(64, 13);
            lblFinal.TabIndex = 6;
            lblFinal.Text = "Final Score:";
            // 
            // nudFinal
            // 
            nudFinal.DecimalPlaces = 1;
            nudFinal.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudFinal.Location = new Point(109, 108);
            nudFinal.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudFinal.Name = "nudFinal";
            nudFinal.Size = new Size(120, 20);
            nudFinal.TabIndex = 7;
            // 
            // lblGradeValue
            // 
            lblGradeValue.AutoSize = true;
            lblGradeValue.Location = new Point(8, 170);
            lblGradeValue.Name = "lblGradeValue";
            lblGradeValue.Size = new Size(38, 13);
            lblGradeValue.TabIndex = 8;
            lblGradeValue.Text = "Grade:";
            // 
            // txtGradeValue
            // 
            txtGradeValue.Location = new Point(109, 167);
            txtGradeValue.Name = "txtGradeValue";
            txtGradeValue.ReadOnly = true;
            txtGradeValue.Size = new Size(120, 20);
            txtGradeValue.TabIndex = 9;
            // 
            // lblLetterGrade
            // 
            lblLetterGrade.AutoSize = true;
            lblLetterGrade.Location = new Point(8, 200);
            lblLetterGrade.Name = "lblLetterGrade";
            lblLetterGrade.Size = new Size(70, 13);
            lblLetterGrade.TabIndex = 10;
            lblLetterGrade.Text = "Letter Grade:";
            // 
            // txtLetterGrade
            // 
            txtLetterGrade.Location = new Point(109, 197);
            txtLetterGrade.Name = "txtLetterGrade";
            txtLetterGrade.ReadOnly = true;
            txtLetterGrade.Size = new Size(120, 20);
            txtLetterGrade.TabIndex = 11;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(109, 138);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(120, 23);
            btnCalculate.TabIndex = 12;
            btnCalculate.Text = "Calculate Grade";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(120, 290);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(201, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // EnrollmentEditForm
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            ClientSize = new Size(400, 330);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EnrollmentEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += EnrollmentEditForm_Load;
            tabControl.ResumeLayout(false);
            tabEnrollment.ResumeLayout(false);
            tabEnrollment.PerformLayout();
            tabGrade.ResumeLayout(false);
            tabGrade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAttendance).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAssignment).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMidterm).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFinal).EndInit();
            ResumeLayout(false);
        }

        private TabControl tabControl;
        private TabPage tabEnrollment;
        private TabPage tabGrade;
        private Label lblId;
        private TextBox txtId;
        private Label lblStudent;
        private ComboBox cboStudent;
        private Label lblCourse;
        private ComboBox cboCourse;
        private Label lblSemester;
        private ComboBox cboSemester;
        private Label lblAcademicYear;
        private TextBox txtAcademicYear;
        private Label lblStatus;
        private TextBox txtStatus;
        private Label lblAttendance;
        private NumericUpDown nudAttendance;
        private Label lblAssignment;
        private NumericUpDown nudAssignment;
        private Label lblMidterm;
        private NumericUpDown nudMidterm;
        private Label lblFinal;
        private NumericUpDown nudFinal;
        private Label lblGradeValue;
        private TextBox txtGradeValue;
        private Label lblLetterGrade;
        private TextBox txtLetterGrade;
        private Button btnCalculate;
        private Button btnSave;
        private Button btnCancel;

        private void EnrollmentEditForm_Load(object sender, EventArgs e)
        {
            // Load students to combobox
            LoadStudents();

            // Load courses to combobox
            LoadCourses();

            // Set default values for Semester
            if (cboSemester.Items.Count > 0 && cboSemester.SelectedIndex < 0)
            {
                cboSemester.SelectedIndex = 0;
            }

            // Generate a new ID for new enrollments
            if (isNewEnrollment)
            {
                txtId.Text = Guid.NewGuid().ToString();
                tabControl.TabPages.Remove(tabGrade);
            }
            else
            {
                // Fill the form with enrollment data
                FillForm();
            }

            // Set readonly fields
            txtId.ReadOnly = true;
            txtGradeValue.ReadOnly = true;
            txtLetterGrade.ReadOnly = true;
        }

        private void LoadStudents()
        {
            cboStudent.Items.Clear();

            foreach (Student student in studentRepository.Items)
            {
                // Only show active students
                if (student.State.GetStateName() == "Active")
                {
                    cboStudent.Items.Add(student);
                }
            }

            if (cboStudent.Items.Count > 0)
            {
                cboStudent.SelectedIndex = 0;
            }
        }

        private void LoadCourses()
        {
            cboCourse.Items.Clear();

            foreach (Course course in courseRepository.Items)
            {
                cboCourse.Items.Add(course);
            }

            if (cboCourse.Items.Count > 0)
            {
                cboCourse.SelectedIndex = 0;
            }
        }

        private void FillForm()
        {
            txtId.Text = enrollment.Id;
            txtStatus.Text = enrollment.Status;

            // Set student
            if (enrollment.Student != null)
            {
                for (int i = 0; i < cboStudent.Items.Count; i++)
                {
                    Student student = cboStudent.Items[i] as Student;
                    if (student != null && student.Id == enrollment.Student.Id)
                    {
                        cboStudent.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Set course
            if (enrollment.Course != null)
            {
                for (int i = 0; i < cboCourse.Items.Count; i++)
                {
                    Course course = cboCourse.Items[i] as Course;
                    if (course != null && course.Id == enrollment.Course.Id)
                    {
                        cboCourse.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Set semester
            switch (enrollment.Semester)
            {
                case "Fall":
                    cboSemester.SelectedIndex = 0;
                    break;
                case "Spring":
                    cboSemester.SelectedIndex = 1;
                    break;
                case "Summer":
                    cboSemester.SelectedIndex = 2;
                    break;
                default:
                    cboSemester.SelectedIndex = 0;
                    break;
            }

            txtAcademicYear.Text = enrollment.AcademicYear;

            // Set grade if available
            if (enrollment.Grade != null)
            {
                nudAttendance.Value = (decimal)enrollment.Grade.AttendanceScore;
                nudAssignment.Value = (decimal)enrollment.Grade.AssignmentScore;
                nudMidterm.Value = (decimal)enrollment.Grade.MidtermScore;
                nudFinal.Value = (decimal)enrollment.Grade.FinalScore;
                txtGradeValue.Text = enrollment.Grade.Value.ToString("F2");
                txtLetterGrade.Text = enrollment.Grade.LetterGrade;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double attendanceScore = (double)nudAttendance.Value;
            double assignmentScore = (double)nudAssignment.Value;
            double midtermScore = (double)nudMidterm.Value;
            double finalScore = (double)nudFinal.Value;

            Grade grade = new Grade(attendanceScore, assignmentScore, midtermScore, finalScore);

            txtGradeValue.Text = grade.Value.ToString("F2");
            txtLetterGrade.Text = grade.LetterGrade;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (cboStudent.SelectedItem == null)
            {
                MessageBox.Show("Please select a student.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStudent.Focus();
                return;
            }

            if (cboCourse.SelectedItem == null)
            {
                MessageBox.Show("Please select a course.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCourse.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtAcademicYear.Text))
            {
                MessageBox.Show("Please enter academic year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAcademicYear.Focus();
                return;
            }

            // Check if student is already enrolled in the course
            Student selectedStudent = cboStudent.SelectedItem as Student;
            Course selectedCourse = cboCourse.SelectedItem as Course;
            string selectedSemester = cboSemester.SelectedItem.ToString();
            string academicYear = txtAcademicYear.Text;

            if (isNewEnrollment && enrollmentRepository.IsEnrolled(selectedStudent, selectedCourse, selectedSemester, academicYear))
            {
                MessageBox.Show("Student is already enrolled in this course for the selected semester.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update enrollment object
            enrollment.Id = txtId.Text;
            enrollment.Student = selectedStudent;
            enrollment.Course = selectedCourse;
            enrollment.Semester = selectedSemester;
            enrollment.AcademicYear = academicYear;
            enrollment.Status = txtStatus.Text;

            // Update grade if on grade tab
            if (!isNewEnrollment && tabControl.SelectedTab == tabGrade)
            {
                double attendanceScore = (double)nudAttendance.Value;
                double assignmentScore = (double)nudAssignment.Value;
                double midtermScore = (double)nudMidterm.Value;
                double finalScore = (double)nudFinal.Value;

                enrollment.SetGrade(attendanceScore, assignmentScore, midtermScore, finalScore);
            }

            try
            {
                // Add or update enrollment
                if (isNewEnrollment)
                {
                    enrollmentRepository.Add(enrollment);
                    MessageBox.Show("Enrollment added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    enrollmentRepository.Update(enrollment);
                    MessageBox.Show("Enrollment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}