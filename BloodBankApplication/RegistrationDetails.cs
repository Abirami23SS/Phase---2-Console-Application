using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankApplication
{
    public class RegistrationDetails
    {
        //	Donor Id (Auto Incremented which is start from UID1001)
        // 	Donor Name
        // 	Mobile Number
        // 	Blood Group
        // 	Age
        //  LastDonationDate
        private static int s_donorID = 1000;
        public string DonorID{get;}
        public string DonorName{get; set;}
        public long MobileNumber{get; set;}
        public BloodGroup BloodType{get; set;}
        public int Age{get; set;}
        public DateTime LastDonationDate{get; set;}

        public RegistrationDetails(string donarName,long mobileNumber,BloodGroup bloodType,int age,DateTime lastDonationdate)
        {
            s_donorID++;
            DonorID="UID" + s_donorID;
            DonorName=donarName;
            MobileNumber=mobileNumber;
            BloodType=bloodType;
            Age=age;
            LastDonationDate=lastDonationdate;
        }

          public RegistrationDetails(string users)
        {
            string[] values=users.Split(",");
            s_donorID=int.Parse(values[0].Remove(0,3));
            DonorID=values[0];
            DonorName=values[1];
            MobileNumber=long.Parse(values[2]);
            BloodType=Enum.Parse<BloodGroup>(values[3]);
            Age=int.Parse(values[4]);
            LastDonationDate=DateTime.ParseExact(values[5],"dd/MM/yyyy",null);
        }

       
    }
}