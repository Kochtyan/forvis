using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RomanNumberExtend : RomanNumber
{
    private static readonly Dictionary<char, int> Roman =
        new Dictionary<char, int> {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

    public RomanNumberExtend(string num)  : base(1) {
        int numb_now = 0;
        int numb_prev = 0;
        int counter = 0;
        bool check = true;
        foreach (char ch in num)
        {
            if (check == true)
            {
                int curr = Roman[ch];
                if (numb_prev == curr) counter++; else counter = 0;

                if (counter >= 1 && ( curr == 5 || curr == 50 || curr == 500 )) check = false;
                if (counter >= 3 && (curr != 5 || curr != 50 || curr != 500)) check = false;

                if (curr > numb_prev) numb_now += curr - 2 * numb_prev;
                else numb_now += curr;
                numb_prev = curr;
            }
            else throw new RomanNumberException("Неверная запись числа");
        }
        numb = Convert.ToUInt16(numb_now);
    }
}

