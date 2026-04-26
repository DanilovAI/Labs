using Model;
using NUnit.Framework;

namespace ModelTests
{
    public class HybridCarTests
    {
        private const double Tolerance = 1e-6;

        // ПОЗИТИВНЫЕ ТЕСТЫ

        [TestCase(100, FuelType.Petrol, 1.2, 50, FuelType.Electricity, 
            TestName = "Создание HybridCar: бензин + электричество")]
        [TestCase(150, FuelType.Diesel, 1.5, 40, FuelType.Electricity, 
            TestName = "Создание HybridCar: дизель + электричество")]
        public void ConstructorWithMotorsAndWeightSetsProperties(
            double powerMain, FuelType fuelMain, double weight, 
            double powerAdd, FuelType fuelAdd)
        {
            // Arrange
            var mainMotor = new Motor(powerMain, fuelMain);
            var addMotor = new Motor(powerAdd, fuelAdd);

            // Act
            var hybrid = new HybridCar(mainMotor, weight, addMotor);

            // Assert
            Assert.AreEqual(mainMotor, hybrid.Motor);
            Assert.AreEqual(addMotor, hybrid.AdditionalMotor);
            Assert.AreEqual(weight, hybrid.Weight, Tolerance);
        }

        [Test(Description = "Конструктор по умолчанию создаёт HybridCar " +
            "с бензиновым (100 л.с.) и электрическим (50 л.с.) моторами, вес 1 т")]
        public void DefaultConstructorSetsDefaultValues()
        {
            // Act
            var hybrid = new HybridCar();

            // Assert
            Assert.AreEqual(100, hybrid.Motor.Power);
            Assert.AreEqual(FuelType.Petrol, hybrid.Motor.FuelType);
            Assert.AreEqual(50, hybrid.AdditionalMotor.Power);
            Assert.AreEqual(FuelType.Electricity, hybrid.AdditionalMotor.FuelType);
            Assert.AreEqual(1.0, hybrid.Weight, Tolerance);
            Assert.AreEqual("Гибридная машина", hybrid.TypeTransport);
        }

        [TestCase(100, FuelType.Petrol, 1.2, 50, FuelType.Electricity,
            "Основное топливо: Бензин", "Мощность электрического двигателя: 50 л.с.",
            TestName = "DisplayInfo для бензин+электричество")]
        [TestCase(180, FuelType.Diesel, 1.5, 120, FuelType.Electricity,
            "Основное топливо: Дизель", "Мощность электрического двигателя: 120 л.с.",
            TestName = "DisplayInfo для дизель+электричество")]
        public void DisplayInfoContainsCorrectFields(
            double powerMain, FuelType fuelMain, double weight,
            double powerAdd, FuelType fuelAdd,
            string expectedMainFuelLine, string expectedAddPowerLine)
        {
            // Arrange
            var mainMotor = new Motor(powerMain, fuelMain);
            var addMotor = new Motor(powerAdd, fuelAdd);
            var hybrid = new HybridCar(mainMotor, weight, addMotor);

            // Act
            string info = hybrid.DisplayInfo;

            // Assert
            Assert.IsTrue(info.Contains(expectedMainFuelLine));
            Assert.IsTrue(info.Contains($"Мощность основного двигателя:" +
                $" {powerMain} л.с."));
            Assert.IsTrue(info.Contains(expectedAddPowerLine));
            Assert.IsTrue(info.Contains($"Масса: {weight} т"));
        }

        [TestCase(100, FuelType.Petrol, 1.2, 50, FuelType.Electricity, 100,
            TestName = "CalculateFuel для гибрида на 100 км" +
            " возвращает положительное значение")]
        public void CalculateFuelReturnsPositiveValue(
            double powerMain, FuelType fuelMain, double weight,
            double powerAdd, FuelType fuelAdd, double distance)
        {
            // Arrange
            var mainMotor = new Motor(powerMain, fuelMain);
            var addMotor = new Motor(powerAdd, fuelAdd);
            var hybrid = new HybridCar(mainMotor, weight, addMotor);

            // Act
            double fuel = hybrid.CalculateFuel(distance);

            // Assert
            Assert.Greater(fuel, 0);
            Assert.IsFalse(double.IsNaN(fuel));
            Assert.IsFalse(double.IsInfinity(fuel));
        }

