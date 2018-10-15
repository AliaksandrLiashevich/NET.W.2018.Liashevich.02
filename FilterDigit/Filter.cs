using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigit
{
    public static class NumberFilter
    {
        public static List<int> FilterDigit(List<int> numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("Object cannot be null");
            if (numbers[0] < 0 || numbers[0] > 9)
                throw new ArgumentOutOfRangeException("Invalid Parametrs");
            string mainDigital = Convert.ToString(numbers[0]);
            List<string> stringNumbers = numbers.Select(n => n.ToString()).ToList();
            stringNumbers.RemoveAt(0);
            List<int> filteredNumbers = new List<int>();
            foreach (string row in stringNumbers)
            {
                if (row.Contains(mainDigital))
                {
                    filteredNumbers.Add(Convert.ToInt32(row));
                }
            }
            return filteredNumbers;
        }
    }
}
