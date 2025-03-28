using System;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp chứa thông tin địa chỉ
    /// </summary>
    [Serializable]
    public class Address : IStorable, IValidatable
    {
        // Properties
        private string street;
        private string district;
        private string city;
        private string zipCode;
        private string country;

        // Constructors
        public Address()
        {
            country = "Việt Nam";
        }

        public Address(string street, string district, string city, string zipCode, string country)
        {
            this.street = street;
            this.district = district;
            this.city = city;
            this.zipCode = zipCode;
            this.country = country ?? "Việt Nam";
        }

        // Getters và Setters
        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string District
        {
            get { return district; }
            set { district = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value ?? "Việt Nam"; }
        }

        // Phương thức
        public string GetFullAddress()
        {
            return $"{street}, {district}, {city}, {zipCode}, {country}";
        }

        // Interface implementations
        public string ToStorageString()
        {
            return $"{street}~{district}~{city}~{zipCode}~{country}";
        }

        public void FromStorageString(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException("Data cannot be null or empty.");
            }

            string[] parts = data.Split('~');
            if (parts.Length < 5)
            {
                throw new ArgumentException("Invalid data format.");
            }

            street = parts[0];
            district = parts[1];
            city = parts[2];
            zipCode = parts[3];
            country = parts[4];
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(country);
        }

        public string GetValidationMessage()
        {
            if (string.IsNullOrEmpty(city))
            {
                return "Thành phố không được để trống.";
            }

            if (string.IsNullOrEmpty(country))
            {
                return "Quốc gia không được để trống.";
            }

            return string.Empty;
        }

        public override string ToString()
        {
            return GetFullAddress();
        }
    }
}