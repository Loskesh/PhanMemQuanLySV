using System;
using System.Collections.Generic;
using System.Diagnostics;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp quản lý sinh viên
    /// </summary>
    public class StudentRepository : Repository<Student>
    {
        // Constructors
        public StudentRepository() : base("students.dat")
        {
        }

        // Ghi đè các phương thức để đảm bảo lưu dữ liệu đúng
        public override void Add(Student student)
        {
            base.Add(student);
            SaveData(); // Đảm bảo lưu sau khi thêm
        }

        public override void Update(Student student)
        {
            base.Update(student);
            SaveData(); // Đảm bảo lưu sau khi cập nhật
        }

        public override void Remove(Student student)
        {
            base.Remove(student);
            SaveData(); // Đảm bảo lưu sau khi xóa
        }

        // Ghi đè phương thức LoadData để xử lý các tham chiếu của StudentState
        protected override void LoadData()
        {
            try
            {
                Console.WriteLine($"Loading data for {typeof(Student).Name} from {filename}");
                var loadedItems = fileManager.Deserialize<List<Student>>(filename);
                if (loadedItems != null)
                {
                    items = loadedItems;
                    Console.WriteLine($"Loaded {items.Count} items for {typeof(Student).Name}");

                    // Sửa các tham chiếu student trong state
                    foreach (var student in items)
                    {
                        student.FixStateReference();
                    }
                }
                else
                {
                    items = new List<Student>();
                    Console.WriteLine($"No data found, initialized empty list for {typeof(Student).Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data for {typeof(Student).Name}: {ex.Message}");
                Debug.WriteLine(ex.StackTrace);
                items = new List<Student>();
            }
        }

        // Methods
        public Student GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            foreach (Student student in items)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }

            return null;
        }

        public Student GetByStudentId(string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return null;
            }

            foreach (Student student in items)
            {
                if (student.StudentId == studentId)
                {
                    return student;
                }
            }

            return null;
        }

        public List<Student> GetByClassName(string className)
        {
            if (string.IsNullOrEmpty(className))
            {
                return new List<Student>();
            }

            List<Student> result = new List<Student>();
            foreach (Student student in items)
            {
                if (student.ClassName == className)
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public List<Student> GetByMajor(string major)
        {
            if (string.IsNullOrEmpty(major))
            {
                return new List<Student>();
            }

            List<Student> result = new List<Student>();
            foreach (Student student in items)
            {
                if (student.Major == major)
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public List<Student> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return new List<Student>(items);
            }

            keyword = keyword.ToLower();
            List<Student> result = new List<Student>();
            foreach (Student student in items)
            {
                if (student.Id.ToLower().Contains(keyword) ||
                    student.StudentId.ToLower().Contains(keyword) ||
                    student.FullName.ToLower().Contains(keyword) ||
                    student.ClassName.ToLower().Contains(keyword) ||
                    student.Major.ToLower().Contains(keyword))
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public List<Student> GetActiveStudents()
        {
            List<Student> result = new List<Student>();
            foreach (Student student in items)
            {
                if (student.State.GetStateName() == "Active")
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public List<Student> GetGraduatedStudents()
        {
            List<Student> result = new List<Student>();
            foreach (Student student in items)
            {
                if (student.State.GetStateName() == "Graduated")
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public List<Student> GetSuspendedStudents()
        {
            List<Student> result = new List<Student>();
            foreach (Student student in items)
            {
                if (student.State.GetStateName() == "Suspended")
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public List<Student> GetOnLeaveStudents()
        {
            List<Student> result = new List<Student>();
            foreach (Student student in items)
            {
                if (student.State.GetStateName() == "OnLeave")
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public List<Student> GetStudentsByState(string state)
        {
            if (string.IsNullOrEmpty(state))
            {
                return new List<Student>();
            }

            List<Student> result = new List<Student>();
            foreach (Student student in items)
            {
                if (student.State.GetStateName() == state)
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public bool Exists(string studentId)
        {
            return GetByStudentId(studentId) != null;
        }
    }
}