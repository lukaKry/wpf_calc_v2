using Calc_Interpreter.Calculations;
using NUnit.Framework;

namespace Calc_Interpreter.UnitTests
{
    public class Tests
    {
        // private Memory _memory;

        [SetUp]
        public void Setup()
        {
           //  _memory = new();
        }


        /* tested cases 
          2+2           simple addition
          2+2+2         
          3-2           simple subtraction
          2-2-2 
          3*2           simple multiplication

          2+2*2         mixed priority
          2+2-2         equal priority
          2+2*2*2+2*2   complex priority
        */



        [Test]
        public void SimpleSum_TwoArguments()
        {
            // 2 + 2

            var memory = new Memory();

            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Sum());
            memory.AddNumberToTheMemory(2m);
            memory.CurrentEquation = Solver.Solve(memory.CurrentEquation);

            Assert.That(memory.CurrentEquation.Result == 4);
        }

        [Test]
        public void SimpleSum_ThreeArguments()
        {
            // 2 + 2 + 2

            var memory = new Memory();

            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Sum());
            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Sum());
            memory.AddNumberToTheMemory(2m);
            memory.CurrentEquation = Solver.Solve(memory.CurrentEquation);

            Assert.That(memory.CurrentEquation.Result == 6);
        }

        [Test]
        public void SimpleSubtraction_TwoArguments()
        {
            // 3 - 2

            var memory = new Memory();

            memory.AddNumberToTheMemory(3m);
            memory.AddCalculationToTheMemory(new Subtraction());
            memory.AddNumberToTheMemory(2m);
            memory.CurrentEquation = Solver.Solve(memory.CurrentEquation);

            Assert.That(memory.CurrentEquation.Result == 1);
        }

        [Test]
        public void SimpleSubtraction_ThreeArguments()
        {
            // 2 - 2 - 2

            var memory = new Memory();

            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Subtraction());
            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Subtraction());
            memory.AddNumberToTheMemory(2m);
            memory.CurrentEquation = Solver.Solve(memory.CurrentEquation);

            Assert.That(memory.CurrentEquation.Result == -2);
        }


        [Test]
        public void SimpleMultiplication_TwoArguments()
        {
            // 3 * 2

            var memory = new Memory();

            memory.AddNumberToTheMemory(3m);
            memory.AddCalculationToTheMemory(new Multiplication());
            memory.AddNumberToTheMemory(2m);
            memory.CurrentEquation = Solver.Solve(memory.CurrentEquation);

            Assert.That(memory.CurrentEquation.Result == 6);
        }


        [Test]
        public void SimpleMultiplication_ThreeArguments()
        {
            // 3 * 2 * 2

            var memory = new Memory();

            memory.AddNumberToTheMemory(3m);
            memory.AddCalculationToTheMemory(new Multiplication());
            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Multiplication());
            memory.AddNumberToTheMemory(2m);
            memory.CurrentEquation = Solver.Solve(memory.CurrentEquation);

            Assert.That(memory.CurrentEquation.Result == 12);
        }


        [Test]
        public void MixedCalculation_ThreeArguments()
        {
            // 2 + 2 * 2

            var memory = new Memory();

            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Sum());
            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Multiplication());
            memory.AddNumberToTheMemory(2m);
            memory.CurrentEquation = Solver.Solve(memory.CurrentEquation);

            Assert.That(memory.CurrentEquation.Result == 6);
        }


        [Test]
        public void MixedCalculation_ThreeArgumentsEqualPriority()
        {
            // 2 + 2 - 2

            var memory = new Memory();

            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Sum());
            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Subtraction());
            memory.AddNumberToTheMemory(2m);
            memory.CurrentEquation = Solver.Solve(memory.CurrentEquation);

            Assert.That(memory.CurrentEquation.Result == 2);
        }


        


        [Test]
        public void MixedCalculation_ManyArguments()
        {
            // 2 + 2 * 2 * 2 + 2 * 2

            var memory = new Memory();

            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Sum());
            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Multiplication());
            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Multiplication());
            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Sum());
            memory.AddNumberToTheMemory(2m);
            memory.AddCalculationToTheMemory(new Multiplication());
            memory.AddNumberToTheMemory(2m);


            memory.CurrentEquation = Solver.Solve(memory.CurrentEquation);

            Assert.That(memory.CurrentEquation.Result == 14);
        }
    }
}