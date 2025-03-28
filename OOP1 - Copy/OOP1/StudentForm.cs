using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    public partial class StudentForm : Form
    {
        private StudentRepository studentRepository;
        private List<Student> displayedStudents;

        public StudentForm(StudentRepository studentRepository)
        {
            InitializeComponent();
            InitializeGridColumns();
            this.studentRepository = studentRepository;
            LoadData();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridStudents = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.cboState);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(640, 14);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "All",
            "Active",
            "OnLeave",
            "Graduated",
            "Suspended"});
            this.cboState.Location = new System.Drawing.Point(513, 15);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(121, 21);
            this.cboState.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(263, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 20);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(429, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(93, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridStudents);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 400);
            this.panel2.TabIndex = 1;
            // 
            // gridStudents
            // 
            this.gridStudents.AllowUserToAddRows = false;
            this.gridStudents.AllowUserToDeleteRows = false;
            this.gridStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStudents.Location = new System.Drawing.Point(0, 0);
            this.gridStudents.MultiSelect = false;
            this.gridStudents.Name = "gridStudents";
            this.gridStudents.ReadOnly = true;
            this.gridStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStudents.Size = new System.Drawing.Size(800, 400);
            this.gridStudents.TabIndex = 0;
            // 
            // StudentForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StudentForm";
            this.Text = "Student Management";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStudents)).EndInit();
            this.ResumeLayout(false);
        }

        private Panel panel1;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private TextBox txtSearch;
        private ComboBox cboState;
        private Button btnFilter;
        private Panel panel2;
        private DataGridView gridStudents;

        private void InitializeGridColumns()
        {
            gridStudents.ColumnCount = 10;
            gridStudents.Columns[0].Name = "ID";
            gridStudents.Columns[0].Visible = false;
            gridStudents.Columns[1].Name = "Student ID";
            gridStudents.Columns[2].Name = "Full Name";
            gridStudents.Columns[3].Name = "Date of Birth";
            gridStudents.Columns[4].Name = "Gender";
            gridStudents.Columns[5].Name = "Class";
            gridStudents.Columns[6].Name = "Major";
            gridStudents.Columns[7].Name = "Intake";
            gridStudents.Columns[8].Name = "State";
            gridStudents.Columns[9].Name = "GPA";
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

            // Set default state filter
            cboState.SelectedIndex = 0;
        }

        private void LoadData()
        {
            displayedStudents = new List<Student>();
            gridStudents.Rows.Clear();

            string stateFilter = cboState.SelectedItem?.ToString();
            List<Student> students;

            if (stateFilter == "All" || stateFilter == null)
            {
                students = studentRepository.Items;
            }
            else
            {
                students = studentRepository.GetStudentsByState(stateFilter);
            }

            foreach (Student student in students)
            {
                string searchText = txtSearch.Text.ToLower();
                if (string.IsNullOrEmpty(searchText) ||
                    student.StudentId.ToLower().Contains(searchText) ||
                    student.FullName.ToLower().Contains(searchText) ||
                    student.ClassName.ToLower().Contains(searchText) ||
                    student.Major.ToLower().Contains(searchText))
                {
                    displayedStudents.Add(student);
                    gridStudents.Rows.Add(
                        student.Id,
                        student.StudentId,
                        student.FullName,
                        student.DateOfBirth.ToShortDateString(),
                        student.Gender,
                        student.ClassName,
                        student.Major,
                        student.Intake,
                        student.State.GetStateName(),
                        student.CalculateGPA().ToString("F2")
                    );
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StudentEditForm editForm = new StudentEditForm(null, studentRepository);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridStudents.SelectedRows.Count > 0)
            {
                int selectedIndex = gridStudents.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < displayedStudents.Count)
                {
                    Student selectedStudent = displayedStudents[selectedIndex];
                    StudentEditForm editForm = new StudentEditForm(selectedStudent, studentRepository);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to edit.", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridStudents.SelectedRows.Count > 0)
            {
                int selectedIndex = gridStudents.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < displayedStudents.Count)
                {
                    Student selectedStudent = displayedStudents[selectedIndex];

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete student '{selectedStudent.FullName}' ({selectedStudent.StudentId})?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            studentRepository.Remove(selectedStudent);
                            LoadData();
                            MessageBox.Show("Student deleted successfully.", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    public class StudentEditForm : Form
    {
        private Student student;
        private StudentRepository studentRepository;
        private bool isNewStudent;

        public StudentEditForm(Student student, StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
            this.isNewStudent = student == null;

            if (isNewStudent)
            {
                this.student = new Student();
                this.Text = "Add New Student";
            }
            else
            {
                this.student = student;
                this.Text = "Edit Student";
            }

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblGender = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.grpAddress = new System.Windows.Forms.GroupBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblMajor = new System.Windows.Forms.Label();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.lblIntake = new System.Windows.Forms.Label();
            this.nudIntake = new System.Windows.Forms.NumericUpDown();
            this.lblState = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntake)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 15);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(87, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(200, 20);
            this.txtId.TabIndex = 1;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(12, 41);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(57, 13);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(87, 38);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(200, 20);
            this.txtFullName.TabIndex = 3;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(12, 67);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(69, 13);
            this.lblDateOfBirth.TabIndex = 4;
            this.lblDateOfBirth.Text = "Date of Birth:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(87, 64);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(200, 20);
            this.dtpDateOfBirth.TabIndex = 5;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(12, 93);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Gender:";
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cboGender.Location = new System.Drawing.Point(87, 90);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(200, 21);
            this.cboGender.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 120);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(87, 117);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 146);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(87, 143);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 20);
            this.txtPhone.TabIndex = 11;
            // 
            // grpAddress
            // 
            this.grpAddress.Controls.Add(this.lblCountry);
            this.grpAddress.Controls.Add(this.txtCountry);
            this.grpAddress.Controls.Add(this.lblZipCode);
            this.grpAddress.Controls.Add(this.txtZipCode);
            this.grpAddress.Controls.Add(this.lblCity);
            this.grpAddress.Controls.Add(this.txtCity);
            this.grpAddress.Controls.Add(this.lblDistrict);
            this.grpAddress.Controls.Add(this.txtDistrict);
            this.grpAddress.Controls.Add(this.lblStreet);
            this.grpAddress.Controls.Add(this.txtStreet);
            this.grpAddress.Location = new System.Drawing.Point(12, 169);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Size = new System.Drawing.Size(275, 157);
            this.grpAddress.TabIndex = 12;
            this.grpAddress.TabStop = false;
            this.grpAddress.Text = "Address";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(6, 126);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(46, 13);
            this.lblCountry.TabIndex = 9;
            this.lblCountry.Text = "Country:";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(75, 123);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(179, 20);
            this.txtCountry.TabIndex = 8;
            this.txtCountry.Text = "Việt Nam";
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Location = new System.Drawing.Point(6, 100);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(53, 13);
            this.lblZipCode.TabIndex = 7;
            this.lblZipCode.Text = "Zip Code:";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(75, 97);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(179, 20);
            this.txtZipCode.TabIndex = 6;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(6, 74);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 5;
            this.lblCity.Text = "City:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(75, 71);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(179, 20);
            this.txtCity.TabIndex = 4;
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(6, 48);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(42, 13);
            this.lblDistrict.TabIndex = 3;
            this.lblDistrict.Text = "District:";
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(75, 45);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(179, 20);
            this.txtDistrict.TabIndex = 2;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(6, 22);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(38, 13);
            this.lblStreet.TabIndex = 1;
            this.lblStreet.Text = "Street:";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(75, 19);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(179, 20);
            this.txtStreet.TabIndex = 0;
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Location = new System.Drawing.Point(303, 15);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(61, 13);
            this.lblStudentId.TabIndex = 13;
            this.lblStudentId.Text = "Student ID:";
            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(370, 12);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(200, 20);
            this.txtStudentId.TabIndex = 14;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(303, 41);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(35, 13);
            this.lblClass.TabIndex = 15;
            this.lblClass.Text = "Class:";
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(370, 38);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(200, 20);
            this.txtClass.TabIndex = 16;
            // 
            // lblMajor
            // 
            this.lblMajor.AutoSize = true;
            this.lblMajor.Location = new System.Drawing.Point(303, 67);
            this.lblMajor.Name = "lblMajor";
            this.lblMajor.Size = new System.Drawing.Size(36, 13);
            this.lblMajor.TabIndex = 17;
            this.lblMajor.Text = "Major:";
            // 
            // txtMajor
            // 
            this.txtMajor.Location = new System.Drawing.Point(370, 64);
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.Size = new System.Drawing.Size(200, 20);
            this.txtMajor.TabIndex = 18;
            // 
            // lblIntake
            // 
            this.lblIntake.AutoSize = true;
            this.lblIntake.Location = new System.Drawing.Point(303, 93);
            this.lblIntake.Name = "lblIntake";
            this.lblIntake.Size = new System.Drawing.Size(40, 13);
            this.lblIntake.TabIndex = 19;
            this.lblIntake.Text = "Intake:";
            // 
            // nudIntake
            // 
            this.nudIntake.Location = new System.Drawing.Point(370, 91);
            this.nudIntake.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.nudIntake.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudIntake.Name = "nudIntake";
            this.nudIntake.Size = new System.Drawing.Size(200, 20);
            this.nudIntake.TabIndex = 20;
            this.nudIntake.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(303, 120);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 21;
            this.lblState.Text = "State:";
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "Active",
            "OnLeave",
            "Graduated",
            "Suspended"});
            this.cboState.Location = new System.Drawing.Point(370, 117);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(200, 21);
            this.cboState.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(370, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(451, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // StudentEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 339);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.nudIntake);
            this.Controls.Add(this.lblIntake);
            this.Controls.Add(this.txtMajor);
            this.Controls.Add(this.lblMajor);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.txtStudentId);
            this.Controls.Add(this.lblStudentId);
            this.Controls.Add(this.grpAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.StudentEditForm_Load);
            this.grpAddress.ResumeLayout(false);
            this.grpAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntake)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblId;
        private TextBox txtId;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblDateOfBirth;
        private DateTimePicker dtpDateOfBirth;
        private Label lblGender;
        private ComboBox cboGender;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private GroupBox grpAddress;
        private Label lblCountry;
        private TextBox txtCountry;
        private Label lblZipCode;
        private TextBox txtZipCode;
        private Label lblCity;
        private TextBox txtCity;
        private Label lblDistrict;
        private TextBox txtDistrict;
        private Label lblStreet;
        private TextBox txtStreet;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblClass;
        private TextBox txtClass;
        private Label lblMajor;
        private TextBox txtMajor;
        private Label lblIntake;
        private NumericUpDown nudIntake;
        private Label lblState;
        private ComboBox cboState;
        private Button btnSave;
        private Button btnCancel;

        private void StudentEditForm_Load(object sender, EventArgs e)
        {
            // Set default values for Gender and State
            if (cboGender.Items.Count > 0 && cboGender.SelectedIndex < 0)
            {
                cboGender.SelectedIndex = 0;
            }

            if (cboState.Items.Count > 0 && cboState.SelectedIndex < 0)
            {
                cboState.SelectedIndex = 0;
            }

            // Generate a new ID for new students
            if (isNewStudent)
            {
                txtId.Text = Guid.NewGuid().ToString();
            }
            else
            {
                // Fill the form with student data
                FillForm();
            }

            // Set readonly fields
            txtId.ReadOnly = true;
        }

        private void FillForm()
        {
            txtId.Text = student.Id;
            txtFullName.Text = student.FullName;
            dtpDateOfBirth.Value = student.DateOfBirth;

            // Set gender
            switch (student.Gender)
            {
                case "Male":
                    cboGender.SelectedIndex = 0;
                    break;
                case "Female":
                    cboGender.SelectedIndex = 1;
                    break;
                case "Other":
                    cboGender.SelectedIndex = 2;
                    break;
                default:
                    cboGender.SelectedIndex = 0;
                    break;
            }

            txtEmail.Text = student.Email;
            txtPhone.Text = student.PhoneNumber;

            // Address
            txtStreet.Text = student.Address.Street;
            txtDistrict.Text = student.Address.District;
            txtCity.Text = student.Address.City;
            txtZipCode.Text = student.Address.ZipCode;
            txtCountry.Text = student.Address.Country;

            // Student specific
            txtStudentId.Text = student.StudentId;
            txtClass.Text = student.ClassName;
            txtMajor.Text = student.Major;
            nudIntake.Value = student.Intake;

            // State
            string stateName = student.State.GetStateName();
            switch (stateName)
            {
                case "Active":
                    cboState.SelectedIndex = 0;
                    break;
                case "OnLeave":
                    cboState.SelectedIndex = 1;
                    break;
                case "Graduated":
                    cboState.SelectedIndex = 2;
                    break;
                case "Suspended":
                    cboState.SelectedIndex = 3;
                    break;
                default:
                    cboState.SelectedIndex = 0;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Please enter full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtStudentId.Text))
            {
                MessageBox.Show("Please enter student ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtClass.Text))
            {
                MessageBox.Show("Please enter class.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClass.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMajor.Text))
            {
                MessageBox.Show("Please enter major.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMajor.Focus();
                return;
            }

            // Check duplicate student ID
            if (isNewStudent && studentRepository.Exists(txtStudentId.Text))
            {
                MessageBox.Show("Student ID already exists. Please enter a different ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                return;
            }

            // Update student object
            student.Id = txtId.Text;
            student.FullName = txtFullName.Text;
            student.DateOfBirth = dtpDateOfBirth.Value;
            student.Gender = cboGender.SelectedItem.ToString();
            student.Email = txtEmail.Text;
            student.PhoneNumber = txtPhone.Text;

            // Update address
            if (student.Address == null)
            {
                student.Address = new Address();
            }
            student.Address.Street = txtStreet.Text;
            student.Address.District = txtDistrict.Text;
            student.Address.City = txtCity.Text;
            student.Address.ZipCode = txtZipCode.Text;
            student.Address.Country = txtCountry.Text;

            // Update student specific
            student.StudentId = txtStudentId.Text;
            student.ClassName = txtClass.Text;
            student.Major = txtMajor.Text;
            student.Intake = (int)nudIntake.Value;

            // Update state
            string newState = cboState.SelectedItem.ToString();
            switch (newState)
            {
                case "Active":
                    student.ChangeState(new ActiveState(student));
                    break;
                case "OnLeave":
                    student.ChangeState(new OnLeaveState(student));
                    break;
                case "Graduated":
                    student.ChangeState(new GraduatedState(student));
                    break;
                case "Suspended":
                    student.ChangeState(new SuspendedState(student));
                    break;
            }

            try
            {
                // Add or update student
                if (isNewStudent)
                {
                    studentRepository.Add(student);
                    MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    studentRepository.Update(student);
                    MessageBox.Show("Student updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}