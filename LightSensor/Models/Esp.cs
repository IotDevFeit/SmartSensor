using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSensor.Models
{
    public class Esp
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SSID { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public string IsActive { get; set; }
        public string HasLight { get; set; }
        public string IsEmptyRoom { get; set; }
        public string Manual { get; set; }
    }
}
