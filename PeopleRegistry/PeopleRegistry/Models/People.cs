using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace PeopleRegistry.Models
{
    public class People
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }

        public string DateOfBirth { get; set; }

        public string Sex { get; set; } 

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }



    }
}
