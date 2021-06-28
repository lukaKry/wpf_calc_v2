using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Calc
{
    public interface ICalculation
    {
        public string Name { get; set; }

        public int Priority { get; set; }
        public void Calculate() { }
    }
}
