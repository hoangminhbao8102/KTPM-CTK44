using CalLib;

namespace NUnitTestCalLib
{
    public class UnitTestOperations
    {
        private Operations op;

        [SetUp]
        public void Setup()
        {
            op = new Operations();
        }

        [Test]
        public void SummationTest()
        {
            var list = new List<TestData>
            {
                new TestData(1, 2, 3),
                new TestData(4.5, 5.5, 10),
                new TestData(-2, 2, 0)
            };

            foreach (var item in list)
            {
                double result = op.Summation(item.a, item.b);
                Assert.That(result, Is.EqualTo(item.result).Within(0.001));
            }
        }

        [Test]
        public void SubtractionTest()
        {
            var list = new List<TestData>
            {
                new TestData(10, 3, 7),
                new TestData(0, 0, 0),
                new TestData(-5, -5, 0)
            };

            foreach (var item in list)
            {
                double result = op.Subtraction(item.a, item.b);
                Assert.That(result, Is.EqualTo(item.result).Within(0.001));
            }
        }

        [Test]
        public void MultiplicationTest()
        {
            var list = new List<TestData>
            {
                new TestData(2, 4, 8),
                new TestData(0, 5, 0),
                new TestData(-2, 3, -6)
            };

            foreach (var item in list)
            {
                double result = op.Multiplication(item.a, item.b);
                Assert.That(result, Is.EqualTo(item.result).Within(0.001));
            }
        }

        [Test]
        public void DivisionTest()
        {
            var list = new List<TestData>
            {
                new TestData(10, 2, 5),
                new TestData(5, 2, 2.5),
                new TestData(-6, -2, 3)
            };

            foreach (var item in list)
            {
                double result = op.Division(item.a, item.b);
                Assert.That(result, Is.EqualTo(item.result).Within(0.001));
            }
        }

        [Test]
        public void TestDivisionByZero()
        {
            Assert.That(() => op.Division(8, 0), Throws.TypeOf<DivideByZeroException>());
        }
    }
}
