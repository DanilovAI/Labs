using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс машина
    /// </summary>
    public class Car : TransportBase
    {
        /// <summary>
        /// Двигатель
        /// </summary>
        private Motor _motor;

        /// <summary>
        /// Конструктор класса машина
        /// </summary>
        /// <param name="motor">Двигатель</param>
        /// <param name="weight">Масса (т)</param>
        public Car(Motor motor, double weight) 
        {
            Motor = motor;
            Weight = weight;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Car() : this(new Motor(150, FuelType.Petrol), 1) { }

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
            get => "Машина";
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
                    {FuelType.Petrol, "Бензин"},
                    {FuelType.Diesel, "Дизель"},
                    {FuelType.Electricity, "Электричество"},
                    {FuelType.Gas, "Газ"},
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
            get
            {
                if (Motor.FuelType == FuelType.Electricity)
                {
                    return $"{Math.Round(CalculateFuel(100), 2)} кВт⋅ч на 100 км";
                }
                return $"{Math.Round(CalculateFuel(100), 2)} л на 100 км";
            }
        }

        /// <summary>
        /// Расчитывает расход топлива
        /// </summary>
        /// <param name="distance">Расстояние (км)</param>
        /// <returns>Расход топлива (л)</returns>
        public override double CalculateFuel(double distance)
        {
            double coeffСonsumption = Motor.СalculateConsumption();

            return distance * coeffСonsumption * Weight;
        }
    }
}
