using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Calc.UnitTests
{
    [TestFixture]
    class DisplayTests
    {
        private Display _display;

        [SetUp]
        public void SetUp()
        {
            _display = new Display();
        }

        [Test]
        [TestCase("a")]
        [TestCase("1.2")]
        public void AddToDisplay_WhenCalled_AddedNewInputToTheContent(string input)
        {
            _display.AddToDisplay(input);
            Assert.That(_display.Content, Does.Contain(input));
        }

        [Test]
        public void ClearDisplay_WhenCalled_ContentIsEmptyString()
        {
            _display.ClearDisplay();
            Assert.That(_display.Content, Is.EqualTo(""));
        }

        [Test]
        public void ChangeDisplay_WhenCalled_ContentIsEqualToTheNewInput()
        {
            _display.Content = "+";
            _display.ChangeDisplay("-");
            Assert.That(_display.Content, Is.EqualTo("-"));
        }
    }
}
