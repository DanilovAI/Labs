using Model;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ModelTests
{
    //TODO: XML
    public class CarTests
    {
        //TODO: XML
        private const double Tolerance = 1e-6;

        // ПОЗИТИВНЫЕ ТЕСТЫ

        [TestCase(100, 1.2, FuelType.Petrol, TestName =
            "Создание Car с бензиновым двигателем 100 л.с., массой 1.2 т")]
        [TestCase(200, 1.5, FuelType.Diesel, TestName =
            "Создание Car с дизельным двигателем 200 л.с., массой 1.5 т")]
        [TestCase(50, 0.8, FuelType.Electricity, TestName =
            "Создание Car с электродвигателем 50 л.с., массой 0.8 т")]
        [TestCase(150, 2.0, FuelType.Gas, TestName =
            "Создание Car с двигателем на газе 150 л.с., массой 2.0 т")]
        public void ConstructorWithMotorAndWeightSetsProperties(
            double power, double weight, FuelType fuelType)
        {
            // Arrange
            var motor = new Motor(power, fuelType);

            // Act
            var car = new Car(motor, weight);

            // Assert
            Assert.AreEqual(motor, car.Motor);
            Assert.AreEqual(weight, car.Weight);
        }

        [Test(Description = "Конструктор по умолчанию создаёт " +
            "Car с двигателем 150 л.с., бензин, вес 1 т")]
        public void DefaultConstructorSetsDefaultValues()
        {
            // Act
            var motor = new Motor();
            var car = new Car();
            var car1 = new Car(motor, 1);

            // Assert
            Assert.AreEqual(150, car.Motor.Power);
            Assert.AreEqual(FuelType.Petrol, car.Motor.FuelType);
            Assert.AreEqual(1.0, car.Weight, Tolerance);
            Assert.AreEqual("Машина", car.TypeTransport);
            Assert.AreEqual(150, car1.Motor.Power);
            Assert.AreEqual(FuelType.Petrol, car1.Motor.FuelType);
            Assert.AreEqual(1.0, car1.Weight, Tolerance);
            Assert.AreEqual("Машина", car1.TypeTransport);
        }


        [TestCase(150, FuelType.Petrol, 1.2, "Тип топлива: Бензин", 
            TestName = "DisplayInfo для бензиновой машины")]
        [TestCase(200, FuelType.Diesel, 1.5, "Тип топлива: Дизель", 
            TestName = "DisplayInfo для дизельной машины")]
        [TestCase(80, FuelType.Electricity, 1.4, "Тип топлива: Электричество", 
            TestName = "DisplayInfo для электромобиля")]
        [TestCase(100, FuelType.Gas, 0.9, "Тип топлива: Газ", 
            TestName = "DisplayInfo для машины на газе")]
        public void DisplayInfoContainsCorrectFields(
            double power, FuelType fuelType,
            double weight, string expectedFuelLine)
        {
            // Arrange
            var motor = new Motor(power, fuelType);
            var car = new Car(motor, weight);

            // Act
            string info = car.DisplayInfo;

            // Assert
            Assert.IsTrue(info.Contains(expectedFuelLine));
            Assert.IsTrue(info.Contains($"{power} л.с."));
            Assert.IsTrue(info.Contains($"{weight} т"));
        }

        [TestCase(150, FuelType.Petrol, 1.2, 100, TestName =
            "CalculateFuel для бензина на 100 км возвращает корректное значение")]
        [TestCase(220, FuelType.Diesel, 1.5, 50, TestName =
            "CalculateFuel для дизеля на 50 км возвращает корректное значение")]
        [TestCase(80, FuelType.Electricity, 1.4, 200, TestName =
            "CalculateFuel для электричества на 200 км возвращает корректное значение")]
        public void CalculateFuelReturnsPositiveValue(
            double power, FuelType fuelType, double weight, double distance)
        {
            // Arrange
            var motor = new Motor(power, fuelType);
            var car = new Car(motor, weight);

            // Act
            double fuel = car.CalculateFuel(distance);

            // Assert
            Assert.Greater(fuel, 0);
            Assert.IsFalse(double.IsNaN(fuel));
            Assert.IsFalse(double.IsInfinity(fuel));
        }

        [TestCase(150, FuelType.Petrol, 1.2, 0, 0, TestName =
            "При нулевой дистанции расход равен 0")]
        [TestCase(200, FuelType.Diesel, 1.5, 100, 1, TestName =
            "Расход положителен при положительной дистанции")]
        public void CalculateFuelForZeroDistanceReturnsZero(
            double power, FuelType fuelType, 
            double weight, double distance, double expected)
        {
            // Arrange
            var motor = new Motor(power, fuelType);
            var car = new Car(motor, weight);

            // Act
            double fuel = car.CalculateFuel(distance);

            // Assert
            if (expected == 0)
                Assert.AreEqual(0, fuel, Tolerance);
            else
                Assert.Greater(fuel, 0);
        }

        [TestCase(150, FuelType.Petrol, 1.2, 100, "л на 100 км", 
            TestName = "FuelConsumption возвращает литры для бензина")]
        [TestCase(200, FuelType.Diesel, 1.5, 100, "л на 100 км", 
            TestName = "FuelConsumption возвращает литры для дизеля")]
        [TestCase(80, FuelType.Electricity, 1.4, 100, "кВт⋅ч на 100 км", 
            TestName = "FuelConsumption возвращает кВт⋅ч для электричества")]
        public void FuelConsumptionReturnsCorrectUnit(
            double power, FuelType fuelType,
            double weight, double distance, string expectedUnit)
        {
            // Arrange
            var motor = new Motor(power, fuelType);
            var car = new Car(motor, weight);
            double calculated = car.CalculateFuel(distance);

            // Act
            string consumption = car.FuelConsumption;

            // Assert
            Assert.IsTrue(consumption.Contains(expectedUnit));
        }

        // НЕГАТИВНЫЕ ТЕСТЫ

        [TestCase(-1.0, TestName = "Установка Weight = -1")]
        [TestCase(0.0, TestName = "Установка Weight = 0")]
        [TestCase(double.NaN, TestName = "Установка Weight = NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Установка Weight" +
            " = PositiveInfinity")]
        [TestCase(double.NegativeInfinity, TestName = "Установка Weight " +
            "= NegativeInfinity")]
        public void SettingWeightInvalidValueThrowsArgumentException
            (double invalidWeight)
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => car.Weight = invalidWeight);
        }

        [TestCase(-1.0, TestName = "Создание Car с Weight = -1")]
        [TestCase(0.0, TestName = "Создание Car с Weight = 0")]
        [TestCase(double.NaN, TestName = "Создание Car с Weight = NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Создание Car с Weight " +
            "= PositiveInfinity")]
        [TestCase(double.NegativeInfinity, TestName = "Создание Car с Weight " +
            "= NegativeInfinity")]
        public void ConstructorWithInvalidWeightThrowsArgumentException(
            double invalidWeight)
        {
            // Arrange
            var validMotor = new Motor(150, FuelType.Petrol);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Car(validMotor, invalidWeight));
        }

        [TestCase(-10.0, TestName = "Установка Power = -10")]
        [TestCase(0.0, TestName = "Установка Power = 0")]
        [TestCase(double.NaN, TestName = "Установка Power = NaN")]
        [TestCase(double.PositiveInfinity, TestName = "Установка Power =" +
            " PositiveInfinity")]
        [TestCase(double.NegativeInfinity, TestName = "Установка Power =" +
            " NegativeInfinity")]
        public void SettingMotorPowerInvalidValueThrowsArgumentException(
            double invalidPower)
        {
            // Arrange
            var motor = new Motor(150, FuelType.Petrol);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => motor.Power = invalidPower);
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
            Assert.Throws<ArgumentException>(() => 
            new Motor(invalidPower, FuelType.Petrol));
        }

        [Test(Description = "Установка Motor =" +
            " null выбрасывает NullReferenceException (CheckIsMotorEmpty)")]
        public void SettingMotorNullThrowsNullReferenceException()
        {
            // Arrange
            var car = new Car();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => car.Motor = null);
        }

        [Test(Description = "Создание Car с null мотором выбрасывает" +
            " NullReferenceException")]
        public void ConstructorNullMotorThrowsNullReferenceException()
        {
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new Car(null, 1.0));
        }


    }
}