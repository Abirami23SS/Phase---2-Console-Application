using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApllication
{
    public class FileHandling
    {
        //create file method
        public static void Create()
        {
            if(!Directory.Exists("EcommerceApllication"))
            {
                Console.WriteLine("Creating Folder ");
                Directory.CreateDirectory("EcommerceApllication");
            }
            else{
                Console.WriteLine("Folder exists");
            }
            //file 
            if(!File.Exists("EcommerceApllication/CustomerDetails.csv"))
            {
                Console.WriteLine("Creating file for Customer...");
                File.Create("EcommerceApllication/CustomerDetails.csv").Close();
            }
            else{
                Console.WriteLine("File exists");
            }

             if(!File.Exists("EcommerceApllication/OrderDetails.csv"))
            {
                Console.WriteLine("Creating file for Order...");
                File.Create("EcommerceApllication/OrderDetails.csv").Close();
            }
            else{
                Console.WriteLine("File exists");
            }

             if(!File.Exists("EcommerceApllication/ProductDetails.csv"))
            {
                Console.WriteLine("Creating file for Product...");
                File.Create("EcommerceApllication/ProductDetails.csv").Close();
            }
            else{
                Console.WriteLine("File exists");
            }

        }
        //write to csv
        public static void WriteToCSV()
        {
            //customer details list
            string[] customer=new string[Operation.customerList.Count];
            for(int i=0;i<Operation.customerList.Count;i++)
            {
                customer[i]=Operation.customerList[i].CustomerID+","+Operation.customerList[i].CustomerName+","+Operation.customerList[i].City+","+Operation.customerList[i].MobileNumber+","+Operation.customerList[i].WalletBalance+","+Operation.customerList[i].EmailId;
            }
            File.WriteAllLines("EcommerceApllication/CustomerDetails.csv",customer);
            //order details list
            string[] order=new string[Operation.orderList.Count];
            for(int i=0;i<Operation.orderList.Count;i++)
            {
                order[i]=Operation.orderList[i].OrderID+","+Operation.orderList[i].CustomerID+","+Operation.orderList[i].ProductID+","+Operation.orderList[i].TotalPrice+","+Operation.orderList[i].PurchaseDate.ToString("dd/MM/yyyy")+","+Operation.orderList[i].Quantity+","+Operation.orderList[i].OrderStatus;
            }
            File.WriteAllLines("EcommerceApllication/OrderDetails.csv",order);
            //product details list
            string [] product =new string[Operation.productList.Count];
            for(int i=0;i<Operation.productList.Count;i++)
            {
                product[i]=Operation.productList[i].ProductID+","+Operation.productList[i].ProductName+","+Operation.productList[i].Stock+","+Operation.productList[i].Price+","+Operation.productList[i].ShippingDuration;
            }
            File.WriteAllLines("EcommerceApllication/ProductDetails.csv",product);
        }
        public static void ReadToCSV()
        {
            string[] customer=File.ReadAllLines("EcommerceApllication/CustomerDetails.csv");
            foreach(string customers in customer)
            {
                CustomerDetails customer1=new CustomerDetails(customers);
                Operation.customerList.Add(customer1);
            }
            string[] order=File.ReadAllLines("EcommerceApllication/OrderDetails.csv");
            foreach(string orders in order)
            {
                OrderDetails order1=new OrderDetails(orders);
                Operation.orderList.Add(order1);
            }
            string[] product=File.ReadAllLines("EcommerceApllication/ProductDetails.csv");
            foreach(string products in product)
            {
                ProductDetails product1=new ProductDetails(products);
                Operation.productList.Add(product1);
            }
        }
    }
}