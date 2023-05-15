using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_HW15
{
    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public Country Country { get; set; }
        public DateTime CityFounded { get; set; }
    }
}
