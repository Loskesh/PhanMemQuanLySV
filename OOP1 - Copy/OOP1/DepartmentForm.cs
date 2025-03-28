using System;
using System.Windows.Forms;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    public partial class DepartmentForm : Form
    {
        private DepartmentRepository departmentRepository;
        private List<Department> displayedDepartments;

        public DepartmentForm(DepartmentRepository departmentRepository)
        {
            InitializeComponent();
            InitializeGrid();
            this.departmentRepository = departmentRepository;
            LoadData();
        }

        private void InitializeComponent()
        {
            panel1 = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            panel2 = new Panel();
            gridDepartments = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridDepartments).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 50);
            panel1.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(263, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(160, 31);
            txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(429, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 30);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(174, 14);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 30);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(93, 14);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 30);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 14);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 30);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(gridDepartments);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 400);
            panel2.TabIndex = 1;
            // 
            // gridDepartments
            // 
            gridDepartments.AllowUserToAddRows = false;
            gridDepartments.AllowUserToDeleteRows = false;
            gridDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDepartments.Dock = DockStyle.Fill;
            gridDepartments.Location = new Point(0, 0);
            gridDepartments.MultiSelect = false;
            gridDepartments.Name = "gridDepartments";
            gridDepartments.ReadOnly = true;
            gridDepartments.RowHeadersWidth = 62;
            gridDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridDepartments.Size = new Size(800, 400);
            gridDepartments.TabIndex = 0;
            // 
            // DepartmentForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DepartmentForm";
            Text = "Department Management";
            Load += DepartmentForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridDepartments).EndInit();
            ResumeLayout(false);
        }

        private Panel panel1;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private TextBox txtSearch;
        private Panel panel2;
        private DataGridView gridDepartments;

        private void InitializeGrid()
        {
            // Initialize the DataGridView columns
            gridDepartments.ColumnCount = 7;
            gridDepartments.Columns[0].Name = "ID";
            gridDepartments.Columns[0].Visible = false;
            gridDepartments.Columns[1].Name = "Name";
            gridDepartments.Columns[2].Name = "Short Name";
            gridDepartments.Columns[3].Name = "Location";
            gridDepartments.Columns[4].Name = "Description";
            gridDepartments.Columns[5].Name = "Lecturers";
            gridDepartments.Columns[6].Name = "Students";
        }
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            // Set default search text or other UI elements if needed
            txtSearch.Text = string.Empty;

            // Optionally, load data again if needed
            LoadData();
        }

        private void LoadData()
        {
            displayedDepartments = new List<Department>();
            gridDepartments.Rows.Clear();

            foreach (Department department in departmentRepository.Items)
            {
                string searchText = txtSearch.Text.ToLower();
                if (string.IsNullOrEmpty(searchText) ||
                    department.Name.ToLower().Contains(searchText) ||
                    department.ShortName.ToLower().Contains(searchText) ||
                    department.Location.ToLower().Contains(searchText) ||
                    department.Description.ToLower().Contains(searchText))
                {
                    displayedDepartments.Add(department);

                    gridDepartments.Rows.Add(
                        department.Id,
                        department.Name,
                        department.ShortName,
                        department.Location,
                        department.Description,
                        department.GetLecturerCount(),
                        department.GetStudentCount()
                    );
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DepartmentEditForm editForm = new DepartmentEditForm(null, departmentRepository);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridDepartments.SelectedRows.Count > 0)
            {
                int selectedIndex = gridDepartments.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < displayedDepartments.Count)
                {
                    Department selectedDepartment = displayedDepartments[selectedIndex];
                    DepartmentEditForm editForm = new DepartmentEditForm(selectedDepartment, departmentRepository);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a department to edit.", "Edit Department", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridDepartments.SelectedRows.Count > 0)
            {
                int selectedIndex = gridDepartments.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < displayedDepartments.Count)
                {
                    Department selectedDepartment = displayedDepartments[selectedIndex];

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete department '{selectedDepartment.Name}' ({selectedDepartment.ShortName})?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            departmentRepository.Remove(selectedDepartment);
                            LoadData();
                            MessageBox.Show("Department deleted successfully.", "Delete Department", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a department to delete.", "Delete Department", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }

    public class DepartmentEditForm : Form
    {
        private Department department;
        private DepartmentRepository departmentRepository;
        private bool isNewDepartment;

        public DepartmentEditForm(Department department, DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
            this.isNewDepartment = department == null;

            if (isNewDepartment)
            {
                this.department = new Department();
                this.Text = "Add New Department";
            }
            else
            {
                this.department = department;
                this.Text = "Edit Department";
            }

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            lblId = new Label();
            txtId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblShortName = new Label();
            txtShortName = new TextBox();
            lblLocation = new Label();
            txtLocation = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
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
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 41);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 13);
            lblName.TabIndex = 2;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(87, 38);
            txtName.Name = "txtName";
            txtName.Size = new Size(280, 20);
            txtName.TabIndex = 3;
            // 
            // lblShortName
            // 
            lblShortName.AutoSize = true;
            lblShortName.Location = new Point(12, 67);
            lblShortName.Name = "lblShortName";
            lblShortName.Size = new Size(66, 13);
            lblShortName.TabIndex = 4;
            lblShortName.Text = "Short Name:";
            // 
            // txtShortName
            // 
            txtShortName.Location = new Point(87, 64);
            txtShortName.Name = "txtShortName";
            txtShortName.Size = new Size(280, 20);
            txtShortName.TabIndex = 5;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(12, 93);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(51, 13);
            lblLocation.TabIndex = 6;
            lblLocation.Text = "Location:";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(87, 90);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(280, 20);
            txtLocation.TabIndex = 7;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 119);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(63, 13);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(87, 116);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(280, 60);
            txtDescription.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(87, 196);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(168, 196);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // DepartmentEditForm
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            ClientSize = new Size(394, 241);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtLocation);
            Controls.Add(lblLocation);
            Controls.Add(txtShortName);
            Controls.Add(lblShortName);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtId);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DepartmentEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += DepartmentEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblId;
        private TextBox txtId;
        private Label lblName;
        private TextBox txtName;
        private Label lblShortName;
        private TextBox txtShortName;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;

        private void DepartmentEditForm_Load(object sender, EventArgs e)
        {
            // Generate a new ID for new departments
            if (isNewDepartment)
            {
                txtId.Text = Guid.NewGuid().ToString();
            }
            else
            {
                // Fill the form with department data
                FillForm();
            }

            // Set readonly fields
            txtId.ReadOnly = true;
        }

        private void FillForm()
        {
            txtId.Text = department.Id;
            txtName.Text = department.Name;
            txtShortName.Text = department.ShortName;
            txtLocation.Text = department.Location;
            txtDescription.Text = department.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter department name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtShortName.Text))
            {
                MessageBox.Show("Please enter short name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShortName.Focus();
                return;
            }

            // Check duplicate department ID
            if (isNewDepartment && departmentRepository.Exists(txtId.Text))
            {
                MessageBox.Show("Department ID already exists. Please enter a different ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update department object
            department.Id = txtId.Text;
            department.Name = txtName.Text;
            department.ShortName = txtShortName.Text;
            department.Location = txtLocation.Text;
            department.Description = txtDescription.Text;

            try
            {
                // Add or update department
                if (isNewDepartment)
                {
                    departmentRepository.Add(department);
                    MessageBox.Show("Department added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    departmentRepository.Update(department);
                    MessageBox.Show("Department updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}