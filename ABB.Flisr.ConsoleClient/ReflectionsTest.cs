using ABB.Flisr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Flisr.ConsoleClient
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }

    public class Employee
    {
        private decimal salary;

        public int Id { get; set; }
        public string Department { get; set; }

        public void DoWork(string message, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(message);
            }
          
        }
    }

    public class ReflectionsTest
    {
        public static void ActivateTest()
        {
            string classname = "Employee";

            string objectToInstantiate = $"ABB.Flisr.ConsoleClient.{classname}, ABB.Flisr.ConsoleClient";

            var objectType = Type.GetType(objectToInstantiate);

            var instantiatedObject = Activator.CreateInstance(objectType);

            MethodInfo methodInfo = objectType.GetMethod("DoWork");

            var parameters = new object[] { "Hello", 10 };

            methodInfo.Invoke(instantiatedObject, parameters);

        }
     

        public static void ReflectionTest()
        {
            Network network = new Network(1, "Network 1", 10);

            Type type = typeof(Network);

            ConstructorInfo[] ci = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);



        }
    }
}
