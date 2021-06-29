using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_Interpreter.Calculations
{
    public class Multiplication : ICalculation
    {
        public string Name { get; init; }
        public int Priority { get; init; }
        public decimal Result { get; set; }
        public decimal Argument1 { get; set; }
        public decimal Argument2 { get; set; }

        public Multiplication()
        {
            Name = "*";
            Priority = 1;
        }

        public decimal Calculate()
        {
            return Argument1 * Argument2;
        }
    }
}