        [TestCase(100, FuelType.Petrol, 1.2, 50, FuelType.Electricity, 0, 0, 
            TestName = "При нулевой дистанции расход равен 0")]
        [TestCase(100, FuelType.Petrol, 1.2, 50, FuelType.Electricity, 50, 1, 
            TestName = "Расход положителен при положительной дистанции")]
        public void CalculateFuelForZeroDistanceReturnsZero(
            double powerMain, FuelType fuelMain, double weight,
            double powerAdd, FuelType fuelAdd,double distance, double expected)
        {
            // Arrange
            var mainMotor = new Motor(powerMain, fuelMain);
            var addMotor = new Motor(powerAdd, fuelAdd);
            var hybrid = new HybridCar(mainMotor, weight, addMotor);

            // Act
            double fuel = hybrid.CalculateFuel(distance);

            // Assert
            if (expected == 0)
                Assert.AreEqual(0, fuel, Tolerance);
            else
                Assert.Greater(fuel, 0);
        }

        [TestCase(100, FuelType.Petrol, 1.2, 50, FuelType.Electricity, 
            "л на 100 км", TestName = "FuelConsumption возвращает литры на 100 км")]
        public void FuelConsumptionReturnsCorrectUnit(
            double powerMain, FuelType fuelMain, double weight,
            double powerAdd, FuelType fuelAdd, string expectedUnit)
        {
            // Arrange
            var mainMotor = new Motor(powerMain, fuelMain);
            var addMotor = new Motor(powerAdd, fuelAdd);
            var hybrid = new HybridCar(mainMotor, weight, addMotor);
            double calculated = hybrid.CalculateFuel(100);

            // Act
            string consumption = hybrid.FuelConsumption;

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
            var hybrid = new HybridCar();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => hybrid.Weight = invalidWeight);
        }

        [TestCase(-1.0, TestName = "Создание HybridCar с Weight = -1")]
        [TestCase(0.0, TestName = "Создание HybridCar с Weight = 0")]
        [TestCase(double.NaN, TestName = "Создание HybridCar с Weight = NaN")]
        [TestCase(double.PositiveInfinity, TestName =
            "Создание HybridCar с Weight = PositiveInfinity")]
        [TestCase(double.NegativeInfinity, TestName =
            "Создание HybridCar с Weight = NegativeInfinity")]
        public void ConstructorWithInvalidWeightThrowsArgumentException(
            double invalidWeight)
        {
            // Arrange
            var mainMotor = new Motor(100, FuelType.Petrol);
            var addMotor = new Motor(50, FuelType.Electricity);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => 
            new HybridCar(mainMotor, invalidWeight, addMotor));
        }

        [TestCase(-10.0, TestName = "Установка Power основного мотора = -10")]
        [TestCase(0.0, TestName = "Установка Power основного мотора = 0")]
        [TestCase(double.NaN, TestName = "Установка Power основного мотора = NaN")]
        [TestCase(double.PositiveInfinity, TestName =
            "Установка Power основного мотора = +Infinity")]
        [TestCase(double.NegativeInfinity, TestName =
            "Установка Power основного мотора = -Infinity")]
        public void SettingMainMotorPowerInvalidValueThrowsArgumentException(
            double invalidPower)
        {
            // Arrange
            var hybrid = new HybridCar();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            hybrid.Motor.Power = invalidPower);
        }

        [Test(Description = "Установка AdditionalMotor с тем же типом топлива," +
            " что и у основного, вызывает ArgumentException")]
        public void SettingAdditionalMotorSameFuelTypeThrowsArgumentException()
        {
            // Arrange
            var mainMotor = new Motor(100, FuelType.Petrol);
            var addMotor = new Motor(50, FuelType.Petrol);
            
            var hybrid = new HybridCar(mainMotor, 1.0, 
                new Motor(50, FuelType.Electricity));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => 
            hybrid.AdditionalMotor = addMotor);
        }

        [Test(Description = "Установка AdditionalMotor =" +
            " null выбрасывает NullReferenceException")]
        public void SettingAdditionalMotorNullThrowsNullReferenceException()
        {
            // Arrange
            var mainMotor = new Motor(100, FuelType.Petrol);
            var hybrid = new HybridCar(mainMotor, 1.0, 
                new Motor(50, FuelType.Electricity));

            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
            hybrid.AdditionalMotor = null);
        }

        [Test(Description = "Создание HybridCar с null" +
            " AdditionalMotor выбрасывает NullReferenceException")]
        public void ConstructorNullAdditionalMotorThrowsNullReferenceException()
        {
            // Arrange
            var mainMotor = new Motor(100, FuelType.Petrol);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => 
            new HybridCar(mainMotor, 1.0, null));
        }

        [Test(Description = "Создание HybridCar с null" +
            " основным мотором выбрасывает NullReferenceException")]
        public void ConstructorNullMainMotorThrowsNullReferenceException()
        {
            // Arrange
            var addMotor = new Motor(50, FuelType.Electricity);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new HybridCar(null, 1.0, addMotor));
        }

    }
}