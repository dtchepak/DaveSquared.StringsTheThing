using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace DaveSquared.StringsTheThing.Specs
{
    public class AdderSpecs
    {
        public class When_adding : ConcernFor<Adder>
        {
            protected IEnumerable<int> numbers;
            protected int sumOfTheNumbers;
            protected int result;

            protected override void Because() { result = Subject.Add(numbers); }
            protected override Adder CreateSubject() { return new Adder(); }
        }

        public class When_adding_numbers : When_adding
        {
            [Test]
            public void Result_is_the_sum_of_the_numbers()
            {
                Assert.That(result, Is.EqualTo(sumOfTheNumbers));
            }

            protected override void Context()
            {
                numbers = new[] { 1, 2, 3 };
                sumOfTheNumbers = 6;
            }
        }

        public class When_adding_no_numbers : When_adding
        {
            [Test]
            public void The_result_is_zero()
            {
                Assert.That(result, Is.EqualTo(0));
            }

            protected override void Context()
            {
                numbers = new int[0];
            }
        }
    }
}