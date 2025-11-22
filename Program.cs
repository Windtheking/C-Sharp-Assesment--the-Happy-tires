using HappyTires.Models;

namespace HappyTires
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Services.GeneralLevelServices generalLevelServices = new Services.GeneralLevelServices();
            generalLevelServices.fileClientDBExistance();
            generalLevelServices.fileInspectorDBExistance();
            Console.WriteLine("Welcome to the main menu of (change tittle card)");
            Console.WriteLine("Please input the information of the client of your choice");
            Console.WriteLine("Dont forget the information needed is: Name, Document ID, Phone Number, Email and Address");
            Console.WriteLine("Name plase: ");
            string? TheName = Console.ReadLine();
            Console.WriteLine("DocumentID plase: ");
            string? TheID = Console.ReadLine();
            Console.WriteLine("Phone Number plase: ");
            string? ThePhonenum = Console.ReadLine();
            Console.WriteLine("Email plase: ");
            string? TheEmail = Console.ReadLine();
            Console.WriteLine("Address plase: ");
            string? TheAdress = Console.ReadLine();
            Models.Client clientCrud = new Models.Client(TheName, TheID, ThePhonenum, TheEmail, TheAdress);
            System.Console.WriteLine("testeo de borrado, inserta tu CC");
            string id = Console.ReadLine();
            clientCrud.ClientDeletionFromDatabase(id);
            clientCrud.ClientInsertionToDatabase(clientCrud);
        }
    }
}