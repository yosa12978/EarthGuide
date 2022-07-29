using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthGuide.Core.Domain
{
    public class Place
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Desc { get; set; } = default!;
        public double Latitude { get; set; } = default!;
        public double Longitude { get; set; } = default!;
        public bool IsActive { get; set; } = default!;
        public long Date { get; set; } = default!;
    }
}
