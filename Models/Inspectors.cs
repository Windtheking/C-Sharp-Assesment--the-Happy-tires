using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyTires.Interfaces;

namespace HappyTires.Models
{
    public class Inspectors : Iperson
    {
        public string Name { get; set; }
        public string DocumentID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TipeOfInspection { get; set;}

        public Inspectors(string name,string documentID,string phoneNumber,string email, string tipeOfInspection) 
        {
            Name = name;
            DocumentID = documentID;
            PhoneNumber = phoneNumber;
            Email = email;
            TipeOfInspection = tipeOfInspection;
        }
    }
}