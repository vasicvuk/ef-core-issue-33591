using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreIssue33591.Entities
{
    public class Car : TransportBase
    {
        public string Model { get; set; }
        public Motor Motor { get; set; }
    }

    public class Motor
    {
        public int Ccm { get; set; }
        public int Power { get; set; }
        public string FuelType { get; set; }
    }
}
