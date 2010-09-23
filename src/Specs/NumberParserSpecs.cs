using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public class NumberParserSpecs
    {
        public class When_parsing : ConcernFor<NumberParser>
        {
            protected IEnumerable<int> result;
            protected int[] numbers;
            protected string stringOfNumbers;

            protected override void Because()
            {
                result = Subject.Parse(stringOfNumbers);
            }

            protected override NumberParser CreateSubject()
            {
                const char delimiter = ',';
                return new NumberParser(delimiter);
            }
        }

        public class When_parsing_numbers_delimited_by_commas : When_parsing
        {
            [Test]
            public void Should_return_the_numbers()
            {
                Assert.That(result, Is.EqualTo(numbers));
            }

            protected override void Context()
            {
                stringOfNumbers = "1,2,3";
                numbers = new[] { 1, 2, 3 };
            }
        }

        public class When_parsing_an_empty_string : When_parsing
        {
            [Test]
            public void Should_return_no_numbers()
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