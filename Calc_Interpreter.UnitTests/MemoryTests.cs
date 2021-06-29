using NUnit.Framework;

namespace Calc_Interpreter.UnitTests
{
    public class MemoryTests
    {
        [Test]
        public void AddNumberToTheMemory_SimpleNumber_CurrentEquationChange()
        {
            var memory = new Memory();
            memory.AddNumberToTheMemory(2m);
            Assert.That(memory.CurrentEquation.Numbers[^1] == 2);
        }

        [Test]
        public void AddCalculationToTheMemory_AddSumCalculation_CurrentEquationChange()
        {
            var memory = new Memory();
            memory.AddCalculationToTheMemory(new Sum());
            Assert.That(memory.CurrentEquation.Calculations.Count > 0);
        }
    }
}
