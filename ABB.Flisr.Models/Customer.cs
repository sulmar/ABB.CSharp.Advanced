using System;
using System.Collections.Generic;
using System.Text;

namespace ABB.Flisr.Models
{
    public class Customer : Base
    {      
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
