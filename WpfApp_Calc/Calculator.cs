using System;
using System.Collections.Generic;
using System.Globalization;

namespace WpfApp_Calc
{
    public class Calculator
    {
        public List<Equation> Memory { get; set; } = new();
        public Calculations Calculations { get; set; }
        public Equation CurrentEquation { get; set; } = new();


        public void ChangeLastSymbolInTheMemory(string symbol)
        {
            CurrentEquation.Symbols[^1] = symbol;
        }

        public void AddNumberToTheMemory(string number)
        {
            //NumberFormatInfo provider = new ();
            //provider.NumberDecimalSeparator = ".";
            // CurrentEquation.Numbers.Add(Convert.ToDouble(number, provider));
            CurrentEquation.Numbers.Add(Convert.ToDecimal(number));
        }

        public void AddSymbolToTheMemory(string buttonUid)
        {
            CurrentEquation.Symbols.Add(buttonUid);
        }


        public string GetLastEquation()
        {
            string a = "b";
            return a;
        }

        public void SaveCurrentEquation()
        {
            Memory.Add(CurrentEquation);
        }

        public void ResetCurrentEquation()
        {
            CurrentEquation = new Equation();
        }

        public void Calculate()
        {
            try
            {
                Calculations = new Calculations(CurrentEquation);
                CurrentEquation.Result = Calculations.MakeCalculations();
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException();
            }
        }
    }
}