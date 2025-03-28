using System;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp cơ sở chứa thông tin chung về con người
    /// </summary>
    [Serializable]
    public abstract class Person : IStorable, IValidatable
    {
        // Properties
        private string id;
        private string fullName;
        private DateTime dateOfBirth;
        private string gender;
        private string email;
        private string phoneNumber;
        private Address address;

        // Constructors
        public Person()
        {
            address = new Address();
        }

        public Person(string id, string fullName, DateTime dateOfBirth, string gender, string email, string phoneNumber, Address address)
        {
            this.id = id;
            this.fullName = fullName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address ?? new Address();
        }

        // Getters và Setters
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value ?? new Address(); }
        }

        // Phương thức
        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        // Interface implementations
        public virtual string ToStorageString()
        {
            return $"{id}|{fullName}|{dateOfBirth.ToString("yyyy-MM-dd")}|{gender}|{email}|{phoneNumber}|{address.ToStorageString()}";
        }

        public virtual void FromStorageString(string data)
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
            fullName = parts[1];
            dateOfBirth = DateTime.Parse(parts[2]);
            gender = parts[3];
            email = parts[4];
            phoneNumber = parts[5];
            address = new Address();
            address.FromStorageString(parts[6]);
        }

        public virtual bool IsValid()
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(fullName))
            {
                return false;
            }

            if (dateOfBirth > DateTime.Now || GetAge() > 100)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(email) && !email.Contains("@"))
            {
                return false;
            }

            return address.IsValid();
        }

        public virtual string GetValidationMessage()
        {
            if (string.IsNullOrEmpty(id))
            {
                return "ID không được để trống.";
            }

            if (string.IsNullOrEmpty(fullName))
            {
                return "Họ tên không được để trống.";
            }

            if (dateOfBirth > DateTime.Now)
            {
                return "Ngày sinh không hợp lệ (không thể sau ngày hiện tại).";
            }

            if (GetAge() > 100)
            {
                return "Ngày sinh không hợp lệ (tuổi quá lớn).";
            }

            if (!string.IsNullOrEmpty(email) && !email.Contains("@"))
            {
                return "Email không hợp lệ.";
            }

            if (!address.IsValid())
            {
                return address.GetValidationMessage();
            }

            return string.Empty;
        }

        // Phương thức trừu tượng
        public abstract string GetDescription();
    }
}