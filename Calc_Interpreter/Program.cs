using Calc_Interpreter.Calculations;
using System;

namespace Calc_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var memory = new Memory();

            // pressed 2
            memory.AddNumberToTheMemory(2m);

            // pressed +
            memory.AddCalculationToTheMemory(new Sum());

            // pressed 2
            memory.AddNumberToTheMemory(2m);

            // pressed +
            memory.AddCalculationToTheMemory(new Multiplication());

            // pressed 2
            memory.AddNumberToTheMemory(3m);

            // pressed +
            memory.AddCalculationToTheMemory(new Sum());

            // pressed 2
            memory.AddNumberToTheMemory(2m);

            // pressed =
            memory.CurrentEquation = Solver.Solve(memory.CurrentEquation);


            // nie dziala jak powinno - drukuje tylko ostatnie równanie
            Console.WriteLine(memory.CurrentEquation.ToString());
        }
    }
}
