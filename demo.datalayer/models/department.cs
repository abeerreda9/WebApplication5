using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.models
{
    public class department:baseentity
    {
        public string name { get; set; }
        public int code { get; set; }
        public string description { get; set; }
    }
}
