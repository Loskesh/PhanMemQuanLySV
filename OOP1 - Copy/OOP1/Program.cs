using System;
using System.IO;
using System.Windows.Forms;
using OOP1;

namespace OOP1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Thiết lập log file để debug
            SetupConsoleOutput();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Console.WriteLine("Starting application");
            Application.Run(new MainForm());
            Console.WriteLine("Application terminated");
        }

        private static void SetupConsoleOutput()
        {
            try
            {
                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_log.txt");
                FileStream fileStream = new FileStream(logPath, FileMode.Create, FileAccess.Write, FileShare.Read);
                StreamWriter writer = new StreamWriter(fileStream);
                writer.AutoFlush = true;
                Console.SetOut(writer);
                Console.SetError(writer);

                Console.WriteLine($"=== Application started at {DateTime.Now} ===");
                Console.WriteLine($"Base directory: {AppDomain.CurrentDomain.BaseDirectory}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting up logging: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}