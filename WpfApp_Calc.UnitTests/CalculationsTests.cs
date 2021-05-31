using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Calc.UnitTests
{
    [TestFixture]
    class CalculationsTests
    {
        [Test]
        [TestCase(2, 2, "+", 4)]
        [TestCase(2, 2, "-", 0)]
        [TestCase(2, 3, "*", 6)]
        [TestCase(10, 2, "/", 5)]

        public void MakeCalculation_SimpleEquationWithTwoNumbers_CorrectResult(decimal firstNumber, decimal secondNumber, string symbol, decimal expectedResult)
        {
            var equation = new Equation
            {
                Numbers = new List<decimal> { firstNumber, secondNumber },
                Symbols = new List<string> { symbol }
            };

            var calc = new Calculations(equation);

            var result = calc.MakeCalculations();

            Assert.That(result, Is.EqualTo(expectedResult));

        }


        [Test]
        [TestCase(2.5, 2, "+", 4.5)]
        [TestCase(3, 2.1, "-", 0.9)]
        [TestCase(2.5, 3, "*", 7.5)]
        [TestCase(10, 0.2, "/", 50)]

        public void MakeCalculation_EquationWithFloatingPointNumbers_CorrectResult(decimal firstNumber, decimal secondNumber, string symbol, decimal expectedResult)
        {
            var equation = new Equation
            {
                Numbers = new List<decimal> { firstNumber, secondNumber },
                Symbols = new List<string> { symbol }
            };

            var calc = new Calculations(equation);

            var result = calc.MakeCalculations();

            Assert.That(result, Is.EqualTo(expectedResult));

        }
    }
}
