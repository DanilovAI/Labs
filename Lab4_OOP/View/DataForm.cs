using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Класс DataForm
    /// </summary>
    public partial class DataForm : Form
    {
        /// <summary>
        /// Поле для обработки события добавления транспорта
        /// </summary>
        public EventHandler TransportAdded;

        /// <summary>
        /// Поле для обработки события отмена
        /// </summary>
        public EventHandler TransportCancel;

        /// <summary>
        /// Поле для хранения последнего добавленного объекта
        /// </summary>
        private TransportBase _lastTransport;

        /// <summary>
        /// Словарь тип транспорта
        /// </summary>
        private static readonly Dictionary<string, TypeTransport>
            _typesTransports = new Dictionary<string, TypeTransport>
        {
            {"Машина", TypeTransport.Car},
            {"Гибридная машина", TypeTransport.HybridCar},
            {"Вертолет", TypeTransport.Helicopter},
        };

        /// <summary>
        /// Словарь типов топлива
        /// </summary>
        private static readonly Dictionary<string, FuelType> _typesFuel
            = new Dictionary<string, FuelType>
        {
            {"Бензин", FuelType.Petrol},
            {"Дизель", FuelType.Diesel},
            {"Электричество", FuelType.Electricity},
            {"Газ", FuelType.Gas},
            {"Авиационный керосин", FuelType.AviationKerosene},
            {"Авиационный бензин", FuelType.AviationGasoline},
        };

        /// <summary>
        /// Словарь типов топлива для каждого транспорта
        /// </summary>
        private static readonly Dictionary<TypeTransport, FuelType[]>
            _transportFuelTypes = new Dictionary<TypeTransport, FuelType[]>
        {
            {
                TypeTransport.Car,
                new FuelType[]
                {
                    FuelType.Petrol,
                    FuelType.Diesel,
                    FuelType.Electricity,
                    FuelType.Gas,
                }
            },
            {
                TypeTransport.HybridCar,
                new FuelType[]
                {
                    FuelType.Petrol,
                    FuelType.Diesel,
                    FuelType.Gas,
                }
            },
            {
                TypeTransport.Helicopter,
                new FuelType[]
                {
                    FuelType.AviationGasoline,
                    FuelType.AviationKerosene
                }
            },
        };

        /// <summary>
        /// Конструктор
        /// </summary>
        public DataForm()
        {
            InitializeComponent();
            FillComboBox(_typesTransports.Keys.ToArray(),
                _comboBoxTransportType);
            FillComboBoxFuel();
            _comboBoxTransportType.SelectedIndexChanged +=
                ComboBoxTransportFillComboBoxFuel;
        }

        /// <summary>
        /// Метод нажатия на кнопку "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAgreeClick(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            try
            {
                TypeTransport typeTransport =
                    _typesTransports[_comboBoxTransportType.Text];
                TransportBase transport = CreateTransport(typeTransport);

                if (transport != null)
                {
                    TransportAdded?.Invoke(this,
                        new TransportAddedEventArgs(transport));
                    _lastTransport = transport;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании транспорта: " +
                    $"{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Создает транспорт указанного типа
        /// </summary>
        /// <param name="typeTransport">Тип транспорта</param>
        /// <returns>Созданный транспорт</returns>
        /// <exception cref="ArgumentException"></exception>
        private TransportBase CreateTransport(TypeTransport typeTransport)
        {
            //TODO: {}
            switch (typeTransport)
            {
                case TypeTransport.Car:
                    return CreateCar();

                case TypeTransport.HybridCar:
                    return CreateHybridCar();

                case TypeTransport.Helicopter:
                    return CreateHelicopter();

                default:
                    throw new ArgumentException(
                        "Неизвестный тип транспорта");
            }
        }

        /// <summary>
        /// Создает автомобиль
        /// </summary>
        /// <returns>Объект автомобиль</returns>
        private Car CreateCar()
        {
            Motor motor = new Motor();
            motor.FuelType = (FuelType)_comboBoxFuel.SelectedValue;
            motor.Power = Convert.ToDouble(_textBoxPower.Text);
            double weight = Convert.ToDouble(_textBoxWeight.Text);

            return new Car()
            {
                Motor = motor,
                Weight = weight
            };
        }


        /// <summary>
        /// Создает гибридный автомобиль
        /// </summary>
        /// <returns>Объект гибридный автомобиль</returns>
        private HybridCar CreateHybridCar()
        {
            Motor motor = new Motor();
            motor.FuelType = (FuelType)_comboBoxFuel.SelectedValue;
            motor.Power = Convert.ToDouble(_textBoxPower.Text);

            Motor additionalMotor = new Motor();
            additionalMotor.FuelType = FuelType.Electricity;
            additionalMotor.Power =
                Convert.ToDouble(_textBoxHybridPower.Text);

            double weight = Convert.ToDouble(_textBoxWeight.Text);

            return new HybridCar()
            {
                Motor = motor,
                AdditionalMotor = additionalMotor,
                Weight = weight,
            };
        }

        /// <summary>
        /// Создает вертолет
        /// </summary>
        /// <returns>Объект вертолет</returns>
        private Helicopter CreateHelicopter()
        {
            Motor motor = new Motor();
            motor.FuelType = (FuelType)_comboBoxFuel.SelectedValue;
            motor.Power = Convert.ToDouble(_textBoxPower.Text);
            double weight = Convert.ToDouble(_textBoxWeight.Text);

            return new Helicopter()
            {
                Motor = motor,
                Weight = weight
            };
        }

        /// <summary>
        /// Проверяет правильность введеных данных
        /// </summary>
        /// <returns>True, если данные корректны, иначе False</returns>
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(_textBoxWeight.Text) ||
                string.IsNullOrWhiteSpace(_textBoxPower.Text))
            {
                MessageBox.Show("Заполните все обязательные поля.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (_groupBoxDataHybridCar.Visible &&
                string.IsNullOrWhiteSpace(_textBoxHybridPower.Text))
            {
                MessageBox.Show("Заполните мощность электрического " +
                    "двигателя.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            //TODO: duplication
            if (!double.TryParse(_textBoxWeight.Text, out double weight) ||
                weight <= 0)
            {
                MessageBox.Show("Введите корректную массу.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            //TODO: duplication
            if (!double.TryParse(_textBoxPower.Text, out double power)
                || power <= 0)
            {
                MessageBox.Show("Введите корректную мощность.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            //TODO: duplication
            if (_groupBoxDataHybridCar.Visible)
            {
                if (!double.TryParse(_textBoxHybridPower.Text,
                    out double powerHybrid)
                || powerHybrid <= 0)
                {
                    MessageBox.Show(
                        "Введите корректную мощность гибридной машины.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }


            return true;
        }

        /// <summary>
        /// Заполнение comboBox массивом данных
        /// </summary>
        /// <param name="dataSource">Массив данных</param>
        /// <param name="comboBox">ComboBox</param>
        private void FillComboBox<T>(T[] dataSource, ComboBox comboBox)
        {
            comboBox.DataSource = dataSource;
            comboBox.SelectedItem = dataSource.GetValue(0);
        }

        /// <summary>
        /// Добавление GroupBoxDataHybridCar на форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddGroupBoxDataHybridCar(object sender, EventArgs e)
        {
            TypeTransport typeTransport =
                _typesTransports[_comboBoxTransportType.Text];

            switch (typeTransport)
            {
                //TOOD: отступы
                case TypeTransport.Car:
                    {
                        _groupBoxDataHybridCar.Visible = false;
                        break;
                    }
                case TypeTransport.HybridCar:
                    {
                        _groupBoxDataHybridCar.Visible = true;
                        break;
                    }
                case TypeTransport.Helicopter:
                    {
                        _groupBoxDataHybridCar.Visible = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// Заполнение ComboBoxFuel массивом данных
        /// в соответствии с выбранным типом транспорта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxTransportFillComboBoxFuel(object sender,
            EventArgs e)
        {
            FillComboBoxFuel();
        }

        /// <summary>
        /// Заполнение ComboBoxFuel массивом данных
        /// в соответствии с выбранным типом транспорта
        /// </summary>
        private void FillComboBoxFuel()
        {
            TypeTransport typeTransport =
                _typesTransports[_comboBoxTransportType.Text];

            if (_transportFuelTypes.TryGetValue(typeTransport,
                out FuelType[] availableFuels))
            {
                var fuelDictionary = availableFuels.ToDictionary(
                    fuel => _typesFuel.First(x => x.Value == fuel).Key,
                    fuel => fuel);

                _comboBoxFuel.DataSource =
                    new BindingSource(fuelDictionary, null);
                _comboBoxFuel.DisplayMember = "Key";
                _comboBoxFuel.ValueMember = "Value";
            }
        }

        /// <summary>
        /// Метод нажатия на кнопку "Отмена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            if (_lastTransport != null)
            {
                TransportCancel?.Invoke(this,
                    new TransportAddedEventArgs(_lastTransport));
            }
        }

        /// <summary>
        /// Проверка, допустимы ли данные, вводимые в TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && textBox.Text.Contains(","))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '0' && textBox.Text == "0")
            {
                e.Handled = true;
            }
        }
#if DEBUG
        /// <summary>
        /// Заполнение случайными числами полей TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRandomClick(object sender, EventArgs e)
        {
            Random random = new Random();

            int weight = random.Next(1, 11);
            _textBoxWeight.Text = weight.ToString();

            _textBoxPower.Text = (weight * 100).ToString();

            if (_groupBoxDataHybridCar.Visible)
            {
                _textBoxHybridPower.Text = (weight * 50).ToString();
            }
        }
#endif
    }
}
