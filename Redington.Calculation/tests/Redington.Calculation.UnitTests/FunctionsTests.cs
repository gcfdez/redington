using Redington.Calculation.Domain;
using System;
using Xunit;

namespace Redington.Calculation.Api.Tests
{
    public class FunctionsTests
    {
        [Fact]
        public void Create_Valid_CombinedWithFunction_And_Check_Results()
        {
            // Arrange
            var combinedWith = SeedData.CreateValidCombinedWithFunction();

            // Act
            var result = combinedWith.GetCalculationResult();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("CombinedWith: P(A)* P(B)", result.TypeOfCalculation);
            Assert.Equal(0.3m, result.Result);
        }

        [Fact]
        public void Create_InValid_CombinedWithFunction_With_InvalidProbabilityA()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SeedData.CreateInvalidCombinedWithFunctionWrongProbA());
        }

        [Fact]
        public void Create_InValid_CombinedWithFunction_With_InvalidProbabilityB()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SeedData.CreateInvalidCombinedWithFunctionWrongProbB());
        }

        [Fact]
        public void Create_Valid_EitherFunction_And_Check_Results()
        {
            // Arrange
            var combinedWith = SeedData.CreateValidEitherFunction();

            // Act
            var result = combinedWith.GetCalculationResult();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Either: P(A) + P(B) - P(A) * P(B)", result.TypeOfCalculation);
            Assert.Equal(0.8m, result.Result);
        }

        [Fact]
        public void Create_InValid_EitherFunction_With_InvalidProbabilityA()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SeedData.CreateInvalidEitherFunctionWrongProbA());
        }

        [Fact]
        public void Create_InValid_EitherFunction_With_InvalidProbabilityB()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SeedData.CreateInvalidEitherFunctionWrongProbB());
        }
    }
}
