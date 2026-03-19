using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс FilterForm
    /// </summary>
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Исходынй список транспорта
        /// </summary>
        private BindingList<TransportBase> _transportList;

        /// <summary>
        /// Отфильтрованный список странспорта
        /// </summary>
        private BindingList<TransportBase> _filteredTransportList;

        /// <summary>
        /// Поле для обработки события фильтрации транспорта
        /// </summary>
        public EventHandler TransportFiltered;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="transportList">Список транспорта</param>
        public FilterForm(BindingList<TransportBase> transportList)
        {
            InitializeComponent();
            _transportList = transportList;
        }

        /// <summary>
        /// Метод нажатия на кнопку "ОК"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAgreeClick(object sender, EventArgs e)
        {
            bool checkClick = _checkBoxFindCar.Checked
                || _checkBoxFindHybridCar.Checked
                || _checkBoxFindHelicopter.Checked
                || _checkBoxWeight.Checked
                || _checkBoxPower.Checked;

            if (!checkClick)
            {
                MessageBox.Show("Заполните критерии поиска.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var filteredList = new List<TransportBase>(_transportList);

                if (_checkBoxFindCar.Checked
                    || _checkBoxFindHybridCar.Checked
                    || _checkBoxFindHelicopter.Checked)
                {
                    filteredList = FilterByType(filteredList);
                }

                if (_checkBoxWeight.Checked &&
                    !string.IsNullOrEmpty(_textBoxMinWeight.Text) &&
                    !string.IsNullOrEmpty(_textBoxMaxWeight.Text))
                {
                    filteredList = FilterByWeight
                        (filteredList,
                        Convert.ToDouble(_textBoxMinWeight.Text),
                        Convert.ToDouble(_textBoxMaxWeight.Text));
                }

                if (_checkBoxPower.Checked &&
                    !string.IsNullOrEmpty(_textBoxMinPower.Text) &&
                    !string.IsNullOrEmpty(_textBoxMaxPower.Text))
                {
                    filteredList = FilterByPower
                        (filteredList,
                        Convert.ToDouble(_textBoxMinPower.Text),
                        Convert.ToDouble(_textBoxMaxPower.Text));
                }

                _filteredTransportList =
                    new BindingList<TransportBase>(filteredList);

                if (_filteredTransportList.Count == 0)
                {
                    MessageBox.Show("Совпадений не найдено.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                TransportFiltered?.Invoke(this,
                    new TransportFilterEventArgs(_filteredTransportList));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при фильтрации: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Фильтрация списка по типу транспорта
        /// </summary>
        /// <param name="transportList">Список для фильтрации</param>
        /// <returns>Отфильтрованный список</returns>
        private List<TransportBase> FilterByType(
            List<TransportBase> transportList)
        {
            var filtered = new List<TransportBase>();

            if (_checkBoxFindCar.Checked)
            {
                filtered.AddRange(transportList.OfType<Car>()
                    .Where(c => !(c is HybridCar)));
            }

            if (_checkBoxFindHybridCar.Checked)
            {
                filtered.AddRange(transportList.OfType<HybridCar>());
            }

            if (_checkBoxFindHelicopter.Checked)
            {
                filtered.AddRange(transportList.OfType<Helicopter>());
            }

            return filtered;
        }

        /// <summary>
        /// Фильрация списка по массе
        /// </summary>
        /// <param name="transportList">Отфильтрованный по типу список
        /// </param>
        /// <param name="minWeight">Минимальная масса</param>
        /// <param name="maxWeight">Максимальная масса</param>
        /// <returns>Отфильтрованный по массе список</returns>
        private List<TransportBase> FilterByWeight(
            List<TransportBase> transportList,
            double minWeight, double maxWeight)
        {
            return transportList
                .Where(t => t.Weight >= minWeight &&
                t.Weight <= maxWeight)
                .ToList();
        }

        /// <summary>
        /// Фильтрация списка по массе
        /// </summary>
        /// <param name="transportList">Отфильтрованный по типу список
        /// </param>
        /// <param name="minPower">Минимальная мощность</param>
        /// <param name="maxPower">Максимальная мощность</param>
        /// <returns>Отфильтрованный по массе список</returns>
        private List<TransportBase> FilterByPower(
            List<TransportBase> transportList,
            double minPower, double maxPower)
        {
            return transportList.Where(t =>
            {
                if (t is Car)
                {
                    var car = t as Car;
                    return car.Motor.Power >= minPower &&
                    car.Motor.Power <= maxPower;
                }
                else if (t is Helicopter)
                {
                    var helicopter = t as Helicopter;
                    return helicopter.Motor.Power >= minPower &&
                    helicopter.Motor.Power <= maxPower;
                }
                return false;
            }).ToList();
        }
    }
}