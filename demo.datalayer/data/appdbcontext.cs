using demo.datalayer.data.configrations;
using demo.datalayer.models;
using demo.datalayer.models.employeemodel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace demo.datalayer.data
{
    public class appdbcontext:DbContext


    {

        
        public appdbcontext(DbContextOptions<appdbcontext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=mvc;trusted_connection=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          // modelBuilder.ApplyConfiguration<department>(new departmentconfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<department> department { get; set; }
        public DbSet<employee> employee { get; set; }
    }
}
