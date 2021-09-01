using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneLabHub.Data
{
    public class DroneRun
    {
        public string elapsed_time { get; set; }
        public int frame { get; set; }
        public int battery { get; set; }
        public int temperature { get; set; }
        public string flight_time { get; set; }
        public string height { get; set; }
        public string pitch { get; set; }
        public string roll { get; set; }
        public string yaw { get; set; }
        public int get_distance_tof { get; set; }
        public float get_barometer { get; set; }


    }
}
