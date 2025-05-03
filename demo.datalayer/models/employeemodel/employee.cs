using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.models.employeemodel
{
    public class employee:baseentity
    {
        public string name { get; set; }
        public int age { get; set; }
        public decimal salary { get; set; }
        public string? address { get; set; }
        public bool isactive { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public DateTime hiringdate { get; set; }
        public empgender gender { get; set; }
        public employee type { get; set; }
        public int? departmentid { get; set; } //fk colomn
        //navigation prop[one]
        public virtual department department { get; set; }
    }
}
