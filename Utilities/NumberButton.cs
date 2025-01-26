using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Utilities
{
    internal class NumberButton :BaseButton
    {
        public static readonly DependencyProperty DisplayCharacterPropery =
            DependencyProperty.Register("DisplayCharacter", typeof(string), typeof(NumberButton), new PropertyMetadata(string.Empty));

        public string DisplayCharacter
        {
            get { return (string)GetValue(DisplayCharacterPropery); }
            set { SetValue(DisplayCharacterPropery, value); }
        }

    }
}
