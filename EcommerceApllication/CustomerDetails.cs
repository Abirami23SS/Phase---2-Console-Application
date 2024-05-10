using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApllication
{
    public class CustomerDetails
    {
        //CustomerID (Auto Increment -CID3001)
        // CustomerName
        // City
        // MobileNumber
        // WalletBalance
        // EmailID
        private static int s_customerID = 3000;
        public string CustomerID { get; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public long MobileNumber { get; set; }
        public double WalletBalance { get; set; }
        public string EmailId { get; set; }

        public CustomerDetails(string customerName, string city, long mobileNumber, double walletBalance, string emailID)
        {
            s_customerID++;
            CustomerID = "CID" + s_customerID;
            CustomerName = customerName;
            City = city;
            MobileNumber = mobileNumber;
            WalletBalance = walletBalance;
            EmailId = emailID;
        }

          public CustomerDetails(string customers)
        {
            string[] values=customers.Split(",");
            s_customerID=int.Parse(values[0].Remove(0, 3));
             CustomerID = values[0];
            CustomerName = values[1];
            City = values[2];
            MobileNumber = long.Parse(values[3]);
            WalletBalance = double.Parse(values[4]);
            EmailId = values[5];
        }
        public void WalletRecharge1(double amount)
        {
            WalletBalance += amount;
        }
        public void DeductBalance(double deductAmount)
        {
            WalletBalance -= deductAmount;
        }
    }
}