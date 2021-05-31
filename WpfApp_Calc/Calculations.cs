using System;

namespace WpfApp_Calc
{
    public class Calculations
    {
        private Equation LastEquation { get; set; }


        public Calculations(Equation lastEquation)
        {
            LastEquation = lastEquation;
        }

        public decimal MakeCalculations()
        {
            int n = 1;
            decimal result = LastEquation.Numbers[0];

            foreach ( var symbol in LastEquation.Symbols)
            {
                switch ( symbol )
                {
                    case "+": result += LastEquation.Numbers[n]; 
                        break;
                    case "-": result -= LastEquation.Numbers[n];
                        break;
                    case "*": result *= LastEquation.Numbers[n];
                        break;
                    case "/":
                        if (LastEquation.Numbers[n] == 0) throw new DivideByZeroException();
                        result /= LastEquation.Numbers[n];
                        break;
                    default:
                        break;
                }
                n++;
            }
            return result;
        }
    }
}