using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Surname
    {
        public int ID { get; set; }
        public string Surnam { get; set; }
        public string Sex { get; set; }
        public int PeoplesCount { get; set; }
        public DateTime WhenPeoplesCount { get; set; }
        public string Source { get; set; }
    }
}
