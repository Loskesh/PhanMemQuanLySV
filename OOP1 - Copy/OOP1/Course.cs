using System;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp chứa thông tin khóa học/môn học
    /// </summary>
    [Serializable]
    public class Course : IStorable, IValidatable
    {
        // Properties
        private string id;
        private string name;
        private string code;
        private int credits;
        private string description;
        private Department department;
        private List<Lecturer> lecturers;
        private List<Enrollment> enrollments;

        // Constructors
        public Course()
        {
            lecturers = new List<Lecturer>();
            enrollments = new List<Enrollment>();
        }

        public Course(string id, string name, string code, int credits, string description, Department department)
        {
            this.id = id;
            this.name = name;
            this.code = code;
            this.credits = credits;
            this.description = description;
            this.department = department;
            this.lecturers = new List<Lecturer>();
            this.enrollments = new List<Enrollment>();
        }

        // Getters và Setters
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public int Credits
        {
            get { return credits; }
            set { credits = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public List<Lecturer> Lecturers
        {
            get { return lecturers; }
        }

        public List<Enrollment> Enrollments
        {
            get { return enrollments; }
        }

        // Phương thức
        public void AddLecturer(Lecturer lecturer)
        {
            if (lecturer != null && !lecturers.Contains(lecturer))
            {
                lecturers.Add(lecturer);
                lecturer.AddCourse(this);
            }
        }

        public void RemoveLecturer(Lecturer lecturer)
        {
            if (lecturer != null)
            {
                lecturers.Remove(lecturer);
                lecturer.RemoveCourse(this);
            }
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            if (enrollment != null && !enrollments.Contains(enrollment))
            {
                enrollments.Add(enrollment);
            }
        }

        public void RemoveEnrollment(Enrollment enrollment)
        {
            if (enrollment != null)
            {
                enrollments.Remove(enrollment);
            }
        }

        public int GetStudentCount()
        {
            return enrollments.Count;
        }

        // Interface implementations
        public string ToStorageString()
        {
            string departmentId = department != null ? department.Id : "";
            return $"{id}|{name}|{code}|{credits}|{description}|{departmentId}";
        }

        public void FromStorageString(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException("Data cannot be null or empty.");
            }

            string[] parts = data.Split('|');
            if (parts.Length < 6)
            {
                throw new ArgumentException("Invalid data format.");
            }

            id = parts[0];
            name = parts[1];
            code = parts[2];
            credits = int.Parse(parts[3]);
            description = parts[4];
            // Note: The department object will be set separately
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(code))
            {
                return false;
            }

            if (credits <= 0)
            {
                return false;
            }

            return true;
        }

        public string GetValidationMessage()
        {
            if (string.IsNullOrEmpty(id))
            {
                return "ID môn học không được để trống.";
            }

            if (string.IsNullOrEmpty(name))
            {
                return "Tên môn học không được để trống.";
            }

            if (string.IsNullOrEmpty(code))
            {
                return "Mã môn học không được để trống.";
            }

            if (credits <= 0)
            {
                return "Số tín chỉ phải lớn hơn 0.";
            }

            return string.Empty;
        }

        public override string ToString()
        {
            return $"{code} - {name} ({credits} tín chỉ)";
        }
    }
}