using Redington.Calculation.Domain;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Redington.Calculation.Api
{
    /// <summary>
    /// Service that works as logging
    /// </summary>
    public class LogFileService : ILogFileService
    {
        /// <summary>
        /// initialization
        /// </summary>
        public LogFileService()
        {
            FileInfo = new FileInfo($"./logs.txt");
            FileFullName = FileInfo.FullName;
        }

        private FileInfo FileInfo { get; }
        private string FileFullName { get; }

        /// <summary>
        /// Logs the calculation in the file when failing
        /// </summary>
        /// <param name="errorMessage">Exception's error message</param>
        /// <param name="type">Type of function</param>
        /// <returns></returns>
        public async Task LogError(string errorMessage, string type)
        {
            await File.AppendAllTextAsync(FileFullName, FormatLogError(errorMessage, type));
        }

        /// <summary>
        /// Logs the successful calculation in the file
        /// </summary>
        /// <param name="calculationResult">Result of the calculation</param>
        /// <returns></returns>
        public async Task LogInfo(CalculationResult calculationResult)
        {
            await File.AppendAllTextAsync(FileFullName, calculationResult.FormatFileString());
        }

        /// <summary>
        /// Formats the error message that it will be save in the file
        /// </summary>
        /// <param name="errorMessage">Exception's error message</param>
        /// <param name="type">Type of function</param>
        /// <returns>The string to be loggged</returns>
        private string FormatLogError(string errorMessage, string type)
        {
            var sb = new StringBuilder();

            sb.AppendLine(new string('#', 10));
            sb.AppendLine($"Calculation Failed - {DateTimeOffset.UtcNow:R}");
            sb.AppendLine($"Type: {type}");
            sb.AppendLine($"Error: {errorMessage}");

            return sb.ToString();
        }
    }
}
