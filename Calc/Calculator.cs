using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Calculator
    {
        // первое число, для таких будем считать операции, с участием одного числа (синус, косинус и тд)
        private double firstNumber;
        
        public Calculator()
        {
            // для проверки на активность кнопки
        }

        public Calculator(double firstNumber)
        {
            this.firstNumber = firstNumber;
        }

        public double Compose(double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public double Substract(double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public double Multiplicate(double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public double? Division(double secondNumber)
        {
            if (secondNumber == 0)
                return null;
            else
                return firstNumber / secondNumber;
            //return (secondNumber == 0 ? null : firstNumber / secondNumber); а такая штука не работает :(
        }

        public double Sin()
        {
            return Math.Sin(firstNumber);
        }

    }
}
