using System;

namespace OOP1
{
    /// <summary>
    /// Lớp cơ sở cho các exception tùy chỉnh
    /// </summary>
    public class CustomException : Exception
    {
        // Properties
        private string errorCode;

        // Constructors
        public CustomException() : base()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CustomException(string message, string errorCode) : base(message)
        {
            this.errorCode = errorCode;
        }

        public CustomException(string message, string errorCode, Exception innerException) : base(message, innerException)
        {
            this.errorCode = errorCode;
        }

        // Getters
        public string ErrorCode
        {
            get { return errorCode; }
        }

        // Methods
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(errorCode))
            {
                return $"Error {errorCode}: {Message}";
            }
            return base.ToString();
        }
    }

    public class DataAccessException : CustomException
    {
        public DataAccessException() : base()
        {
        }

        public DataAccessException(string message) : base(message, "DAT001")
        {
        }

        public DataAccessException(string message, Exception innerException) : base(message, "DAT001", innerException)
        {
        }
    }

    public class ValidationException : CustomException
    {
        public ValidationException() : base()
        {
        }

        public ValidationException(string message) : base(message, "VAL001")
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, "VAL001", innerException)
        {
        }
    }

    public class BusinessRuleException : CustomException
    {
        public BusinessRuleException() : base()
        {
        }

        public BusinessRuleException(string message) : base(message, "BUS001")
        {
        }

        public BusinessRuleException(string message, Exception innerException) : base(message, "BUS001", innerException)
        {
        }
    }
}