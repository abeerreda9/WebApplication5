using demo.datalayer.data.repositry.interfaceies;
using demo.datalayer.models;
using demo.datalayer.models.employeemodel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.data.repositry.classes
{
    public class emprepo : iemployeerepo
    {
        private appdbcontext _dbcontext;//null
       
        public int add(employee entity)
        {
            _dbcontext.employee.Add(entity);
            return _dbcontext.SaveChanges();
        }

        public int delete(employee entity)
        {
            _dbcontext.employee.Remove(entity);//remove locally
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<employee> Getall(bool tracking = false)
        {
            if (tracking)
            {
                return _dbcontext.employee.ToList();
            }
            else
                return _dbcontext.employee.AsNoTracking().ToList();
        }

        public IEnumerable<employee> Getall()
        {
            throw new NotImplementedException();
        }

        public employee getbyid(int id)
        {
            return _dbcontext.employee.Find(id);

        }

        public int update(employee entity)
        {
            _dbcontext.employee.Update(entity);   //update locally
            return (_dbcontext.SaveChanges());
        }
    }

}

