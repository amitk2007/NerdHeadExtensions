using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NerdHeadExtensions.MHMath
{
    public static class NHMath
    {
        public static float Average(params float[] numbers)
        {
            return  Sum(numbers) / numbers.Length;
        }

        public static float Sum(params float[] numbers)
        {
            float total = 0;
            foreach (float num in numbers)
            {
                total += num;
            }
            return total;
        }
    }
}