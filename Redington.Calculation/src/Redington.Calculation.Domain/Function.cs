namespace Redington.Calculation.Domain
{
    /// <summary>
    /// Abstract class that provides some common functionality for the derived classes (Either and CombinedWith)
    /// </summary>
    public abstract class Function
    {
        public Probability A { get; set; }
        public Probability B { get; set; }

        /// <summary>
        /// Gets the final state of the calculation using the overriden implementation of the derived classes.
        /// </summary>
        /// <returns></returns>
        public CalculationResult GetCalculationResult()
        {
            return new CalculationResult
            {
                Result = GetResult(),
                Inputs = new[] { A, B },
                TypeOfCalculation = GetTypeOfCalculation()
            };
        }

        public abstract string GetTypeOfCalculation();
        public abstract decimal GetResult();
    }
}
