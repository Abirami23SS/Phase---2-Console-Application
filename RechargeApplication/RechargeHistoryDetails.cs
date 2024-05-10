using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RechargeApplication
{
    public class RechargeHistoryDetails
    {
        //  RechargeID (Auto increment which is start from RP101)
        // UserID
        // PackID
        // RechargeDate (Current Date)
        // RechargeAmount
        // ValidTill (Date Time)
        // NumberOfChannels
        private static int s_rechargeID = 100;
        public string RechargeID{get;}
        public string UserID{get; set;}
        public string PackID{get; set;}
        public DateTime RechargeDate{get; set;}
        public int RechargeAmount{get; set;}
        public DateTime ValidTill{get; set;}
        public int NumberOfChannels{get; set;}

        public RechargeHistoryDetails(string userID,string packID,DateTime rechargeDate, int rechargeAmount,DateTime validTill,int numberChannels)
        {
            s_rechargeID++;
            RechargeID="RP" +s_rechargeID;
            UserID=userID;
            PackID=packID;
            RechargeDate=rechargeDate;
            RechargeAmount=rechargeAmount;
            ValidTill=validTill;
            NumberOfChannels=numberChannels;
        }

    }
}