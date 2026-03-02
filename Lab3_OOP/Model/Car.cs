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
        /// <param name="mass">Масса (т)</param>
        public Car(Motor motor, double mass) 
        {
            Motor = motor;
            Mass = mass;
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
        /// <param name="distance">Расстояние (км)</param>
        /// <returns>Расход топлива (л)</returns>
        public override double CalculateFuel(double distance)
        {
            double coeffСonsumption = Motor.СalculateConsumption();

            return distance * coeffСonsumption * Mass;
        }
    }
}
