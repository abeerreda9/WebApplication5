using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.bl.dto
{
    public class departmentdto
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public DateOnly dateofcreation { get; set; }

    }
}
