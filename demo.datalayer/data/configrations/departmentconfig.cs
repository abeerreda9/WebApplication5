using demo.datalayer.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.data.configrations
{
    public class departmentconfig : IEntityTypeConfiguration<department>
    {
        public void Configure(EntityTypeBuilder<department> builder)
        {
           builder.Property(d=>d.id).UseIdentityColumn(10,10);
            builder.Property(d => d.name).HasColumnType("varchar(20)");
            builder.Property(d => d.code).HasColumnType("varchar(20)");
            builder.Property(d => d.createdon).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.lastmodifiedon).HasComputedColumnSql("GETDATE()");

        }
    }
}
