using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using HappyTires.Interfaces;

namespace HappyTires.Models
{
    public class Client : Iperson
    {
        public string Name { get; set; }
        public string DocumentID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        private readonly HappyTiresDatabase happyTiresDatabase = new HappyTiresDatabase();
        
        
        //ConstructorBuilder to initialize the properties of the class
        public Client(string name, string documentID, string phoneNumber, string email, string address)
        {
            Name = name;
            DocumentID = documentID;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        public void ClientInsertionToDatabase(Client client)
        {
            // call the existing TXT-based insertion helper (method name matches file: InsertionToDatabse)
            happyTiresDatabase.InsertionToDatabse(client);
        }

        public void ClientDeletionFromDatabase(string DocumentID)
        {
            happyTiresDatabase.DeletionFromDatabase(DocumentID);
        }
    }
}