using System.Xml.Linq;

namespace Model
{
    /// <summary>
    /// Абстрактный класс транспорт
    /// </summary>
    public abstract class TransportBase
    {
        /// <summary>
        /// Масса (т)
        /// </summary>
        private double _weight;

        /// <summary>
        /// Свойство масса
        /// </summary>
        public double Weight
        {
            get { return _weight; }
            set
            {
                ReadPositiveNumber(value);
                _weight = value;
            }
        }

        /// <summary>
        /// Расчитывает расход топлива
        /// </summary>
        /// <param name="distance">Расстояние (км)</param>
        /// <returns>Величина расхода топлива (л)</returns>
        public abstract double CalculateFuel(double distance);

        /// <summary>
        /// Проверка пустое ли поле
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="NullReferenceException">Исключение:
        /// пустое значение</exception>
        protected static void CheckIsMotorEmpty(Motor value)
        {
            if (value is null)
            {
                throw new NullReferenceException
                    ("Значение не может быть пустым");
            }
        }

        /// <summary>
        /// Проверка на ввод положительного числа
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ReadPositiveNumber(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Число должно " +
                    "быть положительным");
            }
        }
    }
}
