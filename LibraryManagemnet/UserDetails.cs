using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagemnet
{
    public enum Department{
        ECE,EEE,CSE
    }
    public class UserDetails
    {
        // a.	UserID (Auto Increment – SF3000)
        // b.	UserName
        // c.	Gender
        // d.	Department – (Enum – ECE, EEE, CSE)
        // e.	MobileNumber
        // f.	MailID
        private static int s_userId = 3000;
        public string UserID{get;}
        public string UserName{get; set;}
        public string Gender{get; set;}
        public Department Department{get; set;}
        public long MobileNumber{get; set;}
        public string MailID{get; set;}
        public double WalletBalance{get; set;}

        public UserDetails(string userName,string gender,Department department,long mobileNumber,string mailID,double walletBalnce)
        {
            s_userId++;
            UserID="SF" + s_userId;
            UserName=userName;
            Gender=gender;
            Department=department;
            MobileNumber=mobileNumber;
            MailID=mailID;
            WalletBalance=walletBalnce;
        }
        public void WalletRecharge(double amount)
        {
           WalletBalance+= amount;
        } 
        public void DeductAmount(int deductAmount)
        {
            WalletBalance+=deductAmount;
        }

    }
}