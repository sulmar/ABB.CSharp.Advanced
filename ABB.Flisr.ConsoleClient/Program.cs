using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Flisr.ConsoleClient
{
    class Program
    {
        static void Print(string text, int copies)
        {

        }

        static void Main(string[] args)
        {

            Calculator calculator = new Calculator();

            calculator.Log += Sender.SendSms;
            
            // inline
            calculator.Log += delegate (string text)
            {
                Console.WriteLine($"Delegate {text}");
            };

            calculator.Log += text => Console.WriteLine(text);

            calculator.Log += Console.WriteLine;

            if (true)
            {
                calculator.Log += Sender.SendPost;
            }

            Delegate[] delegates = calculator.Log.GetInvocationList();

            calculator.Calculate();

            calculator.Log -= Sender.SendSms;

            calculator.Log = null;

           

            calculator.Calculate();

           

            Console.WriteLine("Press any key to exit.");     
            Console.ReadKey();
        }
    }

    class Calculator
    {
        public delegate void LogDelegate(string message);

        public LogDelegate Log { get; set; }

        public void Calculate()
        {
            // calculating...

            if (Log!=null)
              Log("Calculating...");

            Log?.Invoke("Calculated!");

            Printer printer = new Printer();

            printer.Cost += CalculateCost;

    

            printer.Print("Hello World", 2);
        }

        private decimal CalculateCost(int copies)
        {
            return copies * 100;
        }
    }


    class Printer
    {
        //public delegate void LogDelegate(string message);
        //public LogDelegate Log { get; set; }

        public Action<string> Log { get; set; }

        //public delegate decimal CostDelegate(int copies);
        //public CostDelegate Cost { get; set; }

        public Func<int, decimal> Cost { get; set; }

      //  public Func<bool, float> HasToner { get; set; }

        public Predicate<float> HasToner { get; set; }


        public void Print(string content, int copies = 1)
        {
            for (int i = 0; i < copies; i++)
            {
                 Console.WriteLine($"Printing {content}");
            }

            decimal? totalAmount = Cost?.Invoke(copies);

            if (totalAmount.HasValue)
            {
                Console.WriteLine($"LCD {totalAmount}");
            }
         
        }
       
    }


    class Sender
    {
        public delegate void SendDelegate(string content);

        public delegate void DoWork();

        public static void Send(string content)
        {
            SendDelegate sendDelegate = null;

            sendDelegate += SendSms;
            sendDelegate += SendPost;

            sendDelegate.Invoke(content);


        }

        public static void SendSms(string message)
        {
            Console.WriteLine($"Send {message} via sms");
        }

        public static void SendPost(string post)
        {
            Console.WriteLine($"Send post {post}");
        }
    }
}
