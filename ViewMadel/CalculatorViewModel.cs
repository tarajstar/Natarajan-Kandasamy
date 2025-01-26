using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calculator.Interfaces;
using Calculator.Model;
using Calculator.Utilities;
using Calculator.Commands;
using log4net;
using log4net.Config;

namespace Calculator.ViewMadel
{
    internal class CalculatorViewModel : ViewModelBase
    {
       private CalculatorModel calculatorModel;
        private ICalculator _Addition;
        private ICalculator _Subtraction;
        private ICalculator _Multiplication;
        private ICalculator _Division;
       public CalculatorViewModel()
        {
            calculatorModel = new CalculatorModel();
            _Addition = new Addition();
            _Subtraction = new Subtraction();
            _Multiplication = new Multiplication();
            _Division = new Division();
            NumberCommand = new RelayCommand(param => Number_Click(param));
            OperatorCommand = new RelayCommand(param => Operator_Click(param));
            EqualsCommand = new RelayCommand(param => Equals_Click());
            ClearEntryCommand = new RelayCommand(param => ClearEntry_Click());
            ClearCommand = new RelayCommand(param => Clear_Click());
            BackspaceCommand = new RelayCommand(param => Backspace_Click());
            PlusMinusCommand = new RelayCommand(param => PlusMinus_Click());
            DecimalCommand = new RelayCommand(param => Decimal_Click());

        }

        public string CurrentInput
        {
            get => calculatorModel.currentInput;
            set
            {
                calculatorModel.currentInput = value;
                OnPropertyChanged(nameof(CurrentInput));
            }
        }

        public string Display
        {
            get => calculatorModel.display;
            set
            {
                calculatorModel.display = value;
                OnPropertyChanged(nameof(Display));
            }
        }
        public ICommand NumberCommand { get; }
        public ICommand OperatorCommand { get; }
        public ICommand EqualsCommand { get; }
        public ICommand ClearEntryCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand BackspaceCommand { get; }
        public ICommand PlusMinusCommand { get; }
        public ICommand DecimalCommand { get; }

        private void Number_Click(object param)
        {
            CurrentInput += param.ToString();
            Display = CurrentInput;
        }
        private void Operator_Click(object param)
        {
            calculatorModel._operator = param.ToString();

            if (!string.IsNullOrEmpty(CurrentInput) && double.TryParse(CurrentInput, out double number))
            {
                calculatorModel.firstNumber = number;
                CurrentInput = string.Empty;
            }
        }

        private void Equals_Click()
        {
            if (!string.IsNullOrEmpty(CurrentInput) && double.TryParse(CurrentInput, out double number))
            {
                calculatorModel.secondNumber = number;
            }
            else
            {
                calculatorModel.secondNumber = calculatorModel.firstNumber;
            }

            double result = 0;
             switch (calculatorModel._operator)
            {
                case "+":
                    result = _Addition.Operation(calculatorModel.firstNumber, calculatorModel.secondNumber);
                     break;
                case "-":
                    result = _Subtraction.Operation(calculatorModel.firstNumber, calculatorModel.secondNumber);
                    break;
                case "*":
                    result = _Multiplication.Operation(calculatorModel.firstNumber, calculatorModel.secondNumber);
                    break;
                case "/":
                    result = _Division.Operation(calculatorModel.firstNumber, calculatorModel.secondNumber);
                    break;
            }

            Display = Math.Round(result, 5).ToString();
            CurrentInput = result.ToString();
          }

        private void ClearEntry_Click()
        {
            CurrentInput = string.Empty;
            Display = "0";
        }
        private void Clear_Click()
        {
            CurrentInput = string.Empty;
            calculatorModel._operator = string.Empty;
            calculatorModel.firstNumber = 0;
            calculatorModel.secondNumber = 0;
            Display = "0";
        }
        private void Backspace_Click()
        {
            if (CurrentInput.Length > 0)
            {
                CurrentInput = CurrentInput.Substring(0, CurrentInput.Length - 1);
                Display = CurrentInput;
            }
        }

        private void PlusMinus_Click()
        {
            if (CurrentInput.StartsWith("-"))
            {
                CurrentInput = CurrentInput.Substring(1);
            }
            else
            {
                CurrentInput = "-" + CurrentInput;
            }
            Display = CurrentInput;
        }
        private void Decimal_Click()
        {
            if (!CurrentInput.Contains("."))
            {
                CurrentInput += ".";
            }
            else
            {
                var parts = CurrentInput.Split('.');
                if (parts.Length == 2 && parts[1].Length < 5)
                {
                    CurrentInput += ".";
                }
            }
            Display = CurrentInput;
        }
    }
}
