using CalLib;

namespace UnitTestCalLib
{
    [TestClass]
    public class UnitTestOperations
    {
        [TestMethod]
        public void SummationTest()
        {
            // Chuẩn bị các bộ dữ liệu
            var testDatas = new TestData[]
            {
                new TestData(1.1, 1.2, 2.3),
                new TestData(2, 3, 5),
                new TestData(2.4, 3.9, 6.3),
                new TestData(10, 100, 110)
            };
            Operations op = new Operations();
            // Phương thức Test
            foreach (var item in testDatas)
            {
                // Gọi phương thức Phép cộng
                var res = op.Summation(item.a, item.b);
                // Kiểm tra kết quả
                Assert.AreEqual(item.result, res);
            }
        }
        [TestMethod]
        public void SubtractionTest()
        {
            // Chuẩn bị các bộ dữ liệu
            var testDatas = new TestData[]
            {
                new TestData(5, 2, 3),
                new TestData(10, 4.5, 5.5),
                new TestData(-3, -3, 0)
            };
            Operations op = new Operations();
            // Phương thức Test
            foreach (var item in testDatas)
            {
                // Gọi phương thức Phép trừ
                var res = op.Subtraction(item.a, item.b);
                // Kiểm tra kết quả
                Assert.AreEqual(item.result, res);
            }
        }
        [TestMethod]
        public void MultiplicationTest()
        {
            // Chuẩn bị các bộ dữ liệu
            var testDatas = new TestData[]
            {
                new TestData(2, 3, 6),
                new TestData(0, 5, 0),
                new TestData(-2, 4, -8)
            };
            Operations op = new Operations();
            // Phương thức Test
            foreach (var item in testDatas)
            {
                // Gọi phương thức Phép nhân
                var res = op.Multiplication(item.a, item.b);
                // Kiểm tra kết quả
                Assert.AreEqual(item.result, res);
            }
        }
        [TestMethod]
        public void DivisionTest()
        {
            // Chuẩn bị các bộ dữ liệu
            var testDatas = new TestData[]
            {
                new TestData(10, 2, 5),
                new TestData(-9, 3, -3),
                new TestData(5, 2, 2.5)
            };
            Operations op = new Operations();
            // Phương thức Test
            foreach (var item in testDatas)
            {
                // Gọi phương thức Phép chia
                var res = op.Division(item.a, item.b);
                // Kiểm tra kết quả
                Assert.AreEqual(item.result, res);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroTest()
        {
            Operations op = new Operations();
            var res = op.Division(10, 0); // Gây exception
        }
    }
}
