using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Flisr.ConsoleClient
{
    class DynamicTests
    {
        public static void DynamicTest()
        {
            dynamic x = 100;

            x++;

            x.ToString();

            x = "Hello";

        }

        public static void ExpandoObjectTest()
        {
            dynamic expando = new ExpandoObject();
            //expando.FirstName = "Marcin";
            //expando.City = "Bydgoszcz";

            IDictionary<string, bool> properties = new Dictionary<string, bool>
            {
                { "LastName", true },
                { "Color", false },
                { "Age", true },
                { "Language", false },
            };

            var expandoDict = expando as IDictionary<string, dynamic>;

            var selectedProperties = properties.Where(p => p.Value == true);

            foreach (var property in selectedProperties)
            {
                expandoDict.Add(property.Key, 0);
            }

            // expando.Language = "Polish";

            expandoDict["Language"] = "Polish";

            Console.WriteLine(expando.Language);


        }
    }
}
