using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodealer.Classes
{
    public class ArchivedCars
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
    }
}
