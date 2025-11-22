using System;
using System.Linq;
using HappyTires.Models;

namespace HappyTires
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generalLevelServices = new Services.GeneralLevelServices();
            generalLevelServices.fileClientDBExistance();
            generalLevelServices.fileInspectorDBExistance();
            generalLevelServices.fileVehicleDBExistance();

            var db = new HappyTiresDatabase();

            Console.WriteLine("Welcome to the main menu of Happy Tires app");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main menu: select an option");
                Console.WriteLine("1) Client management");
                Console.WriteLine("2) Vehicle management");
                Console.WriteLine("3) Inspector management");
                Console.WriteLine("4) Inspection management");
                Console.WriteLine("0) Exit");
                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int mainSelection))
                {
                    Console.WriteLine("Invalid input. Enter a number.");
                    continue;
                }

                if (mainSelection == 0)
                    break;

                switch (mainSelection)
                {
                    case 1:
                        ClientMenu(db);
                        break;
                    case 2:
                        VehicleMenu(db);
                        break;
                    case 3:
                        InspectorMenu(db);
                        break;
                    case 4:
                        Console.WriteLine("Inspection management is not implemented yet.");
                        break;
                    default:
                        Console.WriteLine("Unknown option.");
                        break;
                }
            }
        }

        // Helper to read a non-empty line (returns trimmed string)
        private static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                    return line.Trim();
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }

        private static void ClientMenu(HappyTiresDatabase db)
        {
            var gls = new Services.GeneralLevelServices();
            Console.WriteLine("Client management - select action:");
            Console.WriteLine("1) Insert new client");
            Console.WriteLine("2) Delete client");
            Console.WriteLine("3) Update client information");
            Console.WriteLine("4) Show one client");
            Console.WriteLine("5) Show all clients (by name)");
            Console.Write("Choice: ");

            if (!int.TryParse(Console.ReadLine(), out int sel))
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            switch (sel)
            {
                case 1:
                    Console.WriteLine("Insert new client (required: Name, DocumentID)");
                    var name = ReadNonEmpty("Name: ").ToLower();
                    var id = ReadNonEmpty("DocumentID: ").ToLower();
                    // prevent duplicate document IDs
                    if (gls.IsDuplicateDocumentId(id))
                    {
                        Console.WriteLine("A client with that DocumentID already exists. Aborting insertion.");
                        return;
                    }
                    var phone = ReadNonEmpty("Phone number: ").ToLower();
                    var email = ReadNonEmpty("Email: ").ToLower();
                    if (!gls.IsValidEmail(email))
                    {
                        Console.WriteLine("Invalid email format. Aborting insertion.");
                        return;
                    }
                    var address = ReadNonEmpty("Address: ").ToLower();

                    var newClient = new Client(name, id, phone, email, address);
                    newClient.ClientInsertionToDatabase(newClient);
                    Console.WriteLine("Client inserted.");
                    break;
                case 2:
                    var delId = ReadNonEmpty("DocumentID to delete: ").ToLower();
                    var delClient = new Client("", "", "", "", "");
                    delClient.ClientDeletionFromDatabase(delId);
                    Console.WriteLine("Delete request processed.");
                    break;
                case 3:
                    var oldElement = ReadNonEmpty("Old element to replace: ").ToLower();
                    var newElement = ReadNonEmpty("New element: ").ToLower();
                    var updClient = new Client("", "", "", "", "");
                    // Client.clientUpdateDatabase expects (newElement, oldElement)
                    updClient.clientUpdateDatabase(newElement, oldElement);
                    Console.WriteLine("Update request processed.");
                    break;
                case 4:
                    var searchName = ReadNonEmpty("Name to search: ").ToLower();
                    Console.Write("DocumentID (optional - press enter to skip): ");
                    var docId = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
                    var showOne = new Client("", "", "", "", "");
                    showOne.ShowOneClientsFromDatabase(searchName, docId);
                    break;
                case 5:
                    var searchAll = ReadNonEmpty("Name to search for (show all): ").ToLower();
                    var showAll = new Client("", "", "", "", "");
                    showAll.ShowAllClientsFromDatabase(searchAll);
                    break;
                default:
                    Console.WriteLine("Unknown client action.");
                    break;
            }
        }

        private static void VehicleMenu(HappyTiresDatabase db)
        {
            var gls = new Services.GeneralLevelServices();
            Console.WriteLine("Vehicle management - select action:");
            Console.WriteLine("1) Insert new vehicle");
            Console.WriteLine("2) Delete vehicle (by license plate)");
            Console.WriteLine("3) Update vehicle field");
            Console.WriteLine("4) Show one vehicle");
            Console.WriteLine("5) Show all vehicles for a client");
            Console.Write("Choice: ");

            if (!int.TryParse(Console.ReadLine(), out int sel))
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            switch (sel)
            {
                case 1:
                    Console.WriteLine("Insert new vehicle");
                    Console.Write("Type (car/motorcycle): ");
                    var type = Console.ReadLine()?.Trim().ToLower();
                    var license = ReadNonEmpty("License plate: ").ToLower();
                    // prevent duplicate license plates
                    if (gls.IsDuplicateLicensePlate(license))
                    {
                        Console.WriteLine("A vehicle with that license plate already exists. Aborting insertion.");
                        return;
                    }
                    var make = ReadNonEmpty("Make: ").ToLower();
                    var brand = ReadNonEmpty("Brand: ").ToLower();
                    var year = ReadNonEmpty("Year: ").ToLower();
                    var assigned = ReadNonEmpty("Assigned client name (or 'none'): ").ToLower();

                    if (!gls.IsValidYear(year, out int parsedYear))
                    {
                        Console.WriteLine($"Year '{year}' is not valid. Aborting insertion.");
                        return;
                    }

                    if (type == "car")
                    {
                        var car = new Models.Car("car", license, make, brand, year, assigned);
                        db.vehicleInsertionToDatabse(car);
                    }
                    else
                    {
                        var moto = new Models.Motorcycles("motorcycle", license, make, brand, year, assigned);
                        db.vehicleInsertionToDatabse(moto);
                    }
                    Console.WriteLine("Vehicle inserted.");
                    break;
                case 2:
                    var plateToDelete = ReadNonEmpty("License plate to delete: ").ToLower();
                    db.vehicleDeletionFromDatabase(plateToDelete);
                    Console.WriteLine("Delete request processed.");
                    break;
                case 3:
                    var oldV = ReadNonEmpty("Old value to replace: ").ToLower();
                    var newV = ReadNonEmpty("New value: ").ToLower();
                    db.vehicleUpdateDatabase(oldV, newV);
                    Console.WriteLine("Update request processed.");
                    break;
                case 4:
                    var plate = ReadNonEmpty("License plate to search: ").ToLower();
                    db.ShowOneVehicleFromDatabase(plate, string.Empty);
                    break;
                case 5:
                    var clientName = ReadNonEmpty("Assigned client name to search: ").ToLower();
                    db.ShowAllVehiclesFromDatabase(clientName);
                    break;
                default:
                    Console.WriteLine("Unknown vehicle action.");
                    break;
            }
        }

        private static void InspectorMenu(HappyTiresDatabase db)
        {
            var gls = new Services.GeneralLevelServices();
            Console.WriteLine("Inspector management - select action:");
            Console.WriteLine("1) Insert new inspector");
            Console.WriteLine("2) Delete inspector");
            Console.WriteLine("3) Update inspector field");
            Console.WriteLine("4) Show one inspector");
            Console.WriteLine("5) Show all inspectors (by name)");
            Console.Write("Choice: ");

            if (!int.TryParse(Console.ReadLine(), out int sel))
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            switch (sel)
            {
                case 1:
                    var name = ReadNonEmpty("Name: ").ToLower();
                    var id = ReadNonEmpty("DocumentID: ").ToLower();
                    // prevent duplicate inspector document IDs
                    if (gls.ExistsInFileField("../HappyTires/Data/DatabaseInspectors.txt", 1, id))
                    {
                        Console.WriteLine("An inspector with that DocumentID already exists. Aborting insertion.");
                        return;
                    }
                    var phone = ReadNonEmpty("Phone number: ").ToLower();
                    var email = ReadNonEmpty("Email: ").ToLower();
                    if (!gls.IsValidEmail(email))
                    {
                        Console.WriteLine("Invalid email format. Aborting insertion.");
                        return;
                    }
                    var tipe = ReadNonEmpty("Type of inspection: ").ToLower();
                    var inspector = new Models.Inspectors(name, id, phone, email, tipe);
                    db.inspectorInsertionToDatabse(inspector);
                    Console.WriteLine("Inspector inserted.");
                    break;
                case 2:
                    var delId = ReadNonEmpty("DocumentID to delete: ").ToLower();
                    db.inspectorDeletionFromDatabase(delId);
                    Console.WriteLine("Delete request processed.");
                    break;
                case 3:
                    var oldE = ReadNonEmpty("Old value to replace: ").ToLower();
                    var newE = ReadNonEmpty("New value: ").ToLower();
                    db.inspectorUpdateDatabase(oldE, newE);
                    Console.WriteLine("Update request processed.");
                    break;
                case 4:
                    var searchName = ReadNonEmpty("Name to search: ").ToLower();
                    Console.Write("DocumentID (optional - press enter to skip): ");
                    var docId = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
                    db.ShowOneInspectorFromDatabase(searchName, docId);
                    break;
                case 5:
                    var searchAll = ReadNonEmpty("Name to search for (show all): ").ToLower();
                    db.ShowAllInspectorsFromDatabase(searchAll);
                    break;
                default:
                    Console.WriteLine("Unknown inspector action.");
                    break;
            }
        }
    }
}