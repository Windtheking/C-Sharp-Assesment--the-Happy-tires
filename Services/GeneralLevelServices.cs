using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

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

        public void fileVehicleDBExistance()
        {

            string path = "../HappyTires/Data/DatabaseVehicles.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Database error while trying to run the app, please check the Data folder for DatabaseVehicles.txt file");
                Console.WriteLine("please create or pleace the file on the correct folder and then reinitilize the app, the app will close in 7 seconds");
                Thread.Sleep(7000);
                Environment.Exit(0);
            }
        }

        public void OnlyAvalibleOtions(int option)
        {
           if (option < 1)
            {
                Console.WriteLine("You have selected an invalid option, the app will close in 7 seconds");
                Thread.Sleep(7000);
                Environment.Exit(0);
            }

        }

        // ---------------------- Validation helpers ----------------------
        // Return true if string is not null/empty/whitespace
        public bool IsNonEmpty(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        // Try parse a positive integer
        public bool TryParsePositiveInt(string input, out int result)
        {
            result = 0;
            if (int.TryParse(input, out int v) && v > 0)
            {
                result = v;
                return true;
            }
            return false;
        }

        // Basic email validation
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            var pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        // Generic: check if value exists in specific CSV field (0-based index)
        public bool ExistsInFileField(string filePath, int fieldIndex, string value)
        {
            if (!File.Exists(filePath))
                return false;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length > fieldIndex)
                {
                    if (parts[fieldIndex].Equals(value, StringComparison.InvariantCultureIgnoreCase))
                        return true;
                }
            }
            return false;
        }

        // Specific convenience checks used across the app
        public bool IsDuplicateDocumentId(string documentId)
        {
            var path = "../HappyTires/Data/DatabaseClient.txt";
            // DocumentID is stored at index 1 in client CSV
            return ExistsInFileField(path, 1, documentId);
        }

        public bool IsClientNameExists(string name)
        {
            var path = "../HappyTires/Data/DatabaseClient.txt";
            // Name is stored at index 0 in client CSV
            return ExistsInFileField(path, 0, name);
        }

        public bool IsDuplicateLicensePlate(string licensePlate)
        {
            var path = "../HappyTires/Data/DatabaseVehicles.txt";
            // License plate stored at index 1 in vehicles CSV (Type,License,...)
            return ExistsInFileField(path, 1, licensePlate);
        }

        // Validate year-like fields (returns parsed year via out)
        public bool IsValidYear(string yearStr, out int year)
        {
            year = 0;
            if (!int.TryParse(yearStr, out int y))
                return false;
            var min = 1886; // first gasoline car
            var max = DateTime.Now.Year + 1;
            if (y < min || y > max)
                return false;
            year = y;
            return true;
        }
    }
}