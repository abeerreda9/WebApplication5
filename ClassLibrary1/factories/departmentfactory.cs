using demo.bl.dto;
using demo.datalayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.bl.factories
{
    static public class departmentfactory
    {
        public static departmentdto todepartmentdto(this department d)
        {
            return new departmentdto()
            {
                id = d.id,
                name = d.name,
                description = d.description,
               
            };
        }
        public static departmentdetailsdto todepartmentdetailsdto(this department dep)
        {
            return new departmentdetailsdto(dep)
            {
                id = dep.id,
                name = dep.name,
                description = dep.description,
            };
        }
        public static department toentity(this createddepartmentdto dto)
        {
            return new department()
            {
                name = dto.name,
                description = dto.description,
               
            };
        }
    }
}
