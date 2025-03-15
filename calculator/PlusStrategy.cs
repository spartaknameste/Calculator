namespace calculator
{
    public class PlusStrategy : ICalculationStrategy
    {
        public double Calculate(double i, double j) => i + j;
    }
}
