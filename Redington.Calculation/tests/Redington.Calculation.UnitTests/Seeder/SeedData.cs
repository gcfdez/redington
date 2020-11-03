using Redington.Calculation.Domain;

namespace Redington.Calculation.Api.Tests
{
    public static class SeedData
    {
        public static Probability CreateValidProbability() => new Probability(0.5m);
        public static Probability CreateValidProbabilityEqualsTo0() => new Probability(0);
        public static Probability CreateValidProbabilityEqualsTo1() => new Probability(1);
        public static Probability CreateInvalidProbabilityLessThan0() => new Probability(-0.10m);
        public static Probability CreateInvalidProbabilityGreatherThan1() => new Probability(1.10m);
        public static CombinedWithFunction CreateValidCombinedWithFunction() => new CombinedWithFunction(0.5m, 0.6m);
        public static CombinedWithFunction CreateInvalidCombinedWithFunctionWrongProbA() => new CombinedWithFunction(-1, 0.6m);
        public static CombinedWithFunction CreateInvalidCombinedWithFunctionWrongProbB() => new CombinedWithFunction(0.5m, 1.5m);
        public static EitherFunction CreateValidEitherFunction() => new EitherFunction(0.5m, 0.6m);
        public static EitherFunction CreateInvalidEitherFunctionWrongProbA() => new EitherFunction(-1, 0.6m);
        public static EitherFunction CreateInvalidEitherFunctionWrongProbB() => new EitherFunction(0.5m, 1.5m);
        public static CalculationRequest CreateValidCalculationRequest() => new CalculationRequest { A = 0.8m, B = 1};
        public static CalculationRequest CreateInvalidCalculationRequestWithWrongProbabilityA() => new CalculationRequest { A = 1.5m, B = 0.8m};
        public static CalculationRequest CreateInvalidCalculationRequestWithWrongProbabilityB() => new CalculationRequest { A = 0.2m, B = -0.8m};
    }
}
