using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_Interpreter
{
    public class Memory
    {
        public List<Equation> EquationsHistory { get; set; } = new();
        // czy to musi byc property? skoro pod spodem i tak lepiej selfexplanatory method
        public Equation CurrentEquation { get; set; } = new();



        public void AddNumberToTheMemory(decimal number) 
        {
            CurrentEquation.Numbers.Add(number);
        }
        public void AddCalculationToTheMemory(ICalculation calculation)
        {
            CurrentEquation.Calculations.Add(calculation);
        }
    }
}
