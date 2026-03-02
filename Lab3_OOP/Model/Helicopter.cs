
namespace Model
{
    /// <summary>
    /// Класс вертолет
    /// </summary>
    public class Helicopter : TransportBase
    {
        /// <summary>
        /// Двигатель
        /// </summary>
        private Motor _motor;

        /// <summary>
        /// Конструктор класса вертолет
        /// </summary>
        /// <param name="motor">Двигатель</param>
        /// <param name="mass">Масса (т)</param>
        public Helicopter(Motor motor, double mass)
        {
            Motor = motor;
            Mass = mass;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Helicopter() : 
            this(new Motor(250, FuelType.AviationKerosene), 10) { }

        /// <summary>
        /// Свойство двигатель
        /// </summary>
        public Motor Motor
        {
            get { return _motor; }
            set
            {
                if (value is null)
                {
                    throw new NullReferenceException
                              ("Значение не может быть пустым");
                }

                _motor = value;
            }
        }

        /// <summary>
        /// Расчитывает расход топлива
        /// </summary>
        /// <param name="distance">Длительность полета (часы)</param>
        /// <returns></returns>
        public override double CalculateFuel(double distance)
        {
            double coeffСonsumption = Motor.СalculateConsumption();

            return distance * coeffСonsumption * Mass;
        }
    }
}
