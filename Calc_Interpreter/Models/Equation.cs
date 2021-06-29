using System.Collections.Generic;

namespace Calc_Interpreter
{
    public class Equation
    {
        public List<ICalculation> Calculations { get; set; } = new();
        public List<decimal> Numbers { get; set; } = new();
        // public List<string> Symbols { get; set; } = new();
        public decimal Result { get; set; }

        public override string ToString()
        {
            // oczywiscie to powinno byc bardziej uniwersalne
            return $"{Numbers[0]} {Calculations[0].Name} {Numbers[1]} = {Result}";
        }
    }
}