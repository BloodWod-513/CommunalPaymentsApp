using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.ValidationTools
{
    public static class DigitValidation
    {
        public static bool TryEnterInt(string str, string parameterName)
        {
            int number;
            if (!StringValidation.CheckString(str, parameterName))
                return false;
            else if (!int.TryParse(str, out number))
            {
                ValidationPrinter.ShowError($"Введите целочисленное число. Параметр: {parameterName}");
                return false;
            }
            else if (!IsPositiveNumber(number, parameterName))
                return false;
            return true;
        }
        public static bool TryEnterDouble(string str, string parameterName)
        {
            double number;
            if (!StringValidation.CheckString(str, parameterName))
                return false;
            else if (!double.TryParse(str, out number))
            {
                ValidationPrinter.ShowError($"Введите нецелочисленное число. Параметр: {parameterName}");
                return false;
            }
            else if (!IsPositiveNumber(number, parameterName))
                return false;
            return true;
        }
        public static bool IsPositiveNumber(double number, string parameterName)
        {
            if (number < 0)
            {
                ValidationPrinter.ShowError($"Отрицательное число нельзя ввести. Параметр: {parameterName}");
                return false;
            }
            return true;
        }
        public static bool CurMoreThanPrevParameter(double prevValue, double value)
        {
            if (prevValue > value)
            {
                ValidationPrinter.ShowError($"Текущий параметр не может быть меньше предыдущего.");
                return false;
            }
            return true;
        }
    }
}
