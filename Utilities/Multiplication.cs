using Calculator.Interfaces;
namespace Calculator.Utilities
{
    internal class Multiplication : ICalculator
    {
        public double Operation(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}
