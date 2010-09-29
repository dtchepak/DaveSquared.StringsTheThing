using System;
using NSubstitute;
using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public class StringCalculatorSpecs
    {
        public class When_adding_numbers_from_a_string: ConcernFor<StringCalculator>
        {
            int result;
            int sumOfTheNumbers;
            string stringOfNumbers;
            INumberParser numberParser;
            IAdder adder;

            [Test]
            public void Result_is_the_sum_of_the_numbers()
            {
                Assert.That(result, Is.EqualTo(sumOfTheNumbers));
            }

            protected override void Because()
            {
                result = Subject.Add(stringOfNumbers);
            }

            protected override void Context()
            {
                stringOfNumbers = "some numbers";
                sumOfTheNumbers = 123;
                numberParser = Substitute.For<INumberParser>();
                adder = Substitute.For<IAdder>();

                var numbers = new[] {1,2,3};
                numberParser.Parse(stringOfNumbers).Returns(numbers);
                adder.Add(numbers).Returns(sumOfTheNumbers);
            }
            protected override StringCalculator CreateSubject()
            {
                return new StringCalculator(numberParser, adder);
            }
        }
    }
}