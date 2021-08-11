using DotnetWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetWebApi.Data
{
    public class CrudContext: DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) : base(options) {}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { ID = 1, Name = "Ashok", Designation = "Full Stack Developer", Department = "Tech Team", CreatedAt = DateTime.Parse("08/06/2021")},
                new Employee { ID = 2, Name = "Jim Doe", Designation = "UI/UX Designer", Department = "Design Team", CreatedAt = DateTime.Parse("08/06/2021") }
            );
        }
    }
}
