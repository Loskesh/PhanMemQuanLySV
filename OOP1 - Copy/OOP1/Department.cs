using System;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp chứa thông tin khoa/ngành học
    /// </summary>
    [Serializable]
    public class Department : IStorable, IValidatable
    {
        // Properties
        private string id;
        private string name;
        private string shortName;
        private string description;
        private string location;
        private List<Lecturer> lecturers;
        private List<Student> students;

        // Constructors
        public Department()
        {
            lecturers = new List<Lecturer>();
            students = new List<Student>();
        }

        public Department(string id, string name, string shortName, string description, string location)
        {
            this.id = id;
            this.name = name;
            this.shortName = shortName;
            this.description = description;
            this.location = location;
            this.lecturers = new List<Lecturer>();
            this.students = new List<Student>();
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

        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public List<Lecturer> Lecturers
        {
            get { return lecturers; }
        }

        public List<Student> Students
        {
            get { return students; }
        }

        // Phương thức
        public void AddLecturer(Lecturer lecturer)
        {
            if (lecturer != null && !lecturers.Contains(lecturer))
            {
                lecturers.Add(lecturer);
            }
        }

        public void RemoveLecturer(Lecturer lecturer)
        {
            if (lecturer != null)
            {
                lecturers.Remove(lecturer);
            }
        }

        public void AddStudent(Student student)
        {
            if (student != null && !students.Contains(student))
            {
                students.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            if (student != null)
            {
                students.Remove(student);
            }
        }

        public int GetStudentCount()
        {
            return students.Count;
        }

        public int GetLecturerCount()
        {
            return lecturers.Count;
        }

        // Interface implementations
        public string ToStorageString()
        {
            return $"{id}|{name}|{shortName}|{description}|{location}";
        }

        public void FromStorageString(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException("Data cannot be null or empty.");
            }

            string[] parts = data.Split('|');
            if (parts.Length < 5)
            {
                throw new ArgumentException("Invalid data format.");
            }

            id = parts[0];
            name = parts[1];
            shortName = parts[2];
            description = parts[3];
            location = parts[4];
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name);
        }

        public string GetValidationMessage()
        {
            if (string.IsNullOrEmpty(id))
            {
                return "Mã khoa không được để trống.";
            }

            if (string.IsNullOrEmpty(name))
            {
                return "Tên khoa không được để trống.";
            }

            return string.Empty;
        }

        public override string ToString()
        {
            return $"{name} ({shortName})";
        }
    }
}