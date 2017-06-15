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

            var data = orders.Select(fieldSelector);

            var ordersCount = data.Count();

            var divideCount = Math.Ceiling((decimal) ordersCount / divideSize);

            var results = new List<int>();

            for (int i = 0; i < divideCount; i++)
            {
                var result = data.Skip(i * divideSize).Take(divideSize).Sum();
                results.Add(result);
            }

            return results;
        }
    }
}