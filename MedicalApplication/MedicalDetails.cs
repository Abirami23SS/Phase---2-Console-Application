using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApplication
{
    public class MedicalDetails
    {
        // a.	MedicineID (Auto increment – MD2000)
        // b.	MedicineName
        // c.	AvailableCount
        // d.	Price
        // e.	DateOfExpiry
        private static int s_medicalID = 2000;
        public string MedicineID{get;}
        public string MedicineName{get; set;}
        public int AvailableCount{get; set;}
        public int Price{get; set;}
        public DateTime DateOfExpiry{get; set;}

        public MedicalDetails(string medicineName,int availableCount,int price,DateTime dateExpiry)
        {
            s_medicalID++;
            MedicineID="MD" +s_medicalID;
            MedicineName=medicineName;
            AvailableCount=availableCount;
            Price=price;
            DateOfExpiry=dateExpiry;
        }

    }
}