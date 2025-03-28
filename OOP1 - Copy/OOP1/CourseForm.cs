using System;
using System.Windows.Forms;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    public partial class CourseForm : Form
    {
        private CourseRepository courseRepository;
        private DepartmentRepository departmentRepository;
        private List<Course> displayedCourses;

        public CourseForm(CourseRepository courseRepository, DepartmentRepository departmentRepository)
        {
            InitializeComponent();
            InitializeGridColumns();
            this.courseRepository = courseRepository;
            this.departmentRepository = departmentRepository;
            LoadData();
        }

        private void InitializeComponent()
        {
            panel1 = new Panel();
            cboDepartment = new ComboBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnFilter = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            panel2 = new Panel();
            gridCourses = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCourses).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cboDepartment);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(btnFilter);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(968, 50);
            panel1.TabIndex = 0;
            // 
            // cboDepartment
            // 
            cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartment.FormattingEnabled = true;
            cboDepartment.Location = new Point(513, 15);
            cboDepartment.Name = "cboDepartment";
            cboDepartment.Size = new Size(121, 33);
            cboDepartment.TabIndex = 6;
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
            btnFilter.Size = new Size(75, 36);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(174, 14);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 33);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(93, 14);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 33);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 14);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(gridCourses);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(968, 512);
            panel2.TabIndex = 1;
            // 
            // gridCourses
            // 
            gridCourses.AllowUserToAddRows = false;
            gridCourses.AllowUserToDeleteRows = false;
            gridCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCourses.Dock = DockStyle.Fill;
            gridCourses.Location = new Point(0, 0);
            gridCourses.MultiSelect = false;
            gridCourses.Name = "gridCourses";
            gridCourses.ReadOnly = true;
            gridCourses.RowHeadersWidth = 62;
            gridCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCourses.Size = new Size(968, 512);
            gridCourses.TabIndex = 0;
            // 
            // CourseForm
            // 
            ClientSize = new Size(968, 562);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CourseForm";
            Text = "Course Management";
            Load += CourseForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridCourses).EndInit();
            ResumeLayout(false);
        }

        private Panel panel1;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnFilter;
        private Button btnSearch;
        private TextBox txtSearch;
        private ComboBox cboDepartment;
        private Panel panel2;
        private DataGridView gridCourses;

        private void InitializeGridColumns()
        {
            gridCourses.ColumnCount = 7;
            gridCourses.Columns[0].Name = "ID";
            gridCourses.Columns[0].Visible = false;
            gridCourses.Columns[1].Name = "Code";
            gridCourses.Columns[2].Name = "Name";
            gridCourses.Columns[3].Name = "Credits";
            gridCourses.Columns[4].Name = "Department";
            gridCourses.Columns[5].Name = "Description";
            gridCourses.Columns[6].Name = "Students";
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
 
            // Load departments to combobox
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            cboDepartment.Items.Clear();
            cboDepartment.Items.Add("All Departments");

            foreach (Department department in departmentRepository.Items)
            {
                cboDepartment.Items.Add(department);
            }

            if (cboDepartment.Items.Count > 0)
            {
                cboDepartment.SelectedIndex = 0;
            }
        }

        private void LoadData()
        {
            displayedCourses = new List<Course>();
            gridCourses.Rows.Clear();

            Department selectedDepartment = cboDepartment.SelectedItem as Department;
            List<Course> courses;

            if (selectedDepartment == null || cboDepartment.SelectedIndex == 0) // "All Departments"
            {
                courses = courseRepository.Items;
            }
            else
            {
                courses = courseRepository.GetByDepartment(selectedDepartment);
            }

            foreach (Course course in courses)
            {
                string searchText = txtSearch.Text.ToLower();
                if (string.IsNullOrEmpty(searchText) ||
                    course.Code.ToLower().Contains(searchText) ||
                    course.Name.ToLower().Contains(searchText) ||
                    course.Description.ToLower().Contains(searchText))
                {
                    displayedCourses.Add(course);
                    string departmentName = course.Department != null ? course.Department.Name : "";

                    gridCourses.Rows.Add(
                        course.Id,
                        course.Code,
                        course.Name,
                        course.Credits,
                        departmentName,
                        course.Description,
                        course.GetStudentCount()
                    );
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CourseEditForm editForm = new CourseEditForm(null, courseRepository, departmentRepository);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridCourses.SelectedRows.Count > 0)
            {
                int selectedIndex = gridCourses.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < displayedCourses.Count)
                {
                    Course selectedCourse = displayedCourses[selectedIndex];
                    CourseEditForm editForm = new CourseEditForm(selectedCourse, courseRepository, departmentRepository);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a course to edit.", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridCourses.SelectedRows.Count > 0)
            {
                int selectedIndex = gridCourses.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < displayedCourses.Count)
                {
                    Course selectedCourse = displayedCourses[selectedIndex];

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete course '{selectedCourse.Name}' ({selectedCourse.Code})?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            courseRepository.Remove(selectedCourse);
                            LoadData();
                            MessageBox.Show("Course deleted successfully.", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a course to delete.", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    public class CourseEditForm : Form
    {
        private Course course;
        private CourseRepository courseRepository;
        private DepartmentRepository departmentRepository;
        private bool isNewCourse;

        public CourseEditForm(Course course, CourseRepository courseRepository, DepartmentRepository departmentRepository)
        {
            this.courseRepository = courseRepository;
            this.departmentRepository = departmentRepository;
            this.isNewCourse = course == null;

            if (isNewCourse)
            {
                this.course = new Course();
                this.Text = "Add New Course";
            }
            else
            {
                this.course = course;
                this.Text = "Edit Course";
            }

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            lblId = new Label();
            txtId = new TextBox();
            lblCode = new Label();
            txtCode = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblCredits = new Label();
            nudCredits = new NumericUpDown();
            lblDepartment = new Label();
            cboDepartment = new ComboBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCredits).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(12, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(21, 13);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Location = new Point(87, 12);
            txtId.Name = "txtId";
            txtId.Size = new Size(280, 20);
            txtId.TabIndex = 1;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(12, 41);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(35, 13);
            lblCode.TabIndex = 2;
            lblCode.Text = "Code:";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(87, 38);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(280, 20);
            txtCode.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 67);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 13);
            lblName.TabIndex = 4;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(87, 64);
            txtName.Name = "txtName";
            txtName.Size = new Size(280, 20);
            txtName.TabIndex = 5;
            // 
            // lblCredits
            // 
            lblCredits.AutoSize = true;
            lblCredits.Location = new Point(12, 93);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(42, 13);
            lblCredits.TabIndex = 6;
            lblCredits.Text = "Credits:";
            // 
            // nudCredits
            // 
            nudCredits.Location = new Point(87, 91);
            nudCredits.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudCredits.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCredits.Name = "nudCredits";
            nudCredits.Size = new Size(280, 20);
            nudCredits.TabIndex = 7;
            nudCredits.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(12, 119);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(65, 13);
            lblDepartment.TabIndex = 8;
            lblDepartment.Text = "Department:";
            // 
            // cboDepartment
            // 
            cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartment.FormattingEnabled = true;
            cboDepartment.Location = new Point(87, 116);
            cboDepartment.Name = "cboDepartment";
            cboDepartment.Size = new Size(280, 21);
            cboDepartment.TabIndex = 9;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 146);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(63, 13);
            lblDescription.TabIndex = 10;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(87, 143);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(280, 60);
            txtDescription.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(87, 223);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(168, 223);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // CourseEditForm
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            ClientSize = new Size(394, 261);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(cboDepartment);
            Controls.Add(lblDepartment);
            Controls.Add(nudCredits);
            Controls.Add(lblCredits);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtCode);
            Controls.Add(lblCode);
            Controls.Add(txtId);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CourseEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += CourseEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudCredits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblId;
        private TextBox txtId;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblName;
        private TextBox txtName;
        private Label lblCredits;
        private NumericUpDown nudCredits;
        private Label lblDepartment;
        private ComboBox cboDepartment;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;

        private void CourseEditForm_Load(object sender, EventArgs e)
        {
            // Load departments to combobox
            LoadDepartments();

            // Generate a new ID for new courses
            if (isNewCourse)
            {
                txtId.Text = Guid.NewGuid().ToString();
            }
            else
            {
                // Fill the form with course data
                FillForm();
            }

            // Set readonly fields
            txtId.ReadOnly = true;
        }

        private void LoadDepartments()
        {
            cboDepartment.Items.Clear();

            foreach (Department department in departmentRepository.Items)
            {
                cboDepartment.Items.Add(department);
            }

            if (cboDepartment.Items.Count > 0)
            {
                cboDepartment.SelectedIndex = 0;
            }
        }

        private void FillForm()
        {
            txtId.Text = course.Id;
            txtCode.Text = course.Code;
            txtName.Text = course.Name;
            nudCredits.Value = course.Credits;
            txtDescription.Text = course.Description;

            // Set department
            if (course.Department != null)
            {
                for (int i = 0; i < cboDepartment.Items.Count; i++)
                {
                    Department department = cboDepartment.Items[i] as Department;
                    if (department != null && department.Id == course.Department.Id)
                    {
                        cboDepartment.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Please enter course code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter course name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (cboDepartment.SelectedItem == null)
            {
                MessageBox.Show("Please select a department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDepartment.Focus();
                return;
            }

            // Check duplicate course code
            if (isNewCourse && courseRepository.Exists(txtCode.Text))
            {
                MessageBox.Show("Course code already exists. Please enter a different code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }

            // Update course object
            course.Id = txtId.Text;
            course.Code = txtCode.Text;
            course.Name = txtName.Text;
            course.Credits = (int)nudCredits.Value;
            course.Description = txtDescription.Text;
            course.Department = cboDepartment.SelectedItem as Department;

            try
            {
                // Add or update course
                if (isNewCourse)
                {
                    courseRepository.Add(course);
                    MessageBox.Show("Course added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    courseRepository.Update(course);
                    MessageBox.Show("Course updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}