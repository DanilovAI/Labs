
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
        /// <param name="weight">Масса (т)</param>
        public Helicopter(Motor motor, double weight)
        {
            Motor = motor;
            Weight = weight;
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
                CheckIsMotorEmpty(value);
                _motor = value;
            }
        }

        /// <summary>
        /// Тип транспорта
        /// </summary>
        public override string TypeTransport
        {
            get => "Вертолет";
        }

        /// <summary>
        /// Основная информация
        /// </summary>
        public override string DisplayInfo
        {
            get
            {
                var fuelNames = new Dictionary<FuelType, string>
                {
                    {FuelType.AviationKerosene, "Авиационный керосин"},
                    {FuelType.AviationGasoline, "Авиационный бензин"}
                };

                return $"Тип топлива: {fuelNames[Motor.FuelType]}\n" +
                       $"Мощность: {Motor.Power} л.с.\n" +
                       $"Масса: {Weight} т";
            }
        }

        /// <summary>
        /// Расход топлива
        /// </summary>
        public override string FuelConsumption
        {
            get => $"{Math.Round(CalculateFuel(1), 2)} л в час";
        }


        /// <summary>
        /// Расчитывает расход топлива
        /// </summary>
        /// <param name="distance">Длительность полета (часы)</param>
        /// <returns></returns>
        public override double CalculateFuel(double distance)
        {
            double coeffСonsumption = Motor.СalculateConsumption();

            return distance * coeffСonsumption * Weight;
        }
    }
}
