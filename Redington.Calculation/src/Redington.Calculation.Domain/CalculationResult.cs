using System;
using System.Linq;
using System.Text;

namespace Redington.Calculation.Domain
{
    /// <summary>
    /// Class which represents the final state of a succesful calculation
    /// </summary>
    public class CalculationResult
    {
        public decimal Result { get; set; }

        public DateTimeOffset Date => DateTimeOffset.UtcNow;

        public string TypeOfCalculation { get; set; }

        public Probability[] Inputs { get; set; }

        public CalculationResult() {}

        /// <summary>
        /// Formats the succesful log that it will be save in the file
        /// </summary>
        /// <returns>The string to be logged.</returns>
        public string FormatFileString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(new string('#', 10));

            sb.AppendLine($"Successful Calculation - {Date:R}");
            sb.AppendLine($"Type: {TypeOfCalculation}");
            sb.AppendLine($"Inputs: {string.Join(',', Inputs.Select(x => x.Value))}");
            sb.AppendLine($"Result: {Result}");

            return sb.ToString();
        }
    }
}
