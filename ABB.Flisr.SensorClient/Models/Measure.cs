using System;
using System.Collections.Generic;
using System.Text;

namespace ABB.Flisr.SensorClient.Models
{

    public class Rootobject
    {
        public Sensor[] Sensors { get; set; }
        public int TTL { get; set; }
    }

    public class Sensor
    {
        public Taskvalue[] TaskValues { get; set; }
        public string TaskEnabled { get; set; }
        public int TaskNumber { get; set; }
    }

    public class Taskvalue
    {
        public int ValueNumber { get; set; }
        public string Name { get; set; }
        public int NrDecimals { get; set; }
        public float Value { get; set; }
    }

}
