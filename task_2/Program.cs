namespace task_2;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первый член геометрической прогрессии:");
        double b1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите знаменатель геометрической прогрессии:");
        double q = double.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Введите номер для вычисления соответствующего члена прогрессии:");
        double n = double.Parse(Console.ReadLine());

        double bn = b1 * Math.Pow(q, n - 1);
        Console.WriteLine(bn);

        Console.ReadKey();

    }
}