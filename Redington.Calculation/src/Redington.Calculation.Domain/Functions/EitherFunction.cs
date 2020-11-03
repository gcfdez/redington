namespace Redington.Calculation.Domain
{
    /// <summary>
    /// Class which represents the either function
    /// </summary>
    public class EitherFunction : Function
    {
        /// <summary>
        /// Initialization with values as parameters
        /// </summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        public EitherFunction(Probability a, Probability b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Initialization with values as parameters
        /// </summary>
        /// <param name="a">Input A</param>
        /// <param name="b">Input B</param>
        public EitherFunction(decimal a, decimal b)
        {
            A = new Probability(a);
            B = new Probability(b);
        }

        /// <summary>
        /// Gets the type of operation
        /// </summary>
        /// <returns>The type of calculation</returns>
        public override string GetTypeOfCalculation()
        {
            return "Either: P(A) + P(B) - P(A) * P(B)";
        }

        /// <summary>
        /// Operation which calculates the total for this specific function.
        /// </summary>
        /// <returns></returns>
        public override decimal GetResult()
        {
            return A.Value + B.Value - A.Value * B.Value;
        }
    }
}
