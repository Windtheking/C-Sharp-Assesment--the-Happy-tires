using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTires.Interfaces
{
    public interface Ivehicles
    {
        public string LicensePLate { get; set; }
        public string Make { get; set; }
        public string Brand { get; set; }
        public string Year { get; set; }
        public string AssignedClientName { get; set; }
    }
}