
namespace Model
{
    /// <summary>
    /// Класс, содержащий данные о ребенке
    /// </summary>
    public class Child : Person
    {
        /// <summary>
        /// Отец ребенка
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Мать ребенка
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Школа или детский сад
        /// </summary>
        private string _school;

        /// <summary>
        /// Наименьший возраст ребенка
        /// </summary>
        public const int MinChildAge = 0;

        /// <summary>
        /// Максимальный возраст ребенка
        /// </summary>
        public const int MaxChildAge = 17;

        /// <summary>
        /// Конструктор класса Child
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="father">Отец</param>
        /// <param name="mother">Мать</param>
        /// <param name="school">Школа или детский сад</param>
        public Child(string name, string surname, int age, Gender gender,
            Adult father, Adult mother, string school)
            : base(name, surname, age, gender)
        {
            Father = father;
            Mother = mother;
            School = school;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Child() { }

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
                if (!(value > MinChildAge) && !(value <= MaxChildAge))
                {
                    throw new Exception($"Возраст не может быть менее" +
                        $" {MinChildAge} или более {MaxChildAge}!");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Отец ребенка
        /// </summary>
        public Adult Father 
        {
            get { return _father; }
            set
            {
                if (value.Gender != Gender.Male)
                {
                    throw new ArgumentException(
                        $"Введен неверный пол для отца -" +
                        $" ожидается мужской пол!");
                }
                _father = value;
            }
        }

        /// <summary>
        /// Мать ребенка
        /// </summary>
        public Adult Mother 
        {
            get { return _mother; }
            set
            {
                if (value.Gender != Gender.Female)
                {
                    throw new ArgumentException(
                        $"Введен неверный пол для матери -" +
                        $" ожидается женский пол!");
                }
                _mother = value;
            }
        }

        /// <summary>
        /// Школа или детский сад
        /// </summary>
        public string School
        {
            get { return _school; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(
                        $"Поле не может быть пустым " +
                        $"или состоять только из пробелов.");
                }
                _school = value;
            }
        }

        /// <summary>
        /// Получение информации о ребенке
        /// </summary>
        public override string GetInfo()
        {
            string father = Father != null
                ? $"{Father.Name} {Father.Surname}"
                : "отсутствует/не указан";

            string mother = Mother != null
                ? $"{Mother.Name} {Mother.Surname}"
                : "отсутствует/не указана";

            return $"{Name} {Surname} " +
                $"\nПол: {Gender}, возраст: {Age}" +
                $"\nОтец: {father}" +
                $"\nМать: {mother}" +
                $"\nМесто учебы: {School}";
        }

        /// <summary>
        /// Метод с занятием ребенка - играть в игры
        /// </summary>
        /// <returns></returns>
        public string PlayGames()
        {
            return $"{Name} {Surname} играет в игры";
        }

    }
}
