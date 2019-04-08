using System.Collections.Generic;

namespace ABB.Flisr.Models
{
    public class Line : Device
    {
        protected ICollection<Load> loads;

        public Line(int id, string name, int length) : base(id, name)
        {
            Length = length;

            loads = new List<Load>();
        }

        public int Length { get; set; }

        public bool IsFault { get; set; }

        public void Connect(Load load)
        {
            loads.Add(load);
        }
    }
}
