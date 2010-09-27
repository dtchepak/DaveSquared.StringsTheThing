using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public class CalculatorExpressionParserSpecs
    {
        public class When_parsing_numbers_from_an_expression: ConcernFor<CalculatorExpressionParser>
        {
            IEnumerable<int> result;
            IEnumerable<int> numbers;
            string expression;
            IExpressionPartsParser expressionPartsParser;
            INumberParserFactory numberParserFactory;

            [Test]
            public void Result_is_the_numbers_in_that_expression()
            {
                Assert.That(result, Is.EqualTo(numbers));
            }

            protected override void Because()
            {
                result = Subject.Parse(expression);
            }

            protected override void Context()
            {
                expression = "the expression";
                numbers = new[] { 1, 2, 3 };
                const char delimiter = ';';
                const string remainder = "the rest of the expression";
                expressionPartsParser = Substitute.For<IExpressionPartsParser>();
                expressionPartsParser.Parse(expression).Returns(new ExpressionParts(delimiter, remainder));

                var numberParser = Substitute.For<INumberParser>();
                numberParser.Parse(remainder).Returns(numbers);

                numberParserFactory = Substitute.For<INumberParserFactory>();
                numberParserFactory.CreateWithDelimiter(delimiter).Returns(numberParser);
            }
            protected override CalculatorExpressionParser CreateSubject()
            {
                return new CalculatorExpressionParser(expressionPartsParser, numberParserFactory);
            }
        }
    }
}