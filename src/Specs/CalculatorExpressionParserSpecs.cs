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
            int[] numbers;
            string expression;
            IExpressionPartsParser expressionPartsParser;
            INumberParser numberParser;
            INumberParserFactory numberParserFactory;

            [Test]
            public void Return_the_numbers()
            {
                Assert.That(result, Is.EqualTo(numbers));
            }

            protected override void Because()
            {
                result = Subject.Parse(expression);
            }

            protected override void Context()
            {
                expression = "some expression";
                numbers = new[] { 1, 2, 3, 4 };
                var delimiter = ';';
                var remainder = "the rest of the expression";
                expressionPartsParser = Substitute.For<IExpressionPartsParser>();
                expressionPartsParser.Parse(expression).Returns(new ExpressionParts(delimiter, remainder));

                numberParser = Substitute.For<INumberParser>();
                numberParser.Parse(remainder).Returns(numbers);

                numberParserFactory = Substitute.For<INumberParserFactory>();
                numberParserFactory.CreateForDelimiter(delimiter).Returns(numberParser);
            }

            protected override CalculatorExpressionParser CreateSubject()
            {
                return new CalculatorExpressionParser(expressionPartsParser, numberParserFactory);
            }
        }
    }
}