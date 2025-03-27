using calculator;

namespace TestCalculator
{
    [TestFixture]
    public class CalculatorStrategyTests
    {
        private Calculator calculator;
        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }
        [TestFixture]
        public class PlusStrategyTests
        {
            [TestCase(12, 1, 13)]
            [TestCase(-5, 5, 0)]
            [TestCase(-10, -9, -19)]
            [TestCase(0, -1, -1)]
            [TestCase(0, 0, 0)]
            public void SumCorrectlyTest(double i, double j, double excepted)
            {
                var strategy = new PlusStrategy();
                var result = strategy.Calculate(i, j);
                Assert.AreEqual(excepted, result);
            }
        }
        [TestFixture]
        public class MinusStrategyTests
        {
            [TestCase(-2, -2, 0)]
            [TestCase(-2, 2, -4)]
            [TestCase(0, 0, 0)]
            //[TestCase(-2.2, -1.3, -0.9)]
            [TestCase(-1, 2, -3)]
            public void MinusCorrectlyTest(double i, double j, double excepted)
            { 
                var strategy = new MinusStrategy();
                var result = strategy.Calculate(i, j);
                Assert.AreEqual(excepted, result);
            }
        }
        [TestFixture]
        public class MultiplicationStrategyTests
        {
            [TestCase(-2, -2, 4)]
            [TestCase(-2, 2, -4)]
            [TestCase(0, 0, 0)]
            [TestCase(14.5, 4.5, 65.25)]
            [TestCase(-10.1, 10, -101)]
            public void MultiplicationCorrectlyTest(double i, double j, double excepted)
            { 
                var strategy = new MultiplicationStrategy();
                var result = strategy.Calculate(i, j);
                Assert.AreEqual(excepted, result);
            }
        }
        [TestFixture]
        public class DivideStrategyTests
        {
            [TestCase(-2, -2, 1)]
            [TestCase(-2, 2, -1)]
            [TestCase(20, 2.5, 8)]
            public void DivideCorrectlyTest(double i, double j, double excepted)
            {
                var strategy = new DivideStrategy();
                var result = strategy.Calculate(i, j);
                Assert.AreEqual(excepted, result);
            }

            [Test]
            public void DivideByZeroExceptionTest()
            {
                var strategy = new DivideStrategy();
                Assert.Throws<DivideByZeroException>(() => strategy.Calculate(12, 0));
            }
        }
        [TestFixture]
        public class RemainderStrategyTests
        {
            [TestCase(7, 3, 1)]
            [TestCase(-7, 3, -1)]
            public void RemainderCorrectlyTest(double i, double j, double excepted)
            {
                var strategy = new RemainderStrategy();
                var result = strategy.Calculate(i, j);
                Assert.AreEqual(excepted, result);
            }

            [Test]
            public void RemainderDivideByZeroException()
            {
                var strategy = new RemainderStrategy();
                Assert.Throws<DivideByZeroException>(() => strategy.Calculate(23, 0.0));
            }
        }
        [TestFixture]
        public class PowStrategyTests
        {
            [TestCase(5, 0, 1)]
            public void PowCorrectlyTest(double i, double j, double excepted)
            {
                var strategy = new RemainderStrategy();
                var result = strategy.Calculate(i, j);
                Assert.AreEqual(excepted, result);
            }
        }
        [TestFixture]
        public class RootStrategyTests
        {
            [TestCase(8, 3, 2)]
            [TestCase(9, 2, 2)]
            public void RootCorrectlyTest(double i, double j, double excepted)
            {
                var strategy = new RootStrategy();
                var result = strategy.Calculate(8, 3);
                Assert.AreEqual(excepted, result, 0.0001);
            }

            [Test]
            public void Calculate_CalculatesRootOfNegativeNumber_ThrowsException()
            {
                var strategy = new RootStrategy();
                Assert.Throws<Exception>(() => strategy.Calculate(-9, 2));
            }

            [Test]
            public void RootWithZeroDegreeException()
            {
                var strategy = new RootStrategy();
                Assert.Throws<DivideByZeroException>(() => strategy.Calculate(9, 0));
            }
        }
    }
}