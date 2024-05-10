using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApplication
{
    public class Operation
    {
        static List<UserDetails> userList = new List<UserDetails>();
        static List<MedicalDetails> medicalList = new List<MedicalDetails>();
        static List<OrderDetails> orderList = new List<OrderDetails>();
        static UserDetails currentUser;

        public static void AddDefaultData()
        {
            UserDetails user1 = new UserDetails("Ravi", 33, "Theni", 987654876, 400);
            userList.Add(user1);
            UserDetails user2 = new UserDetails("Baskarn", 33, "Chennai", 23456745, 500);
            userList.Add(user2);

            MedicalDetails medical1 = new MedicalDetails("Paracitomal", 40, 5, new DateTime(2023, 12, 30));
            medicalList.Add(medical1);
            MedicalDetails medical2 = new MedicalDetails("Calpol", 10, 5, new DateTime(2023, 11, 30));
            medicalList.Add(medical2);
            MedicalDetails medical3 = new MedicalDetails("Gelucil", 3, 40, new DateTime(2024, 04, 30));
            medicalList.Add(medical3);
            MedicalDetails medical4 = new MedicalDetails("Metrogel", 5, 50, new DateTime(2025, 10, 30));
            medicalList.Add(medical4);
            MedicalDetails medical5 = new MedicalDetails("Povidin Iodin", 10, 50, new DateTime(2026, 10, 30));
            medicalList.Add(medical5);

            OrderDetails order1 = new OrderDetails("UID1001", "MD2001", 3, 15, new DateTime(2023, 11, 13), OrderStatus.Purchased);
            orderList.Add(order1);
            OrderDetails order2 = new OrderDetails("UID1001", "MD2002", 2, 10, new DateTime(2023, 11, 13), OrderStatus.Cancelled);
            orderList.Add(order2);
            OrderDetails order3 = new OrderDetails("UID1001", "MD2004", 2, 100, new DateTime(2023, 11, 13), OrderStatus.Purchased);
            orderList.Add(order3);
            OrderDetails order4 = new OrderDetails("UID1002", "MD2003", 3, 120, new DateTime(2024, 01, 15), OrderStatus.Cancelled);
            orderList.Add(order4);
            OrderDetails order5 = new OrderDetails("UID1002", "MD2005", 5, 250, new DateTime(2024, 01, 15), OrderStatus.Purchased);
            orderList.Add(order5);
            OrderDetails order6 = new OrderDetails("UID1002", "MD2002", 3, 15, new DateTime(2024, 01, 15), OrderStatus.Purchased);
            orderList.Add(order6);

            foreach (UserDetails user in userList)
            {
                Console.WriteLine($"  {user.UserID,-10}  |  {user.UserName,-15}  |  {user.Age,-10}  |  {user.City,-15}  |  {user.PhoneNumber,-10} |  {user.Balance,-10}");
            }
            foreach (MedicalDetails medical in medicalList)
            {
                Console.WriteLine($"  {medical.MedicineID,-10}  |  {medical.MedicineName,-15}  |  {medical.AvailableCount,-10}  |  {medical.Price,-10}  |  {medical.DateOfExpiry.ToString("yyy/MM/dd"),-10}");
            }
            foreach (OrderDetails order in orderList)
            {
                Console.WriteLine($"  {order.OrderID,-10}  |  {order.UserID,-10}  |  {order.MedicineID,-10}  |  {order.MedicineCount,-10}  |  {order.TotalPrice,-10}  |  {order.OrderDate.ToString("yyyy/MM/dd"),-10}  |  {order.OrderStatus,-15}");
            }
        }

        public static void MainMenu()
        {
            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.UserRegistration  2.UserLogin  3.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UserRegistration();
                        break;
                    case 2:
                        UserLogin();
                        break;
                    case 3:
                        Exit();
                        flag = false;
                        break;
                }
            } while (flag);
        }

        public static void UserRegistration()
        {
            Console.WriteLine("User Details ");
            Console.Write("Enter Username : ");
            string userName = Console.ReadLine();
            Console.Write("Enter age : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter city : ");
            string city = Console.ReadLine();
            Console.Write("Enter Phone Number : ");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter balance : ");
            double balance = double.Parse(Console.ReadLine());

            UserDetails newUser = new UserDetails(userName, age, city, phoneNumber, balance);
            userList.Add(newUser);
            Console.WriteLine("User registerd successfulle : " + newUser.UserID);
        }
        public static void UserLogin()
        {
            Console.WriteLine("Enter the UserID : ");
            string userID = Console.ReadLine().ToUpper();
            bool flag = true;

            foreach (UserDetails user in userList)
            {
                if (user.UserID == userID)
                {
                    Console.WriteLine("Logged in Successfully...");
                    flag = false;
                    currentUser = user;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid UserId");
            }
        }

        public static void SubMenu()
        {
            int choice;
            bool flag = true;
            do
            {
                // a.	Show medicine list.
                // b.	Purchase medicine
                // c.	Cancel purchase.
                // d.	Show purchase history.
                // e.	Recharge
                // f.	Show WalletBalance
                Console.WriteLine("1.Show Medicine List  2.Purchase Medicine  3.Cancel Purchase  4.Show purchase history  5.Recharge  6.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            ShowMedicineList();
                            break;
                        }
                    case 2:
                        {
                            PurchaseMedicine();
                            break;
                        }
                    case 3:
                        {
                            CancelPurchase();
                            break;
                        }
                    case 4:
                        {
                            ShowPurchaseHistory();
                            break;
                        }
                    case 5:
                        {
                            Recharge();
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

        public static void ShowMedicineList()
        {
            foreach (MedicalDetails medical in medicalList)
            {
                Console.WriteLine($"  {medical.MedicineID,-10}  |  {medical.MedicineName,-15}  |  {medical.AvailableCount,-10}  |  {medical.Price,-10}  |  {medical.DateOfExpiry.ToString("yyy/MM/dd"),-10}");
            }
        }

        public static void PurchaseMedicine()
        {
            //1.Show the List of medicine details by traversing the medicine details list.
            foreach (MedicalDetails medical in medicalList)
            {
                Console.WriteLine($"  {medical.MedicineID,-10}  |  {medical.MedicineName,-15}  |  {medical.AvailableCount,-10}  |  {medical.Price,-10}  |  {medical.DateOfExpiry.ToString("yyy/MM/dd"),-10}");
            }
            Console.WriteLine("Enter Medicine ID :");
            //2 Ask the user to select the medicine using MedicineID
            string medicineID = Console.ReadLine();
            //3.Ask the number of counts of that medicine he wants to buy
            bool flag = true;

            foreach (MedicalDetails medicine in medicalList)
            {
                if (medicineID == medicine.MedicineID)
                {
                    flag = false;
                    Console.WriteLine("Enter the count he want to buy ");
                    int count = int.Parse(Console.ReadLine());
                    if (count <= medicine.AvailableCount)
                    {
                        if (medicine.DateOfExpiry > DateTime.Now)
                        {
                            //c.If the medicine is not expired, then check User has enough balance to purchase that medicine. 
                            int total = count * medicine.Price;
                            Console.WriteLine(total);
                            if (total <= currentUser.Balance)
                            {
                                currentUser.Balance -= total;
                                //5.Reduce the number of AvailableCount of that medicine in MedicineDetails. 
                                medicine.AvailableCount = medicine.AvailableCount - count;
                                OrderDetails newOrder = new OrderDetails(currentUser.UserID, medicineID, count, total, DateTime.Now, OrderStatus.Purchased);
                                orderList.Add(newOrder);
                                Console.WriteLine("Medicine was purchased successfully " + medicine.AvailableCount);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Medicine expired");
                        }
                    }
                    else
                    {
                        Console.WriteLine("count not available");
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Medcinie ID...");
            }
        }
        public static void CancelPurchase()
        {
            //1.Show the order details of the currently logged in user whose order status is “Purchased”.
            bool flag = true;
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.UserID == order.UserID)
                {
                    flag = false;
                    Console.WriteLine($"  {order.OrderID,-10}  |  {order.UserID,-10}  |  {order.MedicineID,-10}  |  {order.MedicineCount,-10}  |  {order.TotalPrice,-10}  |  {order.OrderDate.ToString("yyyy/MM/dd"),-10}  |  {order.OrderStatus,-15}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Purchase Done");
            }
            if (!flag)
            {
                Console.WriteLine("Enter order id to cancel");
                string orderID = Console.ReadLine();
                bool IsFlag = true;
                foreach (OrderDetails order in orderList)
                {
                    if (orderID == order.OrderID)
                    {
                        IsFlag = false;
                        foreach (MedicalDetails medicine in medicalList)
                        {
                            //check its OrderStatus is Purchased
                            //3.If the OrderID matches increase the count of that Medicine in the medicine details.
                            medicine.AvailableCount += order.MedicineCount;
                            Console.WriteLine("Available Count : " + medicine.AvailableCount);
                            break;
                        }
                    }
                    //Return the amount to the user.
                    currentUser.Balance += order.TotalPrice;
                    Console.WriteLine("Updated Balance : " + currentUser.Balance);
                    //.Change the Status of the order to “Cancelled”.
                    order.OrderStatus = OrderStatus.Cancelled;
                    Console.WriteLine("Order ID: " + order.OrderID + " cancelled successfully");
                }
                if (IsFlag)
                {
                    Console.WriteLine("No order to cancel");
                }
            }
        }

        public static void ShowPurchaseHistory()
        {
            //Show the purchased history of the current logged in user by traversing the OrderDetails list. 
            bool flag = true;
            foreach (OrderDetails order in orderList)
            {
                flag = false;
                if (currentUser.UserID == order.UserID)
                {
                    Console.WriteLine($"  {order.OrderID,-10}  |  {order.UserID,-10}  |  {order.MedicineID,-10}  |  {order.MedicineCount,-10}  |  {order.TotalPrice,-10}  |  {order.OrderDate.ToString("yyyy/MM/dd"),-10}  |  {order.OrderStatus,-15}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Purchase Done");
            }
        }
        public static void Recharge()
        {
            //Get the amount to be recharged from the current logged in user and update the balance information on his property.
            Console.WriteLine("Enter the amount to be recharged");
            int amount = int.Parse(Console.ReadLine());
            if (amount > 0)
            {
                double rechargeAmount = amount + currentUser.Balance;
                Console.WriteLine("Updated Balance : " + rechargeAmount);
            }
            else{
                Console.WriteLine("Invalid Recharge amount");
            }

        }
        public static void Exit()
        {
            Console.WriteLine("Exit....!");
        }
    }

}


