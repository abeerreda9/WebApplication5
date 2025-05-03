using demo.datalayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.data.repositry. interfaceis
{
    public interface igenericrepo<T> where T : baseentity
{
        IEnumerable<T> Getall();
        //get id
        T getbyid(int id);
        //update
        void update(T entity);
        //delete
        void delete(T entity);
        //insert
        void add(T entity);
    }
}
