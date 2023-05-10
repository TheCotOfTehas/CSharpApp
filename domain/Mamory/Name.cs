using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Name
    {
        public int ID { get; set; }
        public string Name_ { get; set; }
        public string Sex { get; set; }
        public int PeoplesCount { get; set; }
        public DateTime WhenPeoplesCount { get; set; }
        public string Source { get; set; }
    }
}
