namespace calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите пример в формате 'число оператор число' или что-то более сложное, например: 'число оператор число оператор число'");
            string input = Console.ReadLine();
            string[] partsOfExample = input.Split(" ");
            Calculator calculator = new Calculator();
            if (partsOfExample.Length == 3)
            {
                double result = calculator.SolveExample(partsOfExample[1], Convert.ToDouble(partsOfExample[0]), Convert.ToDouble(partsOfExample[2]));
                Console.WriteLine($"Результат: {result}");
            }
            else
            {
                double result = calculator.CalculateComplexExample(input);
                Console.WriteLine($"Результат: {result}");
            }
        }

    }
}
