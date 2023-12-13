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
    public class StudentConfiguration<T> : IEntityTypeConfiguration<Student> where T : class
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);
            builder.Property(x=> x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x=> x.Surname).HasMaxLength(50).IsRequired(true);
            builder.Property(x=> x.Diagnosis).IsRequired(true);
            builder.Property(x=> x.Exercise).HasMaxLength(500).IsRequired(true);
            //builder.Property(x=> x.Age).IsRequired(true);
            //builder.Property(x=> x.Address).IsRequired(true);
        }
    }
}
