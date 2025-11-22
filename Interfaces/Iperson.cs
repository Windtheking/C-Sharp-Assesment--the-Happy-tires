using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace HappyTires.Interfaces
{
    public interface Iperson
    {
        public string Name {get; set;}
        public string DocumentID {get; set;}
        public string PhoneNumber {get; set;}
        public string Email {get; set;}
    }
}