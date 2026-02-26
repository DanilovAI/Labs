using System.Reflection;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс, содержащий данные о человеке
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст
        /// </summary>
        protected int _age;

        /// <summary>
        /// Проверка на содержание только символов кириллицы
        /// </summary>
        private const string _russianPattern =
            @"^[а-яА-ЯёЁ]+(?:-[а-яА-ЯёЁ]+)?$";

        /// <summary>
        /// Проверка на содержание только символов латиницы
        /// </summary>
        private const string _latinPattern =
            @"^[a-zA-Z]+(?:-[a-zA-Z]+)?$";

        /// <summary>
        /// Конструктор класса Person
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public PersonBase(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Создание нового экземпляра класса по умолчанию
        /// </summary>
        public PersonBase() { }

        /// <summary>
        /// Свойство Имя
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = Validate(value, "Имя");

                if (!string.IsNullOrEmpty(_surname))
                {
                    EnsureLanguage();
                }
            }
        }

        /// <summary>
        /// Свойство Фамилия
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = Validate(value, "Фамилия");

                if (!string.IsNullOrEmpty(_name))
                {
                    EnsureLanguage();
                }
            }
        }

        /// <summary>
        /// Свойство Возраст
        /// </summary>
        public abstract int Age { get; set; }

        /// <summary>
        /// Свойство Пол
        /// </summary>
        public Gender Gender { get; set; }


        /// <summary>
        /// Проверка корректности входных данных
        /// </summary>
        /// <param name="value">Строка для проверки</param>
        /// <param name="fieldName">Название поля</param>
        /// <returns>Значение после проверок</returns>
        /// <exception cref="ArgumentException">Неверное значение</exception>
        private static string Validate(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    $"{fieldName} не может быть пустым " +
                    $"или состоять только из пробелов.");
            }

            bool isRussian = Regex.IsMatch(value, _russianPattern);
            bool isLatin = Regex.IsMatch(value, _latinPattern);

            if (!isRussian && !isLatin)
            {
                throw new ArgumentException(
                    $"{fieldName} может содержать только русские буквы" +
                    $" или только английские буквы. " +
                    $"Двойное имя/фамилия допускается через дефис.");
            }

            var textInfo =
                System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(value.ToLowerInvariant());
        }

        /// <summary>
        /// Проверка языка имени и фамилии
        /// </summary>
        /// <exception cref="InvalidOperationException">Несовпадение языков</exception>
        private void EnsureLanguage()
        {
            bool nameIsRussian = Regex.IsMatch(_name, _russianPattern);
            bool surnameIsRussian = Regex.IsMatch(_surname, _russianPattern);

            if (nameIsRussian != surnameIsRussian)
            {
                throw new InvalidOperationException(
                    $"Язык имени и фамилии не совпадает. " +
                    "Имя и фамилия должны быть на одном языке.");
            }
        }

        /// <summary>
        /// Получение информации о человеке
        /// </summary>
        public abstract string GetInfo();
    }
}
