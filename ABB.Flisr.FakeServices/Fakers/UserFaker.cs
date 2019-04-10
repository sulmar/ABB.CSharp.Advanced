using ABB.Flisr.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABB.Flisr.FakeServices.Fakers
{
    public class UserFaker : Faker<User>
    {

        public UserFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Gender, f => (Gender) f.Person.Gender);
            RuleFor(p => p.IsDeleted, f => f.Random.Bool(0.2f));
            Ignore(p => p.Salary);

        }
    }
}
