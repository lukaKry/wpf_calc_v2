using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Calc.Services
{
    public class InterpreterService
    {
        private static InterpreterService _instance;
        private InterpreterService() { }
        public static InterpreterService Instance => _instance ?? (_instance = new InterpreterService());

        public ICalculation Interpret()
        {
            // 

            throw new NotImplementedException();
        }
    }
}
