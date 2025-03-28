using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OOP1
{
    public class StudentStateConverter : JsonConverter<StudentState>
    {
        public override StudentState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Xử lý các kiểu token khác nhau
            if (reader.TokenType == JsonTokenType.String)
            {
                // Xử lý chuỗi như trước
                string stateName = reader.GetString();
                Student student = null;

                switch (stateName)
                {
                    case "Active":
                        return new ActiveState(student);
                    case "OnLeave":
                        return new OnLeaveState(student);
                    case "Graduated":
                        return new GraduatedState(student);
                    case "Suspended":
                        return new SuspendedState(student);
                    default:
                        return new ActiveState(student);
                }
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                // Xử lý khi token là một đối tượng
                // Đọc qua các thuộc tính của đối tượng để tìm "stateName" hoặc thuộc tính tương tự
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        break;

                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        string propertyName = reader.GetString();
                        reader.Read(); // Đọc giá trị của thuộc tính

                        if (propertyName.ToLower() == "name" || propertyName.ToLower() == "statename" && reader.TokenType == JsonTokenType.String)
                        {
                            // Lấy tên trạng thái từ thuộc tính
                            string stateName = reader.GetString();
                            Student student = null;

                            switch (stateName)
                            {
                                case "Active":
                                    return new ActiveState(student);
                                case "OnLeave":
                                    return new OnLeaveState(student);
                                case "Graduated":
                                    return new GraduatedState(student);
                                case "Suspended":
                                    return new SuspendedState(student);
                                default:
                                    return new ActiveState(student);
                            }
                        }
                    }
                }

                // Nếu không tìm thấy tên trạng thái trong đối tượng
                return new ActiveState(null);
            }

            // Mặc định trả về ActiveState
            return new ActiveState(null);
        }

        public override void Write(Utf8JsonWriter writer, StudentState value, JsonSerializerOptions options)
        {
            // Chỉ lưu tên của state
            writer.WriteStringValue(value.GetStateName());
        }
    }
}