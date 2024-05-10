using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApllication
{
    public enum OrderStatus
    {
        Default, Ordered, Cancelled
    }
    public class OrderDetails
    {
        // OrderID (Auto Increment – OID1001)
        // CustomerID
        // ProductID
        // TotalPrice 
        // PurchaseDate
        // Quantity
        // OrderStatus – (Enum- Default, Ordered, Cancelled)
        private static int s_orderID = 1000;
        public string OrderID { get; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public OrderDetails(string customerId, string productId, int totalPrice, DateTime purchaseDate, int quantity,
                 OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;
            CustomerID = customerId;
            ProductID = productId;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            OrderStatus = orderStatus;
        }

        public OrderDetails(string orders)
        {
            string[] values=orders.Split(",");
            OrderID = values[0];
            s_orderID=int.Parse(values[0].Remove(0,3));
            CustomerID = values[1];
            ProductID = values[2];
            TotalPrice = int.Parse(values[3]);
            PurchaseDate = DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            Quantity = int.Parse(values[5]);
            OrderStatus = Enum.Parse<OrderStatus>(values[6]);
        }
    }
}