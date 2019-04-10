using System;
using System.Collections.Generic;
using System.Text;

namespace ABB.Flisr.Models
{
    public class User : Base
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Salary { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string PrefixFullName => "Mr" + FullName;
    }

    public enum Gender
    {
        Female,
        Male
    }
}
