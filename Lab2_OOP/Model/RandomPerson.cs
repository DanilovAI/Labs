
using System;
using System.Reflection;
using System.Threading;

namespace Model
{
    /// <summary>
    /// Класс для случайной генерации человека
    /// </summary>
    public class RandomPerson
    {
        /// <summary>
        /// Объект класса Random
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Мужские имена
        /// </summary>
        private static string[] _maleNames = 
        { 
            "Иван", "Алексей", "Дмитрий",                                  
            "Сергей", "Андрей", "Михаил",                                  
            "Владимир", "Александр" 
        };

        /// <summary>
        /// Женские имена
        /// </summary>
        private static string[] _femaleNames = 
        {   
            "Анна", "Мария", "Екатерина",
            "Ольга", "Елена", "Наталья",
            "Ирина", "Татьяна" 
        };

        /// <summary>
        /// Мужские фамилии
        /// </summary>
        private static string[] _maleSurnames =
        {
            "Иванов", "Петров", "Сидоров",
            "Кузнецов","Смирнов", "Попов",
            "Васильев", "Новиков"
        };

        /// <summary>
        /// Женские фамилии
        /// </summary>
        private static string[] _femaleSurnames =
        {
            "Иванова", "Петрова", "Сидорова",
            "Кузнецова","Смирнова", "Попова",
            "Васильева", "Новикова"
        };

        /// <summary>
        /// Заполнение полей базового класса
        /// </summary>
        /// <param name="person">Человек</param>
        public static void CreateRandomPersonInfo(PersonBase person, 
                                                    Gender? gender = null)
        {
            person.Gender = gender ?? (Gender)_random.Next(2);

            person.Name = person.Gender == Gender.Male
                ? _maleNames[_random.Next(_maleNames.Length)]
                : _femaleNames[_random.Next(_femaleNames.Length)];

            person.Surname = person.Gender == Gender.Male
                ? _maleSurnames[_random.Next(_maleSurnames.Length)]
                : _femaleSurnames[_random.Next(_femaleSurnames.Length)];
        }

        /// <summary>
        /// Создание случайного взрослого
        /// </summary>
        /// <param name="adult">Экземляр класса Adult</param>
        public static Adult CreateRandomAdult(bool married = false, 
                                                Adult partner = null, 
                                                Gender? gender = null)
        {
            var randomAdult = new Adult();
            CreateRandomPersonInfo(randomAdult, gender);
            randomAdult.Age = _random.Next(Adult.MinAdultAge, 
                                             Adult.MaxAdultAge);
            if (!married)
            {
                int numberOfMaritalStatuses = 4;
                randomAdult.MaritalStatus = 
                    (MaritalStatus)_random.Next(0, numberOfMaritalStatuses);
                if (randomAdult.MaritalStatus == MaritalStatus.Married)
                {
                    randomAdult.Partner = 
                        CreateRandomAdult(true, randomAdult);
                }
            }
            else
            {
                randomAdult.MaritalStatus = MaritalStatus.Married;
                randomAdult.Partner = partner;
            }
            string[] jobs =
            {
                "Школа", "Полиция", "Банк",
                "Больница", "Бар", "Магазин",
                "Университет", "Завод"
            };
            randomAdult.Job = jobs[_random.Next(0, jobs.Length)];
            randomAdult.PassportData = 
                _random.Next(1000000000, 2000000000).ToString();
            return randomAdult;
        }

        /// <summary>
        /// Создание случайного ребенка
        /// </summary>
        /// <returns>Экземпляр класса Child</returns>
        public static Child CreateRandomChild()
        {
            Child randomChild = new Child();
            CreateRandomPersonInfo(randomChild);
            randomChild.Age =_random.Next(Child.MinChildAge,
                                            Child.MaxChildAge);

            bool hasMother = _random.Next(0, 2) != 0;

            if (hasMother)
            {
                randomChild.Mother = CreateRandomAdult(false, null, 
                                                        Gender.Female);
            }

            bool hasFather = _random.Next(0, 2) != 0;

            if (hasFather)
            {
                randomChild.Father = CreateRandomAdult(false, null,
                                                        Gender.Male);
            }

            string[] schools =
            {
                "Школа №5", "Школа №67",
                "Школа №1", "Лицей №5",
            };
            
            string[] kindergartens =
            {   "Детский сад Лесовичок","Детский сад Радуга",
                "Детский сад Солнышко"
            };

            int kindergartenAge = 7;
            randomChild.School = randomChild.Age >= kindergartenAge
                ? schools[_random.Next(schools.Length)]
                : kindergartens[_random.Next(kindergartens.Length)];

            return randomChild;
        }

        /// <summary>
        /// Генерация случайного человека - взрослого или ребенка
        /// </summary>
        /// <returns></returns>
        public static PersonBase GetRandomPerson()
        {
            if (_random.Next(0, 2) != 0)
            {
                return CreateRandomAdult();
            }
            else
            {
                return CreateRandomChild();
            }
        }

    }
}
