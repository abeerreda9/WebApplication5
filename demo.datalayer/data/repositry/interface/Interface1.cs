using demo.datalayer.data.repositry.Interface;
using demo.datalayer.data.repositry.interfaceies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.data.repositries.Interfaces
{
    public interface Iunitofwork
{
        public iemployeerepo employeerepo { get;  }
        public idepartmentrepository departmentrepo { get;  }
        int savechanges();
    }
}
