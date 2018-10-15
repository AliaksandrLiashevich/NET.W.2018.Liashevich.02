using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Sorts;

namespace FindNextBiggerNumberLibrary
{
    public static class Number
    {
        public static int FindNextBiggerNumber(int numeric, Stopwatch leadTime)
        {
            if (numeric < 0)
                throw new ArgumentOutOfRangeException("Invalid Parametrs");
            if (leadTime == null)
                throw new ArgumentNullException("Object cannot be null");
            if (numeric == 0)
                return -1;
            int size = (int)(Math.Floor(Math.Log10(numeric) + 1));
            int[] digitals = new int[size];
            ParseToDigitals(digitals, size, numeric);
            leadTime.Start();
            FindNearest(digitals, size);
            leadTime.Stop();
            int answer = ConvertToInt(digitals, size);
            if ((numeric - answer) != 0)
                return answer;
            else
                return -1;
        }
        private static void ParseToDigitals(int[] digitals, int size, int numeric)
        {
            for (int i = 0; i < size; i++)
            {
                digitals[size - i - 1] = numeric % 10;
                numeric /= 10;
            }
        }
        private static void FindNearest(int[] digitals, int size)
        {
            for (int i = (size - 1); i > 0; i--)
            {
                QSort.Sort(digitals, i, size - 1);
                for (int j = i; j < size; j++)
                {
                    if (digitals[i - 1] < digitals[j])
                    {
                        int temp = digitals[i - 1];
                        digitals[i - 1] = digitals[j];
                        digitals[j] = temp;
                        return;
                    }
                }
            }
        }
        private static int ConvertToInt(int[] digitals, int size)
        {
            int result = 0;
            for (int i = 0; i < size; i++)
                result += (int)(digitals[size - i - 1] * Math.Pow(10, i));
            return result;
        }
    }
}
