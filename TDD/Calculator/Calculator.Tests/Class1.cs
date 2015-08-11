using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void ShouldAddTwoNumbers()
        {
            var sut = new SimpleCalculator();

            int result = sut.Add(5, 10);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void ShouldMultiplyTwoNumbers()
        {
            var sut = new SimpleCalculator();

            int result = sut.Multiply(10, 5);

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void shouldJoinTwoNames()
        {
            var sut = new SimpleFunctions();

            string fullName = sut.JoinToNames("Shibu", "Thannikkunnath");

            Assert.That(fullName,Is.EqualTo("Shibu Thannikkunnath"));
        }

        [Test]
        public void ShouldJoinTwoNamesCaseIgnore()
        {
            var sut = new SimpleFunctions();

            string fullName = sut.JoinToNames("Shibu", "Thannikkunnath");

            Assert.That(fullName, Is.EqualTo("SHIBU THANNIKKUNNATH").IgnoreCase );
        }

        [Test]
        public void ShouldJoinTwoNamesNotEqualto()
        {
            var sut = new SimpleFunctions();

            string fullName = sut.JoinToNames("Shibu", "Thannikkunnath");

            Assert.That(fullName, Is.Not.EqualTo("SHIBU THANNIKKUNNATH"));
        }

        [Test]
        public void AddDoublewithTolerance()
        {
            var sut = new SimpleCalculator();

            double result = sut.AddDouble(1.1, 2.2);

            Assert.That(result, Is.EqualTo(3.3).Within(0.1));
        }

        [Test]
        public void AddDoublewithPercent()
        {
            var sut = new SimpleCalculator();

            double result = sut.AddDouble(50, 50);

            Assert.That(result, Is.EqualTo(101).Within(1).Percent);
        }
    }
}
