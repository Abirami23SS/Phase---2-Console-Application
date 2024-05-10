using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApllication
{

    public class Operation
    {
        public static CustomList<CustomerDetails> customerList = new CustomList<CustomerDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        public static CustomList<ProductDetails> productList = new CustomList<ProductDetails>();
        static CustomerDetails currentCustomer;

        public static void AddDefaultData()
        {
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", 9885858588, 50000, "ravi@mail.com");
            customerList.Add(customer1);
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", 9888475757, 60000, "baskaran@mail.com");
            customerList.Add(customer2);

            ProductDetails product1 = new ProductDetails("Mobile( Samsung)", 10, 10000, 3);
            productList.Add(product1);
            ProductDetails product2 = new ProductDetails("Tablet (Lenovo)", 5, 15000, 2);
            productList.Add(product2);
            ProductDetails product3 = new ProductDetails("Camara (Sony)", 3, 20000, 4);
            productList.Add(product3);
            ProductDetails product4 = new ProductDetails("iPhone ", 5, 50000, 6);
            productList.Add(product4);
            ProductDetails product5 = new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3);
            productList.Add(product5);
            ProductDetails product6 = new ProductDetails("HeadPhone (Boat)", 5, 1000, 2);
            productList.Add(product6);
            ProductDetails product7 = new ProductDetails("Speakers (Boat)", 4, 500, 2);
            productList.Add(product7);

            OrderDetails order1 = new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatus.Ordered);
            orderList.Add(order1);
            OrderDetails order2 = new OrderDetails("CID3002", "PID2002", 40000, DateTime.Now, 2, OrderStatus.Ordered);
            orderList.Add(order2);

            Console.WriteLine("---Default Customer Details---");
            foreach (CustomerDetails customer in customerList)
            {
                Console.WriteLine($"  |{customer.CustomerID,-10}  |  {customer.CustomerName,-20}  |  {customer.City,-15}  |  {customer.MobileNumber,-10}  |  {customer.WalletBalance,-10}  |  {customer.EmailId,-15}");

            }
            Console.WriteLine("---Default Product Details---");
            foreach (ProductDetails product in productList)
            {
                Console.WriteLine($"  |{product.ProductID,-10}  |  {product.ProductName,-20}  |  {product.Stock,-10}  |  {product.Price,-10}    |  {product.ShippingDuration,-10}");

            }
            Console.WriteLine("---Default Order Details---");
            foreach (OrderDetails order in orderList)
            {
                Console.WriteLine($"  |{order.OrderID,-10}  |  {order.CustomerID,-10}  |  {order.ProductID,-10}  |  {order.TotalPrice,-10}  |  {order.PurchaseDate.ToString("yyyy/MM/dd"),-10}  |  {order.Quantity,-10}  |  {order.OrderStatus,-10}");

            }
        }
        public static void MainMenu()
        {
            Console.WriteLine("\t\tE-Commerce Application for Buying Consumer Electronics Products\t\t");
            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.Customer Registartion \n2.Login \n3.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            //Console.WriteLine("Registration selected");
                            CustomerRegistartion();
                            break;
                        }
                    case 2:
                        {
                            //Console.WriteLine("Login selected");
                            Login();
                            break;
                        }

                    case 3:
                        {
                            //Console.WriteLine("Exit Selected");
                            flag = false;
                            break;
                        }

                }
            } while (flag);
        }
        public static void CustomerRegistartion()
        {
            Console.WriteLine("Customer Register");
            Console.Write("Customer Name : ");
            string customerName = Console.ReadLine();
            Console.Write("City : ");
            string city = Console.ReadLine();
            Console.Write("Mobile Number : ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.Write("Your Wallet Balance : ");
            double walletBalance = double.Parse(Console.ReadLine());
            Console.Write("Email Id : ");
            string emailID = Console.ReadLine();

            //user input customer id creating object
            CustomerDetails customer = new CustomerDetails(customerName, city, mobileNumber, walletBalance, emailID);
            customerList.Add(customer);
            Console.WriteLine("Registered Customer Id : " + customer.CustomerID);
        }
        public static void Login()
        {
            //1.If the customer selects 2 from main menu, Login option will be selected.
            //2.Get the CustomerID and validate the CustomerID.
            Console.WriteLine("Enter customer Id : ");
            string customerId = Console.ReadLine().ToUpper();
            bool flag = true;

            foreach (CustomerDetails customer in customerList)
            {
                if (customer.CustomerID == customerId)
                {
                    Console.WriteLine("Customer Id Loggined in Successfully...");
                    flag = false;
                    currentCustomer = customer;
                    SubMenu();
                    break;
                }
            }
            //3.If the CustomerID doesn’t match, show “Invalid customerID”. Else the following sub menu option “a to e” shown.
            if (flag)
            {
                Console.WriteLine("Invalid Customer ID");
            }

        }
        public static void SubMenu()
        {
            //a.Purchase
            // b.OrderHistory
            // c.CancelOrder
            // d.WalletBalance
            // e.WalletRecharge
            // f.Exit

            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.Purchase 2.OrderHistory 3.CancelOrder 4.WalletBalance 5.WalletRecharge 6.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            //Console.WriteLine(");
                            Purchase();
                            break;
                        }
                    case 2:
                        {
                            //Console.WriteLine("");
                            OrderHistory();
                            break;
                        }
                    case 3:
                        {
                            //Console.WriteLine("");
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            //Console.WriteLine("");
                            WalletBalance();
                            break;
                        }
                    case 5:
                        {
                            //Console.WriteLine("");
                            WalletRecharge();
                            break;
                        }
                    case 6:
                        {
                            //Console.WriteLine("");
                            flag = false;
                            break;
                        }
                }
            } while (flag);
        }
        public static void Purchase()
        {
            //1.Once the Customer logged in show the list of Products.  
            foreach (ProductDetails product in productList)
            {
                Console.WriteLine($" {product.ProductID,-10}  |  {product.ProductName,-15}  |  {product.Stock,-10}  |  {product.Price,-10}  |    {product.ShippingDuration,-10}");
            }
            //Ask the customer to select a Product using Product ID.
            Console.WriteLine("Enter product Id");
            string productID = Console.ReadLine();
            bool flag = true;

            foreach (ProductDetails product in productList)
            {
                if (productID == product.ProductID)
                {
                    flag = false;
                    //3.If it is valid, Then ask for the count he wish to purchase.
                    Console.WriteLine("No of products to be purchased");
                    int noOfproducts = int.Parse(Console.ReadLine());

                    //4.If the required count is not available in the product’s stock, 

                    if (noOfproducts <= product.Stock)
                    {
                        int deliveryCharge = 50;
                        //5.If the count is available calculate total amount with the below formula.
                        // Delivery charge is Rs 50
                        // Total Amount = (required count * price per quantity) + Delivery charge
                        int totalPrice = (noOfproducts * product.Price) + deliveryCharge;

                        //6.Check the current logged in customer’s wallet balance to ensure he is having enough balance to purchase by comparing with total price.
                        if (totalPrice < currentCustomer.WalletBalance)
                        {
                            //a.Deduct the total amount from the wallet balance of the current logged in customer.
                            currentCustomer.DeductBalance(totalPrice);
                            //b.	Deduct the count from the stock availability of the product.
                            product.Stock = product.Stock - noOfproducts;
                            //9. Create order with available details and make its status as Ordered. 
                            //add it to order List and show 
                            OrderDetails order = new OrderDetails(currentCustomer.CustomerID, productID, totalPrice, DateTime.Now, noOfproducts, OrderStatus.Ordered);
                            orderList.Add(order);
                            DateTime deliveryDate = order.PurchaseDate.AddDays(product.ShippingDuration);
                            //“Order Placed Successfully. Order ID: OID1001”.
                            Console.WriteLine($" Order Placed Successfully Order ID :{order.OrderID} \n And Your order will be delivered on {deliveryDate.ToString("yyyy/MM/dd")}");

                        }
                        else
                        {
                            Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again”.");
                        }
                    }
                    else
                    {
                        //then show like “Required count not available. Current availability is {product’s stock count}”.
                        Console.WriteLine("Required count not Available : " + product.Stock);
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Product Id");
            }
        }
        public static void OrderHistory()
        {
            Console.WriteLine(" Order Id  |  Customer Id  |  Product Id  |  Total Price  |  Purchase Date  |  Quantity  |  OrderStatus");
            bool flag = true;
            foreach (OrderDetails order in orderList)
            {
                flag = false;
                if (currentCustomer.CustomerID == order.CustomerID)
                {
                    Console.WriteLine($"  {order.OrderID}  |  {order.CustomerID}  |  {order.ProductID}  |  {order.TotalPrice}  |  {order.PurchaseDate}  |  {order.Quantity}  |  {order.OrderStatus}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No orders yet...");
            }
        }
        public static void CancelOrder()
        {
            //1.Show all orders placed by current logged in customer whose order status is Ordered.
            bool flag = true;
            foreach (OrderDetails order in orderList)
            {
                if (currentCustomer.CustomerID == order.CustomerID)
                {
                    flag = false;
                    Console.WriteLine($"  {order.OrderID}  |  {order.CustomerID}  |  {order.ProductID}  |  {order.TotalPrice}  |  {order.PurchaseDate}  |  {order.Quantity}  |  {order.OrderStatus}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No orders yet...");
            }
            if (!flag)
            {
                //2.Ask customer to select an order to be cancelled by the OrderID.
                Console.WriteLine("Enter order ID to be cancelled : ");
                string cancelID = Console.ReadLine();
                bool IsFlag = true;
                foreach (OrderDetails order in orderList)
                {
                    if (cancelID == order.OrderID && order.OrderStatus == OrderStatus.Ordered)
                    {
                        IsFlag = false;
                        foreach (ProductDetails product in productList)
                        {
                            if (order.ProductID == product.ProductID)
                            {
                                product.Stock = product.Stock + order.Quantity;
                                currentCustomer.WalletBalance = order.TotalPrice + currentCustomer.WalletBalance;
                                order.OrderStatus = OrderStatus.Cancelled;
                                Console.WriteLine("Order ID: " + order.OrderID + " cancelled successfully");
                                Console.WriteLine($"Remaining Product Stock : {product.Stock}");
                            }
                        }
                    }

                }
                //3.Validate orderID and show “Invalid OrderID” if there is no such order.
                if (IsFlag)
                {
                    Console.WriteLine("Invalid order Id ");
                }
            }
        }
        public static void WalletBalance()
        {
            Console.WriteLine($"  Wallet Balance : {currentCustomer.WalletBalance}");
        }
        public static void WalletRecharge()
        {
            //Ask the customer whether he wish to recharge the wallet
            Console.WriteLine("Ask the customer whether he wish to recharge the wallet? ");
            string option = Console.ReadLine();
            if (option == "yes")
            {
                //2.If “Yes” then ask for the amount to be recharged and update the amount in the wallet and 
                //display the updated wallet balance.
                double userAmount = int.Parse(Console.ReadLine());
                if (userAmount > 0)
                {
                    currentCustomer.WalletRecharge1(userAmount);
                    Console.WriteLine("Updated Balance : " + currentCustomer.WalletBalance);
                }
                else
                {
                    Console.WriteLine("Invalid recharge amount");
                }
            }
        }
    }
}



