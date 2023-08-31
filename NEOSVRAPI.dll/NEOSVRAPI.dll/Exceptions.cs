
namespace NeosApiLibrary
{
    public class NeosApiException : Exception
    {
        public NeosApiException(string message, Exception innerException)
            : base(message, innerException)
        {
            LogError(message, innerException);
        }

        private void LogError(string message, Exception innerException)
        {
            string logFilePath = "error_log.txt"; 

            try
            {
                using (var writer = new StreamWriter(logFilePath, append: true))
                {
                    writer.WriteLine($"[ERROR] {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {message}");
                    writer.WriteLine($"Inner Exception: {innerException}");
                    writer.WriteLine(new string('-', 80));
                }
            }
            catch (Exception ex)
            {
                // If an error occurs while logging, catch and display the error
                Console.WriteLine($"Error while logging exception: {ex}");
            }
        }
    }
}
