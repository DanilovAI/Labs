using Model;
using NUnit.Framework;

namespace ModelTests
{
    public class HelicopterTests
    {
        private const double Tolerance = 1e-6;

        // ПОЗИТИВНЫЕ ТЕСТЫ

        [TestCase(250, FuelType.AviationKerosene, 5.0, 
            TestName = "Создание Helicopter с авиационным керосином, масса 5 т")]
        [TestCase(300, FuelType.AviationGasoline, 6.5, 
            TestName = "Создание Helicopter с авиационным бензином, масса 6.5 т")]
        public void ConstructorWithMotorAndWeightSetsProperties(
            double power, FuelType fuelType, double weight)
        {
            // Arrange
            var motor = new Motor(power, fuelType);

            // Act
            var helicopter = new Helicopter(motor, weight);

            // Assert
            Assert.AreEqual(motor, helicopter.Motor);
            Assert.AreEqual(weight, helicopter.Weight, Tolerance);
            Assert.IsNotNull(helicopter);
        }

        [Test(Description = "Конструктор по умолчанию создаёт Helicopter" +
            " с мотором 250 л.с., авиационный керосин, масса 10 т")]
        public void DefaultConstructorSetsDefaultValues()
        {
            // Act
            var helicopter = new Helicopter();

            // Assert
            Assert.AreEqual(250, helicopter.Motor.Power);
            Assert.AreEqual(FuelType.AviationKerosene, helicopter.Motor.FuelType);
            Assert.AreEqual(10.0, helicopter.Weight, Tolerance);
            Assert.AreEqual("Вертолет", helicopter.TypeTransport);
        }

        [TestCase(250, FuelType.AviationKerosene, 5.0,
            "Тип топлива: Авиационный керосин", 
            TestName = "DisplayInfo для авиационного керосина")]
        [TestCase(300, FuelType.AviationGasoline, 6.5, 
            "Тип топлива: Авиационный бензин", 
            TestName = "DisplayInfo для авиационного бензина")]
        public void DisplayInfoContainsCorrectFields(
            double power, FuelType fuelType, 
            double weight, string expectedFuelLine)
        {
            // Arrange
            var motor = new Motor(power, fuelType);
            var helicopter = new Helicopter(motor, weight);

            // Act
            string info = helicopter.DisplayInfo;

            // Assert
            Assert.IsTrue(info.Contains(expectedFuelLine));
            Assert.IsTrue(info.Contains($"{power} л.с."));
            Assert.IsTrue(info.Contains($"{weight} т"));
        }

        [TestCase(250, FuelType.AviationKerosene, 5.0, 1.5, TestName =
            "CalculateFuel для 1.5 часов полёта возвращает " +
            "положительное значение")]
        [TestCase(300, FuelType.AviationGasoline, 6.0, 2.0, TestName =
            "CalculateFuel для 2 часов полёта возвращает " +
            "положительное значение")]
        public void CalculateFuelReturnsPositiveValue(
            double power, FuelType fuelType, 
            double weight, double hours)
        {
            // Arrange
            var motor = new Motor(power, fuelType);
            var helicopter = new Helicopter(motor, weight);

            // Act
            double fuel = helicopter.CalculateFuel(hours);

            // Assert
            Assert.Greater(fuel, 0);
            Assert.IsFalse(double.IsNaN(fuel));
            Assert.IsFalse(double.IsInfinity(fuel));
        }

        [TestCase(250, FuelType.AviationKerosene, 5.0, 0.0, 0,
            TestName = "При нулевой длительности расход равен 0")]
        [TestCase(250, FuelType.AviationKerosene, 5.0, 1.0, 1,
            TestName = "Расход положителен при положительной длительности")]
        public void CalculateFuelForZeroHoursReturnsZero(
            double power, FuelType fuelType,
            double weight, double hours, double expected)
        {
            // Arrange
            var motor = new Motor(power, fuelType);
            var helicopter = new Helicopter(motor, weight);

            // Act
            double fuel = helicopter.CalculateFuel(hours);

            // Assert
            if (expected == 0)
                Assert.AreEqual(0, fuel, Tolerance);
            else
                Assert.Greater(fuel, 0);
        }

