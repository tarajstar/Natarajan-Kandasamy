using Calculator.Interfaces;
namespace Calculator.Utilities
{
    internal class Subtraction : ICalculator
    {
        public double Operation(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
}
