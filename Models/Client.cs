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

        //methods brought from HappyTiresDatabase class to be used in Client class
        public void ClientInsertionToDatabase(Client client)
        {
            
            happyTiresDatabase.clientInsertionToDatabse(client);
        }

        public void ClientDeletionFromDatabase(string DocumentID)
        {
            happyTiresDatabase.clientDeletionFromDatabase(DocumentID);
        }

        public void ShowOneClientsFromDatabase(string Name, string DocumentID = "")
        {
            happyTiresDatabase.ShowOneClientsFromDatabase(Name, DocumentID);
        }

        public void ShowAllClientsFromDatabase(string Name, string DocumentID = "")
        {
            happyTiresDatabase.ShowAllClientsFromDatabase(Name);
        }

        public void clientUpdateDatabase(string newElement , string oldElement="")
        {
            happyTiresDatabase.clientUpdateDatabase(oldElement, newElement);
        }
    }
}