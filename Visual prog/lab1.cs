using System;


public class HW1
{
    public static long QueueTime(int[] customers, int n)
    {
        int[][] array = new int[n][];
        for (int i = 0; i < n; i++)
        {
            if (i == 0) array[i] = new int[customers.Length];
            else array[i] = new int[1];
        }

        for (int i = 0; i < customers.Length; i++)
        {
            array[0][i] = customers[i];
        }

        int check = 0;
        int time = 0;
        while (check != n)
        {
            time++;
            check = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i][0] == 0)
                {
                    int s = 1;
                    while (array[0][s] == 0)
                    {
                        s++;
                        if (s == customers.Length) break;
                    }
                    if (s != customers.Length)
                    {
                        array[i][0] = array[0][s];
                        array[0][s] = 0;
                    }
                }
                if (array[i][0] != 0) 
                    array[i][0]--;
            }

            for (int i = 0; i < n; i++)
            {
                if (array[i][0] == 0) 
                    check++;
            }
            if (check == n)
                for (int i = 0; i < customers.Length; i++) 
                    if (array[0][i] != 0) 
                        check = 0;
        }
        return time;
    }
}
class Programm
{
    static void Main()
    {

        Console.Write("Введите количество людей в очереди: ");
        int numberppl = int.Parse(Console.ReadLine());

        int[] queue = new int[numberppl];

        for (int i = 0; i < queue.Length; i++)
        {
            Console.Write($"Введите единицу времени для покупателя {i + 1} в очереди: ");
            queue[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Введите количество работающих касс: ");
        int cashreg = int.Parse(Console.ReadLine());

        Console.Write($"Время = {HW1.QueueTime(queue, cashreg)}");

    }

}

