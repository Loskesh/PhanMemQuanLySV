using System;
using System.Windows.Forms;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    public partial class LecturerForm : Form
    {
        private LecturerRepository lecturerRepository;
        private List<Lecturer> displayedLecturers;

        public LecturerForm(LecturerRepository lecturerRepository)
        {
            InitializeComponent();
            InitializeGridColumns();
            this.lecturerRepository = lecturerRepository;
            LoadData();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridLecturers = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLecturers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
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
            this.panel2.Controls.Add(this.gridLecturers);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 400);
            this.panel2.TabIndex = 1;
            // 
            // gridLecturers
            // 
            this.gridLecturers.AllowUserToAddRows = false;
            this.gridLecturers.AllowUserToDeleteRows = false;
            this.gridLecturers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLecturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLecturers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLecturers.Location = new System.Drawing.Point(0, 0);
            this.gridLecturers.MultiSelect = false;
            this.gridLecturers.Name = "gridLecturers";
            this.gridLecturers.ReadOnly = true;
            this.gridLecturers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLecturers.Size = new System.Drawing.Size(800, 400);
            this.gridLecturers.TabIndex = 0;
            // 
            // LecturerForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LecturerForm";
            this.Text = "Lecturer Management";
            this.Load += new System.EventHandler(this.LecturerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLecturers)).EndInit();
            this.ResumeLayout(false);

        }

        private Panel panel1;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private TextBox txtSearch;
        private Panel panel2;
        private DataGridView gridLecturers;

        private void InitializeGridColumns()
        {
            gridLecturers.ColumnCount = 7;
            gridLecturers.Columns[0].Name = "ID";
            gridLecturers.Columns[0].Visible = false;
            gridLecturers.Columns[1].Name = "Lecturer ID";
            gridLecturers.Columns[2].Name = "Full Name";
            gridLecturers.Columns[3].Name = "Department";
            gridLecturers.Columns[4].Name = "Position";
            gridLecturers.Columns[5].Name = "Specialization";
            gridLecturers.Columns[6].Name = "Joining Date";
        }

        private void LecturerForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            displayedLecturers = new List<Lecturer>();
            gridLecturers.Rows.Clear();

            foreach (Lecturer lecturer in lecturerRepository.Items)
            {
                string searchText = txtSearch.Text.ToLower();
                if (string.IsNullOrEmpty(searchText) ||
                    lecturer.LecturerId.ToLower().Contains(searchText) ||
                    lecturer.FullName.ToLower().Contains(searchText) ||
                    lecturer.Department.ToLower().Contains(searchText) ||
                    lecturer.Position.ToLower().Contains(searchText) ||
                    lecturer.Specialization.ToLower().Contains(searchText))
                {
                    displayedLecturers.Add(lecturer);
                    gridLecturers.Rows.Add(
                        lecturer.Id,
                        lecturer.LecturerId,
                        lecturer.FullName,
                        lecturer.Department,
                        lecturer.Position,
                        lecturer.Specialization,
                        lecturer.JoiningDate.ToShortDateString()
                    );
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LecturerEditForm editForm = new LecturerEditForm(null, lecturerRepository);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridLecturers.SelectedRows.Count > 0)
            {
                int selectedIndex = gridLecturers.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < displayedLecturers.Count)
                {
                    Lecturer selectedLecturer = displayedLecturers[selectedIndex];
                    LecturerEditForm editForm = new LecturerEditForm(selectedLecturer, lecturerRepository);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a lecturer to edit.", "Edit Lecturer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridLecturers.SelectedRows.Count > 0)
            {
                int selectedIndex = gridLecturers.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < displayedLecturers.Count)
                {
                    Lecturer selectedLecturer = displayedLecturers[selectedIndex];

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete lecturer '{selectedLecturer.FullName}' ({selectedLecturer.LecturerId})?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            lecturerRepository.Remove(selectedLecturer);
                            LoadData();
                            MessageBox.Show("Lecturer deleted successfully.", "Delete Lecturer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting lecturer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a lecturer to delete.", "Delete Lecturer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }

    public class LecturerEditForm : Form
    {
        private Lecturer lecturer;
        private LecturerRepository lecturerRepository;
        private bool isNewLecturer;

        public LecturerEditForm(Lecturer lecturer, LecturerRepository lecturerRepository)
        {
            this.lecturerRepository = lecturerRepository;
            this.isNewLecturer = lecturer == null;

            if (isNewLecturer)
            {
                this.lecturer = new Lecturer();
                this.Text = "Add New Lecturer";
            }
            else
            {
                this.lecturer = lecturer;
                this.Text = "Edit Lecturer";
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
            this.lblLecturerId = new System.Windows.Forms.Label();
            this.txtLecturerId = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.txtSpecialization = new System.Windows.Forms.TextBox();
            this.lblJoiningDate = new System.Windows.Forms.Label();
            this.dtpJoiningDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpAddress.SuspendLayout();
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
            // lblLecturerId
            // 
            this.lblLecturerId.AutoSize = true;
            this.lblLecturerId.Location = new System.Drawing.Point(303, 15);
            this.lblLecturerId.Name = "lblLecturerId";
            this.lblLecturerId.Size = new System.Drawing.Size(61, 13);
            this.lblLecturerId.TabIndex = 13;
            this.lblLecturerId.Text = "Lecturer ID:";
            // 
            // txtLecturerId
            // 
            this.txtLecturerId.Location = new System.Drawing.Point(370, 12);
            this.txtLecturerId.Name = "txtLecturerId";
            this.txtLecturerId.Size = new System.Drawing.Size(200, 20);
            this.txtLecturerId.TabIndex = 14;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(303, 41);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 13);
            this.lblDepartment.TabIndex = 15;
            this.lblDepartment.Text = "Department:";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(370, 38);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(200, 20);
            this.txtDepartment.TabIndex = 16;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(303, 67);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(47, 13);
            this.lblPosition.TabIndex = 17;
            this.lblPosition.Text = "Position:";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(370, 64);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(200, 20);
            this.txtPosition.TabIndex = 18;
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.Location = new System.Drawing.Point(303, 93);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(75, 13);
            this.lblSpecialization.TabIndex = 19;
            this.lblSpecialization.Text = "Specialization:";
            // 
            // txtSpecialization
            // 
            this.txtSpecialization.Location = new System.Drawing.Point(370, 90);
            this.txtSpecialization.Name = "txtSpecialization";
            this.txtSpecialization.Size = new System.Drawing.Size(200, 20);
            this.txtSpecialization.TabIndex = 20;
            // 
            // lblJoiningDate
            // 
            this.lblJoiningDate.AutoSize = true;
            this.lblJoiningDate.Location = new System.Drawing.Point(303, 120);
            this.lblJoiningDate.Name = "lblJoiningDate";
            this.lblJoiningDate.Size = new System.Drawing.Size(68, 13);
            this.lblJoiningDate.TabIndex = 21;
            this.lblJoiningDate.Text = "Joining Date:";
            // 
            // dtpJoiningDate
            // 
            this.dtpJoiningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJoiningDate.Location = new System.Drawing.Point(370, 117);
            this.dtpJoiningDate.Name = "dtpJoiningDate";
            this.dtpJoiningDate.Size = new System.Drawing.Size(200, 20);
            this.dtpJoiningDate.TabIndex = 22;
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
            // LecturerEditForm
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 339);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpJoiningDate);
            this.Controls.Add(this.lblJoiningDate);
            this.Controls.Add(this.txtSpecialization);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.txtLecturerId);
            this.Controls.Add(this.lblLecturerId);
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
            this.Name = "LecturerEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.LecturerEditForm_Load);
            this.grpAddress.ResumeLayout(false);
            this.grpAddress.PerformLayout();
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
        private Label lblLecturerId;
        private TextBox txtLecturerId;
        private Label lblDepartment;
        private TextBox txtDepartment;
        private Label lblPosition;
        private TextBox txtPosition;
        private Label lblSpecialization;
        private TextBox txtSpecialization;
        private Label lblJoiningDate;
        private DateTimePicker dtpJoiningDate;
        private Button btnSave;
        private Button btnCancel;

        private void LecturerEditForm_Load(object sender, EventArgs e)
        {
            // Set default values for Gender
            if (cboGender.Items.Count > 0 && cboGender.SelectedIndex < 0)
            {
                cboGender.SelectedIndex = 0;
            }

            // Generate a new ID for new lecturers
            if (isNewLecturer)
            {
                txtId.Text = Guid.NewGuid().ToString();
            }
            else
            {
                // Fill the form with lecturer data
                FillForm();
            }

            // Set readonly fields
            txtId.ReadOnly = true;
        }

        private void FillForm()
        {
            txtId.Text = lecturer.Id;
            txtFullName.Text = lecturer.FullName;
            dtpDateOfBirth.Value = lecturer.DateOfBirth;

            // Set gender
            switch (lecturer.Gender)
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

            txtEmail.Text = lecturer.Email;
            txtPhone.Text = lecturer.PhoneNumber;

            // Address
            txtStreet.Text = lecturer.Address.Street;
            txtDistrict.Text = lecturer.Address.District;
            txtCity.Text = lecturer.Address.City;
            txtZipCode.Text = lecturer.Address.ZipCode;
            txtCountry.Text = lecturer.Address.Country;

            // Lecturer specific
            txtLecturerId.Text = lecturer.LecturerId;
            txtDepartment.Text = lecturer.Department;
            txtPosition.Text = lecturer.Position;
            txtSpecialization.Text = lecturer.Specialization;
            dtpJoiningDate.Value = lecturer.JoiningDate;
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

            if (string.IsNullOrEmpty(txtLecturerId.Text))
            {
                MessageBox.Show("Please enter lecturer ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLecturerId.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDepartment.Text))
            {
                MessageBox.Show("Please enter department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepartment.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPosition.Text))
            {
                MessageBox.Show("Please enter position.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPosition.Focus();
                return;
            }

            // Check duplicate lecturer ID
            if (isNewLecturer && lecturerRepository.Exists(txtLecturerId.Text))
            {
                MessageBox.Show("Lecturer ID already exists. Please enter a different ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLecturerId.Focus();
                return;
            }

            // Update lecturer object
            lecturer.Id = txtId.Text;
            lecturer.FullName = txtFullName.Text;
            lecturer.DateOfBirth = dtpDateOfBirth.Value;
            lecturer.Gender = cboGender.SelectedItem.ToString();
            lecturer.Email = txtEmail.Text;
            lecturer.PhoneNumber = txtPhone.Text;

            // Update address
            if (lecturer.Address == null)
            {
                lecturer.Address = new Address();
            }
            lecturer.Address.Street = txtStreet.Text;
            lecturer.Address.District = txtDistrict.Text;
            lecturer.Address.City = txtCity.Text;
            lecturer.Address.ZipCode = txtZipCode.Text;
            lecturer.Address.Country = txtCountry.Text;

            // Update lecturer specific
            lecturer.LecturerId = txtLecturerId.Text;
            lecturer.Department = txtDepartment.Text;
            lecturer.Position = txtPosition.Text;
            lecturer.Specialization = txtSpecialization.Text;
            lecturer.JoiningDate = dtpJoiningDate.Value;

            try
            {
                // Add or update lecturer
                if (isNewLecturer)
                {
                    lecturerRepository.Add(lecturer);
                    MessageBox.Show("Lecturer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lecturerRepository.Update(lecturer);
                    MessageBox.Show("Lecturer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving lecturer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
