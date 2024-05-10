using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankApplication
{
    public enum BloodGroup{
        A_Positive,B_Positive,O_Positive,AB_Positive}
    public class DonationDetails
    {
        // •	Donation ID (Auto increment - DID1001)
        // •	Donor Id
        // •	Donation Date
        // •	Weight
        // •	Blood Pressure
        // •	Hemoglobin Count (above 13.5)
        // •	Blood Group – (Enum – A_Positive, B_Positive, O_Positive, AB_Positive)
        private static int s_donationID = 1000;
        public string DonationID{get;}
        public string DonarId{get; set;}
        public DateTime DonationDate{get; set;}
        public int Weight{get; set;}
        public int BloodPressure{get; set;}
        public double HemoglobinCount{get; set;}
        public BloodGroup BloodGroup{get; set;}

        public DonationDetails(string donarId,DateTime donationDate,int weight,int bloodPressure,double hemoglobinCount,BloodGroup bloodGroup)
        {
            s_donationID++;
            DonationID="DID" +s_donationID;
            DonarId=donarId;
            DonationDate=donationDate;
            Weight=weight;
            BloodPressure=bloodPressure;
            HemoglobinCount=hemoglobinCount;
            BloodGroup=bloodGroup;
        }

         public DonationDetails(string donation1)
        {
            string[] values=donation1.Split(",");
            s_donationID=int.Parse(values[0].Remove(0,3));
            DonationID=values[0];
            DonarId=values[1];
            DonationDate=DateTime.ParseExact(values[2],"dd/MM/yyyy",null);
            Weight=int.Parse(values[3]);
            BloodPressure=int.Parse(values[4]);
            HemoglobinCount=double.Parse(values[5]);
            BloodGroup=Enum.Parse<BloodGroup>(values[6]);
        }
    }
}
