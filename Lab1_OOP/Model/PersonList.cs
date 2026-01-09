namespace Model
{
    /// <summary>
    /// Класс, представляющий абстрацию списка объектов класса Person
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Список объектов класса Person
        /// </summary>
        private List<Person> _list;

        /// <summary>
        /// Конструктор пустого списка
        /// </summary>
        public PersonList()
        {
            _list = new List<Person>();
        }

        /// <summary>
        /// Добавить элемент в список
        /// </summary>
        /// <param name="person">Элемент класса Person</param>
        public void AddPerson(Person person)
        {
            _list.Add(person);
            Console.WriteLine($"Добавлен: {person.Surname} {person.Name}");
        }

        /// <summary>
        /// Удалить элемент из списка
        /// </summary>
        /// <param name="person">Элемент класса Person</param>
        /// <returns>Возвращает, удален ли элемент</returns>
        public bool RemovePerson(Person person)
        {
            bool removed = _list.Remove(person);
            if (removed)
            {
                Console.WriteLine($"Удален: {person.Surname} {person.Name}");
            }
            return removed;
        }

        /// <summary>
        /// Удалить элемент по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Возвращет, удален ли элемент</returns>
        public bool RemovePersonByIndex(int index)
        {
            if (index < 0 || index >= _list.Count)
            {
                Console.WriteLine($"Ошибка: индекс {index}" +
                    $" вне диапазона [0, {_list.Count - 1}]");
                return false;
            }

            var personToRemove = _list[index];
            _list.RemoveAt(index);
            Console.WriteLine($"Удален элемент с индексом {index}:" +
                $" {personToRemove.Surname} {personToRemove.Name}");
            return true;
        }

        /// <summary>
        /// Получить элемент по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Возвращает полученный элемент</returns>
        public Person GetPersonByIndex(int index)
        {
            if (index < 0 || index >= _list.Count)
            {
                throw new IndexOutOfRangeException(
                    $"Ошибка: индекс {index} вне диапазона " +
                    $"[0, {_list.Count - 1}]");
            }
            return _list[index];
        }

        /// <summary>
        /// Получить индекс элемента при наличии его в списке
        /// </summary>
        /// <param name="person">Элемент класса Person</param>
        /// <returns>Возвращает индекс</returns>
        public int IndexOfPerson(Person person)
        {
            return _list.IndexOf(person);
        }

        /// <summary>
        /// Очистить список
        /// </summary>
        /// <param name="list">Элемент класса PersonList</param>
        public void ClearList(List<Person> list)
        {
            int count = list.Count;
            list.Clear();
            Console.WriteLine($"Список очищен." +
                $" Удалено {count} элементов.");
        }

        /// <summary>
        /// Получить количество элементов
        /// </summary>
        /// <param name="list">Элемент класса PersonList</param>
        public void CountElements(List<Person> list)
        {
            int count = list.Count;
            Console.WriteLine($"Количество элементов в списке: {count}");
        }
    }
}
