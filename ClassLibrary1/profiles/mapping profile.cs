using AutoMapper;
using demo.bl.dto;
using demo.datalayer.Migrations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.bl.profiles
{
    public class mapping_profile:Profile
    {
        public mapping_profile()
        {
            CreateMap<employee, employeedto>();
                

            CreateMap<employee,empdetailsdto>();
        }
    }
}
