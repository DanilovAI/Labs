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


    }
}
