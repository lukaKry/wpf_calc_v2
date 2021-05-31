using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Calc.UnitTests
{
    [TestFixture]
    class CalculatorTests
    {
        private Calculator _calc;

        [SetUp]
        public void SetUp()
        {
            _calc = new Calculator();
        }


        [Test]
        public void ChangeLastSymbolInTheMemory_SingleSymbolInMemory_MemoryChanged()
        {
            _calc.CurrentEquation.Symbols.Add("+");
            _calc.ChangeLastSymbolInTheMemory("-");
            Assert.That(_calc.CurrentEquation.Symbols[^1] == "-");
        }

        [Test]
        public void ChangeLastSymbolInTheMemory_MultipleSymbolsInMemory_MemoryChanged()
        {
            _calc.CurrentEquation.Symbols.AddRange(new string[] { "+", "-", "*" });
            _calc.ChangeLastSymbolInTheMemory("-");
            Assert.That(_calc.CurrentEquation.Symbols[^1] == "-");
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("0,5", 0.5)]
        public void AddNumberToTheMemory_WhenCalled_MamoryChange(string input, decimal expectedOutput)
        {
            _calc.AddNumberToTheMemory(input);
            Assert.That(_calc.CurrentEquation.Numbers[^1] == expectedOutput);

        }
    }
}
