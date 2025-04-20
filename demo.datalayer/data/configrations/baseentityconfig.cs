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
    public class baseentityconfig<T> : IEntityTypeConfiguration<T> where T : baseentity
    {
      public  void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.createdon).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.lastmodifiedon).HasComputedColumnSql("GETDATE()");
        }
    }
}
