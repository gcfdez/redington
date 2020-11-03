using System;
using Xunit;

namespace Redington.Calculation.Api.Tests
{
    public class ProbabilityTests
    {
        [Fact]
        public void Create_Valid_Probability()
        {
            var prob = SeedData.CreateValidProbability();

            Assert.NotNull(prob);
            Assert.Equal(0.5m, prob.Value);
        }

        [Fact]
        public void Create_Valid_Probability_EqualsTo0()
        {
            var prob = SeedData.CreateValidProbabilityEqualsTo0();

            Assert.NotNull(prob);
            Assert.Equal(0, prob.Value);
        }

        [Fact]
        public void Create_Valid_Probability_EqualsTo1()
        {
            var prob = SeedData.CreateValidProbabilityEqualsTo1();

            Assert.NotNull(prob);
            Assert.Equal(1, prob.Value);
        }

        [Fact]
        public void Create_Invalid_Probability_LessThan0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SeedData.CreateInvalidProbabilityLessThan0());
        }

        [Fact]
        public void Create_Invalid_Probability_GreatherThan1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SeedData.CreateInvalidProbabilityGreatherThan1());
        }
    }
}
