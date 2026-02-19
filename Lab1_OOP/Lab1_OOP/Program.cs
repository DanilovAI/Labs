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

            for (int i = 0; i < 3; i++)
            {
                list1.AddPerson(Person.GetRandomPerson());
            }

            for (int i = 0; i < 3; i++)
            {
                list2.AddPerson(Person.GetRandomPerson());
            }
            // Вывод созданных списков
            Console.WriteLine("Созданные списки:");
            PrintPersonList(list1, "Список 1");
            PrintPersonList(list2, "Список 2");

            // Добавляем нового человека в 1-ый список
            Console.ReadKey();
            Console.WriteLine("\nДобавление нового человека в 1-ый список:");
            list1.AddPerson(new Person("Наталья", "Краснова",
                                        66, Gender.Female));
            PrintPersonList(list1, "Список 1 (после добавления)");

            // Копируем второго человека из первого списка в конец второго
            Console.ReadKey();
            Person personToCopy = list1.GetPersonByIndex(1);
            list2.AddPerson(personToCopy);
            PrintPersonList(list1, "Список 1 (после копирования)");
            PrintPersonList(list2, "Список 2 (после копирования)");

            // Удаляем второго человека из первого списка
            Console.ReadKey();
            list1.RemovePersonByIndex(1);
            PrintPersonList(list1, "Список 1 (после удаления)");
            PrintPersonList(list2, "Список 2 (остался без изменений)");

            // Очищаем второй список
            Console.ReadKey();
            list2.ClearList();
            PrintPersonList(list2, "Список 2 (очищен)");
            Console.WriteLine("\nРабота завершена.");
            Console.ReadKey();

            // Ввод, добавление в список, вывод
            Console.WriteLine("\nДобавим человека вручную в Список 1:");
            Person newperson = ReadFromConsole();
            list1.AddPerson(newperson);
            PrintPersonList(list1, "Список 1 (после ручного добавления)");
            Console.ReadKey();
        }

        /// <summary>
        /// Вывести содержимое списка
        /// </summary>
        /// <param name="list">Список людей</param>
        /// <param name="listName">Название списка</param>
        public static void PrintPersonList(PersonList list, string listName)
        {
            Console.WriteLine($"\n{listName}");
            foreach (Person person in list.List)
            {
                person.PrintPersonInfo(person);
            }
        }

        /// <summary>
        /// Ввод персоны с консоли
        /// </summary>
        /// <returns>Объект класса Person</returns>
        /// <exception cref="Exception">При неверном вводе</exception>
        public static Person ReadFromConsole()
        {
            var person1 = new Person();

            var actionDictionary = new Dictionary<string, Action>()
            {
                {
                    "имя",
                    new Action(() =>
                        {
                            person1.Name = Console.ReadLine();
                        })
                },
                {
                    "фамилию",
                    new Action(() =>
                        {
                            person1.Surname = Console.ReadLine();
                        })
                },
                {
                    "возраст",
                    new Action(() =>
                        {
                            if (int.TryParse(Console.ReadLine(), out int age))
                            {
                                person1.Age = age;
                            }
                            else
                            {
                                throw new Exception("Введённая строка " +
                             "не может быть преобразована в число");
                            }
                        })
                },
                {
                    "пол (1 — Мужчина, 2 — Женщина)",
                    new Action(() =>
                    {
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                            {
                                person1.Gender = Gender.Male;
                                break;
                            }
                            case "2":
                            {
                                person1.Gender = Gender.Female;
                                break;
                            }
                            default:
                            {
                                throw new Exception("Некорректный ввод" +
                                    " Введите 1 или 2.");
                            }

                        }
                    })
                }
            };

            foreach (var actionHandler in actionDictionary)
            {
                ActionHandler(actionHandler.Value, actionHandler.Key);
            }
            return person1;
        }

        /// <summary>
        /// Вывод сообщения и повторение ввода при возникновении исключения
        /// </summary>
        /// <param name="action"></param>
        /// <param name="fieldName"></param>
        private static void ActionHandler(Action action, string fieldName)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Введите {fieldName}: ");
                    action.Invoke();
                    return;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($" Ошибка: {exception.Message}" +
                        $" Попробуйте снова.");
                }
            }
        }
    }
}