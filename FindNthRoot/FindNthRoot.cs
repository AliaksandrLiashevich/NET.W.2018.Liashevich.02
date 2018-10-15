using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNthRootLibrary
{
    public static class RootCalculator
    {
        public static double FindNthRoot(double number, double root, double accuracy)
        {
            if ((number < 0 && root % 2 == 0) || root < 1 || accuracy < 0)
                throw new ArgumentOutOfRangeException("Invalid Parametrs");
            double xNext = 1, xCurrent = 0;
            while (Math.Abs(xNext - xCurrent) > accuracy)
            {
                xCurrent = xNext;
                xNext = (1 / root) * ((root - 1) * xCurrent + (number / Math.Pow(xCurrent, (root - 1))));
            }
            return xNext;
        }
    }
}
