using demo.datalayer.data.repositry.interfaceis;
using demo.datalayer.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.data.repositry.classes
{
    public class GenericRepo<T> : igenericrepo<T> where T : baseentity
    {
        private readonly appdbcontext _dbcontext;

        public GenericRepo(appdbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int Add(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
            return _dbcontext.SaveChanges();
        }

        public int add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            _dbcontext.Set<T>().Remove(entity); // remove locally
            return _dbcontext.SaveChanges();
        }

        public int delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(bool tracking = false)
        {
            if (tracking)
            {
                return _dbcontext.Set<T>().ToList();
            }
            else
            {
                return _dbcontext.Set<T>().AsNoTracking().ToList();
            }
        }

        public IEnumerable<T> Getall()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

        public T getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            _dbcontext.Set<T>().Update(entity); // update locally
            return _dbcontext.SaveChanges();
        }

        public int update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}