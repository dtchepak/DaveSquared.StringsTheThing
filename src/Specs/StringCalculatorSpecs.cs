using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public class StringCalculatorSpecs
    {
        public class When_adding_numbers_in_a_string: ConcernFor<StringCalculator>
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
                sumOfTheNumbers = 2345;

                numberParser = Substitute.For<INumberParser>();
                adder = Substitute.For<IAdder>();

                IEnumerable<int> theNumbers = new[] {1,2,3};
                numberParser.Parse(stringOfNumbers).Returns(theNumbers);
                adder.Add(theNumbers).Returns(sumOfTheNumbers);
            }

            protected override StringCalculator CreateSubject()
            {
                return new StringCalculator(numberParser, adder);
            }
        }
    }
}