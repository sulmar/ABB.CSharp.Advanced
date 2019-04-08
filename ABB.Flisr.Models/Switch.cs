namespace ABB.Flisr.Models
{
    public class Switch : Device
    {
        public Switch(int id, string name) : base(id, name)
        {
        }

        public SwitchState State { get; set; }
    }
}
