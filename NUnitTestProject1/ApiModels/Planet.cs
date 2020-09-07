using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiAdMixer.ApiModels
{
    public class Planet
    {
        public string Climate { get; set; }
        public DateTime Created { get; set; }
        public long Diameter { get; set; }
        public DateTime Edited { get; set; }
        public List<Uri> Films { get; set; }
        public string Gravity { get; set; }
        public string Name { get; set; }
        public long OrbitalPeriod { get; set; }
        public long Population { get; set; }
        public List<Uri> Residents { get; set; }
        public long RotationPeriod { get; set; }
        public long SurfaceWater { get; set; }
        public string Terrain { get; set; }
        public Uri Url { get; set; }
    }
}

