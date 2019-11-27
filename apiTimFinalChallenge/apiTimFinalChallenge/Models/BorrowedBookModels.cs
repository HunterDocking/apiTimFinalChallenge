using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiTimFinalChallenge.Models
{
    public class BorrowedBookModels
    {
        public int ISBN { get; set; }
        public BorrowerModels borrower { get; set; }
        public string title { get; set; }
        


        public BorrowedBookModels(int ISBN, int id, string surname, string firstname, string DOB, string title)
        { 
            this.ISBN = ISBN;
            this.borrower = new BorrowerModels(id, surname, firstname, DOB);
            this.title = title;
        }
    }
}