using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodealer.Classes
{
     public class AOToWorkers
    {
        public int id { get; set; }
        [DisplayName("Марка автомобиля")]
        public string carMark { get; set; }

        [DisplayName("Модель автомобиля")]
        public string carModel { get; set; }

        [DisplayName("Цвет автомобиля")]
        public string carColor { get; set; }

        [DisplayName("Дата выпуска")]
        public string carReleaseDate { get; set; }

        [DisplayName("Цена $")]
        public int carPrice { get; set; }

        [DisplayName("Имя клиента")]
        public string clientName { get; set; }

        [DisplayName("Фамилия клиента")]
        public string clientSurname { get; set; }

        [DisplayName("Отчество клиента")]
        public string clientMiddlename { get; set; }

        [DisplayName("Номер телефона клиента")]
        public string clientMobileNumber { get; set; }

        [DisplayName("Электронная почта клиента")]
        public string clientEmail { get; set; }

        [DisplayName("Отчество клиента")]
        public int worker_id { get; set; }

        [DisplayName("Имя сотрудника")]
        public string name { get; set; }

        [DisplayName("Фамилия сотрудника")]
        public string surname { get; set; }

        [DisplayName("Отчество сотрудника")]
        public string middlename { get; set; }

    }
}
