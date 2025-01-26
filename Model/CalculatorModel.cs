using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    internal class CalculatorModel
    {
        public string currentInput { get; set; }
        public string display { get; set; } = "0";
        public double firstNumber { get; set; }
        public double secondNumber { get; set; }
        public string _operator {  get; set; }
    }
}
