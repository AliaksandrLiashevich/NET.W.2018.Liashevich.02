using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertBitesLibrary
{
    public static class NumberTransform
    {
        public static int InsertNumber(int numberOne, int numberTwo, int start, int end)
        {
            if (start < 0 || end < 0 || start > 32 || end > 32 || start > end)
                throw new ArgumentOutOfRangeException("Invalid Parametrs");
            int numbersLength = 32, insertLength = end - start + 1;
            string one = Convert.ToString(numberOne, 2);
            string two = Convert.ToString(numberTwo, 2);
            string one32 = AddZero(one, numbersLength);
            string two32 = AddZero(two, numbersLength);
            string result = one32.Insert(numbersLength - end - 1, two32.Substring((numbersLength - insertLength), insertLength));
            result = result.Remove(result.Length - insertLength);
            return Convert.ToInt32(result, 2);
        }
        private static string AddZero(string row, int length)
        {
            string temp = null;
            if (row.Length < length)
                temp = new String('0', (length - row.Length));
            return temp + row;
        }
    }
}
