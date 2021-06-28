using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Calc
{
    public class MyApplication
    {
        public Calculator Calculator { get; set; }
        public Display MainDisplay { get; set; }
        public Display AdditionalDisplay { get; set; }
        public Display MemoryDisplay { get; set; }

        public MyApplication()
        {
            Calculator = new Calculator();
            MainDisplay = new Display();
            AdditionalDisplay = new Display();
            MemoryDisplay = new Display();
        }


        public void NumberButtonIsClicked(string buttonUid)
        {
            MainDisplay.AddToDisplay(buttonUid);
        }

        public void SymbolButtonIsClicked(string buttonUid)
        {
            // Udpate Additional Display
            AdditionalDisplay.AddToDisplay($"{MainDisplay.Content} {buttonUid} ");

            // Update Calculator memory
            Calculator.AddSymbolToTheMemory(buttonUid);
            Calculator.AddNumberToTheMemory(MainDisplay.Content);

            MainDisplay.ClearDisplay();
        }

        public void EqualSignIsClicked()
        {
            // add last number from the display to the current equation
            Calculator.AddNumberToTheMemory(MainDisplay.Content);

            try
            {
                // perform calculations
                Calculator.Calculate();
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException();
            }

            // Refresh Additional Display
            AdditionalDisplay.AddToDisplay(MainDisplay.Content);

            // display result
            MainDisplay.Content = Calculator.CurrentEquation.Result.ToString();
        }

        public void CommaButtonIsClicked()
        {
            if (MainDisplay.Content == "") MainDisplay.AddToDisplay("0");
            MainDisplay.AddToDisplay(",");
        }

        public void ClearButtonIsClicked()
        {
            MainDisplay.Content = "";
            AdditionalDisplay.Content = "";
            Calculator.CurrentEquation = new Equation();
        }

        public void MemoryButtonIsClicked()
        {
            if (Calculator.Memory.Count > 0)
            {
                var memory = $"{PrepareInputForAdditionalDisplay(Calculator.Memory[^1])} = {Calculator.Memory[^1].Result}";
                ClearButtonIsClicked();
                AdditionalDisplay.AddToDisplay(memory);
            }
        }

        public void SaveCurrentEquationToTheLongTermMemory()
        {
            Calculator.SaveCurrentEquation();
            Calculator.ResetCurrentEquation();
        }

        public void SymbolChange(string buttonUid)
        {
            Calculator.ChangeLastSymbolInTheMemory(buttonUid);
            var newInputForAdditionalDisplay = PrepareInputForAdditionalDisplay(Calculator.CurrentEquation);
            AdditionalDisplay.ChangeDisplay(newInputForAdditionalDisplay);
        }

        private string PrepareInputForAdditionalDisplay(IEquation equation)
        {
            StringBuilder sb = new();
            for (int i = 0; i < equation.Numbers.Count; i++)
            {
                sb.Append(equation.Numbers[i] + " ");
                if ( equation.Symbols.Count > i) 
                    sb.Append(equation.Symbols[i] + " ");
            }
            return sb.ToString();
        }

    }
}
