using System;
using System.Collections.Generic;
using System.Text;

namespace ABB.Flisr.Models
{
    public class User : Base
    {    
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string PrefixFullName => "Mr" + FullName;
    }
}
