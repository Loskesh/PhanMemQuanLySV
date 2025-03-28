using System;
using System.IO;
using System.Windows.Forms;
using OOP1;

namespace OOP1
{
    public partial class MainForm : Form
    {
        private StudentRepository studentRepository;
        private CourseRepository courseRepository;
        private DepartmentRepository departmentRepository;
        private EnrollmentRepository enrollmentRepository;
        private LecturerRepository lecturerRepository;

        public MainForm()
        {
            InitializeComponent();

            // Initialize repositories
            studentRepository = new StudentRepository();
            courseRepository = new CourseRepository();
            departmentRepository = new DepartmentRepository();
            lecturerRepository = new LecturerRepository();
            enrollmentRepository = new EnrollmentRepository(studentRepository, courseRepository);

            // Register event handlers for data changes
            studentRepository.DataChanged += OnDataChanged;
            courseRepository.DataChanged += OnDataChanged;
            departmentRepository.DataChanged += OnDataChanged;
            enrollmentRepository.DataChanged += OnDataChanged;
            lecturerRepository.DataChanged += OnDataChanged;

            // Đăng ký sự kiện FormClosing
            this.FormClosing += MainForm_FormClosing;
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            managementToolStripMenuItem = new ToolStripMenuItem();
            studentsToolStripMenuItem = new ToolStripMenuItem();
            coursesToolStripMenuItem = new ToolStripMenuItem();
            departmentsToolStripMenuItem = new ToolStripMenuItem();
            enrollmentsToolStripMenuItem = new ToolStripMenuItem();
            lecturersToolStripMenuItem = new ToolStripMenuItem(); // New menu item for Lecturers
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            panelMain = new Panel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, managementToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1039, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(141, 34);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // managementToolStripMenuItem
            // 
            managementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { studentsToolStripMenuItem, coursesToolStripMenuItem, departmentsToolStripMenuItem, enrollmentsToolStripMenuItem, lecturersToolStripMenuItem });
            managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            managementToolStripMenuItem.Size = new Size(133, 29);
            managementToolStripMenuItem.Text = "&Management";
            // 
            // studentsToolStripMenuItem
            // 
            studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            studentsToolStripMenuItem.Size = new Size(217, 34);
            studentsToolStripMenuItem.Text = "&Students";
            studentsToolStripMenuItem.Click += studentsToolStripMenuItem_Click;
            // 
            // coursesToolStripMenuItem
            // 
            coursesToolStripMenuItem.Name = "coursesToolStripMenuItem";
            coursesToolStripMenuItem.Size = new Size(217, 34);
            coursesToolStripMenuItem.Text = "&Courses";
            coursesToolStripMenuItem.Click += coursesToolStripMenuItem_Click;
            // 
            // departmentsToolStripMenuItem
            // 
            departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            departmentsToolStripMenuItem.Size = new Size(217, 34);
            departmentsToolStripMenuItem.Text = "&Departments";
            departmentsToolStripMenuItem.Click += departmentsToolStripMenuItem_Click;
            // 
            // enrollmentsToolStripMenuItem
            // 
            enrollmentsToolStripMenuItem.Name = "enrollmentsToolStripMenuItem";
            enrollmentsToolStripMenuItem.Size = new Size(217, 34);
            enrollmentsToolStripMenuItem.Text = "&Enrollments";
            enrollmentsToolStripMenuItem.Click += enrollmentsToolStripMenuItem_Click;
            // 
            // lecturersToolStripMenuItem
            // 
            lecturersToolStripMenuItem.Name = "lecturersToolStripMenuItem";
            lecturersToolStripMenuItem.Size = new Size(217, 34);
            lecturersToolStripMenuItem.Text = "&Lecturers";
            lecturersToolStripMenuItem.Click += lecturersToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(164, 34);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 555);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1039, 32);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(60, 25);
            statusLabel.Text = "Ready";
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 33);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1039, 522);
            panelMain.TabIndex = 2;
            // 
            // MainForm
            // 
            ClientSize = new Size(1039, 587);
            Controls.Add(panelMain);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Student Management System";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem managementToolStripMenuItem;
        private ToolStripMenuItem studentsToolStripMenuItem;
        private ToolStripMenuItem coursesToolStripMenuItem;
        private ToolStripMenuItem departmentsToolStripMenuItem;
        private ToolStripMenuItem enrollmentsToolStripMenuItem;
        private ToolStripMenuItem lecturersToolStripMenuItem; // New menu item for Lecturers
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private Panel panelMain;

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Kiểm tra và chuẩn bị thư mục dữ liệu
            CheckDataDirectory();

            // Initialize with default view
            ShowStudentForm();
            UpdateStatusBar();
        }

        private void CheckDataDirectory()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string dataPath = Path.Combine(baseDir, "Data");

                Console.WriteLine($"Checking data directory: {dataPath}");

                if (!Directory.Exists(dataPath))
                {
                    Console.WriteLine("Data directory not found, creating...");
                    Directory.CreateDirectory(dataPath);
                }

                // Kiểm tra quyền ghi
                string testFile = Path.Combine(dataPath, "test.txt");
                File.WriteAllText(testFile, "Test write access");
                File.Delete(testFile);

                Console.WriteLine("Data directory is valid and writable");

                // Hiển thị thông tin về các file dữ liệu
                string[] dataFiles = Directory.GetFiles(dataPath, "*.dat");
                Console.WriteLine($"Found {dataFiles.Length} data files:");
                foreach (string file in dataFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine($"- {fileInfo.Name} ({fileInfo.Length} bytes, last modified: {fileInfo.LastWriteTime})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking data directory: {ex.Message}");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Console.WriteLine("Application closing - saving all data");

                // Lưu tất cả dữ liệu khi đóng ứng dụng
                studentRepository.SaveData();
                courseRepository.SaveData();
                departmentRepository.SaveData();
                enrollmentRepository.SaveData();
                lecturerRepository.SaveData();

                Console.WriteLine("All data saved successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when saving data: {ex.Message}");
                MessageBox.Show($"Có lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentForm();
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCourseForm();
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDepartmentForm();
        }

        private void enrollmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEnrollmentForm();
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLecturerForm();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Student Management System\nVersion 1.0\n\nDeveloped by:\n- Lê Nguyễn Minh Hoàng\n- Đàm Trung Hiếu\n- Nguyễn Hoàng Minh\n- Nguyễn Ngọc Thảo Vân",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void ShowStudentForm()
        {
            panelMain.Controls.Clear();
            StudentForm studentForm = new StudentForm(studentRepository);
            studentForm.TopLevel = false;
            studentForm.FormBorderStyle = FormBorderStyle.None;
            studentForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(studentForm);
            studentForm.Show();
            statusLabel.Text = "Managing Students";
        }

        private void ShowCourseForm()
        {
            panelMain.Controls.Clear();
            CourseForm courseForm = new CourseForm(courseRepository, departmentRepository);
            courseForm.TopLevel = false;
            courseForm.FormBorderStyle = FormBorderStyle.None;
            courseForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(courseForm);
            courseForm.Show();
            statusLabel.Text = "Managing Courses";
        }

        private void ShowDepartmentForm()
        {
            panelMain.Controls.Clear();
            DepartmentForm departmentForm = new DepartmentForm(departmentRepository);
            departmentForm.TopLevel = false;
            departmentForm.FormBorderStyle = FormBorderStyle.None;
            departmentForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(departmentForm);
            departmentForm.Show();
            statusLabel.Text = "Managing Departments";
        }

        private void ShowEnrollmentForm()
        {
            panelMain.Controls.Clear();
            EnrollmentForm enrollmentForm = new EnrollmentForm(enrollmentRepository, studentRepository, courseRepository);
            enrollmentForm.TopLevel = false;
            enrollmentForm.FormBorderStyle = FormBorderStyle.None;
            enrollmentForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(enrollmentForm);
            enrollmentForm.Show();
            statusLabel.Text = "Managing Enrollments";
        }

        private void ShowLecturerForm()
        {
            panelMain.Controls.Clear();
            LecturerForm lecturerForm = new LecturerForm(lecturerRepository);
            lecturerForm.TopLevel = false;
            lecturerForm.FormBorderStyle = FormBorderStyle.None;
            lecturerForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(lecturerForm);
            lecturerForm.Show();
            statusLabel.Text = "Managing Lecturers";
        }

        private void OnDataChanged(object sender, DataChangeEventArgs e)
        {
            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            int studentCount = studentRepository.Count();
            int courseCount = courseRepository.Count();
            int departmentCount = departmentRepository.Count();
            int enrollmentCount = enrollmentRepository.Count();
            int lecturerCount = lecturerRepository.Count();

            statusLabel.Text = $"Students: {studentCount} | Courses: {courseCount} | Departments: {departmentCount} | Enrollments: {enrollmentCount} | Lecturers: {lecturerCount}";
        }
    }
}