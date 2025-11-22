using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata;

namespace HappyTires.Models
{
    public class HappyTiresDatabase
    {
        /*
        * Methods for CRUD in database using TXT files for data persistence 
        * avoiding data loss or the need to re insert the data each time the
        * program is ran
        */
        public  void clientInsertionToDatabse(Client client)
        {
            //Used to track the txt file and append the text in a new line of the txt file
            File.AppendAllText("../HappyTires/Data/DatabaseClient.txt", Environment.NewLine + client.Name + "," + client.DocumentID + "," + client.PhoneNumber + "," + client.Email + "," + client.Address);
        }

        public  void clientDeletionFromDatabase(string DocumentID)
        {
            /*
            * Method used to filter all the information on the text file that is not 
            * the information you want to delete
            * then rewrite the whole document to eliminate the unwanted information
            */
            var AllData = File.ReadAllLines("../HappyTires/Data/DatabaseClient.txt");
            var FoundElement = AllData.Where(AllData => !AllData.Contains(DocumentID));
            File.WriteAllLines("../HappyTires/Data/DatabaseClient.txt", FoundElement);
        }

        public void ShowAllClientsFromDatabase(string Name)
        {
            /*
            * This method will search for all the posible matches with the filtering selected,
            * when used with only the Name parameter it will search for all the clients with that name, 
            * and must skip the document ID parameter, if it finds 
            */
            var AlltheData = File.ReadAllLines("../HappyTires/Data/DatabaseClient.txt");
            var i = 0;
            foreach (var line in AlltheData)
            {
                if (line.Contains(Name))
                {
                    if (line.Contains(Name) && Name != "")
                    {
                        Console.WriteLine($"{i} Client(s) found with the name: {Name} ");

                    }
                } i++;
            }
        }


        public void ShowOneClientsFromDatabase(string Name, string DocumentID)
        {
            /*
            * This method will search for all the posible matches with the filtering selected,
            * when used with only the Name parameter it will search for all the clients with that name, 
            * and must skip the document ID parameter, if it finds 
            */
            var AlltheData = File.ReadAllLines("../HappyTires/Data/DatabaseClient.txt");
            foreach (var line in AlltheData)
            {
                if (line.Contains(Name) || line.Contains(DocumentID))
                {
                    if (line.Contains(Name) && Name != "")
                    {
                        Console.WriteLine("Client found with the name: " + Name);
                        break;
                    }
                    else if (line.Contains(DocumentID) && DocumentID != "")
                    {
                        Console.WriteLine("Client found with the Document ID: " + DocumentID);
                    }
                }
            }
        }

        /*
        * Fragments the existing txt file data, assuming it is separated by commas which it is
        * and replaces the old element with the new element given as parameters
        */
        public void clientUpdateDatabase(string OldElement, string NewElement)
        {
            string filePath = "../HappyTires/Data/DatabaseClient.txt";

            var AllData = File.ReadAllLines(filePath);

            for (int i = 0; i < AllData.Length; i++)
            {
                if (AllData[i].Contains(OldElement))
                {
                    var parts = AllData[i].Split(',');

                    for (int j = 0; j < parts.Length; j++)
                    {
                        if (parts[j] == OldElement)
                        {
                            parts[j] = NewElement; 
                            break;
                        }
                    }

                    AllData[i] = string.Join(",", parts);
                    
                }
            }

            File.WriteAllLines(filePath, AllData);
        }

        /*
        * This fragment of code is actually self explanatory, this is the section for inspectors, no need to 
        * go over what does what when compared to the client section they are identical in functionality
        */
        public void inspectorInsertionToDatabse(Inspectors inspector)
        {
            File.AppendAllText("../HappyTires/Data/DatabaseInspectors.txt", Environment.NewLine + inspector.Name + "," + inspector.DocumentID + "," + inspector.PhoneNumber + "," + inspector.Email + "," + inspector.TipeOfInspection);
        }

        public void inspectorDeletionFromDatabase(string DocumentID)
        {
            string filePath = "../HappyTires/Data/DatabaseInspectors.txt";
            if (!File.Exists(filePath))
                return;

            var AllData = File.ReadAllLines(filePath);
            var FoundElement = AllData.Where(line => !line.Contains(DocumentID));
            File.WriteAllLines(filePath, FoundElement);
        }

        public void ShowAllInspectorsFromDatabase(string Name)
        {
            string filePath = "../HappyTires/Data/DatabaseInspectors.txt";
            if (!File.Exists(filePath))
                return;

            var AlltheData = File.ReadAllLines(filePath);
            var i = 0;
            foreach (var line in AlltheData)
            {
                if (line.Contains(Name))
                {
                    if (line.Contains(Name) && Name != "")
                    {
                        Console.WriteLine($"{i} Inspector(s) found with the name: {Name} ");
                    }
                }
                i++;
            }
        }

        public void ShowOneInspectorFromDatabase(string Name, string DocumentID)
        {
            string filePath = "../HappyTires/Data/DatabaseInspectors.txt";
            if (!File.Exists(filePath))
                return;

            var AlltheData = File.ReadAllLines(filePath);
            foreach (var line in AlltheData)
            {
                if (line.Contains(Name) || line.Contains(DocumentID))
                {
                    if (line.Contains(Name) && Name != "")
                    {
                        Console.WriteLine("Inspector found with the name: " + Name);
                        break;
                    }
                    else if (line.Contains(DocumentID) && DocumentID != "")
                    {
                        Console.WriteLine("Inspector found with the Document ID: " + DocumentID);
                    }
                }
            }
        }

        public void inspectorUpdateDatabase(string OldElement, string NewElement)
        {
            string filePath = "../HappyTires/Data/DatabaseInspectors.txt";

            if (!File.Exists(filePath))
                return;

            var AllData = File.ReadAllLines(filePath);

            for (int i = 0; i < AllData.Length; i++)
            {
                if (AllData[i].Contains(OldElement))
                {
                    var parts = AllData[i].Split(',');

                    for (int j = 0; j < parts.Length; j++)
                    {
                        if (parts[j] == OldElement)
                        {
                            parts[j] = NewElement; 
                            break;
                        }
                    }

                    AllData[i] = string.Join(",", parts);
                    
                }
            }

            File.WriteAllLines(filePath, AllData);
        }
    }
}