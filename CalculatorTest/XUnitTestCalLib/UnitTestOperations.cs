using CalLib;

namespace XUnitTestCalLib
{
    public class UnitTestOperations
    {
        public Operations op = new Operations();

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-10, 2, -8)]
        [InlineData(100, 72, 172)]
        public void SummationTest(double a, double b, double expectedRes)
        {
            var res = op.Summation(a, b); // Chạy phép toán
            Assert.True(expectedRes == res); // Kiểm tra kết quả
        }

        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(-3, -3, 0)]
        [InlineData(7.5, 2.5, 5)]
        public void SubtractionTest(double a, double b, double expectedRes)
        {
            var res = op.Subtraction(a, b); // Chạy phép toán
            Assert.True(expectedRes == res); // Kiểm tra kết quả
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-2, -4, 8)]
        [InlineData(0, 10, 0)]
        public void MultiplicationTest(double a, double b, double expectedRes)
        {
            var res = op.Multiplication(a, b); // Chạy phép toán
            Assert.True(expectedRes == res); // Kiểm tra kết quả
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(9, 3, 3)]
        [InlineData(5, 2, 2.5)]
        public void Division(double a, double b, double expectedRes)
        {
            var res = op.Division(a, b); // Chạy phép toán
            Assert.True(expectedRes == res); // Kiểm tra kết quả
        }

        [Fact]
        public void DivisionByZeroTest()
        {
            Assert.Throws<DivideByZeroException>(() => op.Division(10, 0));
        }
    }
}
