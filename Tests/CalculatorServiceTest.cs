using Services;
using System;
using Xunit;

namespace Tests
{
    public class CalculatorServiceTest
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorServiceTest()
        {
            _calculatorService = new CalculatorService();
        }

        [Fact]
        public void Adding_Two_And_Two_Should_Equal_Four()
        {
            var m = 2;
            var n = 2;
            var result = _calculatorService.Add(m, n);
            Assert.Equal(4.0, result, 0);
        }
    }
}
