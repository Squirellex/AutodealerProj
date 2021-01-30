using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodealer.Classes
{
    public class AOD
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
        public int carArchieved { get; set; }
        [DisplayName("Имя сотрудника")]
        public string name { get; set; }
        [DisplayName("Фамилия сотрудника")]
        public string surname { get; set; }
        [DisplayName("Отчество сотрудника")]
        public string middlename { get; set; }
        [DisplayName("Номер телефона")]
        public string mobileNumber { get; set; }
        [DisplayName("Электронная почта")]
        public string email { get; set; }
        [DisplayName("Логин")]
        public string login { get; set; }
        [DisplayName("Пароль")]
        public string password { get; set; }
        [DisplayName("Должность")]
        public string role { get; set; }
        public string clientName { get; set; }
        [DisplayName("Фамилия клиента")]
        public string clientSurname { get; set; }
        [DisplayName("Отчество клиента")]
        public string clientMiddlename { get; set; }
        [DisplayName("Номер телефона")]
        public string clientMobileNumber { get; set; }
        [DisplayName("Электронная почта")]
        public string clientEmail { get; set; }
        [DisplayName("Логин")]
        public string clientLogin { get; set; }
    }
}
