using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public class DelimitedNumberParserSpecs
    {
        public class When_parsing : ConcernFor<DelimitedNumberParser>
        {
            protected IEnumerable<int> result;
            protected int[] numbers;
            protected string stringOfNumbers;

            protected override void Because()
            {
                result = Subject.Parse(stringOfNumbers);
            }

            protected override DelimitedNumberParser CreateSubject()
            {
                return new DelimitedNumberParser(',');
            }
        }

        public class When_parsing_numbers_from_a_comma_separated_string: When_parsing
        {
            [Test]
            public void Result_is_the_numbers()
            {
                Assert.That(result, Is.EqualTo(numbers));
            }

            protected override void Context()
            {
                stringOfNumbers = "1,2,3";
                numbers = new[] { 1, 2, 3 };
            }
        }

        public class When_parsing_numbers_from_an_empty_string : When_parsing {
            [Test]
            public void Result_to_be_no_numbers()
            {
                Assert.That(result, Is.Empty);
            }

            protected override void Context()
            {
                stringOfNumbers = "";
            }
        }
    }
}