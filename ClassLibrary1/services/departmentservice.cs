using demo.bl.dto;
using demo.bl.factories;
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
        private readonly idepartmentrepository _departmentRepo;

        public DepartmentService(idepartmentrepository departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        // Get all departments
        public IEnumerable<departmentdto> GetAllDepartments()
        {
            var departments = _departmentRepo.Getall();
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
            var department = _departmentRepo.getbyid(id);
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
           return _departmentRepo.add(departments);
        }
    }

}
