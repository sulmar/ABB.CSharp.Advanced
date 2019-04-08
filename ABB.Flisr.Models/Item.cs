namespace ABB.Flisr.Models
{
    public abstract class Item : Base
    {
        protected Item(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnergize { get; set; }
    }
}
