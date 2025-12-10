namespace Model
{
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
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Свойство Имя
        /// </summary>
        public string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception($"{nameof(Name)}" +
                        $" can't be null or empty!");
                }
                else
                {
                    _name = value;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception($"{nameof(Surname)}" +
                        $" can't be null or empty!");
                }
                else
                {
                    _surname = value;
                }
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
                const int minAge = 0;
                const int maxAge = 123;
                if (value < minAge || value > maxAge)
                {
                    throw new Exception($"{nameof(Age)} can't be less" +
                        $" {minAge} or above {maxAge}!");
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
        /// Функция для вывода данных о человеке
        /// </summary>
        /// <param name="person"></param>
        public void PrintPersonInfo(Person person)
        {
            Console.WriteLine($"Имя - {Name}, Фамилия - {Surname}" +
                $"Возраст - {Age}, Пол - {Gender}.");
        }


    }
}
