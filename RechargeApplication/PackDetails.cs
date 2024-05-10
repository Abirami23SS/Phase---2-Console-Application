using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RechargeApplication
{
    public class PackDetails
    {
        // PackID 
        // PackName
        // Price
        // Validity 
        // NoOfChannels
        public string PackID{get; set;}
        public string PackName{get; set;}
        public int Price{get; set;}
        public int Validity{get; set;}
        public int NumberOfChannels{get; set;}

        public PackDetails(string packID,string packName,int price,int validity,int numberChannels)
        {
            PackID=packID;
            PackName=packName;
            Price=price;
            Validity=validity;
            NumberOfChannels=numberChannels;
        }

    }
}