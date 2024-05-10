using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagemnet
{
    public enum Status{
        Default,Borrowed,Returned
    }
    public class BorrowDetails
    {
        // •	BorrowID (Auto Increment – LB2000)
        // •	BookID 
        // •	UserID
        // •	BorrowedDate – ( Current Date and Time )
        // •	BorrowBookCount 
        // •	Status –  ( Enum - Default, Borrowed, Returned )
        // •	PaidFineAmount
        private static int s_borrowID = 2000;
        public string BorrowID{get;}
        public string BookID{get; set;}
        public string UserID{get; set;}
        public DateTime BorrowDate{get; set;}
        public int BorrowBookCount{get; set;}
        public Status Status{get; set;}
        public int PaidFineAmount{get; set;}

        public BorrowDetails(string bookID,string userID,DateTime borrowDate,int borrowBookCount,Status status,int paidFine)
        {
            s_borrowID++;
            BorrowID="LB" + s_borrowID;
            BookID=bookID;
            UserID=userID;
            BorrowDate=borrowDate;
            BorrowBookCount=borrowBookCount;
            Status=status;
            PaidFineAmount=paidFine;
        }

    }
}