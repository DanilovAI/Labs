using System;
using System.Dynamic;
using Model;


namespace ConsoleLoader
{
    /// <summary>
    /// Точка входа в консольное приложение
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Главное тело программы
        /// </summary>
        /// <param name="args">Аргумент</param>
        internal static void Main(string[] args)
        {
            bool workProgram = true;

            while (workProgram)
            {
                Console.WriteLine("\n1 - Выполнить расчет расхода топлива" +
               "\n2 - Выйти");

                char readProgram = Console.ReadKey().KeyChar;

                switch (readProgram)
                {
                    case '1':
                        {
                            TransportBase transport = SelectTransport();
                            СalculateСonsumptionFuel(transport);
                            break;
                        }

                    case '2':
                        {
                            Console.WriteLine("\nПрограмма завершена");
                            workProgram = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\nНекорректный ввод. " +
                                "Попробуйте еще раз");
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Выбор типа транспорта для расчета расхода топлива
        /// </summary>
        /// <returns>Nhfycgjhn</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static TransportBase SelectTransport()
        {
            TransportBase transport = new Car();

            var catchDictionary = GetCatchDictionary();

            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine("\nВыберите тип транспорта:" +
                        "\n\t1 - машина" +
                        "\n\t2 - машина-гибрид" +
                        "\n\t3 - вертолет");

                    char readTransport = Console.ReadKey().KeyChar;

                    switch (readTransport)
                    {
                        case '1':
                        {
                            transport = ReadCar();
                            break;
                        }

                        case '2':
                        {
                            transport = ReadHybridCar();
                            break;
                        }

                        case '3':
                        {
                            transport = ReadHelicopter();
                            break;
                        }

                        default:
                        {
                            throw new ArgumentOutOfRangeException(
                                "Неверно введен тип транспорта");
                        }
                    }
                },
            };

            ActionsHandler(actions, catchDictionary);

            return transport;
        }

        /// <summary>
        /// Расчет расхода топлива
        /// </summary>
        /// <param name="transport">Объект транспорт</param>
        public static void СalculateСonsumptionFuel(TransportBase transport)
        {
            var catchDictionary = GetCatchDictionary();

            Action action =
                () =>
                {
                    switch (transport)
                    {
                        case HybridCar newHybridCar:
                        {
                            Console.Write($"\nВведите расстояние в км: ");

                            double distance = 
                                Convert.ToDouble(Console.ReadLine());
                            ReadPositiveDouble(distance);

                            double consumption = 
                                newHybridCar.CalculateFuel(distance);

                            var consumptionRounded = 
                                Math.Round(consumption, 1);

                            Console.Write($"\nРасход топлива " +
                                $"для прохождения {distance} км " +
                                $"составит {consumptionRounded} л.\n");
                        }
                        break;

                        case Car newCar:
                        {
                            Console.Write("\nВведите расстояние в км: ");

                            double distance = 
                                Convert.ToDouble(Console.ReadLine());
                            ReadPositiveDouble(distance);

                            double consumption = 
                                newCar.CalculateFuel(distance);
                            var consumptionRounded = 
                                Math.Round(consumption, 1);
                            string unit = newCar.Motor.FuelType == 
                                FuelType.Electricity 
                                ? "кВт·ч" : "л";

                            Console.Write($"\nРасход топлива " +
                                $"для прохождения расстояния " +
                                $"{distance} км составит " +
                                $"{consumptionRounded} {unit}.\n");
                        }
                        break;

                        case Helicopter newHelicopter:
                        {
                            Console.Write("\nВведите длительность " +
                                "полета в часах: ");
                            double flightHours = 
                                Convert.ToDouble(Console.ReadLine());
                            ReadPositiveDouble(flightHours);

                            double consumption =
                                newHelicopter.CalculateFuel(flightHours);
                            var consumptionRounded = 
                                Math.Round(consumption, 1);

                            Console.Write($"\nРасход топлива для полета " +
                                $"{flightHours} ч " +
                                $"составит {consumptionRounded} л.\n");
                        }
                        break;

                        default:
                        {
                            Console.WriteLine("Неизвестный тип транспорта.");
                        }
                        break;
                    }
                };

            ActionHandler(action, catchDictionary);
        }

        /// <summary>
        /// Ввод данных о машине
        /// </summary>
        /// <returns>Объект машина</returns>
        public static Car ReadCar()
        {
            var catchDictionary = GetCatchDictionary();

            Car car = new Car();

            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine($"\nВведите данные о двигателе");
                     car.Motor = ReadMotor(car);
                },

                ()=>
                {
                    car.Mass = ReadMass();
                },
            };

            ActionsHandler(actions, catchDictionary);

