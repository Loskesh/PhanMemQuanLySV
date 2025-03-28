using System;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp chứa thông tin điểm số
    /// </summary>
    [Serializable]
    public class Grade : IStorable, IValidatable
    {
        // Properties
        private double attendanceScore;
        private double assignmentScore;
        private double midtermScore;
        private double finalScore;
        private double value;
        private string letterGrade;

        // Constructors
        public Grade()
        {
            CalculateValue();
            CalculateLetterGrade();
        }

        public Grade(double attendanceScore, double assignmentScore, double midtermScore, double finalScore)
        {
            this.attendanceScore = attendanceScore;
            this.assignmentScore = assignmentScore;
            this.midtermScore = midtermScore;
            this.finalScore = finalScore;
            CalculateValue();
            CalculateLetterGrade();
        }

        // Getters và Setters
        public double AttendanceScore
        {
            get { return attendanceScore; }
            set { attendanceScore = value; CalculateValue(); CalculateLetterGrade(); }
        }

        public double AssignmentScore
        {
            get { return assignmentScore; }
            set { assignmentScore = value; CalculateValue(); CalculateLetterGrade(); }
        }

        public double MidtermScore
        {
            get { return midtermScore; }
            set { midtermScore = value; CalculateValue(); CalculateLetterGrade(); }
        }

        public double FinalScore
        {
            get { return finalScore; }
            set { finalScore = value; CalculateValue(); CalculateLetterGrade(); }
        }

        public double Value
        {
            get { return value; }
        }

        public string LetterGrade
        {
            get { return letterGrade; }
        }

        // Phương thức
        private void CalculateValue()
        {
            // Giả sử: 10% điểm danh, 20% bài tập, 20% giữa kỳ, 50% cuối kỳ
            this.value = (attendanceScore * 0.1) + (assignmentScore * 0.2) + (midtermScore * 0.2) + (finalScore * 0.5);

            // Đảm bảo điểm nằm trong khoảng 0-10
            if (this.value < 0) this.value = 0;
            if (this.value > 10) this.value = 10;
        }

        private void CalculateLetterGrade()
        {
            if (this.value >= 9.0)
            {
                letterGrade = "A+";
            }
            else if (this.value >= 8.5)
            {
                letterGrade = "A";
            }
            else if (this.value >= 8.0)
            {
                letterGrade = "B+";
            }
            else if (this.value >= 7.0)
            {
                letterGrade = "B";
            }
            else if (this.value >= 6.5)
            {
                letterGrade = "C+";
            }
            else if (this.value >= 5.5)
            {
                letterGrade = "C";
            }
            else if (this.value >= 5.0)
            {
                letterGrade = "D+";
            }
            else if (this.value >= 4.0)
            {
                letterGrade = "D";
            }
            else
            {
                letterGrade = "F";
            }
        }

        public bool IsPassing()
        {
            return this.value >= 4.0;
        }

        // Interface implementations
        public string ToStorageString()
        {
            return $"{attendanceScore}|{assignmentScore}|{midtermScore}|{finalScore}|{value}|{letterGrade}";
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

            attendanceScore = double.Parse(parts[0]);
            assignmentScore = double.Parse(parts[1]);
            midtermScore = double.Parse(parts[2]);
            finalScore = double.Parse(parts[3]);
            // value and letterGrade will be calculated
            CalculateValue();
            CalculateLetterGrade();
        }

        public bool IsValid()
        {
            return attendanceScore >= 0 && attendanceScore <= 10 &&
                   assignmentScore >= 0 && assignmentScore <= 10 &&
                   midtermScore >= 0 && midtermScore <= 10 &&
                   finalScore >= 0 && finalScore <= 10;
        }

        public string GetValidationMessage()
        {
            if (attendanceScore < 0 || attendanceScore > 10)
            {
                return "Điểm chuyên cần phải nằm trong khoảng 0-10.";
            }

            if (assignmentScore < 0 || assignmentScore > 10)
            {
                return "Điểm bài tập phải nằm trong khoảng 0-10.";
            }

            if (midtermScore < 0 || midtermScore > 10)
            {
                return "Điểm giữa kỳ phải nằm trong khoảng 0-10.";
            }

            if (finalScore < 0 || finalScore > 10)
            {
                return "Điểm cuối kỳ phải nằm trong khoảng 0-10.";
            }

            return string.Empty;
        }

        public override string ToString()
        {
            return $"{value:F2} ({letterGrade})";
        }
    }
}