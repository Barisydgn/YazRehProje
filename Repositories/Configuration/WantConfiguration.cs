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
    public class WantConfiguration<T> : IEntityTypeConfiguration<Wants> where T : class
    {
        public void Configure(EntityTypeBuilder<Wants> builder)
        {
            builder.HasKey(x => x.WantsId);
            builder.Property(x => x.Explanation).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(false);
        }
    }
}
