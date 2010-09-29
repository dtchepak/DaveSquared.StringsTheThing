using System;
using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public class ExpressionPartsParserSpecs
    {
        public class When_parsing_expression_parts : ConcernFor<ExpressionPartsParser>
        {
            protected ExpressionParts result;
            protected string expression;

            protected override void Because()
            {
                result = Subject.Parse(expression);
            }

            protected override ExpressionPartsParser CreateSubject()
            {
                return new ExpressionPartsParser();
            }
        }

        public class When_parsing_expression_parts_from_an_expression_with_a_custom_delimiter : When_parsing_expression_parts
        {
            char delimiter;
            string remainder;

            [Test]
            public void Return_the_delimiter_from_the_expression()
            {
                Assert.That(result.Delimiter, Is.EqualTo(delimiter));
            }

            [Test]
            public void Return_the_remainder_of_the_expression_to_parse()
            {
                Assert.That(result.Remainder, Is.EqualTo(remainder));
            }

            protected override void Context()
            {
                delimiter = ';';
                remainder = "the rest of the expression";
                expression = string.Format("//{0}\n{1}", delimiter, remainder);
            }
        }

        public class When_parsing_parts_from_an_expression_without_a_custom_delimiter : When_parsing_expression_parts {

            [Test]
            public void Return_comma_as_the_default_delimiter()
            {
                Assert.That(result.Delimiter, Is.EqualTo(','));
            }

            [Test]
            public void Return_the_whole_expression_as_the_remainder_to_parse()
            {
                Assert.That(result.Remainder, Is.EqualTo(expression));
            }

            protected override void Context()
            {
                expression = "the expression";
            }
        }
    }

}