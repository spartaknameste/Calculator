using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class Calculator
    {
        private readonly Dictionary<string, ICalculationStrategy> _strategies;
        public Calculator()
        {
            _strategies = new Dictionary<string, ICalculationStrategy>
            {
                { "+", new PlusStrategy() },
                { "-", new MinusStrategy() },
                { "*", new MultiplicationStrategy() },
                { "/", new DivideStrategy() },
                { "%", new RemainderStrategy() },
                { "^", new PowStrategy() },
                { "√", new RootStrategy() }
            };
        }
        public double Execute(string operation, double i, double j)
        {
            if (!_strategies.ContainsKey(operation))
                throw new InvalidOperationException($"Операция '{operation}' не поддерживается");

            return _strategies[operation].Calculate(i, j);
        }
    }
}
