using System;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp quản lý đăng ký môn học
    /// </summary>
    public class EnrollmentRepository : Repository<Enrollment>
    {
        // Fields
        private StudentRepository studentRepository;
        private CourseRepository courseRepository;

        // Constructors
        public EnrollmentRepository(StudentRepository studentRepository, CourseRepository courseRepository) : base("enrollments.dat")
        {
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }

        // Ghi đè các phương thức để đảm bảo lưu dữ liệu
        public override void Add(Enrollment enrollment)
        {
            base.Add(enrollment);
            SaveData();
        }

        public override void Update(Enrollment enrollment)
        {
            base.Update(enrollment);
            SaveData();
        }

        public override void Remove(Enrollment enrollment)
        {
            base.Remove(enrollment);
            SaveData();
        }

        // Methods
       protected override void LoadData()
{
    try
    {
        base.LoadData();
        
        // Kiểm tra null trước khi sử dụng
        if (studentRepository == null || courseRepository == null)
        {
            Console.WriteLine("WARNING: studentRepository or courseRepository is null in EnrollmentRepository.LoadData()");
            return;
        }
        
        // Link up Student and Course references that were lost during deserialization
        foreach (Enrollment enrollment in items)
        {
            try
            {
                string[] parts = enrollment.ToStorageString().Split('|');

                if (parts.Length >= 3)
                {
                    string studentId = parts[1];
                    string courseId = parts[2];

                    Student student = studentRepository.GetById(studentId);
                    Course course = courseRepository.GetById(courseId);

                    if (student != null && course != null)
                    {
                        enrollment.Student = student;
                        enrollment.Course = course;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing enrollment: {ex.Message}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error in EnrollmentRepository.LoadData: {ex.Message}");
        items = new List<Enrollment>();
    }
}

        public Enrollment GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            foreach (Enrollment enrollment in items)
            {
                if (enrollment.Id == id)
                {
                    return enrollment;
                }
            }

            return null;
        }

        public List<Enrollment> GetByStudent(Student student)
        {
            if (student == null)
            {
                return new List<Enrollment>();
            }

            List<Enrollment> result = new List<Enrollment>();
            foreach (Enrollment enrollment in items)
            {
                if (enrollment.Student != null && enrollment.Student.Id == student.Id)
                {
                    result.Add(enrollment);
                }
            }

            return result;
        }

        public List<Enrollment> GetByCourse(Course course)
        {
            if (course == null)
            {
                return new List<Enrollment>();
            }

            List<Enrollment> result = new List<Enrollment>();
            foreach (Enrollment enrollment in items)
            {
                if (enrollment.Course != null && enrollment.Course.Id == course.Id)
                {
                    result.Add(enrollment);
                }
            }

            return result;
        }

        public List<Enrollment> GetBySemester(string semester, string academicYear)
        {
            if (string.IsNullOrEmpty(semester) || string.IsNullOrEmpty(academicYear))
            {
                return new List<Enrollment>();
            }

            List<Enrollment> result = new List<Enrollment>();
            foreach (Enrollment enrollment in items)
            {
                if (enrollment.Semester == semester && enrollment.AcademicYear == academicYear)
                {
                    result.Add(enrollment);
                }
            }

            return result;
        }

        public List<Enrollment> GetByStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return new List<Enrollment>();
            }

            List<Enrollment> result = new List<Enrollment>();
            foreach (Enrollment enrollment in items)
            {
                if (enrollment.Status == status)
                {
                    result.Add(enrollment);
                }
            }

            return result;
        }

        public bool IsEnrolled(Student student, Course course, string semester, string academicYear)
        {
            if (student == null || course == null)
            {
                return false;
            }

            foreach (Enrollment enrollment in items)
            {
                if (enrollment.Student != null && enrollment.Student.Id == student.Id &&
                    enrollment.Course != null && enrollment.Course.Id == course.Id &&
                    enrollment.Semester == semester && enrollment.AcademicYear == academicYear)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Enrollment> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return new List<Enrollment>(items);
            }

            keyword = keyword.ToLower();
            List<Enrollment> result = new List<Enrollment>();
            foreach (Enrollment enrollment in items)
            {
                if (enrollment.Id.ToLower().Contains(keyword) ||
                    (enrollment.Student != null && enrollment.Student.FullName.ToLower().Contains(keyword)) ||
                    (enrollment.Course != null && enrollment.Course.Name.ToLower().Contains(keyword)) ||
                    enrollment.Semester.ToLower().Contains(keyword) ||
                    enrollment.AcademicYear.ToLower().Contains(keyword) ||
                    enrollment.Status.ToLower().Contains(keyword))
                {
                    result.Add(enrollment);
                }
            }

            return result;
        }
    }
}
