using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.models
{
    public class baseentity
    {
        public int id { get; set; }
        public int createdby { get; set; }//user id
        public DateTime createdon { get; set;}//time of create
        public int lastmodifiedby { get; set; }//user id
        public DateTime lastmodifiedon { get; set; }
        public bool isdeleted { get; set; }//softdelete
    }
}
