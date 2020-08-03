using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Person
    {
        public int person_id { get; set; }
        public string Name { get; set; }
	    public string Surname { get; set; }
	    public DateTime? DateOfBirth { get; set; }
    }
}
