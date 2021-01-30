using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodealer
{
    public class Staff
    {
        public int id { get; set; }
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
        public int Archived { get; set; }

    }
}
