namespace ABB.Flisr.Models
{
    // Stacja zasilajaca
    public class SubStation : Item
        
    {
        public SubStation(int id, string name, float power = 0) : base(id, name)
        {
            this.Power = power;
        }

        public Item Terminal { get; set; }
        public float Power { get; set; }
    }
}
