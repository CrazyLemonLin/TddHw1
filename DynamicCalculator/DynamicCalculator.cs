using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicCalculator
{
    public class DynamicCalculator
    {
        public DynamicCalculator()
        {
        }

        public List<int> Calculate(List<dynamic> orders, int divideSize, Func<dynamic, int> fieldSelector)
        {
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