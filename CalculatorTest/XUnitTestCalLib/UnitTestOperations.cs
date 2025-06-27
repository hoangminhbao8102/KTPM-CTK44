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
        public void SummationTest(int a, int b, int expectedRes)
        {
            var res = op.Summation(a, b); // Chạy phép toán
            Assert.True(expectedRes == res); // Kiểm tra kết quả
        }
    }
}
