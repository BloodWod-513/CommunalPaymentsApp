using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.ValidationTools
{
    public static class StringValidation
    {
        public static bool CheckString(string str, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                ValidationPrinter.ShowError($"Вы ничего не ввели. Параметр: {parameterName}");
                return false;
            }
            return true;
        }
    }
}
