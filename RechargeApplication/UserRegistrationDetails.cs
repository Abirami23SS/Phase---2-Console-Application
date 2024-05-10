using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RechargeApplication
{
    public class UserRegistrationDetails
    {
        /*•	UserID (Auto Incremented which is start from UID1001)
           •	UserName
           •	MobileNumber
            •	EmailID
             •	WalletBalance*/
        private static int s_userID = 1000;
        public string UserID{get;}
        public string UserName{get; set;}
        public long MobileNumber{get; set;}
        public string EmailID{get; set;}
        public int WalletBalance{get; set;}

        public UserRegistrationDetails(string userName,long mobileNumber,string emailId,int walletBalance)
        {
            s_userID++;
            UserID="UID" +s_userID;
            UserName=userName;
            MobileNumber=mobileNumber;
            EmailID=emailId;
            WalletBalance=walletBalance;
        }

       
    }
}