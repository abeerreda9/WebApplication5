using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.bl.dto
{
    public class employeedto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        [DataType(DataType.Currency)]
        public decimal salary { get; set; }
        [Display(Name ="is active")]
        public bool isactive { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string gender { get; set; }
        [Display(Name = "emp type ")]
        public string employeetype { get; set; }
        public string department { get; set; }
       
    }
}
