using System;

namespace Lr4
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List();
            var list2 = new List();

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    list1.AddLast(i);
                }
                else
                {
                    list2 += i;
                }
            }

            Console.WriteLine($"list1 = {list1}");
            Console.WriteLine($"list2 = {list2}");
            Console.WriteLine($"list1 == list2? {list1 == list2}");

            Console.WriteLine("list1 *= list2");
            list1 *= list2;

            Console.WriteLine($"list1 = {list1}");
            Console.WriteLine($"list2 = {list2}");

            Console.WriteLine("Call list2--");
            list2--;
            Console.WriteLine($"list2 = {list2}");
            Console.WriteLine("Call list2.RemoveLast()");
            list2.RemoveLast();
            Console.WriteLine($"list2 = {list2}");

            Console.WriteLine("Вложенный объект Owner");
            Console.WriteLine(list1.Owner);
            Console.WriteLine("Дата создания объекта list2:");
            Console.WriteLine(list2.DateOfCreation);

            Console.WriteLine($"MathOperation.Max(list1) = {MathOperation.Max(list1)}");
            Console.WriteLine($"MathOperation.Min(list2) = {MathOperation.Min(list2)}");
            Console.WriteLine($"MathOperation.Count(list2) = {MathOperation.Count(list2)}");

            Console.WriteLine($"list1.HasDuplicates() = {list1.HasDuplicates()}");
            list1 += list1[0];
            Console.WriteLine("list1 += list1[0]");
            Console.WriteLine($"list1.HasDuplicates() = {list1.HasDuplicates()}");

            var testStr = @"Never gonna Give you Up
Never gonna let you down
Never gonna run around and desert you
Never gonna make you cry
Never gonna say goodbye
Never gonna tell a lie and hurt you";

            Console.WriteLine("Тестовая строка:");
            Console.WriteLine(testStr);
            Console.WriteLine($"Количество слов с большой буквы: {testStr.CountCapitalWords()}");

            Console.ReadKey(true);
        }
    }
}