            return car;
        }

        /// <summary>
        /// Ввод данных о машине-гибриде
        /// </summary>
        /// <returns>Объект машина-гибрид</returns>
        public static HybridCar ReadHybridCar()
        {
            var catchDictionary = GetCatchDictionary();

            HybridCar hybridCar = new HybridCar();

            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine($"\nВведите данные об основном" +
                         $" двигателе");
                     hybridCar.Motor = ReadMotor(hybridCar);
                },

                ()=>
                {
                    Console.WriteLine($"\nВведите данные о дополнительном" +
                        $" двигателе");
                    hybridCar.AdditionalMotor = 
                    ReadAdditionalMotor(hybridCar.Motor);
                },

                ()=>
                {
                    hybridCar.Mass = ReadMass();
                },
            };

            ActionsHandler(actions, catchDictionary);

            return hybridCar;
        }

        /// <summary>
        /// Ввод данных о вертолете
        /// </summary>
        /// <returns>Объект вертолет</returns>
        public static Helicopter ReadHelicopter()
        {
            var catchDictionary = GetCatchDictionary();

            Helicopter helicopter = new Helicopter();

            List<Action> actions = new()
            {
                ()=>
                {
                     Console.WriteLine($"\nВведите данные о двигателе");
                     helicopter.Motor = ReadMotor(helicopter);
                },

                ()=>
                {
                    helicopter.Mass = ReadHelicopterMass();
                },
            };

            ActionsHandler(actions, catchDictionary);

            return helicopter;
        }


        /// <summary>
        /// Ввод данных о двигателе
        /// </summary>
        /// <param name="transport">Транспорт</param>
        /// <returns>Объект двигатель</returns>
        /// <exception cref="ArgumentOutOfRangeException">Выход
        /// за пределы</exception>
        public static Motor ReadMotor(TransportBase transport)
        {
            var catchDictionary = GetCatchDictionary();

            Motor motor = new Motor();

            List<Action> actions = new()
            {
                ()=>
                {
                    Dictionary<char, FuelType> сonsumptionFuel;
                    char keyInfo;

                    Console.WriteLine($"\nВыберите вид топлива: ");

                    if (transport is Car || transport is HybridCar)
                    {
                        Console.WriteLine($"\t1 - бензин" +
                                         "\n\t2 - дизель" +
                                         "\n\t3 - электричество" +
                                         "\n\t4 - газ");

                        keyInfo = Console.ReadKey().KeyChar;

                        сonsumptionFuel = new()
                        {
                            {'1', FuelType.Petrol},
                            {'2', FuelType.Diesel},
                            {'3', FuelType.Electricity},
                            {'4', FuelType.Gas},
                        };
                    }
                    else
                    {
                        Console.WriteLine($"\n\t1 - авиационный керосин" +
                                           "\n\t2 - авиационный бензин");

                        keyInfo = Console.ReadKey().KeyChar;

                        сonsumptionFuel = new()
                        {
                            {'1', FuelType.AviationKerosene},
                            {'2', FuelType.AviationGasoline},
                        };
                    }

                    if(!сonsumptionFuel.ContainsKey(keyInfo))
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                     motor.FuelType = сonsumptionFuel[keyInfo];
                },

                ()=>
                {
                    if (transport is Car || transport is HybridCar)
                    {
                        motor.Power = ReadCarMotorPower();
                    }
                    else
                    {
                        motor.Power = ReadHelicopterMotorPower();
                    }
                },
            };

            ActionsHandler(actions, catchDictionary);

            return motor;
        }

        /// <summary>
        /// Ввод данных о дополнительном двигателе
        /// </summary>
        /// <param name="mainMotor"></param>
        /// <returns>Объект двигатель</returns>
        /// <exception cref="ArgumentOutOfRangeException">Выход
        /// за пределы</exception>
        public static Motor ReadAdditionalMotor(Motor mainMotor)
        {
            var catchDictionary = GetCatchDictionary();

            Motor additionalMotor = new Motor();

            List<Action> actions = new()
            {
                () =>
                {
                    if (mainMotor.FuelType == FuelType.Electricity)
                    {
                        Console.WriteLine("\nВыберите вид топлива " +
                            "для дополнительного двигателя: " +
                        "\n\t1 - бензин" +
                        "\n\t2 - дизель" +
                        "\n\t3 - газ");

                        char keyInfo = Console.ReadKey().KeyChar;

                        Dictionary<char, FuelType> consumptionFuel = new()
                        {
                            { '1', FuelType.Petrol },
                            { '2', FuelType.Diesel },
                            { '3', FuelType.Gas },
                        };

                        if (!consumptionFuel.ContainsKey(keyInfo))
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        additionalMotor.FuelType = consumptionFuel[keyInfo];
                    }
                    else
                    {
                        Console.WriteLine("\nТип второго двигателя - " +
                            "электрический");
                        additionalMotor.FuelType = FuelType.Electricity;
                    }
                },
                () =>
                {
                    additionalMotor.Power = ReadCarMotorPower();
                },
            };

            ActionsHandler(actions, catchDictionary);

            return additionalMotor;
        }


        /// <summary>
        /// Ввод мощности двигателя авто в л.с.
        /// </summary>
        /// <returns>Мощность в л.с.</returns>
        public static double ReadCarMotorPower()
        {
            double power;
            const int minPower = 1;
            const int maxPower = 2300;

            do
            {
                Console.Write($"\nВведите мощность двигателя в л.с. " +
                      $"(не более {maxPower} л.с.): ");
                power = Convert.ToDouble(Console.ReadLine());

                if (power < minPower || power > maxPower)
                {
                    Console.WriteLine($"\nПожалуйста, " +
                        $"введите мощность двигателя в пределах от " +
                        $"{minPower} до {maxPower} л.с.");
                }
            } 
            while (power < minPower || power > maxPower);

            return power;
        }

        /// <summary>
        /// Ввод мощности вертолета в л.с.
        /// </summary>
        /// <returns>Мощность вертолета в л.с.</returns>
        public static double ReadHelicopterMotorPower()
        {
            double power;
            const int minPower = 100;
            const int maxPower = 22800;

            do
            {
                Console.Write($"\nВведите мощность двигателя " +
                    $"вертолета в л.с. (не более {maxPower} л.с.): " +
                              $": ");
                power = Convert.ToDouble(Console.ReadLine());

                if (power < minPower || power > maxPower)
                {
                    Console.WriteLine($"\nПожалуйста, " +
                        $"введите мощность двигателя в пределах " +
                        $"от {minPower} до {minPower} л.с.");
                }
            } while (power < minPower || power > maxPower);

            return power;
        }

        /// <summary>
        /// Ввод массы автомобиля в тоннах
        /// </summary>
        /// <returns></returns>
        public static double ReadMass()
        {
            double mass;
            const double minMass = 0.1;
            const double maxMass = 10;
            do
            {
                Console.Write($"\nВведите массу машины в тоннах " +
                    $"(не более {maxMass} тонн): ");

                mass = Convert.ToDouble(Console.ReadLine());

                if (mass < minMass || mass > maxMass)
                {
                    Console.WriteLine($"\nПожалуйста," +
                        $" введите массу в пределах от {minMass} " +
                        $"до {minMass} тонн.");
                }
            } while (mass < minMass || mass > maxMass);

            return mass;
        }

        /// <summary>
        /// Ввод массы вертолета в тоннах
        /// </summary>
        /// <returns>Масса вертолета в тоннах</returns>
        public static double ReadHelicopterMass()
        {
            double mass;
            const double minMass = 0.1;
            const double maxMass = 56;

            do
            {
                Console.Write($"\nВведите массу вертолета в тоннах " +
                    $"(не более {maxMass} тонн): ");

                mass = Convert.ToDouble(Console.ReadLine());

                if (mass < minMass || mass > maxMass)
                {
                    Console.WriteLine($"\nПожалуйста, " +
                        $"введите массу в пределах от " +
                        $"{minMass} до {maxMass} тонн.");
                }
            } while (mass < minMass || mass > maxMass);

            return mass;
        }

        /// <summary>
        /// Проверка на ввод положительного числа
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static void ReadPositiveDouble(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Число должно быть" +
                    " положительным");
            }
        }

        /// <summary>
        /// Создание словаря для обработки исключений
        /// </summary>
        /// <returns>Словарь</returns>
        private static Dictionary<Type, Action<string>> GetCatchDictionary()
        {
            return new Dictionary<Type, Action<string>>
            {
                {
                    typeof(ArgumentOutOfRangeException),
                    (msg) => Console.WriteLine($"\nИсключение: {msg}")
                },
                {
                    typeof(ArgumentException),
                    (msg) => Console.WriteLine($"\nИсключение: {msg}")
                },
                {
                    typeof(FormatException),
                    (msg) => Console.WriteLine($"\nИсключение: {msg}")
                },
                {
                    typeof(OverflowException),
                    (msg) => Console.WriteLine($"\nИсключение: {msg}")
                },
            };

        }

        /// <summary>
        /// Метод обработки действий
        /// </summary>
        /// <param name="assignActions">Действие, требующее проверки</param>
        /// <param name="catchDictionary">Словарь искоючений</param>
        private static void ActionsHandler(List<Action> assignActions,
            Dictionary<Type, Action<string>> catchDictionary)
        {
            foreach (var assignAction in assignActions)
            {
                ActionHandler(assignAction, catchDictionary);
            }
        }

        /// <summary>
        /// Метод обработки действий
        /// </summary>
        /// <param name="assignAction">Действие, требующее проверки</param>
        /// <param name="catchDictionary">Словарь искоючений</param>
        private static void ActionHandler(Action assignAction,
            Dictionary<Type, Action<string>> catchDictionary)
        {
            while (true)
            {
                try
                {
                    assignAction.Invoke();
                    break;
                }
                catch (Exception exception)
                {
                    catchDictionary[exception.GetType()].
                        Invoke(exception.Message);
                }
            }
        }

    }
}
