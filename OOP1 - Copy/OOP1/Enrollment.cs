using System;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp chứa thông tin đăng ký môn học của sinh viên
    /// </summary>
    [Serializable]
    public class Enrollment : IStorable, IValidatable
    {
        // Properties
        private string id;
        private Student student;
        private Course course;
        private string semester;
        private string academicYear;
        private DateTime enrollmentDate;
        private Grade grade;
        private string status;

        // Constructors
        public Enrollment()
        {
            enrollmentDate = DateTime.Now;
            status = "Đã đăng ký";
        }

        public Enrollment(string id, Student student, Course course, string semester, string academicYear)
        {
            this.id = id;
            this.student = student;
            this.course = course;
            this.semester = semester;
            this.academicYear = academicYear;
            this.enrollmentDate = DateTime.Now;
            this.status = "Đã đăng ký";
        }

        // Getters và Setters
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public Student Student
        {
            get { return student; }
            set
            {
                if (student != null)
                {
                    student.RemoveEnrollment(this);
                }
                student = value;
                if (student != null)
                {
                    student.AddEnrollment(this);
                }
            }
        }

        public Course Course
        {
            get { return course; }
            set
            {
                if (course != null)
                {
                    course.RemoveEnrollment(this);
                }
                course = value;
                if (course != null)
                {
                    course.AddEnrollment(this);
                }
            }
        }

        public string Semester
        {
            get { return semester; }
            set { semester = value; }
        }

        public string AcademicYear
        {
            get { return academicYear; }
            set { academicYear = value; }
        }

        public DateTime EnrollmentDate
        {
            get { return enrollmentDate; }
            set { enrollmentDate = value; }
        }

        public Grade Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        // Phương thức
        public bool HasGrade()
        {
            return grade != null;
        }

        public bool IsPassing()
        {
            return grade != null && grade.IsPassing();
        }

        public void SetGrade(double attendanceScore, double assignmentScore, double midtermScore, double finalScore)
        {
            grade = new Grade(attendanceScore, assignmentScore, midtermScore, finalScore);
            status = grade.IsPassing() ? "Đã qua" : "Không đạt";
        }

        // Interface implementations
        public string ToStorageString()
        {
            string studentId = student != null ? student.Id : "";
            string courseId = course != null ? course.Id : "";
            string gradeString = grade != null ? grade.ToStorageString() : "";
            return $"{id}|{studentId}|{courseId}|{semester}|{academicYear}|{enrollmentDate.ToString("yyyy-MM-dd")}|{status}|{gradeString}";
        }

        public void FromStorageString(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException("Data cannot be null or empty.");
            }

            string[] parts = data.Split('|');
            if (parts.Length < 7)
            {
                throw new ArgumentException("Invalid data format.");
            }

            id = parts[0];
            // student and course will be set separately
            semester = parts[3];
            academicYear = parts[4];
            enrollmentDate = DateTime.Parse(parts[5]);
            status = parts[6];

            if (parts.Length > 7 && !string.IsNullOrEmpty(parts[7]))
            {
                grade = new Grade();
                grade.FromStorageString(parts[7]);
            }
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(semester) || string.IsNullOrEmpty(academicYear))
            {
                return false;
            }

            if (student == null || course == null)
            {
                return false;
            }

            return true;
        }

        public string GetValidationMessage()
        {
            if (string.IsNullOrEmpty(id))
            {
                return "ID đăng ký không được để trống.";
            }

            if (student == null)
            {
                return "Sinh viên không được để trống.";
            }

            if (course == null)
            {
                return "Môn học không được để trống.";
            }

            if (string.IsNullOrEmpty(semester))
            {
                return "Học kỳ không được để trống.";
            }

            if (string.IsNullOrEmpty(academicYear))
            {
                return "Năm học không được để trống.";
            }

            return string.Empty;
        }

        public override string ToString()
        {
            string studentName = student != null ? student.FullName : "N/A";
            string courseName = course != null ? course.Name : "N/A";
            return $"{studentName} - {courseName} ({semester}, {academicYear})";
        }
    }
}