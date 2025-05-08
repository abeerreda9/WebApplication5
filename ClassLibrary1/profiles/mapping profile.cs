using AutoMapper;
using demo.bl.dto;
using demo.datalayer.Migrations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.datalayer.models.employeemodel;

namespace demo.bl.profiles
{
    public class mapping_profile:Profile
    {
        public mapping_profile()
        {
            CreateMap<employee, employeedto>()
                .ForMember(dest => dest.department, opt=>opt.MapFrom(src => src.department));

            CreateMap<employee,empdetailsdto>();
        }
    }
}
