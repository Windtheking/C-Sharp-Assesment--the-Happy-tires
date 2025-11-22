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
            Console.WriteLine("Welcome to the main menu of Happy tires app");
            Console.WriteLine("Please input the information of the client of your choice");
            Console.WriteLine("Dont forget the information needed is: Name, Document ID, Phone Number, Email and Address");
            Console.WriteLine("Name plase: ");
            string? TheName = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("DocumentID plase: ");
            string? TheID = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("Phone Number plase: ");
            string? ThePhonenum = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("Email plase: ");
            string? TheEmail = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("Address plase: ");
            string? TheAdress = Console.ReadLine().Trim().ToLower();
            Models.Client clientCrud = new Models.Client(TheName, TheID, ThePhonenum, TheEmail, TheAdress);
            //clientCrud.ClientInsertionToDatabase(clientCrud);
            //System.Console.WriteLine("testeo de borrado, inserta tu CC");
            //string id = Console.ReadLine();
            //clientCrud.ClientDeletionFromDatabase(id);
            //================================
            //string posiblename = Console.ReadLine().Trim().ToLower();
            //string posibledocid = Console.ReadLine().Trim().ToLower();
            //clientCrud.ShowOneClientsFromDatabase(posiblename, posibledocid);
            //clientCrud.ShowAllClientsFromDatabase(posiblename);
            //================================
            string OldElement = Console.ReadLine().Trim().ToLower();
            string NewElement = Console.ReadLine().Trim().ToLower();
            clientCrud.clientUpdateDatabase(NewElement, OldElement);

        }
    }
}