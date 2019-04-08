namespace ABB.Flisr.Models
{
    public abstract class Device : Item
    {
        protected Device(int id, string name) : base(id, name)
        {
        }

        public Item Terminal1 { get; set; }
        public Item Terminal2 { get; set; }
    }
}
