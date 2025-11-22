using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyTires.Interfaces;

namespace HappyTires.Models

{
    public class Motorcycles : Ivehicles
    {
        public string TypeOfVechicle {get; set;}
        public string LicensePLate { get; set; }
        public string Make { get; set; }
        public string Brand { get; set; }
        public string Year { get; set; }
        
        public Motorcycles(string typeOfVechicle, string licensePLate, string make, string brand, string year)
        {
            TypeOfVechicle = typeOfVechicle;
            LicensePLate = licensePLate;
            Make = make;
            Brand = brand;
            Year = year;
        }
    }

}
