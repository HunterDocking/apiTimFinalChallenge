using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiTimFinalChallenge.Models
{
    public class BookModels
    {
        public int ISBN { get; set; }
        public string title { get; set; }



        public BookModels(int ISBN, string title)
        {
            this.ISBN = ISBN;
            this.title = title;
        }
    }
}