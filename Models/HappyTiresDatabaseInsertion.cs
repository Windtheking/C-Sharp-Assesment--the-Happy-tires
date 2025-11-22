using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace HappyTires.Models
{
    public class HappyTiresDatabase
    {
        /*
        * Methods for CRUD in database using TXT files for data persistence 
        * avoiding data loss or the need to re insert the data each time the
        * program is ran
        */
        public virtual void InsertionToDatabse(Client client)
        {
            //Used to track the txt file and append the text in a new line of the txt file
            File.AppendAllText("../HappyTires/Data/DatabaseClient.txt", Environment.NewLine + client.Name + "," + client.DocumentID + "," + client.PhoneNumber + "," + client.Email + "," + client.Address);
        }

        public virtual void DeletionFromDatabase(string DocumentID)
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

        public virtual void UpdateDatabase()
        {
            
        }
    }
}