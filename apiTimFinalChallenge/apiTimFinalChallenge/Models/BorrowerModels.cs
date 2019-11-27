using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiTimFinalChallenge.Models
{
    public class BorrowerModels
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }
        public string DOB { get; set; }


        public BorrowerModels(int id, string surname, string firstname, string DOB)
        {
            this.id = id;
            this.surname = surname;
            this.firstname = firstname;
            this.DOB = DOB;
        }
    }
}