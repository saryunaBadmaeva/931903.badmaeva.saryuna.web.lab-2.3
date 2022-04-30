using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Lab3.Models
{
    public class Quiz
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string Operation { get; set; }
        public int RightAnswer { get; set; }
        public int UserAnswer { get; set; }
        public string QueryStr { get; set; }
    }
}
