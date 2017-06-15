using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicCalculator
{
    public class DynamicCalculator
    {
        public IEnumerable<int> Calculate<T>(List<T> orders, int divideSize, Func<T, int> fieldSelector)
        {
            if (divideSize <= 0) { throw new ArgumentException("divideSize應為大於0之正整數"); }

            var ordersCount = orders.Count();

            var divideCount = Math.Ceiling((decimal) ordersCount / divideSize);

            var results = new List<int>();

            for (int i = 0; i < divideCount; i++)
            {
                var result = orders.Skip(i * divideSize).Take(divideSize).Sum(fieldSelector);
                results.Add(result);
            }

            return results;
        }
    }
}