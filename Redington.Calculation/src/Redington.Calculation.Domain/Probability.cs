using System;

namespace Redington.Calculation.Domain
{
    /// <summary>
    /// Class which represents each input
    /// </summary>
    public class Probability
    {
        public decimal Value { get; private set; }

        /// <summary>
        /// Initialization checking whether the value is valid or not (between 0 and 1)
        /// </summary>
        /// <param name="value">Probability</param>
        public Probability(decimal value)
        {
            if (value < 0 || value > 1) throw new ArgumentOutOfRangeException(nameof(Value), $"Value [{value}] is not valid");

            Value = value;
        }
    }
}
