using System;
using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public class ExpressionPartsParserSpecs
    {
        public class When_parsing_expression : ConcernFor<ExpressionPartsParser>
        {
            protected char delimiter;
            protected string remainder;
            protected string expression;
            protected ExpressionParts result;

            protected override void Because()
            {
                result = Subject.Parse(expression);
            }

            protected override ExpressionPartsParser CreateSubject()
            {
                return new ExpressionPartsParser();
            }
        }

        public class When_parsing_an_expression_with_a_custom_delimiter : When_parsing_expression {

            [Test]
            public void Parts_should_have_the_custom_delimiter()
            {
                Assert.That(result.Delimiter, Is.EqualTo(delimiter));
            }

            [Test]
            public void Parts_should_have_the_remainder_of_the_expression()
            {
                Assert.That(result.Remainder, Is.EqualTo(remainder));
            }

            protected override void Context()
            {
                delimiter = ';';
                remainder = "the rest";
                expression = string.Format("//{0}\n{1}", delimiter, remainder);
            }
        }

        public class When_parsing_an_expression_with_no_custom_delimiter : When_parsing_expression
        {
            [Test]
            public void Parts_should_use_comma_as_default_delimiter()
            {
                Assert.That(result.Delimiter, Is.EqualTo(','));
            }

            [Test]
            public void Parts_remainder_should_be_the_entire_expression()
            {
                Assert.That(result.Remainder, Is.EqualTo(expression));
            }

            protected override void Context()
            {
                expression = "an expression without a delimiter";
            }
        }
    }
}