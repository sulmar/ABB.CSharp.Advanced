﻿using ABB.Flisr.FakeServices;
using ABB.Flisr.FakeServices.Fakers;
using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Flisr.LinqClient
{

    class anonymouse_5235rweouru8924u3c4hiuw34y78w3y423y49w3y42
    {
        public string FirstName { get; set; }
        public bool IsDeleted { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // typ anonimowy
            //  AnomouseType();

            // LinqTest();

            ZipTest2();
            ZipTest();


            //var q2 = q1.SelectMany(u => u).ToList();

            //foreach (var item in q2)
            //{
            //    Console.WriteLine(item.FullName);
            //}

            SetsTest();

            SetEmployeesTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        private static void SetEmployeesTest()
        {
            var usersA = new[]
            {
                new { FirstName = "Marcin", City = "Krakow"},
                new { FirstName = "Przemek", City = "Krakow"},
                new { FirstName = "Michal", City = "Krakow"},
                new { FirstName = "Pawel", City = "Krakow"},
            };

            var usersB = new[]
           {
                new { FirstName = "Marcin", City = "Warszawa"},
                new { FirstName = "Przemek", City = "Krakow"},
                new { FirstName = "Michal", City = "Majorka"},
                new { FirstName = "Pawel", City = "Krakow"},
            };

            bool allInKrakow = usersB.All(u => u.City == "Krakow");


            // zla praktyka
            // bool inMajorka = usersB.Where(u => u.City == "Majorka").Count() > 0;

            bool inMajorka = usersB.Any(u => u.City == "Majorka");

            var q = usersA
                .Join(usersB,
                    inner => new { inner.FirstName },
                    outer => new { outer.FirstName },
                    (inner, outer) => new { inner.FirstName, OldCity = inner.City, NewCity = outer.City });


            var unchanged3 = q.Where(u => u.OldCity != u.NewCity);



            var unchanged2 = usersA
                .Join(usersB,
                    inner => new { inner.FirstName, inner.City },
                    outer => new { outer.FirstName, outer.City },
                    (inner, outer) => inner);
                                
            var unchanged = from inner in usersA
                            join outer in usersB
                            on new { inner.FirstName, inner.City } 
                                equals new { outer.FirstName, outer.City }
                            select  inner;

            var changed = usersB.Except(unchanged);  

           
         


        }
        

        private static void SetsTest()
        {
            var numbers = Enumerable.Range(1, 50);

            var happyNumbers = Enumerable.Range(45, 10);

            var common = numbers.Intersect(happyNumbers);

            var unhappyNumbers = numbers.Except(happyNumbers);

           

        }

        private static void ZipTest2()
        {
            var actions = new[]
            {
                new { Action = "start", DeviceId = 1, Date = DateTime.Now },
                new { Action = "start", DeviceId = 2, Date = DateTime.Now.AddSeconds(1) },
                new { Action = "stop", DeviceId = 2, Date = DateTime.Now.AddSeconds(4) },
                new { Action = "stop", DeviceId = 1, Date = DateTime.Now.AddSeconds(5) },
            };

            var startActions = actions.Where(a => a.Action == "start");
            var stopActions = actions.Where(a => a.Action == "stop");

            var q = startActions.Zip(stopActions, (start, stop) => stop.Date.Subtract(start.Date));

        }

        private static void ZipTest()
        {
            IEnumerable<int> numbers = new List<int> { 10, 20, 25, 30 };

            //  numbers = numbers.Concat(new List<int> { 0 });

            // numbers = numbers.Concat(0.ToEnumerable());

            numbers = numbers.Concat(0);

            TimeSpan myTime = 4.Seconds();

            myTime = 0.6.Seconds();

            //    DateTime.Now.Seconds(4);
            

            var q1 = numbers.Zip(numbers.Reverse(), (left, right) => new { L = left, P = right })
                .Select(g => g.L + g.P)
                .ToList();


            //var deltas = numbers.Skip(1).Zip(numbers, (left, right) => new { L = left, P = right })
            //    .Concat(numbers.Take(1).Select(x=> new { L = x, P = 0 }))
            //    .ToList();

            var first = numbers.Take(1).Select(x => new { L = x, P = 0 });        
       
            var deltas = first
                .Concat(numbers.Skip(1).Zip(numbers, (left, right) => new { L = left, P = right }));

            var diff = deltas.Select(d => d.L - d.P);


            // var q = numbers.Take(1);




        }

        private static void LinqTest()
        {
            IUsersService usersService = new FakeUsersService(new UserFaker());

            var users = usersService.Get();

            foreach (var user in users.Select(u => new { u.FullName, u.Gender }))
            {
                Console.WriteLine($"{user.FullName} {user.Gender}");
            }

            // || Gender || Users

            var q1 = users.GroupBy(u => u.Gender).ToList();

            // || Gender || Qty

            var q3 = users
                .GroupBy(u => new { u.Gender, u.IsDeleted })
                .Select(g => new { Gender = g.Key.Gender, IsDeleted = g.Key.IsDeleted, Qty = g.Count() })
                .Where(g => g.Qty > 10)
                   ;

            var q4 = q3.Where(g => g.Qty > 10);


            foreach (var item in q4)
            {

            }


            foreach (var group in q1)
            {
                foreach (var item in group)
                {
                    Console.WriteLine(item.FullName);
                }
            }
        }

        private static void AnomouseType()
        {
            var person = new { FirstName = "Marcin", IsDeleted = true };

            Console.WriteLine($"{person.FirstName} {person.IsDeleted}");
        }
    }
}
