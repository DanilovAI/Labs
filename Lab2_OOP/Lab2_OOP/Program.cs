using System;
using Model;


namespace Lab2_OOP
{
    /// <summary>
    /// Точка входа в консольное приложение
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Главное тело программы
        /// </summary>
        /// <param name="args">Аргумент</param>
        internal static void Main(string[] args)
        {

            var listOfPersons = new PersonList();

            const int listLength = 7;
            Console.WriteLine($"Генерация {listLength} случайных людей:\n");

            for (int i = 0; i < listLength; i++)
            {
                listOfPersons.AddPerson(RandomPerson.GetRandomPerson());
            }

            for (int i = 0; i < listLength; i++)
            {
                Console.WriteLine($"{i + 1}-й человек\n");
                Console.WriteLine(listOfPersons.GetPersonByIndex(i)
                                                .GetInfo());
                Console.WriteLine();
            }

            const int fourthNumberInList = 3;
            Console.Write($"{fourthNumberInList + 1}-й человек в списке:\n\n");
            switch (listOfPersons.GetPersonByIndex(fourthNumberInList))
            {
                case Adult adult:
                {
                    Console.WriteLine(adult.GoToWork());
                    break;
                }

                case Child child:
                {
                    Console.WriteLine(child.PlayGames());
                    break;
                }
            }

        }
    }
}