        [TestCase(250, FuelType.AviationKerosene, 5.0, "л в час", TestName =
            "FuelConsumption возвращает литры в час для авиакеросина")]
        [TestCase(300, FuelType.AviationGasoline, 6.0, "л в час", TestName =
            "FuelConsumption возвращает литры в час для авиабензина")]
        public void FuelConsumptionReturnsCorrectUnit(
            double power, FuelType fuelType, 
            double weight, string expectedUnit)
        {
            // Arrange
            var motor = new Motor(power, fuelType);
            var helicopter = new Helicopter(motor, weight);
            double calculated = helicopter.CalculateFuel(1);

            // Act
            string consumption = helicopter.FuelConsumption;

            // Assert
            Assert.IsTrue(consumption.Contains(expectedUnit));
        }

        // НЕГАТИВНЫЕ ТЕСТЫ

        [TestCase(-1.0, TestName = "Установка Weight = -1")]
        [TestCase(0.0, TestName = "Установка Weight = 0")]
        [TestCase(double.NaN, TestName = "Установка Weight = NaN")]
        [TestCase(double.PositiveInfinity, TestName =
            "Установка Weight = PositiveInfinity")]
        [TestCase(double.NegativeInfinity, TestName =
            "Установка Weight = NegativeInfinity")]
        public void SettingWeightInvalidValueThrowsArgumentException(
            double invalidWeight)
        {
            // Arrange
            var helicopter = new Helicopter();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => 
            helicopter.Weight = invalidWeight);
        }

        [TestCase(-1.0, TestName = "Создание Helicopter с Weight = -1")]
        [TestCase(0.0, TestName = "Создание Helicopter с Weight = 0")]
        [TestCase(double.NaN, TestName = "Создание Helicopter с Weight = NaN")]
        [TestCase(double.PositiveInfinity, TestName =
            "Создание Helicopter с Weight = PositiveInfinity")]
        [TestCase(double.NegativeInfinity, TestName =
            "Создание Helicopter с Weight = NegativeInfinity")]
        public void ConstructorWithInvalidWeightThrowsArgumentException(
            double invalidWeight)
        {
            // Arrange
            var validMotor = new Motor(250, FuelType.AviationKerosene);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => 
            new Helicopter(validMotor, invalidWeight));
        }

        [TestCase(-10.0, TestName = "Установка Power = -10")]
        [TestCase(0.0, TestName = "Установка Power = 0")]
        [TestCase(double.NaN, TestName = "Установка Power = NaN")]
        [TestCase(double.PositiveInfinity, TestName =
            "Установка Power = PositiveInfinity")]
        [TestCase(double.NegativeInfinity, TestName =
            "Установка Power = NegativeInfinity")]
        public void SettingMotorPowerInvalidValueThrowsArgumentException(
            double invalidPower)
        {
            // Arrange
            var motor = new Motor(250, FuelType.AviationKerosene);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            motor.Power = invalidPower);
        }

        [TestCase(double.NaN, TestName = "Создание Motor с Power = NaN")]
        [TestCase(double.PositiveInfinity, TestName =
            "Создание Motor с Power = PositiveInfinity")]
        [TestCase(double.NegativeInfinity, TestName =
            "Создание Motor с Power = NegativeInfinity")]
        [TestCase(-5.0, TestName = "Создание Motor с Power = -5")]
        [TestCase(0.0, TestName = "Создание Motor с Power = 0")]
        public void ConstructorMotorWithInvalidPowerThrowsArgumentException(
            double invalidPower)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Motor(
                invalidPower, FuelType.AviationKerosene));
        }

        [Test(Description = "Установка Motor = null " +
            "выбрасывает NullReferenceException")]
        public void SettingMotorNullThrowsNullReferenceException()
        {
            // Arrange
            var helicopter = new Helicopter();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
            helicopter.Motor = null);
        }

        [Test(Description = "Создание Helicopter с null мотором " +
            "выбрасывает NullReferenceException")]
        public void ConstructorNullMotorThrowsNullReferenceException()
        {
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => 
            new Helicopter(null, 5.0));
        }

    }
}