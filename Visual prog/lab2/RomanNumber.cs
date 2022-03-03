﻿
public class RomanNumber : ICloneable, IComparable
{
    private ushort numb;
    //Конструктор получает число n, которое должен представлять объект класса
    public RomanNumber(ushort n)
    {
        if (n > 0) numb = n;
        else throw new RomanNumberException("Входные данные меньше или равны 0");
    }
    //Сложение римских чисел
    public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.numb + n2.numb > 3999) throw new RomanNumberException("Неверные параметры");
        else return new RomanNumber((ushort)(n1.numb + n2.numb));
    }
    //Вычитание римских чисел
    public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.numb - n2.numb <= 0) throw new RomanNumberException("Неверные параметры");
        else return new RomanNumber((ushort)(n1.numb - n2.numb));
    }
    //Умножение римских чисел
    public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.numb * n2.numb > 3999 || n1.numb * n2.numb <= 0 ) throw new RomanNumberException("Неверные параметры");
        else return new RomanNumber((ushort)(n1.numb * n2.numb));
    }
    //Целочисленное деление римских чисел
    public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n2.numb == 0 || n1.numb/n2.numb <= 0) throw new RomanNumberException("Неверные параметры");
        else return new RomanNumber((ushort)(n1.numb / n2.numb));
    }
    //Возвращает строковое представление римского числа
    public override string ToString()
    {
        string ch_string = "";

        char[] Alfavit = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };

        ushort ch_element = numb;

        int counter = 0;

        while (ch_element != 0)
        {
            counter++;
            ch_element /= 10;
        }


        ch_element = numb;
        double element = 0;
        double element_des = 0;

        for (int i = counter - 1; i >= 0; i--)
        {

            double ch_count = Math.Floor(ch_element / Math.Pow(10, i));

            element = ch_count - element_des;

            element_des = ch_count * 10;

            if (element > 0 && element <= 3)
            {
                for (int j = 0; j < element; j++) ch_string += Alfavit[6 - 2 * i];
            }

            if (element == 4)
            {
                ch_string += Alfavit[6 - 2 * i];
                ch_string += Alfavit[5 - 2 * i];
            }

            if (element >= 5 && element <= 8)
            {
                ch_string += Alfavit[5 - 2 * i];
                for (int j = 0; j < element - 5; j++) ch_string += Alfavit[6 - 2 * i];
            }

            if (element == 9)
            {
                ch_string += Alfavit[6 - 2 * i];
                ch_string += Alfavit[6 - 2 * (i + 1)];
            }
        }
        return ch_string;
    }
    //Реализация интерфейса IClonable
    public object Clone()
    {
        return new RomanNumber(numb);
    }
    //Реализация интерфейса IComparable
    public int CompareTo(object? obj)
    {
        if (obj is RomanNumber number)
        {
            return number.numb - numb;
        }
        else throw new ArgumentException("Неверные параметры");
    }
}
