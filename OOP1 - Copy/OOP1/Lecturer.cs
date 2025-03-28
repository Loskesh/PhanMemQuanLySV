using System;
using System.Collections.Generic;
using OOP1;


namespace OOP1
{
    /// <summary>
    /// Lớp chứa thông tin giảng viên
    /// </summary>
    [Serializable]
    public class Lecturer : Person
    {
        // Properties
        private string lecturerId;
        private string department;
        private string position;
        private string specialization;
        private DateTime joiningDate;
        private List<Course> courses;

        // Constructors
        public Lecturer() : base()
        {
            courses = new List<Course>();
        }

        public Lecturer(
            string id, string fullName, DateTime dateOfBirth, string gender,
            string email, string phoneNumber, Address address,
            string lecturerId, string department, string position, string specialization, DateTime joiningDate
        ) : base(id, fullName, dateOfBirth, gender, email, phoneNumber, address)
        {
            this.lecturerId = lecturerId;
            this.department = department;
            this.position = position;
            this.specialization = specialization;
            this.joiningDate = joiningDate;
            this.courses = new List<Course>();
        }

        // Getters và Setters
        public string LecturerId
        {
            get { return lecturerId; }
            set { lecturerId = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public DateTime JoiningDate
        {
            get { return joiningDate; }
            set { joiningDate = value; }
        }

        public List<Course> Courses
        {
            get { return courses; }
        }

        // Phương thức
        public void AddCourse(Course course)
        {
            if (course != null && !courses.Contains(course))
            {
                courses.Add(course);
            }
        }

        public void RemoveCourse(Course course)
        {
            if (course != null)
            {
                courses.Remove(course);
            }
        }

        public int GetYearsOfService()
        {
            DateTime today = DateTime.Today;
            int years = today.Year - joiningDate.Year;
            if (joiningDate.Date > today.AddYears(-years))
            {
                years--;
            }
            return years;
        }

        // Override
        public override string GetDescription()
        {
            return $"Giảng viên: {FullName}, Mã GV: {lecturerId}, Khoa: {department}, Chức vụ: {position}";
        }

        public override string ToStorageString()
        {
            string baseString = base.ToStorageString();
            return $"{baseString}|{lecturerId}|{department}|{position}|{specialization}|{joiningDate.ToString("yyyy-MM-dd")}";
        }

        public override void FromStorageString(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException("Data cannot be null or empty.");
            }

            string[] parts = data.Split('|');
            if (parts.Length < 12) // Base person (7) + Lecturer (5)
            {
                throw new ArgumentException("Invalid data format.");
            }

            base.FromStorageString(string.Join("|", parts, 0, 7));

            lecturerId = parts[7];
            department = parts[8];
            position = parts[9];
            specialization = parts[10];
            joiningDate = DateTime.Parse(parts[11]);
        }

        public override bool IsValid()
        {
            if (!base.IsValid())
            {
                return false;
            }

            if (string.IsNullOrEmpty(lecturerId) || string.IsNullOrEmpty(department) || string.IsNullOrEmpty(position))
            {
                return false;
            }

            if (joiningDate > DateTime.Now)
            {
                return false;
            }

            return true;
        }

        public override string GetValidationMessage()
        {
            string baseMessage = base.GetValidationMessage();
            if (!string.IsNullOrEmpty(baseMessage))
            {
                return baseMessage;
            }

            if (string.IsNullOrEmpty(lecturerId))
            {
                return "Mã giảng viên không được để trống.";
            }

            if (string.IsNullOrEmpty(department))
            {
                return "Khoa/Phòng ban không được để trống.";
            }

            if (string.IsNullOrEmpty(position))
            {
                return "Chức vụ không được để trống.";
            }

            if (joiningDate > DateTime.Now)
            {
                return "Ngày nhận công tác không hợp lệ (không thể sau ngày hiện tại).";
            }

            return string.Empty;
        }
    }
}