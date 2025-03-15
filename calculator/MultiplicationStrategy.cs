using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class MultiplicationStrategy : ICalculationStrategy
    {
        public double Calculate(double i, double j) => i * j;
    }
}
