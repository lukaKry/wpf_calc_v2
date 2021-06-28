using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Calc
{
    public class EquationModified : IEquation
    {
        public List<decimal> Numbers { get; set; }
        public List<string> Symbols { get; set; }
        public decimal Result { get; set; }

        public ICalculation CalculationType { get; set; }
    }
}
