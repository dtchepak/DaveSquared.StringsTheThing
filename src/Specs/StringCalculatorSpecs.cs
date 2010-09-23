using System;
using NSubstitute;
using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public class StringCalculatorSpecs
    {
        public class When_adding_the_numbers_in_a_string : ConcernFor<StringCalculator>
        {
            int result;
            int sumOfTheNumbers;
            string stringOfNumbers;
            INumberParser numberParser;
            IAdder adder;

            [Test]
            public void The_result_to_be_the_sum_of_the_numbers()
            {
                Assert.That(result, Is.EqualTo(sumOfTheNumbers));
            }

            protected override void Because()
            {
                result = Subject.Add(stringOfNumbers);
            }

            protected override void Context()
            {
                sumOfTheNumbers = 1234;
                stringOfNumbers = "some numbers";
                numberParser = Substitute.For<INumberParser>();
                adder = Substitute.For<IAdder>();

                var numbers = new[] { 1, 2, 3 };
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