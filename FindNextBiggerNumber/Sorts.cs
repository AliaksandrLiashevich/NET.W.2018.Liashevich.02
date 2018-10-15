using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public static class QSort
    {
        public static void Sort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Object cannot be null");
            QSortLogics(array, 0, array.Length - 1);
        }
        public static void Sort(int[] array, int left, int right)
        {
            if (array == null)
                throw new ArgumentNullException("Object cannot be null");
            if (left < 0 || left > right || right > array.Length - 1)
                throw new ArgumentOutOfRangeException("Invalid Parametrs");
            QSortLogics(array, left, right);
        }
        private static void QSortLogics(int[] array, int start, int end)
        {
            if ((end - start) > 0)
            {
                int[] borders = Division(array, start, end);
                QSortLogics(array, start, borders[1]);
                QSortLogics(array, borders[0], end);
            }
        }
        private static int[] Division(int[] array, int start, int end)
        {

            int left = start, right = end, middle = array[(left + right) / 2];
            while ((right - left) >= 0)
            {
                while (array[left] < middle) left++;
                while (array[right] > middle) right--;
                if ((left - right) <= 0)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                    right--;
                }
            }
            return new int[] { left, right };
        }
    }
}
