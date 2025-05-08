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
        private appdbcontext dbcontext;

        public emprepo(appdbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

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

        public IQueryable<employee> getbyid(int id)
        {
            return _dbcontext.employee.Where(e => e.id == id);

        }

        public IQueryable<employee> getempbyname(string name)
        {
            return _dbcontext.employee.Where(e=>e.name.ToLower().Contains(name));
        }

        public int update(employee entity)
        {
            _dbcontext.employee.Update(entity);   //update locally
            return (_dbcontext.SaveChanges());
        }
    }

}

