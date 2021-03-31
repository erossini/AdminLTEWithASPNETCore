using System;

namespace PSC.Extensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Determines whether the specified value is decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Decimal.</returns>
        public static decimal IsDecimal(this object value)
        {
            decimal retNum;
            bool isNum = Decimal.TryParse(Convert.ToString(value), System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

            return isNum ? retNum : 0;
        }
    }
}