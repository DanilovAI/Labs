using Model;
using NUnit.Framework.Constraints;

namespace ModelTests
{
    /// <summary>
    /// Класс для тестирования класса Motor
    /// </summary>
    public class MotorTests
    {
        // ПОЗИТИВНЫЕ ТЕСТЫ

        [TestCase(100, FuelType.Petrol, TestName =
            "Создание Motor с мощностью 100 л.с., бензин")]
        [TestCase(150, FuelType.Diesel, TestName =
            "Создание Motor с мощностью 150 л.с., дизель")]
        [TestCase(50, FuelType.Electricity, TestName =
            "Создание Motor с мощностью 50 л.с., электричество")]
        [TestCase(0.1, FuelType.Gas, TestName =
            "Создание Motor с мощностью 0.1 л.с., газ")]
        [TestCase(200, FuelType.AviationKerosene, TestName =
            "Создание Motor с мощностью 200 л.с., авиакеросин")]
        [TestCase(300, FuelType.AviationGasoline, TestName =
            "Создание Motor с мощностью 300 л.с., авиабензин")]
        public void ConstructorWithPowerAndFuelTypeSetsProperties(
            double power, FuelType fuelType)
        {
            // Arrange & Act
            var motor = new Motor(power, fuelType);

            // Assert
            Assert.AreEqual(power, motor.Power, TestTools.Tolerance);
            Assert.AreEqual(fuelType, motor.FuelType);
        }

        [Test(Description = "Конструктор по умолчанию " +
            "создаёт Motor с мощностью 150 л.с. и бензином")]
        public void DefaultConstructorSetsDefaultValues()
        {
            // Act
            var motor = new Motor();

            // Assert
            Assert.AreEqual(150, motor.Power, TestTools.Tolerance);
            Assert.AreEqual(FuelType.Petrol, motor.FuelType);
        }

        [TestCase(80, FuelType.Petrol, TestName =
            "Установка Power через свойство 80 л.с.")]
        [TestCase(250, FuelType.Diesel, TestName =
            "Установка Power через свойство 250 л.с.")]
        public void SettingPowerSetsCorrectValue(
            double newPower, FuelType fuelType)
        {
            // Arrange
            var motor = new Motor(100, fuelType);

            // Act
            motor.Power = newPower;

            // Assert
            Assert.AreEqual(newPower, motor.Power, TestTools.Tolerance);
        }

        [Test(Description = "Установка FuelType через " +
            "свойство изменяет тип топлива")]
        public void SettingFuelTypeChangesFuelType()
        {
            // Arrange
            var motor = new Motor(150, FuelType.Petrol);

            // Act
            motor.FuelType = FuelType.Diesel;

            // Assert
            Assert.AreEqual(FuelType.Diesel, motor.FuelType);
        }

        
        [TestCase(30, FuelType.Petrol, 0.08 * 0.95, TestName =
            "Power=30, Petrol - коэффициент 0.08*0.95")]
        [TestCase(80, FuelType.Gas, 0.08 * 1.00, TestName =
            "Power=80, Gas - коэффициент 0.08*1.00")]
        [TestCase(100, FuelType.Petrol, 0.08 * 0.95, TestName =
            "Power=100, граница - коэффициент 0.08*0.95")]
        [TestCase(70, FuelType.Electricity, 0.08 * 0.15, TestName =
            "Power=70, Electricity - коэффициент 0.08*0.15")]
        [TestCase(120, FuelType.Petrol, 0.09 * 0.95, TestName =
            "Power=120, Petrol - коэффициент 0.09*0.95")]
        [TestCase(150, FuelType.Diesel, 0.09 * 0.90, TestName =
            "Power=150, Diesel - коэффициент 0.09*0.90")]
        [TestCase(200, FuelType.Petrol, 0.09 * 0.95, TestName =
            "Power=200, граница - коэффициент 0.09*0.95")]
        [TestCase(140, FuelType.Electricity, 0.09 * 0.15, TestName =
            "Power=140, Electricity - коэффициент 0.09*0.15")]
        [TestCase(190, FuelType.AviationGasoline, 0.09 * 35.0, TestName =
            "Power=190, AviationGasoline - коэффициент 0.09*35.0")]
        [TestCase(250, FuelType.Petrol, 0.10 * 0.95, TestName =
            "Power=250, Petrol - коэффициент 0.10*0.95")]
        [TestCase(300, FuelType.Diesel, 0.10 * 0.90, TestName =
            "Power=300, Diesel - коэффициент 0.10*0.90")]
        [TestCase(500, FuelType.Gas, 0.10 * 1.00, TestName =
            "Power=500, Gas - коэффициент 0.10*1.00")]
        [TestCase(450, FuelType.AviationGasoline, 0.10 * 35.0, TestName =
            "Power=450, AviationGasoline - коэффициент 0.10*35.0")]
        public void CalculateConsumptionReturnsCorrectCoefficient(
            double power, FuelType fuelType, double expectedCoefficient)
        {
            // Arrange
            var motor = new Motor(power, fuelType);

            // Act
            double actual = motor.CalculateConsumption();

            // Assert
            Assert.AreEqual(expectedCoefficient, actual, TestTools.Tolerance);
        }

        // НЕГАТИВНЫЕ ТЕСТЫ

        [TestCase(-1.0, TestName = "Установка Power = -1")]
        [TestCase(0.0, TestName = "Установка Power = 0")]
        [TestCase(double.NaN, TestName = "Установка Power = NaN")]
        [TestCase(double.PositiveInfinity, TestName =
            "Установка Power = PositiveInfinity")]
        [TestCase(double.NegativeInfinity, TestName =
            "Установка Power = NegativeInfinity")]
        public void SettingPowerInvalidValueThrowsArgumentException(
            double invalidPower)
        {
            // Arrange
            var motor = new Motor(150, FuelType.Petrol);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => motor.Power = invalidPower);
        }

        [TestCase(-5.0, TestName = "Создание Motor с Power = -5")]
        [TestCase(0.0, TestName = "Создание Motor с Power = 0")]
        [TestCase(double.NaN, TestName = "Создание Motor с Power = NaN")]
        [TestCase(double.PositiveInfinity, TestName =
            "Создание Motor с Power = PositiveInfinity")]
        [TestCase(double.NegativeInfinity, TestName =
            "Создание Motor с Power = NegativeInfinity")]
        public void ConstructorWithInvalidPowerThrowsArgumentException(
            double invalidPower)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => 
            new Motor(invalidPower, FuelType.Petrol));
        }
    }
}


