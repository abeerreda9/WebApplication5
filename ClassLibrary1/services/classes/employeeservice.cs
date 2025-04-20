using demo.bl.services.interfaces;
using demo.datalayer.data.repositry.interfaceies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.bl.services.interfaces;
using demo.bl.dto;
using System.ComponentModel.DataAnnotations;
using demo.datalayer.data.repositry.classes;
using AutoMapper;
using demo.datalayer.Migrations;

namespace demo.bl.services.classes
{
    
        public class Employeeservice :iemployeeservice
        {
            private readonly iemployeerepo _emprepo;

            public Employeeservice(iemployeerepo emprepo)
            {
                _emprepo = emprepo;
            }
        public Employeeservice(IMapper mapper)
        {

        }

        public IEnumerable<employeedto> getallemp(bool withtracking = false)
        {
            throw new NotImplementedException();
        }

        public empdetailsdto getempbyid(int id)
        {
            throw new NotImplementedException();
        }

        public int updateemp(updatedempdto emp)
        {
            throw new NotImplementedException();
        }

        int iemployeeservice.createemp(CreatedEmpDto emp)
        {
            throw new NotImplementedException();
        }

        bool iemployeeservice.deletedemp(int id)
        {
            throw new NotImplementedException();
        }

        //IEnumerable<employeedto> getallemp(bool withtracking)
        //{
        //    var employee = _emprepo.getall(withtracking);
        //    //src =ienumrable of employee
            //des=ienumerable<employeedto>
            //var returnedemp=Mapper.Map<IEnumerable<employee>,IEnumerable<employeedto>>(employee);
            //    Var emp = _emprepo.getall(withtracking);
            //    var returnedemp = emp.select(emp => new employeedto()
            //    {
            //        id = emp.id,
            //        name = emp.name,
            //        age = emp.age,
            //        email= emp.email,
            //        salary= emp.salary,
            //        isactive= emp.isactive,
            //        employeetype = emp.employeetype.ToString(),
            //        gender = emp.gender,
            //    });
            //}

            //    IEnumerable<employeedto> iemployeeservice.getallemp(bool withtracking)
            //{
            //    throw new NotImplementedException();
            //}

        //    empdetailsdto iemployeeservice.getempbyid(int id);
        //{
        //        var emp = _emprepo.getbyid(id);
        //        return emp is null ? Mapper.Map<employee, empdetailsdto>(employee);
        //        //    //if (emp == null)
        //        //    //    return null;
        //        //    //else
                //    //{
                //    //    var returnedemp = new empdetailsdto()
                //    //    {
                //    //        id = emp.id,
                //    //        name = emp.name,
                //    //        age = emp.age,
                //           // email = emp.email,
                //    //        salary = emp.salary,
                //    //        isactive = emp.isactive,
                //    //        employeetype = emp.employeetype.ToString(),
                //    //        gender = emp.gender,
                //    //        phonenumber= emp.phonenumber,
                //    //        hiringdate= emp.hiringdate,
                //    //        createdon= emp.createdon,
                //    //        createdby=1,
                //    //        lastmodifiedby=1

                //    //    };
                //    //    return returnedemp;
                //    //}

                }

        //        int iemployeeservice.updateemp(updatedempdto emp)
        //{
        //    throw new NotImplementedException();
        //}

        //// Add your methods here
    }
    

