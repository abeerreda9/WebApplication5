using demo.bl.dto;
using demo.bl.factories;
using demo.datalayer.data.repositries.Interfaces;
using demo.datalayer.data.repositry.classes;
using demo.datalayer.data.repositry.Interface;
using demo.datalayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.bl.services
{
    public class DepartmentService
    {
        public readonly Iunitofwork _unitofwork;

        public DepartmentService(Iunitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        // Get all departments
        public IEnumerable<departmentdto> GetAllDepartments()
        {
            var departments = _unitofwork.departmentrepo.Getall();
            //1.manual mapping
            //var departmentsToReturn = departments.Select(department => new departmentdto
            //{
            //    id = department.id,
            //    name = department.name,
            //    description = department.description,

            //});

            //return departmentsToReturn;
            //2.extention method
            return departments.Select(d => d.todepartmentdto());
        }

        // Get department by ID

        public departmentdetailsdto GetById(int id)
        {
            var department = _unitofwork.departmentrepo.getbyid(id);
            //manual mapping
            //auto mapper if large
            //constructor mapping
            //execution methods if projevt small
            //if (department == null)
            //    return null;

            //return new departmentdetailsdto(department)
            //{
            //    //id = department.id,
            //    //name = department.name,
            //    //description = department.description,


            //};
            //2.extention

            return department is null ? null : department.todepartmentdetailsdto();
        }
        public int adddepartment(createddepartmentdto department)
        {
            var departments = department.toentity();
            _unitofwork.departmentrepo.add(departments);

           return _unitofwork.savechanges();
        }
    }

}
