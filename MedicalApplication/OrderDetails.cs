using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApplication
{
    public enum OrderStatus{
        Purchased,Cancelled
    }
    public class OrderDetails
    {
        // a.	OrderID (Auto increment – OID3000)
        // b.	UserID
        // c.	MedicineID
        // d.	MedicineCount
        // e.	TotalPrice
        // f.	OrderDate
        // g.	OrderStatus {Enum – Purchased, Cancelled}
        private static int s_orderID = 3000;
        public string OrderID{get;}
        public string UserID{get; set;}
        public string MedicineID{get; set;}
        public int MedicineCount{get; set;}
        public int TotalPrice{get; set;}
        public DateTime OrderDate{get; set;}
        public OrderStatus OrderStatus{get; set;}

        public OrderDetails(string userID,string medicineID,int medicineCount,int totalPrice,DateTime orderDate,OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            UserID=userID;
            MedicineID=medicineID;
            MedicineCount=medicineCount;
            TotalPrice=totalPrice;
            OrderDate=orderDate;
            OrderStatus=orderStatus;
        }
    }
}