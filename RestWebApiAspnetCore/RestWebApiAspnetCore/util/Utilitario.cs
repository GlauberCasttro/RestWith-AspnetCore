using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RestWebApiAspnetCore.util
{
    public static class Utilitario
    {
        public static decimal ConvertToDecimal(string number)
        {
            return Decimal.TryParse(number, out decimal decimalValue) ? decimalValue : 0;
        }

        public static bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = Double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
