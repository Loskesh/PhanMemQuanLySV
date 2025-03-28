using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OOP1
{
    /// <summary>
    /// Lớp quản lý đọc/ghi file, sử dụng Singleton pattern
    /// </summary>
    public sealed class FileManager
    {
        // Singleton instance
        private static readonly FileManager instance = new FileManager();

        // Fields
        private string dataPath;
        private readonly JsonSerializerOptions jsonOptions;

        // Private constructor to prevent instantiation
        private FileManager()
        {
            // Set default data path to a subfolder of the executable location
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            dataPath = Path.Combine(baseDirectory, "Data");

            // Create the data directory if it doesn't exist
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }

            Console.WriteLine($"Data Path: {dataPath}");

            // Cấu hình tùy chọn cho JSON serializer
            jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            // Đăng ký converter cho StudentState
            jsonOptions.Converters.Add(new StudentStateConverter());
        }

        // Public access to the singleton instance
        public static FileManager Instance
        {
            get { return instance; }
        }

        // Properties
        public string DataPath
        {
            get { return dataPath; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    dataPath = value;
                    if (!Directory.Exists(dataPath))
                    {
                        Directory.CreateDirectory(dataPath);
                    }
                }
            }
        }

        // Methods
        public void Serialize<T>(T obj, string filename)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj", "Object to serialize cannot be null.");
            }

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename", "Filename cannot be null or empty.");
            }

            string filePath = Path.Combine(dataPath, filename);
            Console.WriteLine($"Serializing to file: {filePath}");

            try
            {
                string jsonString = JsonSerializer.Serialize(obj, jsonOptions);
                File.WriteAllText(filePath, jsonString, Encoding.UTF8);
                Console.WriteLine($"Successfully serialized data to {filePath}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Serialization error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw new CustomException("Serialization failed. Make sure the object is serializable.", ex);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw new CustomException($"File operation failed for file {filename}.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw new CustomException("An error occurred during serialization.", ex);
            }
        }

        public T Deserialize<T>(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename", "Filename cannot be null or empty.");
            }

            string filePath = Path.Combine(dataPath, filename);
            Console.WriteLine($"Deserializing from file: {filePath}");

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return default(T);
            }

            try
            {
                string jsonString = File.ReadAllText(filePath, Encoding.UTF8);
                var result = JsonSerializer.Deserialize<T>(jsonString, jsonOptions);
                Console.WriteLine($"Successfully deserialized data from {filePath}");
                return result;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Deserialization error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw new CustomException("Deserialization failed. The file format may be invalid.", ex);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw new CustomException($"File operation failed for file {filename}.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw new CustomException("An error occurred during deserialization.", ex);
            }
        }

        public void WriteTextFile(string content, string filename)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content", "Content cannot be null.");
            }

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename", "Filename cannot be null or empty.");
            }

            string filePath = Path.Combine(dataPath, filename);

            try
            {
                File.WriteAllText(filePath, content, Encoding.UTF8);
            }
            catch (IOException ex)
            {
                throw new CustomException($"File operation failed for file {filename}.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException("An error occurred during file write operation.", ex);
            }
        }

        public string ReadTextFile(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename", "Filename cannot be null or empty.");
            }

            string filePath = Path.Combine(dataPath, filename);

            if (!File.Exists(filePath))
            {
                return string.Empty;
            }

            try
            {
                return File.ReadAllText(filePath, Encoding.UTF8);
            }
            catch (IOException ex)
            {
                throw new CustomException($"File operation failed for file {filename}.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException("An error occurred during file read operation.", ex);
            }
        }

        public void DeleteFile(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename", "Filename cannot be null or empty.");
            }

            string filePath = Path.Combine(dataPath, filename);

            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (IOException ex)
                {
                    throw new CustomException($"File operation failed for file {filename}.", ex);
                }
                catch (Exception ex)
                {
                    throw new CustomException("An error occurred during file delete operation.", ex);
                }
            }
        }

        public bool FileExists(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename", "Filename cannot be null or empty.");
            }

            string filePath = Path.Combine(dataPath, filename);
            return File.Exists(filePath);
        }
    }
}