using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// Класс отдает данные событию при фильтрации
    /// </summary>
    internal class TransportFilterEventArgs : EventArgs
    {
        /// <summary>
        /// Свойство для получения отфильтрованного списка
        /// </summary>
        public BindingList<TransportBase> FilteredTransportList { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="filterTransportList">Отфильтрованный список
        /// транспорта</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TransportFilterEventArgs(BindingList<TransportBase>
            filterTransportList)
        {
            if (filterTransportList == null)
            {
                throw new ArgumentNullException(
                    nameof(filterTransportList),
                    "Отфильтрованный список транспорта не может быть null");
            }
            FilteredTransportList = filterTransportList;
        }

    }
}
