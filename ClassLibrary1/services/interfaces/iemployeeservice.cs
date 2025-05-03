using demo.bl.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.bl.services.interfaces
{
    public interface iemployeeservice
    {
        //get all
        IEnumerable<employeedto> getallemp(bool withtracking=false);
        IEnumerable<employeedto>  searchempbyname(string  name);
        empdetailsdto getempbyid(int id);
        void createemp(CreatedEmpDto emp);
        int updateemp(updatedempdto emp);
        bool deletedemp(int id);
    }
}
