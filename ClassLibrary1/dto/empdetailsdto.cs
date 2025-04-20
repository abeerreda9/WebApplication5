using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.bl.dto
{
    public class empdetailsdto
    {
       public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public decimal salary { get; set; }
      
        public bool isactive { get; set; }
   
        public string email { get; set; }
        public string gender { get; set; }
        public int phonenumber { get; set; }
        public DateTime hiringdate { get; set; }
        public string employeetype { get; set; }
        public int createdby { get; set; }
        public DateTime createdon { get; set; }
        public int lastmodifiedby { get; set; }
        public DateTime lastmodifiedin { get; set; }

    }
}
