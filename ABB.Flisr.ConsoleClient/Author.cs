using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Flisr.ConsoleClient
{

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class Author : Attribute
    {
        private string firstname;
        private string lastname;

        public Author(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
    }
}
