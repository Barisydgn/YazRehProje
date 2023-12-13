using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Context
{
    public class YazContext:IdentityDbContext<IdentityUser>
    {
        public YazContext(DbContextOptions<YazContext> options):base(options)
        {
        }
        //git education
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//BU KOD BÜTÜN CONFİG DOSYALARINI ETKİLİYOR
          //  modelBuilder.ApplyConfiguration(new EmployeeConfiguration<Employee>());
          //  modelBuilder.ApplyConfiguration(new StudentConfiguration<Student>());
          //modelBuilder.ApplyConfiguration(new WantConfiguration<Wants>());
          //  modelBuilder.ApplyConfiguration(new RoleConfiguration<IdentityRole>());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Wants> Wants { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
