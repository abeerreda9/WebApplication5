using demo.datalayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.data.repositry.Interface


    { 

   public interface idepartmentrepository
{
    //get all
    IEnumerable<department> Getall();
    //get id
    department getbyid(int id);
    //update
    int update(department entity);
    //delete
    int delete(department entity);
    //insert
    int add(department entity);
}
}
