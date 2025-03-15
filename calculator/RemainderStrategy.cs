using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class RemainderStrategy : ICalculationStrategy
    {
        public double Calculate(double i, double j)
        {
            if (j == 0)
                throw new DivideByZeroException("На ноль делить нельзя");
            return i % j;
        }
    }
}
