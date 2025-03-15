using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class MinusStrategy : ICalculationStrategy
    {
        public double Calculate(double i, double j) => i - j;
    }
}
