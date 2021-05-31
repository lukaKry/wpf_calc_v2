using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Calc.UnitTests
{
    [TestFixture]
    class MyApplicationTests
    {
        private MyApplication _myApp;

        [SetUp]
        public void SetUp()
        {
            _myApp = new MyApplication();
        }


        // NumberButton Tests
        [Test]
        public void NumberButtonIsClicked_WhenCalled_ChangeMainDisplayContent()
        {
            _myApp.NumberButtonIsClicked("9");
            Assert.That(_myApp.MainDisplay.Content.Contains("9"));
        }


        // SymbolButtonIsClicked Tests
        [Test]
        public void SymbolButtonIsClicked_WhenCalled_ClearMainDisplay()
        {
            _myApp.MainDisplay.Content = "9";
            _myApp.SymbolButtonIsClicked("+");
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo(""));
        }

        [Test]
        public void SymbolButtonIsClicked_WhenCalled_ChangeAdditionalDisplay()
        {
            _myApp.MainDisplay.Content = "9";
            _myApp.SymbolButtonIsClicked("+");
            Assert.That(_myApp.AdditionalDisplay.Content, Is.EqualTo("9 + "));
        }

        [Test]
        public void SymbolButtonIsClicked_WhenCalled_CalculatorMemoryUpdate_Symbols()
        {
            _myApp.MainDisplay.Content = "9";
            _myApp.SymbolButtonIsClicked("+");
            Assert.That(_myApp.Calculator.CurrentEquation.Symbols[^1] == "+");
        }

        [Test]
        public void SymbolButtonIsClicked_WhenCalled_CalculatorMemoryUpdate_Numbers()
        {
            _myApp.MainDisplay.Content = "9";
            _myApp.SymbolButtonIsClicked("+");
            Assert.That(_myApp.Calculator.CurrentEquation.Numbers[^1] == 9);
        }


        // SymbolChange Tests
        [Test]
        public void SymbolChange_WhenCalled_ChangeAdditionalDisplayContent()
        {
            
            _myApp.AdditionalDisplay.Content = "9 + ";
            _myApp.Calculator.CurrentEquation.Numbers.Add(9);
            _myApp.Calculator.CurrentEquation.Symbols.Add("+");
            _myApp.SymbolChange("-");

            Assert.That(_myApp.AdditionalDisplay.Content, Is.EqualTo("9 - "));
            Assert.That(_myApp.Calculator.CurrentEquation.Symbols[^1] == "-");
        }


        // EqualSignIsClicked Tests
        [Test]
        public void EqualSignIsClicked_WhenCalled_AddCurrentDisplayContentToTheMemory()
        {
            _myApp.MainDisplay.Content = "5";
            _myApp.EqualSignIsClicked();
            Assert.That(_myApp.Calculator.CurrentEquation.Numbers[^1] == 5);
        }

        [Test]
        public void EqualSignIsClicked_WhenCalled_CalculateResult()
        {
            _myApp.Calculator.CurrentEquation.Numbers.Add(2);
            _myApp.Calculator.CurrentEquation.Symbols.Add("+");
            _myApp.MainDisplay.Content = "2";
            _myApp.EqualSignIsClicked();
            Assert.That(_myApp.Calculator.CurrentEquation.Result, Is.EqualTo(4));
        }

        [Test]
        public void EqualSignIsClicked_WhenCalled_DisplayResult()
        {
            _myApp.Calculator.CurrentEquation.Numbers.Add(2);
            _myApp.Calculator.CurrentEquation.Symbols.Add("+");
            _myApp.MainDisplay.Content = "2";
            _myApp.EqualSignIsClicked();
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("4"));
        }


        // CommaButtonIsClicked Tests
        [Test]
        public void CommaButtonIsClicked_WhenMainDisplayIsEmpty_AddZeroAndCommaToTheDisplay()
        {
            _myApp.MainDisplay.Content = "";

            _myApp.CommaButtonIsClicked();

            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("0,"));
        }

        [Test]
        public void CommaButtonIsClicked_WhenMainDisplayIsNotEmpty_AddZeroAndCommaToTheDisplay()
        {
            _myApp.MainDisplay.Content = "5";

            _myApp.CommaButtonIsClicked();

            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("5,"));
        }


        // ClearButtonIsClicked Tests
        [Test]
        public void ClearButtonIsClicked_WhenCalled_ClearDisplayAndCurrentEquation()
        {
            _myApp.MainDisplay.Content = "5";
            _myApp.AdditionalDisplay.Content = "5 + ";
            _myApp.Calculator.CurrentEquation = new Equation { Numbers = new List<decimal> { 5 }, Symbols = new List<string> { "+" } };

            _myApp.ClearButtonIsClicked();

            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo(""));
            Assert.That(_myApp.AdditionalDisplay.Content, Is.EqualTo(""));
            Assert.That(_myApp.Calculator.CurrentEquation.Numbers.Count == 0);
            Assert.That(_myApp.Calculator.CurrentEquation.Symbols.Count == 0);
            Assert.That(_myApp.Calculator.CurrentEquation.Result == 0);
        }


        // Work flow tests
        [Test]
        public void WorkFlowTest_SimpleAddition()
        {
            _myApp.NumberButtonIsClicked("2");
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("2"));

            _myApp.SymbolButtonIsClicked("+");
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo(""));
            Assert.That(_myApp.AdditionalDisplay.Content, Is.EqualTo("2 + "));

            _myApp.NumberButtonIsClicked("2");
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("2"));

            _myApp.EqualSignIsClicked();
            Assert.That(_myApp.AdditionalDisplay.Content, Is.EqualTo("2 + 2"));
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("4"));
        }

        [Test]
        public void WorkFlowTest_SimpleSubstraction()
        {
            _myApp.NumberButtonIsClicked("2");
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("2"));

            _myApp.SymbolButtonIsClicked("-");
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo(""));
            Assert.That(_myApp.AdditionalDisplay.Content, Is.EqualTo("2 - "));

            _myApp.NumberButtonIsClicked("2");
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("2"));

            _myApp.EqualSignIsClicked();
            Assert.That(_myApp.AdditionalDisplay.Content, Is.EqualTo("2 - 2"));
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("0"));
        }


        [Test]
        public void WorkFlowTest_SimpleMultiplication()
        {
            _myApp.NumberButtonIsClicked("2");
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("2"));

            _myApp.SymbolButtonIsClicked("*");
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo(""));
            Assert.That(_myApp.AdditionalDisplay.Content, Is.EqualTo("2 * "));

            _myApp.NumberButtonIsClicked("3");
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("3"));

            _myApp.EqualSignIsClicked();
            Assert.That(_myApp.AdditionalDisplay.Content, Is.EqualTo("2 * 3"));
            Assert.That(_myApp.MainDisplay.Content, Is.EqualTo("6"));
        }
    }
}
