// See https://aka.ms/new-console-template for more information

namespace Example
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Проверка");
            Console.WriteLine();

            RomanNumber a = new RomanNumber(9);
            RomanNumber b = new RomanNumber(150);
            RomanNumber c = new RomanNumber(2709);

             Console.WriteLine("9 | IX | " + a.ToString());
             Console.WriteLine("150 | CL | " + b.ToString());
             Console.WriteLine("2709 | MMDCCIX | " + c.ToString());

             Console.WriteLine();

             Console.WriteLine("9 + 150 = 159 | CLIX | " + RomanNumber.Add(a, b).ToString());
             Console.WriteLine("2709 - 150 = 2559 | MMDLIX | " + RomanNumber.Sub(c, b).ToString());
             Console.WriteLine("9 * 150 = 1350 | MCCCL | " + RomanNumber.Mul(a, b).ToString());
             Console.WriteLine("2709 / 9 = 301 | CCCI | " + RomanNumber.Div(c, a).ToString());

             Console.WriteLine();

             Console.WriteLine("Массив:");
             RomanNumber[] mass = { a, b, c };
             for (int i = 0; i < mass.Length; i++) Console.WriteLine(mass[i]);

             Console.WriteLine();

             Console.WriteLine("Отсортированный Массив:");

             Array.Sort(mass);

             for (int i = 0; i < mass.Length; i++) Console.WriteLine(mass[i]);

             Console.WriteLine();

             Console.WriteLine("Копирование элемента 150 | CL ");

             var d = (RomanNumber)b.Clone();

             Console.WriteLine(d.ToString());
             
        }
    }
}