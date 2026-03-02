
namespace Model
{
    /// <summary>
    /// Класс машина-гибрид
    /// </summary>
    public class HybridCar : Car
    {
        /// <summary>
        /// Дополнительный двигатель
        /// </summary>
        private Motor _additionalMotor;

        /// <summary>
        /// Конструктор класса машина-гибрид
        /// </summary>
        /// <param name="motor">Основной двигатель</param>
        /// <param name="mass">Масса</param>
        /// <param name="additionalMotor">Дополнительный двигатель</param>
        public HybridCar(Motor motor, double mass, Motor additionalMotor) :
            base(motor, mass)
        {
            AdditionalMotor = additionalMotor;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public HybridCar() : this(new Motor(100, FuelType.Petrol), 1,
            new Motor(50, FuelType.Electricity)) { }

        /// <summary>
        /// Свойство дополнительный двигатель
        /// </summary>
        public Motor AdditionalMotor 
        { 
            get { return _additionalMotor; }
            set
            {
                if (value.FuelType == Motor.FuelType)
                {
                    throw new ArgumentException("Вид топлива основного " +
                        "двигателя и дополнительного должны отличаться");
                }

                if (value is null)
                {
                    throw new NullReferenceException
                              ("Значение не может быть пустым");
                }
                _additionalMotor = value;
            }
        }

        /// <summary>
        /// Рассчитывает расход топлива.
        /// Принято допущениие, что гибрид использует оба двигателя
        /// пропорционально (50% на основном, 50% на дополнительном).
        /// </summary>
        /// <param name="distance">Расстояние (км)</param>
        /// <returns>Общий расход топлива (л)</returns>
        public override double CalculateFuel(double distance)
        {
            double halfDistance = distance / 2;

            double coeffСonsumption = Motor.СalculateConsumption();
            double coeffСonsumptionAdd = 
                AdditionalMotor.СalculateConsumption();

            return halfDistance * Mass * (coeffСonsumption +
                                            coeffСonsumptionAdd);
        }

    }
}
