using demo.datalayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.bl.dto
{
    public class departmentdetailsdto
    {
        public departmentdetailsdto(department department)
        {
            id = department.id;
            name= department.name;
            description= department.description;
            
        }

        public int id {  get; set; }
        public int createdby { get; set; }//user id
        public DateTime createdon { get; set; }//time of create
        public int lastmodifiedby { get; set; }//user id
        public string name { get; set; } = string.Empty;    
        public string code { get; set; } = string.Empty;
        public string description { get; set; }
        public bool isdeleted { get; set; }//softdelete
    }
}
