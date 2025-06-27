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
                new TestData(1.1,1.2,2.3),
                new TestData(2,3,5),
                new TestData(2.4,3.9,6.3),
                new TestData(10,100,110)
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
    }
}
