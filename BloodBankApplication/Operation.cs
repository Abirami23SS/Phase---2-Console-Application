using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankApplication
{
    public class Operation
    {
        public static CustomList<RegistrationDetails> userList = new CustomList<RegistrationDetails>();
        public static CustomList<DonationDetails> donationList = new CustomList<DonationDetails>();
        public static RegistrationDetails currentRegister;

        public static void AddDefaultData()
        {
            RegistrationDetails register1 = new RegistrationDetails("Ravichandran", 8484848, BloodGroup.O_Positive, 30, new DateTime(2022, 08, 25));
            userList.Add(register1);
            RegistrationDetails register2 = new RegistrationDetails("Baskaran", 4747447, BloodGroup.AB_Positive, 30, new DateTime(2022, 09, 30));
            userList.Add(register2);

            DonationDetails donation1 = new DonationDetails("UID1001", new DateTime(2022, 04, 10), 73, 120, 14, BloodGroup.O_Positive);
            donationList.Add(donation1);
            DonationDetails donation2 = new DonationDetails("UID1001", new DateTime(2022, 10, 10), 74, 120, 14, BloodGroup.O_Positive);
            donationList.Add(donation2);
            DonationDetails donation3 = new DonationDetails("UID1002", new DateTime(2022, 07, 11), 74, 120, 13.6, BloodGroup.AB_Positive);
            donationList.Add(donation3);

            foreach (RegistrationDetails register in userList)
            {
                Console.WriteLine($" {register.DonorID,-10}  |  {register.DonorName,-15}  |  {register.MobileNumber,-10}  |  {register.BloodType,-10}  |  {register.Age,-10}  |  {register.LastDonationDate.ToString("yyyy/MM/dd")}");
            }
            foreach (DonationDetails donation in donationList)
            {
                Console.WriteLine($" {donation.DonationID,-10}  |  {donation.DonarId,-10}  |  {donation.DonationDate.ToString("yyyy/MM/dd"),-10}  |  {donation.Weight,-10}  |  {donation.BloodPressure,-15}  |  {donation.HemoglobinCount,-10}  |  {donation.BloodGroup}");
            }
        }
        public static void MainMenu()
        {
            Console.WriteLine("Application For Blood Bank Management");
            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.User Registartion  2.User Login  3.Fetch DonorDetails 4.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            //Console.WriteLine("Registration selected");
                            UserRegistartion();
                            break;
                        }
                    case 2:
                        {
                            //Console.WriteLine("Login selected");
                            UserLogin();
                            break;
                        }

                    case 3:
                        {
                            FetchDonorDetails();
                            break;
                        }
                    case 4:
                        {
                            //Console.WriteLine("Exit Selected");
                            flag = false;
                            Exit();
                            break;
                        }

                }
            } while (flag);
        }
        public static void UserRegistartion()
        {
            Console.WriteLine("User Details...");
            Console.WriteLine("Donar Name : ");
            string donorName = Console.ReadLine();
            Console.WriteLine("Mobile Number : ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Blood Group : ");
            BloodGroup bloodType = Enum.Parse<BloodGroup>(Console.ReadLine(), true);
            Console.WriteLine("Enter Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter LastDonationDate :");
            DateTime lastDonationDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            RegistrationDetails register = new RegistrationDetails(donorName, mobileNumber, bloodType, age, lastDonationDate);
            userList.Add(register);
            Console.WriteLine("User Registered Successfully Donar Id : " + register.DonorID);
        }
        public static void UserLogin()
        {
            Console.WriteLine("Enter Donor Id  : ");
            string donorID = Console.ReadLine();
            bool flag = true;
            foreach (RegistrationDetails user in userList)
            {
                if (donorID == user.DonorID)
                {
                    Console.WriteLine("Logged in Successfully...!");
                    flag = false;
                    currentRegister = user;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Donar Id..");
            }
        }
        public static void FetchDonorDetails()
        {
            Console.WriteLine("Enter Blood group : ");
            BloodGroup BloodGroup = Enum.Parse<BloodGroup>(Console.ReadLine(), true);
            bool flag = true;
            foreach (RegistrationDetails register in userList)
            {
                if (BloodGroup == register.BloodType)
                {
                    flag = false;
                    Console.WriteLine($" {register.DonorName}  {register.MobileNumber} ");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Blood group not found..");
            }

        }
        public static void SubMenu()
        {
            //  i.	Donate Blood
            // ii.	Donation History
            // iii.	Next Eligible Date
            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.Donate Blood  2.Donation History  3.NextEligibleDate  4.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            DonateBlood();
                            break;
                        }
                    case 2:
                        {
                            DonationHistory();
                            break;
                        }
                    case 3:
                        {
                            NextEligibleDate();
                            break;
                        }
                    case 4:
                        {
                            flag = false;
                            Exit();
                            break;
                        }
                }
            } while (flag);
        }
        public static void DonateBlood()
        {
            //•	Get the weight, blood pressure, hemoglobin count from the user 
            Console.Write("Enter weight : ");
            int weight = int.Parse(Console.ReadLine());
            Console.Write("Enter Blood Pressure : ");
            int bp = int.Parse(Console.ReadLine());
            Console.Write("Enter Hemoglobin: ");
            double hb = double.Parse(Console.ReadLine());
            bool flag = true;
            //Weight is above 50, bp is below 130 hemoglobin count is above 13.
            if (weight > 50 && bp < 130 && hb > 13)
            {
                if (currentRegister.LastDonationDate.AddMonths(6) < DateTime.Today)
                {
                    DonationDetails donation1 = new DonationDetails(currentRegister.DonorID, DateTime.Today, weight, bp, hb, currentRegister.BloodType);
                    donationList.Add(donation1);
                    Console.WriteLine("Blood Donated Successfully: " + currentRegister.DonorID);
                    Console.WriteLine("Next Eligible Date of Donation: " + DateTime.Today.AddMonths(6).ToString("dd/MM/yyyy"));
                }
                else
                {
                    Console.WriteLine("You already Donated Next Eligible Date: " + currentRegister.LastDonationDate.AddMonths(6).ToString("dd/MM/yyyy"));
                }

            }
            if (flag)
            {
                Console.WriteLine("No donor id found");
            }
        }
        public static void DonationHistory()
        {
            bool flag = true;
            foreach (DonationDetails donation in donationList)
            {
                if (currentRegister.DonorID == donation.DonarId)
                {
                    Console.WriteLine($" {currentRegister.DonorID}   |  {currentRegister.DonorName}  |  {currentRegister.MobileNumber}  |  {currentRegister.Age}  |  {currentRegister.BloodType}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Donation");
            }
        }
        public static void NextEligibleDate()
        {
            //Show the next eligible date for the user (6 months from the date of last donation). 

            DateTime tempdate = DateTime.Today;

            foreach (DonationDetails donation in donationList)
            {
                if (currentRegister.DonorID == donation.DonarId)
                {
                    if (donation.DonationDate < tempdate)
                    {
                        tempdate = donation.DonationDate;
                    }
                }
            }
            //If the user donates 2 times, last donation must be user recently donated date.
            Console.WriteLine("Next Eligible date : " + tempdate.AddMonths(6).ToString("yyyy/MM/dd"));
        }

        public static void Exit()
        {
            Console.WriteLine("Exit...!");
        }

    }
}