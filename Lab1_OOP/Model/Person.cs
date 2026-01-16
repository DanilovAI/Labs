using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс, содержащий данные о человеке
    /// </summary>
    public class Person
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
        private int _age;

        /// <summary>
        /// Конструктор класса Person
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Создание нового экземпляра класса по умолчанию
        /// </summary>
        public Person() : this("Ivan", "Ivanov", 18, Gender.Male) { }

        /// <summary>
        /// Свойство Имя
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = Validate(value, "Имя");
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
                EnsureLanguage();
            }
        }

        /// <summary>
        /// Свойство Возраст
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                //TODO: duplication
                const int minAge = 0;
                const int maxAge = 123;
                if (value < minAge || value > maxAge)
                {
                    throw new Exception($"{nameof(Age)} не может быть менее" +
                        $" {minAge} или более {maxAge}!");
                }
                else
                {
                    _age = value;
                }
            }
        }

        /// <summary>
        /// Свойство Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Проверка на содержание только символов кириллицы
        /// </summary>
        private const string RussianPattern =
            @"^[а-яА-ЯёЁ]+(?:-[а-яА-ЯёЁ]+)?$";

        /// <summary>
        /// Проверка на содержание только символов латиницы
        /// </summary>
        private const string LatinPattern =
            @"^[a-zA-Z]+(?:-[a-zA-Z]+)?$";

        /// <summary>
        /// Проверка корректности входных данных
        /// </summary>
        /// <param name="value">Строка для проверки</param>
        /// <param name="fieldName">Название поля</param>
        /// <returns>Значение после проверок</returns>
        /// <exception cref="ArgumentException">Неверное значение</exception>
        private static string Validate(string value, string fieldName)
        {
            //TODO: {}
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(
                    $"{fieldName} не может быть пустым " +
                    $"или состоять только из пробелов.");

            bool isRussian = Regex.IsMatch(value, RussianPattern);
            bool isLatin = Regex.IsMatch(value, LatinPattern);

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
        /// <exception cref="Exception">Несовпадение языков</exception>
        private void EnsureLanguage()
        {
            bool nameIsRussian = Regex.IsMatch(_name, RussianPattern);
            bool surnameIsRussian = Regex.IsMatch(_surname, RussianPattern);

            if (nameIsRussian != surnameIsRussian)
            {
                throw new Exception(
                    $"Язык имени и фамилии не совпадает. " +
                    "Имя и фамилия должны быть на одном языке.");
            }
        }

        //TODO: XML
        public static Person GetRandomPerson()
        {
            Random random = new Random();

            string[] maleNames = { "Иван", "Алексей", "Дмитрий",
                                    "Сергей", "Андрей", "Михаил",
                                    "Владимир", "Александр" };

            string[] femaleNames = { "Анна", "Мария", "Екатерина",
                                    "Ольга", "Елена", "Наталья",
                                    "Ирина", "Татьяна" };

            string[] surnamesMale = { "Иванов", "Петров", "Сидоров",
                                    "Кузнецов","Смирнов", "Попов",
                                    "Васильев", "Новиков" };

            string[] surnamesFemale = { "Иванова", "Петрова", "Сидорова",
                                    "Кузнецова", "Смирнова", "Попова",
                                    "Васильева", "Новикова" };

            var gender = random.Next(2) == 0
                ? Gender.Male
                : Gender.Female;

            //TODO: duplication
            int age = random.Next(0, 123);

            string name = gender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string surname = gender == Gender.Male
                ? surnamesMale[random.Next(surnamesMale.Length)]
                : surnamesFemale[random.Next(surnamesFemale.Length)];

            return new Person(name, surname, age, gender);
        }

        /// <summary>
        /// Функция для вывода данных о человеке
        /// </summary>
        /// <param name="person"></param>
        public void PrintPersonInfo(Person person)
        {
            string gender = string.Empty;

            switch (person.Gender)
            {
                //TODO: RSDN
                case Gender.Male:
                    {
                        gender = "Мужчина";
                        break;
                    }
                case Gender.Female:
                    {
                        gender = "Женщина";
                        break;
                    }
                default:
                    {
                        gender = "Неизвестно";
                        break;
                    }
            }

            Console.WriteLine($"Имя: {Name}, Фамилия: {Surname}, " +
                $"Возраст: {Age}, Пол: {gender}.");
        }


    }
}
