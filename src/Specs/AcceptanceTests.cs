using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    [Ignore]
    public class AcceptanceTests
    {
        StringCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = null;
        }

        [Test]
        public void Return_zero_when_no_numbers_provided()
        {
            Assert.That(calculator.Add(""), Is.EqualTo(0));
        }

        [Test]
        public void Return_single_number_when_one_provided()
        {
            Assert.That(calculator.Add("1"), Is.EqualTo(1));
        }

        [Test]
        public void Return_sum_of_numbers_when_delimited_by_commas()
        {
            Assert.That(calculator.Add("1,2,3,4"), Is.EqualTo(10));
        }

        [Test]
        [Ignore]
        public void Return_sum_of_numbers_with_custom_delimiter()
        {
            Assert.That(calculator.Add("//;\n10;20;30;40"), Is.EqualTo(100));
        }
    }
}