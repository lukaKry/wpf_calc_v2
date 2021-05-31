using System.Collections.Generic;

namespace WpfApp_Calc
{
    public class Equation
    {
        public List<decimal> Numbers { get; set; } = new();
        public List<string> Symbols { get; set; } = new();
        public decimal Result { get; set; }
    }
}