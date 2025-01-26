using Calculator.Interfaces;

namespace Calculator.Utilities
{
    internal class Addition : ICalculator
    {
        public double Operation(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
