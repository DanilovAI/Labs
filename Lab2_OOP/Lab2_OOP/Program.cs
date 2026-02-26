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
        static void Main(string[] args)
        {

            var listOfPersons = new PersonList();

            int listLength = 7;
            //TODO: magic (to const) +
            Console.WriteLine("Генерация 7 случайных людей:\n");

            for (int i = 0; i < listLength; i++)
            {
                listOfPersons.AddPerson(RandomPerson.GetRandomPerson());
            }

            for (int i = 0; i < listLength; i++)
            {
                Console.WriteLine($"{i+1}-й человек\n");
                Console.WriteLine(listOfPersons.GetPersonByIndex(i)
                                                .GetInfo());
                Console.WriteLine();
            }

            int fourthNumberInList = 3;
            //TODO: magic (to const) +
            Console.Write("4-й человек в списке:\n\n");
            switch (listOfPersons.GetPersonByIndex(fourthNumberInList))
            {
                //TOOD: отступы +
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
