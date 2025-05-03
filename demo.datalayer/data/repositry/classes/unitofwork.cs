using demo.datalayer.data.repositries.Interfaces;
using demo.datalayer.data.repositry.Interface;
using demo.datalayer.data.repositry.interfaceies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.data.repositry.classes
{
    public class unitofwork : Iunitofwork
    {
        private Lazy<idepartmentrepository> _departmentrepo;
            private Lazy<iemployeerepo> _employeerepo;
        private readonly appdbcontext _dbcontext;

        public unitofwork(appdbcontext dbcontext)
        {
            _departmentrepo= new Lazy<idepartmentrepository>(()=>new departmentrepo(dbcontext));
            _employeerepo= new Lazy<iemployeerepo>(()=>new emprepo(dbcontext));
          _dbcontext = dbcontext;
        }

        public iemployeerepo employeerepo {
            get
            {
                return _employeerepo.Value;
            }
               }
        public idepartmentrepository departmentrepo
        {
            get
            {
                return _departmentrepo.Value;
            }
           
        }

        public int savechanges()
        {
          return _dbcontext.SaveChanges();
        }
    }
}
