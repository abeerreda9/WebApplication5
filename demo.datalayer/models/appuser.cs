using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.models
{
    public class appuser:IdentityUser
    {
        public bool isagree { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

    }
}
