namespace OOP1
{
    /// <summary>
    /// Định nghĩa các phương thức cần thiết cho đối tượng có thể lưu trữ
    /// </summary>
    public interface IStorable
    {
        /// <summary>
        /// Chuyển đổi đối tượng thành dạng có thể lưu trữ
        /// </summary>
        /// <returns>Chuỗi thông tin của đối tượng</returns>
        string ToStorageString();

        /// <summary>
        /// Khôi phục đối tượng từ dạng lưu trữ
        /// </summary>
        /// <param name="data">Chuỗi thông tin lưu trữ</param>
        void FromStorageString(string data);
    }
}