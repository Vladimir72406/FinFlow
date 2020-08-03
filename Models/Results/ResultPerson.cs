using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Results
{
    public class ResultPerson : Result
    {
        public Person person { get; set; }
        public LinkedList<Person> lstPerson { get; set; }

        public ResultPerson()
        { 

        }

    }
}
