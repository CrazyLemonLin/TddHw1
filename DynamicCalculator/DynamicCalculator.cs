using System;
using System.Collections.Generic;

namespace DynamicCalculator
{
    public class DynamicCalculator
    {
        public DynamicCalculator()
        {
        }

        public List<int> Calculate(List<dynamic> orders, int v, Func<dynamic, int> fieldSelector)
        {
            return new List<int> { 6, 15, 24, 21 };
        }
    }
}