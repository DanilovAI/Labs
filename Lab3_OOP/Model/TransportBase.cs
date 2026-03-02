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
        private double _mass;

        /// <summary>
        /// Свойство масса
        /// </summary>
        public double Mass
        {
            get { return _mass; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Масса должна быть положительной!");
                }
                _mass = value;
            }
        }

        /// <summary>
        /// Расчитывает расход топлива
        /// </summary>
        /// <param name="distance">Расстояние (км)</param>
        /// <returns>Величина расхода топлива (л)</returns>
        public abstract double CalculateFuel(double distance);
    }
}
