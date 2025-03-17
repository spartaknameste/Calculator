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

        public double SolveExample(string operation, double i, double j)
        {
            if (!_strategies.ContainsKey(operation))
                throw new InvalidOperationException($"Операция '{operation}' не поддерживается");

            return _strategies[operation].Calculate(i, j);
        }

        public double CalculateComplexExample(string complexExample)
        {
            complexExample = complexExample.Replace(" ", "");
            if (!IsValidExample(complexExample))
            {
                throw new ArgumentException("Некорректное выражение.");
            }
            else
                return ParseAndCalculate(complexExample);
        }

        public double ParseAndCalculate(string example)
        {
            for (int i = example.Length - 1; i >= 0; i--)
            {
                char c = example[i];
                if (c == '+')
                {
                    double left = ParseAndCalculate(example.Substring(0, i));
                    double right = ParseAndCalculate(example.Substring(i + 1));
                    return SolveExample("+", left, right);
                }
                if (c == '-')
                {
                    double left = ParseAndCalculate(example.Substring(0, i));
                    double right = ParseAndCalculate(example.Substring(i + 1));
                    return SolveExample("-", left, right);
                }
            }

            for (int i = example.Length - 1; i >= 0; i--)
            {
                char c = example[i];
                if (c == '*')
                {
                    double left = ParseAndCalculate(example.Substring(0, i));
                    double right = ParseAndCalculate(example.Substring(i + 1));
                    return SolveExample("*", left, right);
                }
                if (c == '/')
                {
                    double left = ParseAndCalculate(example.Substring(0, i));
                    double right = ParseAndCalculate(example.Substring(i + 1));
                    return SolveExample("/", left, right);
                }
            }

            for (int i = example.Length - 1; i >= 0; i--)
            {
                char c = example[i];
                if (c == '^')
                {
                    double left = ParseAndCalculate(example.Substring(0, i));
                    double right = ParseAndCalculate(example.Substring(i + 1));
                    return SolveExample("^", left, right);
                }
                if (c == '√')
                {
                    double left = ParseAndCalculate(example.Substring(0, i));
                    double right = ParseAndCalculate(example.Substring(i + 1));
                    return SolveExample("√", left, right);
                }
            }

            return double.Parse(example);
        }
        private bool IsValidExample(string example)
        {
            foreach (char a in example)
            {
                if (!char.IsDigit(a) && a != '+' && a != '-' && a != '*' && a != '/' && a != '^' && a != '√' && a != '.' && a != ' ')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
