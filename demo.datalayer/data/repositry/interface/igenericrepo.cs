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
        int update(T entity);
        //delete
        int delete(T entity);
        //insert
        int add(T entity);
    }
}
