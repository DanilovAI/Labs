namespace Model
{
    public class PersonList
    {
        /// <summary>
        /// Список
        /// </summary>
        public List<Person> list;

        /// <summary>
        /// Конструктор списка с одним значением
        /// </summary>
        /// <param name="person"></param>
        public PersonList(Person person) 
        {
            list = [person];
        }
        
        /// <summary>
        /// Добавить элемент в список
        /// </summary>
        /// <param name="person"></param>
        public void AddPerson(Person person)
        {
            list.Add(person);
            Console.WriteLine($"Добавлен: {person.Surname} {person.Name}");
        }

        /// <summary>
        /// Удалить элемент из списка
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool RemovePerson(Person person)
        {
            bool removed = list.Remove(person);
            if (removed)
            {
                Console.WriteLine($"Удален: {person.Surname} {person.Name}");
            }
            return removed;
        }

        /// <summary>
        /// Удалить элемент по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemovePersonByIndex(int index)
        {
            if (index < 0  || index >= list.Count)
            {
                Console.WriteLine($"Ошибка: индекс {index}" +
                    $" вне диапазона [0, {list.Count - 1}]");
                return false;
            }

            var personToRemove = list[index];
            list.RemoveAt(index);
            Console.WriteLine($"Удален элемент с индексом {index}:" +
                $" {personToRemove.Surname} {personToRemove.Name}");
            return true;
        }

        /// <summary>
        /// Получить элемент по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Person GetPersonByIndex(int index)
        {
            if (index < 0 || index >= list.Count)
            {
                throw new IndexOutOfRangeException(
                    $"Ошибка: индекс {index} вне диапазона " +
                    $"[0, {list.Count - 1}]");
            }
            return list[index];
        }

        /// <summary>
        /// Получить индекс элемента при наличии его в списке
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public int IndexOfPerson(Person person)
        {
            return list.IndexOf(person);
        }

        /// <summary>
        /// Очистить список
        /// </summary>
        /// <param name="list"></param>
        public void ClearList(List<Person> list)
        {
            int count = list.Count;
            list.Clear();
            Console.WriteLine($"Список очищен." +
                $" Удалено {count} элементов.");
        }

        public void CountElements(List<Person> list)
        {
            int count = list.Count;
            Console.WriteLine($"Количество элементов в списке: {count}");
        }
    }
}
