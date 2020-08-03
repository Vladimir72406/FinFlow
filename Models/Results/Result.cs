using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Results
{
    public class Result
    {
        public int code { get; set; }
        public string error { get; set; }

        public Result() { }
        public Result(int _code, string _error) 
        {
            this.code = _code;
            this.error = _error;
        }
    }
}
