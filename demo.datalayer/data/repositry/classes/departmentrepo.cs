
using demo.datalayer.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.data.repositry.classes
{
    public class departmentrepo : Interface.idepartmentrepository
    {
        private appdbcontext _dbcontext;//null
        public departmentrepo(appdbcontext dbcontext)
        {
            _dbcontext =dbcontext;
        }
        public int add(department entity)
        {
          _dbcontext.department.Add(entity);
            return _dbcontext.SaveChanges();
        }

        public int delete(department entity)
        {
            _dbcontext.department.Remove(entity);//remove locally
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<department> Getall(bool tracking=false)
        {
            if (tracking)
            {
                return _dbcontext.department.ToList();
            }
            else
                return _dbcontext.department.AsNoTracking().ToList();
        }

        public IEnumerable<department> Getall()
        {
            throw new NotImplementedException();
        }

        public department getbyid(int id)
        {
            return _dbcontext.department.Find(id);
            
        }

        public int update(department entity)
        {
            _dbcontext.department.Update(entity);   //update locally
            return (_dbcontext.SaveChanges());
        }
    }

}
