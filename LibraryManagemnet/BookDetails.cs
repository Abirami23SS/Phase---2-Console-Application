using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagemnet
{
    public class BookDetails
    {
        //  1.	BookID (Auto Increment - BID1000)
        // 2.	BookName
        // 3.	AuthorName
        // 4.	BookCount
        private static int s_boodId = 1000;
        public string BookID{get;}
        public string BookName{get; set;}
        public string AuthorName{get; set;}
        public int BookCount{get; set;}

        public BookDetails(string bookName,string authorName,int bookCount)
        {
            s_boodId++;
            BookID="BID" +s_boodId;
            BookName=bookName;
            AuthorName=authorName;
            BookCount=bookCount;
        }

    }
}