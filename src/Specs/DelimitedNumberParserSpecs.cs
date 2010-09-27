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
            protected int[] theNumbers;
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

        public class When_parsing_numbers_from_a_comma_delimited_string: When_parsing
        {
            [Test]
            public void Result_is_the_numbers_in_the_string()
            {
                Assert.That(result, Is.EqualTo(theNumbers));
            }

            protected override void Context()
            {
                stringOfNumbers = "1,2,3";
                theNumbers = new[] { 1, 2, 3 };
            }
        }

        public class When_parsing_numbers_from_an_empty_string : When_parsing
        {
            [Test]
            public void Result_is_no_numbers()
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