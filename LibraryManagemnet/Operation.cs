using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagemnet
{
    public class Operation
    {
        static List<UserDetails> userList = new List<UserDetails>();
        static List<BookDetails> bookList = new List<BookDetails>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        static UserDetails currentUser;

        public static void AddDefaultData()
        {
            UserDetails user1 = new UserDetails("Ravichandran ", "Male", Department.EEE, 9938388333, "ravi@gmail.com", 100);
            userList.Add(user1);
            UserDetails user2 = new UserDetails("Priyadharshini", "Female", Department.CSE, 9944444455, "priya@gmail.com ", 150);
            userList.Add(user2);

            BookDetails book1 = new BookDetails("c#", "Author 1", 1);
            bookList.Add(book1);
            BookDetails book2 = new BookDetails("HTML", "Author 2", 5);
            bookList.Add(book2);
            BookDetails book3 = new BookDetails("CSS", "Author 1", 3);
            bookList.Add(book3);
            BookDetails book4 = new BookDetails("JS", "Author 1", 3);
            bookList.Add(book4);
            BookDetails book5 = new BookDetails("TS", "Author 2", 2);
            bookList.Add(book5);

            BorrowDetails borrow1 = new BorrowDetails(book1.BookID, user1.UserID, new DateTime(2023, 09, 10), 2, Status.Borrowed, 0);
            borrowList.Add(borrow1);
            BorrowDetails borrow2 = new BorrowDetails(book3.BookID, user2.UserID, new DateTime(2023, 09, 12), 1, Status.Borrowed, 0);
            borrowList.Add(borrow2);
            BorrowDetails borrow3 = new BorrowDetails(book4.BookID, user1.UserID, new DateTime(2023, 09, 14), 1, Status.Returned, 16);
            borrowList.Add(borrow3);
            BorrowDetails borrow4 = new BorrowDetails(book2.BookID, user2.UserID, new DateTime(2024, 04, 09), 2, Status.Borrowed, 0);
            borrowList.Add(borrow4);
            BorrowDetails borrow5 = new BorrowDetails(book5.BookID, user2.UserID, new DateTime(2023, 09, 09), 1, Status.Returned, 20);
            borrowList.Add(borrow5);

            foreach (UserDetails user in userList)
            {
                Console.WriteLine($"  {user.UserID}  |  {user.UserName}  |  {user.Gender}  |  {user.Department}  |  {user.MobileNumber}  |  {user.MailID}  |  {user.WalletBalance}");
            }
            foreach (BookDetails book in bookList)
            {
                Console.WriteLine($"  {book.BookID}  |  {book.BookName}  |  {book.AuthorName}  |  {book.BookCount}");

            }
            foreach (BorrowDetails borrow in borrowList)
            {
                Console.WriteLine($"  {borrow.BorrowID}  |  {borrow.BookID}  |  {borrow.UserID}  |  {borrow.BorrowDate.ToString("yyyy/MM/dd")}  |  {borrow.BorrowBookCount}  |  {borrow.Status}  |   {borrow.PaidFineAmount}");
            }
        }
        public static void MainMenu()
        {
            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.UserRegistration  2.UserLogin  3.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            //Console.WriteLine("Registration selected");
                            UserRegistartion();
                            break;
                        }
                    case 2:
                        {
                            //Console.WriteLine("Login selected");
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            //Console.WriteLine("Exit Selected");
                            flag = false;
                            Exit();
                            break;
                        }
                }
            } while (flag);
        }
        public static void UserRegistartion()
        {
            Console.WriteLine("User Details ");
            Console.Write("User Name : ");
            string userName = Console.ReadLine();
            Console.Write("Gender : ");
            string gender = Console.ReadLine();
            Console.Write("Department : ");
            Department department = Enum.Parse<Department>(Console.ReadLine(), true);
            Console.Write("Mobile Number : ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.Write("Mail ID : ");
            string mailID = Console.ReadLine();
            Console.Write("Wallet Balance : ");
            int walletBalnce = int.Parse(Console.ReadLine());

            UserDetails inputUser = new UserDetails(userName, gender, department, mobileNumber, mailID, walletBalnce);
            userList.Add(inputUser);
            Console.WriteLine("User registered successfully : " + inputUser.UserID);
        }
        public static void UserLogin()
        {
            Console.WriteLine("Enter user Id  : ");
            string userID = Console.ReadLine();
            bool flag = true;
            foreach (UserDetails user in userList)
            {
                if (userID == user.UserID)
                {
                    Console.WriteLine("Logged in Successfully...!");
                    flag = false;
                    currentUser = user;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid User Id..");
            }
        }
        public static void SubMenu()
        {
            // 1.	Borrowbook.
            // 2.	ShowBorrowedhistory.
            // 3.	ReturnBooks
            // 4.	WalletRecharge 
            // 5.	Exit
            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.BorrowBook  2.ShowBorrowed history  3.ReturnBooks  4.WalletRecharge  5.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            BorrowBook();
                            break;
                        }
                    case 2:
                        {
                            ShowBorrowHistory();
                            break;
                        }
                    case 3:
                        {
                            ReturnBooks();
                            break;
                        }
                    case 4:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 5:
                        {
                            flag = false;
                            //Exit();
                            break;
                        }
                }

            } while (flag);
        }
        public static void BorrowBook()
        {
            //list of books
            Console.WriteLine("List of books available : ");
            foreach (BookDetails book in bookList)
            {
                Console.WriteLine($"  {book.BookID}  |  {book.BookName}  |  {book.AuthorName}  |  {book.BookCount}");
            }
            //2.Then Ask the user to pick one book by Asking “Enter Book ID to borrow”.
            Console.WriteLine("Enter book id : ");
            string userBookID = Console.ReadLine();

            bool flag = true;

            foreach (BookDetails book1 in bookList)
            {
                //3.Check whether “BookID” is available or not. 
                if (userBookID == book1.BookID)
                {
                    flag = false;
                    Console.WriteLine("Enter the book count : ");
                    int userCount = int.Parse(Console.ReadLine());
                    //5.Check the book count availability of the book selected. 
                    if (userCount <= book1.BookCount)
                    {
                        //need to check whether the user already have any borrowed book. 
                        int total = 0;
                        foreach (BorrowDetails borrow in borrowList)
                        {
                            if (currentUser.UserID == borrow.UserID && borrow.Status == Status.Borrowed)
                            {
                                total += borrow.BorrowBookCount;
                            }
                        }
                        if (userCount <= 3)
                        {
                            if (userCount + total <= 3)
                            {
                                BorrowDetails newBorrow = new BorrowDetails(userBookID, currentUser.UserID, DateTime.Now, userCount, Status.Borrowed, 0);
                                borrowList.Add(newBorrow);
                                book1.BookCount = book1.BookCount - userCount;
                                Console.WriteLine("Book borrowed successfully ");
                            }
                            else
                            {
                                Console.WriteLine("Your already borrowed book count : " + total + " and requested bookcount is " + userCount);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Borrowed 3 books already");
                        }
                    }
                    else
                    {
                        foreach (BorrowDetails borrow in borrowList)
                        {
                            if (userBookID == borrow.BookID && borrow.Status == Status.Borrowed)
                            {
                                Console.WriteLine(borrow.BorrowDate.AddDays(15).ToString("yyyy/MM/dd"));
                            }
                        }
                    }
                }
            }
            //4.If not available display “ Invalid Book ID, Please enter valid ID”, 
            if (flag)
            {
                Console.WriteLine("Invalid book id");
            }
        }
        public static void ShowBorrowHistory()
        {
            bool flag = true;
            foreach (BorrowDetails borrow in borrowList)
            {
                if (currentUser.UserID == borrow.UserID && borrow.Status == Status.Borrowed)
                {
                    flag = false;
                    Console.WriteLine($"  {borrow.BorrowID,-10}  |  {borrow.BookID,-10}  |  {borrow.UserID,-10}  |  {borrow.BorrowDate.ToString("yyyy/MM/dd"),-10}  |  {borrow.BorrowBookCount,-10}  |  {borrow.Status,-10}  |   {borrow.PaidFineAmount}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Borrowed Books");
            }
        }
        public static void ReturnBooks()
        {
            bool flag = true;
            foreach (BorrowDetails borrow in borrowList)
            {
                if (currentUser.UserID == borrow.UserID && borrow.Status == Status.Borrowed)
                {
                    flag = false;
                    Console.WriteLine($"  {borrow.BorrowID,-10}  |  {borrow.BookID,-10}  |  {borrow.UserID,-10}  |  {borrow.BorrowDate.ToString("yyyy/MM/dd"),-10}  |  {borrow.BorrowBookCount,-10}  |  {borrow.Status,-10}  |   {borrow.PaidFineAmount}  |  {borrow.BorrowDate.AddDays(15).ToString("yyyy/MM/dd")}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Borrowed Books");
            }
            if (!flag)
            {
                Console.WriteLine("Enter the borrow id to return");
                String borrowID = Console.ReadLine();
                bool IsFlag = true;
                //Show the borrowed book details of current user whose status is “borrowed” also Print the return date of each book (Return date will be 15 days after borrowing a book).  
                foreach (BorrowDetails borrow in borrowList)
                {
                    if (borrow.BorrowID == borrowID && borrow.Status == Status.Borrowed)
                    {
                        IsFlag = false;
                        int bookCount = borrow.BorrowBookCount;
                        DateTime date = borrow.BorrowDate.AddDays(15);
                        if (date < DateTime.Now)
                        {
                            int date1 = (DateTime.Today - date).Days;
                            // If the return date is elapsed more than 15 days then calculate and show the fine amount (Rs. 1 / Day) for each book
                            int fine = date1 * 1;
                            if (fine <= currentUser.WalletBalance)
                            {
                                currentUser.WalletBalance = currentUser.WalletBalance - fine;
                                borrow.Status = Status.Returned;
                                borrow.PaidFineAmount = fine;
                                foreach (BookDetails book in bookList)
                                {
                                    if (borrow.BookID == book.BookID)
                                    {
                                        book.BookCount += bookCount;
                                    }
                                }
                                Console.WriteLine("Book Returned Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient balance. Please rechange and proceed");

                            }
                        }
                        //Else, change the Status in Booking History to “Returned” and show Book returned successfully. Also, update the “BookCount”.
                        else
                        {
                            borrow.Status = Status.Returned;
                            foreach (BookDetails book in bookList)
                            {
                                if (borrow.BookID == book.BookID)
                                {
                                    book.BookCount += bookCount;
                                }
                            }
                            Console.WriteLine("Book Returned Successfully");
                            //Console.WriteLine("no book");
                        }
                    }
                }
                if (IsFlag)
                {
                    Console.WriteLine("Invalid");
                }
            }

        }
        public static void WalletRecharge()
        {
            Console.WriteLine("Ask the customer whether he wish to recharge the wallet? ");
            string option = Console.ReadLine();
            if (option == "yes")
            {
                //2.If “Yes” then ask for the amount to be recharged and update the amount in the wallet and 
                //display the updated wallet balance.
                double amount = double.Parse(Console.ReadLine());
                if (amount > 0)
                {
                    currentUser.WalletRecharge(amount);
                    Console.WriteLine("Updated Balance : " + currentUser.WalletBalance);
                }
                else
                {
                    Console.WriteLine("Invalid Recharge amount");
                }
            }
        }

        public static void Exit()
        {
            Console.WriteLine("Exit...!");
        }
    }
}