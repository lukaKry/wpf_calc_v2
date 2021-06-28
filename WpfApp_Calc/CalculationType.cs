using System;

namespace WpfApp_Calc
{
    public class CalculationType : ICalculation
    {
        public string Name { get; set; }
        public int Priority { get; set; }


        public void Calculate()
        {
            throw new NotImplementedException();
        }
    }
}