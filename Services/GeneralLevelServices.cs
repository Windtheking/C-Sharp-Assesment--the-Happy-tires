using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTires.Services
{
    public class GeneralLevelServices
    {
        public void fileClientDBExistance()
        {
            string path = "../HappyTires/Data/DatabaseClient.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Database error while trying to run the app, please check the Data folder for DatabaseClient.txt file");
                Console.WriteLine("please create or pleace the file on the correct folder and then reinitilize the app, the app will close in 7 seconds");
                Thread.Sleep(7000);
                Environment.Exit(0);
            }
        }

        public void fileInspectorDBExistance()
        {

            string path = "../HappyTires/Data/DatabaseInspectors.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Database error while trying to run the app, please check the Data folder for DatabaseInspectors.txt file");
                Console.WriteLine("please create or pleace the file on the correct folder and then reinitilize the app, the app will close in 7 seconds");
                Thread.Sleep(7000);
                Environment.Exit(0);
            }
        }
    }
}