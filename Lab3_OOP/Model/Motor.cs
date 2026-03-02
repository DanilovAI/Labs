
namespace Model
{
    public class Motor
    {
        /// <summary>
        /// Мощность двигателя (л.с.)
        /// </summary>
        private double _power;

        /// <summary>
        /// Конструктор класса двигатель
        /// </summary>
        /// <param name="power"></param>
        /// <param name="fuelType"></param>
        public Motor(double power, FuelType fuelType)
        {
            Power = power;
            FuelType = fuelType;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Motor() : this(150, FuelType.Petrol) { }

        /// <summary>
        /// Свойство мощность двигателя
        /// </summary>
        public double Power
        {
            get { return _power; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Мощность должна быть положительной");
                }
                _power = value;
            }
        }

        /// <summary>
        /// Свойство вид топлива
        /// </summary>
        public FuelType FuelType { get; set; }

        /// <summary>
        /// Расчет коэффициента расхода
        /// </summary>
        /// <returns>Коэффициент расхода</returns>
        public double СalculateConsumption()
        {
            double consumptionPower;

            if (Power <= 100)
            {
                consumptionPower = 0.08;
            }
            else if (100 < Power && Power <= 200)
            {
                consumptionPower = 0.09;
            }
            else
            {
                consumptionPower = 0.1;
            }

            Dictionary<FuelType, double> сonsumptionFuel = 
                new Dictionary<FuelType, double>()
            {
                {FuelType.Electricity, 0.15},
                {FuelType.Diesel, 0.90},
                {FuelType.Petrol, 0.95},
                {FuelType.Gas, 1},
                {FuelType.AviationKerosene, 30},
                {FuelType.AviationGasoline, 35}
            };

            double сonsumption = consumptionPower *
                                сonsumptionFuel[FuelType];
            return сonsumption;
        }

    }
}
