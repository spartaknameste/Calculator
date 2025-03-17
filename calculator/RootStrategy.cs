using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class RootStrategy : ICalculationStrategy
    {
        public double Calculate(double i, double j)
        {
            if (i <= 0)
                throw new Exception("Нельзя найти корень из отрицательного числа");
            return Math.Pow(i, 1 / j);
        }
    }
}
