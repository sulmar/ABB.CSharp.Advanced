using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ABB.Flisr.Models
{
    public class Network : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float VoltageLevel { get; set; }

        protected IList<Item> Items { get; set; }

        protected Network()
        {
            Items = new List<Item>();
            
            VoltageLevel = 10;
        }

        public Network(int id, string name, float voltageLevel)
            : this()
        {
            Id = id;
            Name = name;
            VoltageLevel = voltageLevel;
        }


        public IReadOnlyCollection<Item> GetItems()
        {
            return new ReadOnlyCollection<Item>(Items);
        }

        public void Add(Item item)
        {
            // ..


            Items.Add(item);
        }
    }
    
}
