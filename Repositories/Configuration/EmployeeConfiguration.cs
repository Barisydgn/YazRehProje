using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Configuration
{
    public class EmployeeConfiguration<T> : IEntityTypeConfiguration<Employee> where T : class
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.EmployeeId);
            builder.Property(x=> x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x=> x.Surname).HasMaxLength(50).IsRequired(true);
            builder.Property(x=> x.Age).IsRequired(true);
        }
    }
}
