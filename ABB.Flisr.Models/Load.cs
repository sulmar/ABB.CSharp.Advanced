namespace ABB.Flisr.Models
{
    // Odbiorca energii
    public class Load : Item
    {
        public Load(int id, string name) : base(id, name)
        {
        }

    
        public float Power { get; set; }
    }
}
