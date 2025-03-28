namespace OOP1
{
    /// <summary>
    /// Định nghĩa các phương thức kiểm tra tính hợp lệ của đối tượng
    /// </summary>
    public interface IValidatable
    {
        /// <summary>
        /// Kiểm tra tính hợp lệ của đối tượng
        /// </summary>
        /// <returns>True nếu hợp lệ, False nếu không hợp lệ</returns>
        bool IsValid();

        /// <summary>
        /// Lấy thông báo lỗi nếu đối tượng không hợp lệ
        /// </summary>
        /// <returns>Chuỗi thông báo lỗi</returns>
        string GetValidationMessage();
    }
}