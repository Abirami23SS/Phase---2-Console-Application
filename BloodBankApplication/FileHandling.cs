using System;
using System.Collections.Generic;
using System.IO;

namespace BloodBankApplication
{
    public class FileHandling
    {
        //create
        public static void Create()
        {
            if (!Directory.Exists("BloodBankApplication"))
            {
                Console.WriteLine("Creating folder");
                Directory.CreateDirectory("BloodBankApplication");
            }
            if (!File.Exists("BloodBankApplication/RegistrationDetails.csv"))
            {
                Console.WriteLine("Creating file for user");
                File.Create("BloodBankApplication/RegistrationDetails.csv");
            }
            if (!File.Exists("BloodBankApplication/DonationDetails.csv"))
            {
                Console.WriteLine("Creating file for donation");
                File.Create("BloodBankApplication/DonationDetails.csv");
            }
        }
        //write to csv
        public static void WriteToCSV()
        {
            string [] user=new string[Operation.userList.Count];
            for(int i=0;i<Operation.userList.Count;i++)
            {
                user[i]=Operation.userList[i].DonorID+","+Operation.userList[i].DonorName+","+Operation.userList[i].MobileNumber+","+Operation.userList[i].BloodType+","+Operation.userList[i].Age+","+Operation.userList[i].LastDonationDate.ToString("dd/MM/yyyy");
            }
            File.WriteAllLines("BloodBankApplication/RegistrationDetails.csv",user);
            string [] donation=new string[Operation.donationList.Count];
            for(int i=0;i<Operation.donationList.Count;i++)
            {
                donation[i]=Operation.donationList[i].DonationID+","+Operation.donationList[i].DonarId+","+Operation.donationList[i].DonationDate.ToString("dd/MM/yyyy")+","+Operation.donationList[i].Weight+","+Operation.donationList[i].BloodPressure+","+Operation.donationList[i].HemoglobinCount+","+Operation.donationList[i].BloodGroup;
            }
            File.WriteAllLines("BloodBankApplication/DonationDetails.csv",donation);
        }

        //read to csv
        public static void ReadToCSV()
        {
            string[] user=File.ReadAllLines("BloodBankApplication/RegistrationDetails.csv");
            foreach(string users in user)
            {
                RegistrationDetails register = new RegistrationDetails(users);
                Operation.userList.Add(register);
            }
            string[] donation=File.ReadAllLines("BloodBankApplication/DonationDetails.csv");
            foreach(string donations in donation)
            {
                DonationDetails donation1=new DonationDetails(donations);
                Operation.donationList.Add(donation1);
            }
        }
    }
}