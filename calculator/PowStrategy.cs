using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class PowStrategy : ICalculationStrategy
    {
        public double Calculate(double i, double j) => Math.Pow(i, j);
    }
}
