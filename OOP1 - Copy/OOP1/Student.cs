using System;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp chứa thông tin sinh viên
    /// </summary>
    [Serializable]
    public class Student : Person
    {
        // Properties
        private string studentId;
        private string className;
        private string major;
        private int intake;
        private StudentState state;
        private List<Enrollment> enrollments;

        // Constructors
        public Student() : base()
        {
            enrollments = new List<Enrollment>();
        }

        public Student(
            string id, string fullName, DateTime dateOfBirth, string gender,
            string email, string phoneNumber, Address address,
            string studentId, string className, string major, int intake
        ) : base(id, fullName, dateOfBirth, gender, email, phoneNumber, address)
        {
            this.studentId = studentId;
            this.className = className;
            this.major = major;
            this.intake = intake;
            this.state = new ActiveState(this);
            this.enrollments = new List<Enrollment>();
        }

        // Getters và Setters
        public string StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        public string Major
        {
            get { return major; }
            set { major = value; }
        }

        public int Intake
        {
            get { return intake; }
            set { intake = value; }
        }

        public StudentState State
        {
            get { return state; }
            set { state = value; }
        }

        public List<Enrollment> Enrollments
        {
            get { return enrollments; }
        }

        // Phương thức
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

        public void ChangeState(StudentState newState)
        {
            state = newState;
        }

        // Phương thức sửa tham chiếu sau khi deserialize
        public void FixStateReference()
        {
            if (state != null)
            {
                state.SetStudent(this);
            }
        }

        public double CalculateGPA()
        {
            Console.WriteLine("Calculating GPA...");

            if (enrollments == null || enrollments.Count == 0)
            {
                Console.WriteLine("No enrollments found for GPA calculation");
                return 0.0;
            }

            double totalPoints = 0.0;
            int totalCredits = 0;
            int validEnrollments = 0;

            foreach (Enrollment enrollment in enrollments)
            {
                Console.WriteLine($"Processing enrollment: {enrollment.Id}");

                if (enrollment.HasGrade() && enrollment.Course != null)
                {
                    double gradeValue = enrollment.Grade.Value;
                    int credits = enrollment.Course.Credits;

                    Console.WriteLine($"Course: {enrollment.Course.Name}, Credits: {credits}, Grade: {gradeValue}");

                    totalPoints += gradeValue * credits;
                    totalCredits += credits;
                    validEnrollments++;
                }
                else
                {
                    Console.WriteLine("Enrollment skipped (no grade or no course)");
                }
            }

            Console.WriteLine($"Processed {validEnrollments} valid enrollments out of {enrollments.Count} total");

            if (totalCredits == 0)
            {
                Console.WriteLine("No valid credits found for GPA calculation");
                return 0.0;
            }

            double gpa = totalPoints / totalCredits;
            Console.WriteLine($"GPA calculation result: {gpa:F2} (Total points: {totalPoints}, Total credits: {totalCredits})");
            return gpa;
        }

        // Override
        public override string GetDescription()
        {
            return $"Sinh viên: {FullName}, Mã SV: {studentId}, Lớp: {className}, Ngành: {major}";
        }

        public override string ToStorageString()
        {
            string baseString = base.ToStorageString();
            return $"{baseString}|{studentId}|{className}|{major}|{intake}|{state.GetStateName()}";
        }

        public override void FromStorageString(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException("Data cannot be null or empty.");
            }

            string[] parts = data.Split('|');
            if (parts.Length < 12) // Base person (7) + Student (5)
            {
                throw new ArgumentException("Invalid data format.");
            }

            base.FromStorageString(string.Join("|", parts, 0, 7));

            studentId = parts[7];
            className = parts[8];
            major = parts[9];
            intake = int.Parse(parts[10]);
            string stateName = parts[11];
            switch (stateName)
            {
                case "Active":
                    state = new ActiveState(this);
                    break;
                case "OnLeave":
                    state = new OnLeaveState(this);
                    break;
                case "Graduated":
                    state = new GraduatedState(this);
                    break;
                case "Suspended":
                    state = new SuspendedState(this);
                    break;
                default:
                    state = new ActiveState(this);
                    break;
            }
        }

        public override bool IsValid()
        {
            if (!base.IsValid())
            {
                return false;
            }

            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(className) || string.IsNullOrEmpty(major))
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

            if (string.IsNullOrEmpty(studentId))
            {
                return "Mã sinh viên không được để trống.";
            }

            if (string.IsNullOrEmpty(className))
            {
                return "Lớp không được để trống.";
            }

            if (string.IsNullOrEmpty(major))
            {
                return "Ngành không được để trống.";
            }

            return string.Empty;
        }
    }
}