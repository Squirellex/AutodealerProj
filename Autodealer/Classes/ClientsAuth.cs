using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodealer
{
    public class ClientsAuth
    {
        public int id { get; set; }
        [DisplayName("Имя клиента")]
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
        [DisplayName("Пароль")]
        public string clientPassword { get; set; }
        public int clientArchived{ get; set; }
    }
}
