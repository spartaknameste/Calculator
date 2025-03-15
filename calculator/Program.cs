namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите пример в формате 'число оператор число'");
            string input = Console.ReadLine();
            string[] partsOfExample = input.Split(" ");
            if (partsOfExample.Length != 3)
                throw new Exception("Некорректный ввод примера");

            Calculator calculator = new Calculator();
            double result = calculator.Execute(partsOfExample[1], Convert.ToDouble(partsOfExample[0]), Convert.ToDouble(partsOfExample[2]));
            Console.WriteLine($"Результат: {result}");
        }

    }
}
