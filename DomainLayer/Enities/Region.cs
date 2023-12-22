using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enities
{
    public class Region
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public int RegionCode { get; set; }
        public string Continant { get; set; }
    }
}
