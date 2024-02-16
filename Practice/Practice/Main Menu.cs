using System;
using System.Collections.Generic;
using System.IO;

namespace Practice
{
    internal class Main_Menu
    {
        static List<Patient> patients = new List<Patient>();
        private static string filepath = "Data Information.csv";
        public static void writemenu()
        {
            while (true)
            {
                // Load existing data from CSV file
                List<string> existingData = LoadData();

                // Display the current patient data table before adding a new patient
                DisplayPatientTable(existingData);

                // Collect patient information from user input
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("======================================");
                Logo.readlogo();
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("======================================");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter patient ID: ");
                string patientID = Console.ReadLine();

                Console.Write("Enter patient name: ");
                string patientName = Console.ReadLine();

                Console.Write("Enter patient age: ");
                string patientAge = Console.ReadLine();

                Console.Write("Enter patient gender: ");
                string patientGender = Console.ReadLine();

                Console.Write("Enter patient address: ");
                string patientAddress = Console.ReadLine();

                Console.Write("Enter Date/Time:  ");
                string dateTime = Console.ReadLine();
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("======================================");

                //save the input to CSV file
                SaveData($"|{patientID}\t |{patientName}\t|{patientAge}\t |{patientGender}\t |{patientAddress}\t|{dateTime}");


                // Display the updated table with the newly added patient
                DisplayPatientTable(LoadData());

                // Prompt the user to decide whether to add more patients
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Do you want to add another patient? yes/no): ");
                string answer = Console.ReadLine();
                
                // Check if the user wants to continue adding patients
                if (answer != "yes")
                {
                    break;
                }

            }
            

            // Display a message indicating the completion of patient data entry
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Patient data entry complete.");
        }

        
        static void DisplayPatientTable(List<string> data)
        {
            Console.Clear();
            // Display a header for the patient information table;
            
           

            //Display Existing Data 
            foreach (string line in data)
                {
                    Console.WriteLine(line);
                }
       
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("============================================================================================");
        }

        static List<string> LoadData()
        {
            List<string> data = new List<string>();

            try
            {
                if (File.Exists(filepath))
                {
                    using (StreamReader reader = new StreamReader(filepath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            data.Add(line);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("CSV file not found. Creating a new one.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }

            return data;
        }

        static void SaveData(string userInput)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine(userInput);
                }

                Console.WriteLine("Data saved to CSV file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        class Patient
        {
            public string patientID;
            public string patientName;
            public string patientAge;
            public string patientGender;
            public string patientAddress;
            public string dateTime;
            public Patient(string patientID, string patientName, string patientAge, string patientGender, string patientAddress, string dateTime)
            {
                this.patientID = patientID;
                this.patientName = patientName;
                this.patientAge = patientAge;
                this.patientGender = patientGender;
                this.patientAddress = patientAddress;
                this.dateTime = dateTime;
            }
        }
    }
}
