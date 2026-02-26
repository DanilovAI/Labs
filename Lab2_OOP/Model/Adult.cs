
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс, содержащий данные о взрослом человеке
    /// </summary>
    public class Adult : Person
    {
        /// <summary>
        /// Паспортные данные
        /// </summary>
        private string _passportData;

        /// <summary>
        /// Партнер
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Место работы
        /// </summary>
        private string _job;

        /// <summary>
        /// Минимальный возраст
        /// </summary>
        public const int MinAdultAge = 18;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        public const int MaxAdultAge = 123;

        /// <summary>
        /// Максимальное кол-во данных в паспорте
        /// </summary>
        public const int MaxLengthPassport = 10;

        /// <summary>
        /// Конструктор класса Adult
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="passportData">Паспортные данные</param>
        /// <param name="job">Работа</param>
        /// <param name="partner">Партнер</param>
        public Adult(string name, string surname, int age, Gender gender,
            string passportData, string job, MaritalStatus maritalStatus,
            Adult partner)
            : base(name, surname, age, gender)
        {
            PassportData = passportData;
            Job = job;
            Partner = partner;
            MaritalStatus = maritalStatus;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Adult() { }

        /// <summary>
        /// Свойство возраст
        /// </summary>
        public override int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (!(value > MinAdultAge) && !(value <= MaxAdultAge))
                {
                    throw new Exception($"Возраст не может быть менее" +
                        $" {MinAdultAge} или более {MaxAdultAge}!");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Семейное положение
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// Место работы
        /// </summary>
        public string Job 
        {
            get { return _job; }
            set
            {
                _job = string.IsNullOrEmpty(value)
                    ? "Безработный"
                    : $"{value}";
            }
        }

        /// <summary>
        /// Паспортные данные
        /// </summary>
        public string PassportData
        {
            get => _passportData;
            set
            {
                const string pattern = @"\D";
                Regex regex = new Regex(pattern);
                if (value.Length != MaxLengthPassport ||
                    regex.IsMatch(value.ToString()))
                {
                    throw new Exception($"Паспортные данные" +
                        $" должны включать {MaxLengthPassport} цифр!");
                }
                _passportData = value;
            }
        }

        /// <summary>
        /// Партнер
        /// </summary>
        public Adult Partner
        {
            get
            {
                return _partner;
            }
            set
            {
                if (MaritalStatus == MaritalStatus.Married &&
                    value.MaritalStatus == MaritalStatus.Married)
                {
                    _partner = value;
                }
            }
        }

        /// <summary>
        /// Получение информации о взрослом
        /// </summary>
        public override string GetInfo()
        {
            string meritalStatus = Partner != null
                ? $"Есть супруг(а) - {Partner.Name} {Partner.Surname}"
                : "не состоит в браке";

            return $"{Name} {Surname}\nПол: {Gender}, возраст: {Age}" +
                $"\nПаспорт: {PassportData}," +
                $"\nМесто работы: {Job} " +
                $"\nСемейное положение: {meritalStatus}";
        }

        /// <summary>
        /// Метод с занятием взрослого человека - идти на работу
        /// </summary>
        /// <returns>Взрослый идет на работу</returns>
        public string GoToWork()
        { 
            return $"{Name} {Surname} идет на работу";
        }

    }
}
