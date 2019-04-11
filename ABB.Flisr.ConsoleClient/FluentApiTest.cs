using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Flisr.ConsoleClient
{
    class FluentApiTest
    {
        public static void StandardStyleTest()
        {
            Phone phone = new Phone();
            phone.On();

            phone.Off();

            phone.Call("555-666-333", "555-999-020");

        }

        public static void FluentTest()
        {
            IPhone phone = new FluentPhone();

            phone.On()
                .From("555-777-333")
                .To("555-999-020")
                .To("555-777-000")
                .WithSubject(".NET")       
                .Call();
        }
    }
    

    public interface IPhone
    {
        IFrom On();
    }

    public interface ICall
    {
        void Call();
    }

    public interface ITo
    {
        ISubject To(string number);
    }

    public interface ISubject : ICall, ITo
    {
        ICall WithSubject(string subject);
    }

    public interface IFrom
    {
        ITo From(string number);
    }

    public interface IOn
    {
        IFrom On();
    }

    public class FluentPhone : IPhone, IOn, IFrom, ITo, ICall, ISubject
    {
        private bool isOn = false;

        private string from;
        private IList<string> to = new List<string>();
        private string subject;

        public IFrom On()
        {
            isOn = true;
            return this;
        }

        public FluentPhone Off()
        {
            isOn = false;
            return this;
        }
        
        public ITo From(string from)
        {
            this.from = from;
            return this;
        }

        public ISubject To(string to)
        {
            this.to.Add(to);
            return this;
        }

        public ICall WithSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public void Call()
        {
            if (isOn)
            {
                if (string.IsNullOrEmpty(subject))
                {
                    foreach (var number in to)
                    {
                         Console.WriteLine($"Calling from {from} to {number}");
                    }
                 
                }
                else
                {
                    foreach (var number in to)
                    {
                        Console.WriteLine($"Calling from {from} to {number} subject: {subject}");
                    }
                    
                }
            }
        }

    }

    public class Phone
    {
        private bool isOn = false;

        public void On()
        {
            isOn = true;
        }

        public void Off()
        {
            isOn = false;
        }

        public void Call(string from, string to, string subject = null)
        {
            if (isOn)
            {
                if (string.IsNullOrEmpty(subject))
                {
                    Console.WriteLine($"Calling from {from} to {to}");
                }
                else
                {
                    Console.WriteLine($"Calling from {from} to {to} subject: {subject}");
                }
            }
        }
    }
}
