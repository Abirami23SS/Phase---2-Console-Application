using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RechargeApplication
{
    public class Operation
    {
        static List<UserRegistrationDetails> userList = new List<UserRegistrationDetails>();
        static List<PackDetails> packList = new List<PackDetails>();
        static List<RechargeHistoryDetails> rechargeList = new List<RechargeHistoryDetails>();
        static UserRegistrationDetails currentUser;

        public static void AddDefaultData()
        {
            UserRegistrationDetails user1 = new UserRegistrationDetails("John", 9746646466, "john@gmail.com", 500);
            userList.Add(user1);
            UserRegistrationDetails user2 = new UserRegistrationDetails("Merlin", 9782136543, "merlin@gmail.com", 150);
            userList.Add(user2);

            PackDetails pack1 = new PackDetails("RC150", "Pack1", 150, 28, 50);
            packList.Add(pack1);
            PackDetails pack2 = new PackDetails("RC300", "Pack2", 300, 56, 75);
            packList.Add(pack2);
            PackDetails pack3 = new PackDetails("RC500", "Pack3", 500, 28, 200);
            packList.Add(pack3);
            PackDetails pack4 = new PackDetails("RC1500", "Pack4", 1500, 365, 200);
            packList.Add(pack4);

            RechargeHistoryDetails history1 = new RechargeHistoryDetails(user1.UserID, pack1.PackID, new DateTime(2024,04,25), 150, new DateTime(2021, 12, 27), 50);
            rechargeList.Add(history1);
            RechargeHistoryDetails history2 = new RechargeHistoryDetails(user2.UserID, pack2.PackID, new DateTime(2022, 01, 01), 150, new DateTime(2022, 01, 28), 50);
            rechargeList.Add(history2);

            Console.WriteLine("Default User Details");
            foreach (UserRegistrationDetails user in userList)
            {
                Console.WriteLine($" {user.UserID,-10}  |  {user.UserName,-15}  |  {user.MobileNumber,-10}  |  {user.EmailID,-15}  |  {user.WalletBalance,-10}");
            }

            Console.WriteLine("Default Pack Details");
            foreach (PackDetails pack in packList)
            {
                Console.WriteLine($" {pack.PackID,-10}  |  {pack.PackName,-15}  |  {pack.Price,-10}  |  {pack.Validity,-10}  |  {pack.NumberOfChannels,-10}");
            }

            Console.WriteLine("Default History Details");
            foreach (RechargeHistoryDetails recharge in rechargeList)
            {
                Console.WriteLine($" {recharge.RechargeID}  |  {recharge.UserID}  |  {recharge.PackID}  |  {recharge.RechargeDate.ToString("yyyy/MM/dd")}  |  {recharge.RechargeAmount}  |  {recharge.ValidTill.ToString("yyyy/MM/dd")}  |  {recharge.NumberOfChannels}");
            }
        }
        public static void MainMenu()
        {
            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.User Registration  2.User Login  3.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            //Console.WriteLine("Registration selected");
                            Registartion();
                            break;
                        }
                    case 2:
                        {
                            //Console.WriteLine("Login selected");
                            Login();
                            break;
                        }

                    case 3:
                        {
                            //Console.WriteLine("Exit Selected");
                            Exit();
                            flag = false;
                            break;
                        }
                }
            } while (flag);
        }
        public static void Registartion()
        {
            Console.WriteLine("---User Details---");
            Console.Write("User Name : ");
            string userName = Console.ReadLine();
            Console.Write("Mobile Number : ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.Write("Email ID : ");
            string emailId = Console.ReadLine();
            Console.Write("Wallet Balance : ");
            int walletBalance = int.Parse(Console.ReadLine());

            UserRegistrationDetails user = new UserRegistrationDetails(userName, mobileNumber, emailId, walletBalance);
            userList.Add(user);
            Console.WriteLine("User Registered Successfully : " + user.UserID);
        }
        public static void Login()
        {
            //1.Ask for the “User ID” of the user. Check the “User ID” in the user list.
            Console.WriteLine("Enter User Id  : ");
            string userID = Console.ReadLine();
            bool flag = true;
            foreach (UserRegistrationDetails user in userList)
            {
                if (userID == user.UserID)
                {
                    Console.WriteLine("Logged in Successfully...!");
                    flag = false;
                    currentUser = user;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid User Id..");
            }
        }
        public static void SubMenu()
        {
            Console.WriteLine("Sub menu called");
            int choice;
            bool flag = true;
            do
            {
                // Current Pack
                // Pack Recharge
                // Wallet Recharge
                // View Pack Recharge History
                // Show Wallet balance
                // 	Exit

                Console.WriteLine("1.CurrentPack  2.Pack Recharge  3.Wallet Recharge  4.View Pack Recharge History  5.Show Wallet Balnce  6.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            CurrentPack();
                            break;
                        }
                    case 2:
                        {
                            PackRecharge();
                            break;
                        }
                    case 3:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 4:
                        {
                            ViewPackRechargeHistory();
                            break;
                        }
                    case 5:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 6:
                        {
                            //Console.WriteLine("Exit Selected");
                            flag = false;
                            break;
                        }
                }
            } while (flag);

        }
        public static void CurrentPack()
        {
            //1.Displays recent pack detail of current user (User ID, Pack ID, Recharge Amount, Valid Till, Number of channels)
            bool flag = true;
            foreach (RechargeHistoryDetails recharge in rechargeList)
            {
                if (DateTime.Today <= recharge.ValidTill)
                {
                    flag = false;
                    if (currentUser.UserID == recharge.UserID)
                    {
                        Console.WriteLine($"  {recharge.UserID}  |  {recharge.PackID}  |  {recharge.RechargeAmount}  |  {recharge.ValidTill.ToString("yyyy/MM/dd")}  |  {recharge.NumberOfChannels}");
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("Do Recharge...");
            }
        }
        public static void PackRecharge()
        {
            //1.	List the available pack details  
            Console.WriteLine("Available Pack Details..");
            foreach (PackDetails pack in packList)
            {
                Console.WriteLine($" {pack.PackID}  |  {pack.PackName}  |  {pack.Price}  |  {pack.Validity}  |  {pack.NumberOfChannels}");
            }
            //ask the user to choose a pack and recharge.
            Console.WriteLine("Enter a pack that you want ");
            string PackID = Console.ReadLine();
            bool flag = true;
            DateTime tempValid = DateTime.Now;
            foreach (PackDetails pack in packList)
            {
                flag = false;
                if (pack.PackID == PackID)
                {
                    if (pack.Price < currentUser.WalletBalance)
                    {
                        foreach (RechargeHistoryDetails recharge in rechargeList)
                        {
                            if (recharge.UserID == currentUser.UserID)
                            {
                                tempValid = recharge.ValidTill;
                            }
                        }
                        DateTime date = DateTime.Today;
                        DateTime valid = DateTime.Today;
                        //pack recharge over today ,recharge today
                        if (tempValid == DateTime.Today)
                        {
                            date = DateTime.Today.AddDays(1);
                            valid = date.AddDays(pack.Validity);
                            Console.WriteLine("done");
                        }
                        else if (tempValid > DateTime.Today)
                        {
                            date = tempValid.AddDays(1);
                            valid = date.AddDays(pack.Validity);
                        }
                        else if (tempValid < DateTime.Today)
                        {
                            date = DateTime.Today;
                            valid = date.AddDays(pack.Validity);
                        }
                        RechargeHistoryDetails recharge1 = new RechargeHistoryDetails(currentUser.UserID, PackID,date,pack.Price,valid,pack.NumberOfChannels);
                        rechargeList.Add(recharge1);
                        Console.WriteLine("Recharge successfully");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Balance.Please recharge your wallet...");
                        break;
                    }
                }

            }
            //3.If insufficient balance in wallet, ask them to recharge his wallet.
            if (flag)
            {
                Console.WriteLine("Invalid Pack from User..");
            }
        }
        public static void WalletRecharge()
        {
            //1.Ask for the amount to be recharged from the user and update the wallet balance.
            Console.WriteLine("Enetr the amount to be recharged : ");
            int rechargeAmt = int.Parse(Console.ReadLine());
            if (rechargeAmt > 0)
            {
                currentUser.WalletBalance = rechargeAmt + currentUser.WalletBalance;
                Console.WriteLine("Updated Wallet Balance : " + currentUser.WalletBalance);
            }
            else
            {
                Console.WriteLine("Invalid Recharge ID");
            }
        }
        public static void ViewPackRechargeHistory()
        {
            //List the history of recharge details of current user (UserID, PackID, Recharge Amount, Valid Till
            bool flag = true;
            foreach (RechargeHistoryDetails recharge in rechargeList)
            {
                if (recharge.UserID == currentUser.UserID)
                {
                    flag = false;
                    Console.WriteLine($"  {recharge.UserID}  |  {recharge.PackID}  |  {recharge.RechargeAmount}  |  {recharge.ValidTill.ToString("yyyy/MM/dd")} ");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Pack Recharge found");
            }

        }
        public static void ShowWalletBalance()
        {
            Console.WriteLine("Wallet Balance : " + currentUser.WalletBalance);
        }
        public static void Exit()
        {
            Console.WriteLine("Exit....!");
        }

    }
}






