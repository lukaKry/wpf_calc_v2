using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_Interpreter
{
    public static class Solver
    {
        public static Equation Solve(Equation equation)
        {
            // poszukac wyzszego priorytetu 
            if ( equation.Calculations.Any(q => q.Priority == 0) && equation.Calculations.Any(q => q.Priority == 1) )
            {
                ICalculation calc = equation.Calculations.First(q => q.Priority == 1);
                var index = equation.Calculations.IndexOf(calc);
                calc.Argument1 = equation.Numbers[index];
                calc.Argument2 = equation.Numbers[index + 1];

                equation.Numbers.RemoveAt(index);
                equation.Numbers[index] = calc.Calculate();

                equation.Calculations.RemoveAt(index);

                return Solver.Solve(equation);
            }


            // wyjście z pętli
            if ( equation.Calculations.Count == 1)
            {
                ICalculation calc = equation.Calculations[0];
                calc.Argument1 = equation.Numbers[0];
                calc.Argument2 = equation.Numbers[1];

                equation.Result = calc.Calculate();

                return equation;
            }
            else
            {
                ICalculation calc = equation.Calculations[0];
                calc.Argument1 = equation.Numbers[0];
                calc.Argument2 = equation.Numbers[1];

                equation.Numbers.RemoveAt(0);
                equation.Numbers[0] = calc.Calculate();

                equation.Calculations.RemoveAt(0);

                return Solver.Solve(equation);
            }
        }
    }
}
