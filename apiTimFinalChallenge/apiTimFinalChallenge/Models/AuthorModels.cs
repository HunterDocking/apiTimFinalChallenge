using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiTimFinalChallenge.Models
{
    public class AuthorModels
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }


        public AuthorModels(int id, string surname, string firstname)
        {
            this.id = id;
            this.surname = surname;
            this.firstname = firstname;
        }
    }
}
