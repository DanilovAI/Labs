using System;
using Model;

namespace Lab1_OOP
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
            PersonList list1 = new PersonList();
            PersonList list2 = new PersonList();

            // Заполняем list1 тремя случайными персонами
            for (int i = 0; i < 3; i++)
            {
                list1.AddPerson(Person.GetRandomPerson());
            }

            // Заполняем list2 тремя случайными персонами
            for (int i = 0; i < 3; i++)
            {
                list2.AddPerson(Person.GetRandomPerson());
            }
        }
    }
}
