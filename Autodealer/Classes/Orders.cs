using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodealer.Classes
{
    public class Orders
    {
        public int id { get; set; }
        public int car_id { get; set; }
        public int worker_id { get; set; }
        public int client_id { get; set; }
    }
}
