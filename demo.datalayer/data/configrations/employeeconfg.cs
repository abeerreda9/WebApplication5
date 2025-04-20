using demo.datalayer.models.employeemodel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.datalayer.data.configrations
{
    public class employeeconfg :baseentityconfig<employee>, IEntityTypeConfiguration<employee>
    {
        new void Configure(EntityTypeBuilder<employee> builder)
        {
           builder.Property(e=>e.name).HasColumnType("varchar(50)");
            builder.Property(e => e.address).HasColumnType("varchar(150)");
            builder.Property(e => e.salary).HasColumnType("decimal(10,2)");
            builder.Property(e=>e.gender).HasConversion((empgender)=>empgender.ToString(),(returnedempgender)=>(empgender)Enum.Parse(typeof(empgender),returnedempgender));
           

            builder.Property(e => e.type)
                .HasConversion(new EnumToStringConverter<emptype>());
            base.Configure(builder);
        }
    }
}
