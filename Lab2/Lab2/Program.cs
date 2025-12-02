using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задача 1.17
            // Написать программу вычисления сопротивления электрической цепи,
            // состоящей из двух последовательно соединенных сопротивлений.
            // Извне вводятся величина первого и второго сопротивления.
            /*
            int R1 = Convert.ToInt32(Console.ReadLine());
            int R2 = Convert.ToInt32(Console.ReadLine());
            int R12 = R1 + R2;

            Console.WriteLine($"Сопротивление цепи: {R12}");
            Console.Read();
            */

            // Задача 1.21
            // Не используя никакие арифметические действия,
            // кроме умножения, записать операторы присваивания,
            // которые позволят получить для заданного а
            /*
            int a = Convert.ToInt32(Console.ReadLine());
            int b = a * a;
            int c = b * b;
            int d = c * b;
            int e = d * b;

            Console.WriteLine(e);
            Console.Read();
             */

            // Задача 1.22
            // Не используя никакие арифметические действия,
            // кроме умножения, записать операторы присваивания,
            // которые позволят получить для заданного а
            /*
            int a = Convert.ToInt32(Console.ReadLine());
            int b = a * a * a;
            int c = b * b;
            int d = c * c;
            int e = d * c;
            int f = e * b;

            Console.WriteLine($"a^3 = {b} \n" +
                $"a^21 = {f}");
            Console.Read();
            */

            // Задача 2.17
            // Написать программу, которая запрашивает у пользователя номер месяца
            // и затем выводит соответствующее название времени года.
            // Если вводится недопустимое число (<1 или >12),
            // должно появиться сообщение «ошибка ввода данных».

            Console.WriteLine("Введите номер месяца:");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 12 || a == 1 || a == 2)
            {
                Console.WriteLine("Время года: Зима");
            }
            else if (a >= 3 && a < 6)
            {
                Console.WriteLine("Время года: Весна");
            }
            else if (a >= 6 && a < 9)
            {
                Console.WriteLine("Время года: Лето");
            }
            else if (a >= 9 && a < 12)
            {
                Console.WriteLine("Время года: Осень");
            }
            else
                Console.WriteLine("Ошибка ввода условий!");
            Console.Read();

            
        }

    }

}

